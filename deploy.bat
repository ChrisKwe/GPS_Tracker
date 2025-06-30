@echo off
echo 🚀 GPS Tracking System - Quick Deploy to Cloud
echo ==============================================

echo Step 1: Checking Git status...
git --version >nul 2>&1
if errorlevel 1 (
    echo ❌ Git is not installed or not in PATH
    echo Please install Git from https://git-scm.com/
    pause
    exit /b 1
)

echo Step 2: Initializing Git repository...
git init

echo Step 3: Adding all files...
git add .

echo Step 4: Creating initial commit...
git commit -m "Initial commit - GPS Tracking System for cloud deployment"

echo.
echo ✅ Project is ready for cloud deployment!
echo.
echo 📋 Next Steps:
echo 1. Create a new repository on GitHub
echo 2. Copy the repository URL
echo 3. Run: git remote add origin YOUR_GITHUB_URL
echo 4. Run: git branch -M main
echo 5. Run: git push -u origin main
echo.
echo 🌟 Recommended Deployment Platforms:
echo • Railway.app (Easiest): https://railway.app
echo • Render.com (Good): https://render.com  
echo • Azure (Microsoft): https://azure.microsoft.com
echo.
echo 📖 See DEPLOYMENT_GUIDE.md for detailed instructions
echo.
pause 