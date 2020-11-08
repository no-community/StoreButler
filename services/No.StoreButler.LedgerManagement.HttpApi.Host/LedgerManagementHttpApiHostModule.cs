using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CSRedis;
using EasyAbp.Abp.EventBus.Cap;
using EasyAbp.Abp.EventBus.CAP.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using No.StoreButler.LedgerManagement.EntityFrameworkCore;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using Tfc.CAP.AliyunAMQP;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Auditing;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;

namespace No.StoreButler.LedgerManagement
{
    [DependsOn(
        typeof(LedgerManagementApplicationModule),
        typeof(LedgerManagementEntityFrameworkCoreModule),
        typeof(LedgerManagementHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpEventBusCapModule),
        typeof(AbpEventBusCapPostgreSqlModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementDomainModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule)
        )]
    public class LedgerManagementHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureHealthCheck(context, configuration);
            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureCache(configuration);
            ConfigureRedis(context, configuration, hostingEnvironment);
            ConfigureDataBase();
            ConfigureAuditing();
            ConfigureCAP(context, configuration, hostingEnvironment);
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();
            app.UseAbpClaimsMap();
            app.UseMultiTenancy();
            app.UseAbpRequestLocalization();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
            });
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }

        /// <summary>
        ///     配置健康检查
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureHealthCheck(ServiceConfigurationContext context,
                                          IConfiguration configuration) =>
            context.Services.AddHealthChecks()
                   .AddNpgSql(configuration[key: "ConnectionStrings:Default"])
                   .AddRedis(configuration[key: "Redis:Configuration"]);

        /// <summary>
        ///     配置缓存
        /// </summary>
        /// <param name="configuration"></param>
        private void ConfigureCache(IConfiguration configuration) =>
            Configure<AbpDistributedCacheOptions>(configureOptions: options => { options.KeyPrefix = "LedgerManagement:"; });

        /// <summary>
        ///     配置数据库
        /// </summary>
        private void ConfigureDataBase() =>
            Configure<AbpDbContextOptions>(configureOptions: options => { options.UseNpgsql(); });

        /// <summary>
        ///     配置审核日志
        /// </summary>
        private void ConfigureAuditing() =>
            Configure<AbpAuditingOptions>(configureOptions: options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = "No.StoreButler.LedgerManagement.HttpApi.Host";
            });

        /// <summary>
        ///     配置 Redis
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        /// <param name="hostingEnvironment"></param>
        private void ConfigureRedis(ServiceConfigurationContext context,
                                    IConfiguration configuration,
                                    IWebHostEnvironment hostingEnvironment)
        {
            if (!hostingEnvironment.IsDevelopment())
            {
                var connection = new CSRedisClient(configuration[key: "Redis:Configuration"]);
                context.Services.AddSingleton<IDistributedCache>(new CSRedisCache(connection));
                RedisHelper.Initialization(connection);
                context.Services.AddDataProtection().PersistKeysToCSRedis(connection, key: "LedgerManagement-Protection-Keys");
            }
        }

        /// <summary>
        ///     配置 CAP
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        /// <param name="hostingEnvironment"></param>
        private void ConfigureCAP(ServiceConfigurationContext context,
                                  IConfiguration configuration,
                                  IWebHostEnvironment hostingEnvironment) =>
            context.AddCapEventBus(capAction: capOptions =>
            {
                capOptions.UseDashboard();
                capOptions.UseEntityFramework<LedgerManagementDbContext>();
                capOptions.UseRabbitMQ(configure: _ =>
                {
                    _.HostName = configuration[key: "Cap:RabbitMQ:HostName"];
                    _.UserName = configuration[key: "Cap:RabbitMQ:UserName"];
                    _.Password = configuration[key: "Cap:RabbitMQ:Password"];

                    if (hostingEnvironment.IsProduction() &&
                        configuration.GetValue(key: "Cap:Aliyun:Enable", defaultValue: false))
                    {
                        _.ConnectionFactoryOptions = options =>
                        {
                            options.VirtualHost = configuration[key: "Cap:Aliyun:VirtualHost"];
                            options.AuthMechanisms = new List<IAuthMechanismFactory> { new AliyunMechanismFactory() };
                        };
                    }
                });
            });

        /// <summary>
        ///     配置 JWT 验证
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration) =>
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(configureOptions: options =>
                   {
                       options.Authority = configuration[key: "AuthServer:Authority"];
                       options.Audience = configuration[key: "AuthServer:ApiName"];
                       options.RequireHttpsMetadata = false;
                   });

        /// <summary>
        ///     配置多语言
        /// </summary>
        private void ConfigureLocalization() =>
            Configure<AbpLocalizationOptions>(configureOptions: options =>
            {
                options.Languages.Add(new LanguageInfo(cultureName: "en", uiCultureName: "en", displayName: "English"));
                options.Languages.Add(new LanguageInfo(cultureName: "zh-Hans", uiCultureName: "zh-Hans",
                                                       displayName: "简体中文"));
            });

        /// <summary>
        ///     配置 Swagger
        /// </summary>
        /// <param name="context"></param>
        private static void ConfigureSwaggerServices(ServiceConfigurationContext context) =>
            context.Services.AddSwaggerGen(
                                           setupAction: options =>
                                           {
                                               options.SwaggerDoc(name: "v1",
                                                                  new OpenApiInfo
                                                                  {
                                                                      Title = "Ledger Management Service API",
                                                                      Version = "v1"
                                                                  });
                                               options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                                                                              "No.StoreButler.LedgerManagement.Application.Contracts.xml"));
                                               options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                                                                              "No.StoreButler.LedgerManagement.HttpApi.xml"));

                                               options.DocInclusionPredicate(predicate: (docName, description) => true);
                                           });

        /// <summary>
        ///     配置跨域
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration) =>
            context.Services.AddCors(setupAction: options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, configurePolicy: builder =>
                {
                    builder
                        .WithOrigins(
                                     configuration[key: "App:CorsOrigins"]
                                         .Split(separator: ",", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(selector: o => o.RemovePostFix("/"))
                                         .ToArray()
                                    )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
    }
}
