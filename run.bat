@ECHO OFF

IF "%CONFIGURATION%"=="" SET CONFIGURATION=Debug

star --resourcedir="%~dp0src\WasteTrader\wwwroot" "%~dp0src/WasteTrader/bin/%CONFIGURATION%/WasteTrader.exe"