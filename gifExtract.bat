for /f "delims=" %%i in ('dir /b /s /a-d *.gif') do (
	mkdir "%%~ni"
	start /b /wait "" "gifExtract\bin\Release\gifExtract.exe" "%%i" "%%~ni"
)
pause
exit /b 0
