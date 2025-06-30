using Microsoft.AspNetCore.Mvc;
using GPS_Tracker_Demo.Models;

namespace GPS_Tracker_Demo.Controllers
{
    public class MonitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllActiveSessions()
        {
            // 获取真实的追踪会话数据，包含完整的位置历史
            var activeSessions = DriverController.GetActiveTrackingSessions()
                .Where(session => session.IsActive && session.Locations.Any())
                .Select(session => new
                {
                    sessionId = session.SessionId,
                    driverName = $"司机_{session.SessionId.Substring(0, 8)}", // 使用SessionId的前8位作为司机名
                    startTime = session.StartTime,
                    lastLocation = session.Locations.LastOrDefault() != null ? new
                    {
                        latitude = session.Locations.Last().Latitude,
                        longitude = session.Locations.Last().Longitude,
                        timestamp = session.Locations.Last().Timestamp,
                        accuracy = session.Locations.Last().Accuracy ?? 0
                    } : null,
                    // 添加完整的位置历史用于绘制轨迹
                    locationHistory = session.Locations.Select(loc => new
                    {
                        latitude = loc.Latitude,
                        longitude = loc.Longitude,
                        timestamp = loc.Timestamp,
                        accuracy = loc.Accuracy ?? 0,
                        speed = loc.Speed,
                        heading = loc.Heading
                    }).ToList(),
                    isActive = session.IsActive,
                    locationCount = session.Locations.Count
                })
                .Where(session => session.lastLocation != null)
                .ToList();

            return Json(activeSessions);
        }
    }
} 