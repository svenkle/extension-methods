@ECHO OFF

:: Use Release build configuration unless specified
IF "%1"=="" (
CALL build.bat Release
SET build=%errorlevel%
EXIT /b %build%
)

IF NOT EXIST .\packages\nuget\nuget.exe (
IF NOT EXIST .\packages\nuget\ MKDIR .\packages\nuget\
ECHO ^(New-Object System.Net.WebClient^).DownloadFile('https://dist.nuget.org/win-x86-commandline/v3.5.0/nuget.exe', '.\\packages\\nuget\\nuget.exe'^) > .\\packages\\nuget\\nuget.ps1
PowerShell.exe -ExecutionPolicy Bypass -File .\\packages\\nuget\\nuget.ps1
)

.\packages\nuget\nuget.exe restore

:: Build and package
IF NOT EXIST .\build MKDIR .\build
"C:\Program Files (x86)\MSBuild\14.0\Bin\Msbuild.exe" /t:Rebuild "Extension Methods.sln" /p:Configuration=%1
.\packages\nuget\nuget.exe pack .\src\Svenkle.ExtensionMethods\Svenkle.ExtensionMethods.csproj -Prop Configuration=%1 -Verbosity normal -OutputDirectory .\build

EXIT /b 0