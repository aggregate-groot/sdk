& dotnet new uninstall AggregateGroot.TemplatePack
& dotnet pack ../src/TemplatePack/TemplatePack.csproj -c Release
& dotnet new install ../src/TemplatePack/bin/Release/AggregateGroot.TemplatePack.1.0.0.nupkg