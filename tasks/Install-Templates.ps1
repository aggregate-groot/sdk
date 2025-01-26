& dotnet new uninstall AggregateGroot.TemplatePack
& dotnet pack ../TemplatePack/TemplatePack.csproj -c Release
& dotnet new install ../TemplatePack/bin/Release/AggregateGroot.TemplatePack.1.3.0.nupkg