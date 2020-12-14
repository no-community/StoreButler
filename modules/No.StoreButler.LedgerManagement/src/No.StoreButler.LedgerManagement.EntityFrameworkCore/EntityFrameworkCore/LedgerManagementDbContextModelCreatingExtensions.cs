using No.StoreButler.LedgerManagement.LedgerManagement;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore
{
    public static class LedgerManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureLedgerManagement(
            this ModelBuilder builder,
            Action<LedgerManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new LedgerManagementModelBuilderConfigurationOptions(
                LedgerManagementDbProperties.DbTablePrefix,
                LedgerManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<PayTrade>(b =>
            {
                b.ToTable(options.TablePrefix + "pay_trade", options.Schema);
                b.ConfigureByCustomConvention();

                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.PayAmount).HasColumnName("pay_amount");
                b.Property(p => p.PayMethod).HasColumnName("pay_method");
                b.Property(p => p.PayFlowType).HasColumnName("pay_flow_type");
                b.Property(p => p.TradeStatus).HasColumnName("trade_status");
                b.Property(p => p.TradeCategoryId).HasColumnName("trade_category_id");
            });


            builder.Entity<TradeCategory>(b =>
            {
                b.ToTable(options.TablePrefix + "trade_category", options.Schema);
                b.ConfigureByCustomConvention();

                b.Property(t => t.Id).HasColumnName("id");
                b.Property(t => t.Name).HasColumnName("name");
                b.Property(t => t.Remarks).HasColumnName("remarks");
                b.Property(t => t.PayFlowType).HasColumnName("pay_flow_type");
            });
        }
    }
}