@ECHO OFF

:: Use Release build configuration unless specified
IF "%1"=="" (
CALL build.bat Release
SET build=%errorlevel%
EXIT /b %build%
)

:: Download NuGet if its not already there
IF NOT EXIST .\packages\nuget\nuget.exe (
IF NOT EXIST .\packages\nuget\ MKDIR .\packages\nuget
ECHO ^(New-Object System.Net.WebClient^).DownloadFile('http://dist.nuget.org/win-x86-commandline/latest/nuget.exe', '.\\packages\\nuget\\nuget.exe'^) > .\nuget.ps1
PowerShell.exe -ExecutionPolicy Bypass -File .\nuget.ps1
)

:: Clean up
IF EXIST .\nuget.ps1 DEL .\nuget.ps1

:: Restore all packages
.\packages\nuget\nuget.exe restore

:: Build and package
IF NOT EXIST .\build MKDIR .\build
"C:\Program Files (x86)\MSBuild\14.0\Bin\Msbuild.exe" /t:Build .\Svenkle.ExtensionMethods\Svenkle.ExtensionMethods.csproj /p:Configuration=%1
.\packages\nuget\nuget.exe pack .\Svenkle.ExtensionMethods\Svenkle.ExtensionMethods.csproj -Prop Configuration=%1 -Verbosity normal -OutputDirectory .\build

EXIT /b 0