# GPS追踪系统

一个基于ASP.NET Core MVC的实时GPS追踪系统，适用于司机位置监控。

## 功能特点

- 📱 **移动端友好界面** - 响应式设计，完美适配手机屏幕
- 🗺️ **实时地图显示** - 使用免费的OpenStreetMap和Leaflet.js
- 📍 **精确GPS定位** - 高精度位置获取，支持精度显示
- ⏱️ **快速位置更新** - 每10秒自动更新位置信息  
- 🚗 **轨迹记录** - 实时显示司机行驶路径
- 👁️ **监控中心** - 管理端可查看所有司机位置和实时GPS坐标
- 📊 **实时GPS坐标** - 显示每个司机最新的3个GPS坐标，15秒自动更新
- 🔴 **实时指示器** - 最新坐标带有闪烁的LIVE指示器
- 🔄 **实时通信** - 基于SignalR的实时位置广播

## 技术栈

### 后端
- ASP.NET Core 8.0 MVC
- SignalR - 实时通信
- C# - 服务端编程语言

### 前端
- HTML5 Geolocation API - GPS定位
- Leaflet.js - 免费开源地图库
- OpenStreetMap - 免费地图数据源
- Bootstrap 5 - 响应式UI框架
- Font Awesome - 图标库
- JavaScript ES6+ - 客户端编程

## 快速开始

### 环境要求
- .NET 8.0 SDK
- 现代Web浏览器（支持HTML5 Geolocation）
- HTTPS环境（GPS API要求）

### 安装和运行

1. **克隆或下载项目**
```bash
git clone <项目地址>
cd GPS_Tracker_Demo
```

2. **还原依赖包**
```bash
dotnet restore
```

3. **运行应用程序**
```bash
dotnet run --launch-profile https
```

4. **使用Chrome浏览器启动（推荐）**

**方法一：一键启动脚本**
- 双击运行 `start-with-chrome.bat` 文件
- 自动启动服务器并使用Chrome打开所有页面

**方法二：手动PowerShell命令**
```powershell
# 启动应用服务器
dotnet run --launch-profile https

# 在新的PowerShell窗口中，用Chrome打开页面
& "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" "https://localhost:5001"
& "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" "https://localhost:5001/Driver"  
& "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" "https://localhost:5001/Monitor"
```

5. **访问应用**
- 司机端：`https://localhost:5001/Driver`
- 监控端：`https://localhost:5001/Monitor`
- 首页：`https://localhost:5001`

## 使用说明

### 司机端操作

1. **访问司机页面**
   - 在手机浏览器中打开 `/Driver` 页面

2. **开始追踪**
   - 点击"开始追踪"按钮
   - 允许浏览器访问位置权限
   - 系统会立即获取并显示当前位置

3. **位置更新**
   - 系统每10秒自动更新一次位置
   - 实时显示当前坐标、精度和更新时间
   - 地图上显示移动轨迹

4. **结束追踪**
   - 点击"结束追踪"按钮停止位置监控

### 监控端操作

1. **访问监控中心**
   - 在管理端浏览器中打开 `/Monitor` 页面

2. **查看司机位置**
   - 地图上显示所有活跃司机的实时位置
   - 司机列表显示详细信息和状态

3. **实时更新**
   - 启用自动刷新功能
   - 手动刷新数据
   - 实时接收位置更新

## 核心文件说明

### 控制器
- `Controllers/DriverController.cs` - 司机端API
- `Controllers/MonitorController.cs` - 监控端API

### 模型
- `Models/LocationData.cs` - 位置数据模型
- `Models/TrackingSession.cs` - 追踪会话模型

### 视图
- `Views/Driver/Index.cshtml` - 司机操作界面
- `Views/Monitor/Index.cshtml` - 监控中心界面
- `Views/Shared/_Layout.cshtml` - 主布局模板

### SignalR Hub
- `Hubs/LocationHub.cs` - 实时通信中心

## 特色功能

### 移动端优化
- 响应式设计，自适应手机屏幕
- 大按钮设计，便于触摸操作
- 流畅的用户体验

### 高精度GPS
- 启用高精度模式
- 显示位置精度范围
- 支持速度和方向信息

### 实时地图
- 使用免费的OpenStreetMap
- Leaflet.js轻量级地图库
- 支持缩放、平移等操作

### 轨迹追踪
- 实时绘制移动路径
- 历史轨迹保存
- 轨迹回放功能

## 部署说明

### 生产环境部署

1. **HTTPS配置**
   - GPS API要求HTTPS环境
   - 配置SSL证书

2. **性能优化**
   - 启用静态文件压缩
   - 配置CDN加速

3. **数据持久化**
   - 集成数据库（SQL Server、PostgreSQL等）
   - 实现数据存储和查询

## 扩展功能

可以进一步添加的功能：

- 🔐 用户认证和授权
- 💾 数据库持久化存储
- 📊 统计报表和分析
- 🚨 地理围栏告警
- 📧 位置异常通知
- 🌍 多语言支持
- 📱 PWA离线支持

## 免费开源方案

本项目完全基于免费开源技术：

- **地图服务**：OpenStreetMap（完全免费）
- **地图库**：Leaflet.js（开源MIT许可）
- **开发框架**：ASP.NET Core（开源）
- **UI框架**：Bootstrap（开源MIT许可）
- **图标库**：Font Awesome（免费版本）

## 许可证

本项目采用MIT许可证，可自由使用和修改。

## 技术支持

如有问题或建议，请提交Issue或联系开发团队。 