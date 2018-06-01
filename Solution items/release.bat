@echo off
set connection=%~1
set package_root=..\..\
set builduri=%~2

REM Find the spkl in the package folder (irrespective of version)
For /R %package_root% %%G IN (spkl.exe) do (
	IF EXIST "%%G" (set spkl_path=%%G
	goto :continue)
	)

:continue
@echo Deploying Using '%spkl_path%' 
@echo Build URI '%builduri%' 

REM spkl plugins [path] [connection-string] [/p:release]
"%spkl_path%" plugins "%cd%\PluginsSPKL2" "%connection%" /p:release

"%spkl_path%" webresources "%cd%\PluginsSPKL2" "%connection%"

REM %package_root% plugins "%cd%\PluginsSPKL2" "%connection%" /p:release

pause