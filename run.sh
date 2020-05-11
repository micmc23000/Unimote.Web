export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
dotnet build UnimoteStaticWeb/Unimote.Web.cspr
dotnet run --project UnimoteStaticWeb/Unimote.Web.csproj
