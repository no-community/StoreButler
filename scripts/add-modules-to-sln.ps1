$target_sln = "../StoreButler.sln"
$root_projects = get-childitem -path ../modules  -name -attributes d

foreach ($project in $root_projects) {
   
    $project_src_path = "../modules/$project/src"
    $project_test_path = "../modules/$project/test"

    If ((test-path $project_src_path)) {
        $libs = get-childitem -path $project_src_path  -name -attributes d

        foreach ($item in $libs) {
            dotnet sln $target_sln add $project_src_path/$item/$item.csproj -s "modules\$project\src"
        }
    }

    If ((test-path $project_test_path)) {
        $testlibs = get-childitem -path $project_test_path  -name -attributes d

        foreach ($item in $testlibs) {
            dotnet sln $target_sln add $project_test_path/$item/$item.csproj -s "modules\$project\test"
        }
    }

    write-output "$project done."
}