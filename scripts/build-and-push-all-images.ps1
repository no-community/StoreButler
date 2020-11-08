$root_path=(Resolve-Path "../").Path
$target_path="$root_path/services"
$publish_base_path="$root_path/publish-services"
$service_projects = get-childitem -path $target_path  -name -attributes d
$registry_prefix="registry.cn-hongkong.aliyuncs.com/nocommunity/"

Write-Output "发布项目."

foreach ($project in $service_projects) {
    dotnet restore -v n $target_path/$project
    dotnet publish -c Release -o $publish_base_path/$project $target_path/$project
}

Write-Output "构建项目镜像."

Set-Location $root_path
foreach ($project in $service_projects) {
    $tag=$registry_prefix+$project.Replace('.','-').ToLower()+":"+"0.1.0"
    docker build -f Dockerfile --build-arg PROJECT=$project --build-arg TARGETDIR=publish-services/$project/ -t $tag .
}


Write-Output "推送镜像到镜像仓库."

foreach ($project in $service_projects) {
    $tag=$registry_prefix+$project.Replace('.','-').ToLower()+":"+"0.1.0"
    docker push $tag
}

Write-Output "任务完成."