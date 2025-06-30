@echo off
echo 🚀 Starting GPS Tracking System (Using Chrome Browser)
echo =========================================================

echo Starting application server...
start "" powershell.exe -Command "cd '%~dp0'; dotnet run --launch-profile https"

echo Waiting for server to start...
timeout /t 5

echo Opening application pages in Chrome (new windows)...
start "" "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --new-window "https://localhost:5001"
start "" "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --new-window "https://localhost:5001/Driver"
start "" "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --new-window "https://localhost:5001/Monitor"

echo ✅ System startup complete!
echo.
echo 📱 Driver Interface: https://localhost:5001/Driver
echo 🖥️ Monitor Center: https://localhost:5001/Monitor  
echo 🏠 Home Page: https://localhost:5001
echo.
echo ⚡ GPS updates every 10 seconds
echo 📊 Monitor shows latest 3 GPS coordinates for each driver
echo 🔄 Auto-refresh every 15 seconds with live indicators
echo 🔴 Real-time coordinate updates with visual effects
echo.
echo Press any key to close this window...
pause >nul 