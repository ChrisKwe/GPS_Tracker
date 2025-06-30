using Microsoft.AspNetCore.Mvc;
using GPS_Tracker_Demo.Models;
using Microsoft.AspNetCore.SignalR;

namespace GPS_Tracker_Demo.Controllers
{
    public class DriverController : Controller
    {
        private readonly IHubContext<LocationHub> _hubContext;
        private static readonly Dictionary<string, TrackingSession> _trackingSessions = new();
        
        // 静态方法供MonitorController访问追踪数据
        public static IEnumerable<TrackingSession> GetActiveTrackingSessions()
        {
            return _trackingSessions.Values;
        }

        public DriverController(IHubContext<LocationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartTracking()
        {
            var sessionId = Guid.NewGuid().ToString();
            var session = new TrackingSession
            {
                SessionId = sessionId,
                StartTime = DateTime.Now,
                IsActive = true
            };

            _trackingSessions[sessionId] = session;

            return Json(new { success = true, sessionId = sessionId });
        }

        [HttpPost]
        public IActionResult StopTracking(string sessionId)
        {
            if (_trackingSessions.TryGetValue(sessionId, out var session))
            {
                session.IsActive = false;
                session.EndTime = DateTime.Now;
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "会话未找到" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation([FromBody] LocationUpdateRequest request)
        {
            if (_trackingSessions.TryGetValue(request.SessionId, out var session) && session.IsActive)
            {
                var locationData = new LocationData
                {
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Timestamp = DateTime.Now,
                    Accuracy = request.Accuracy,
                    Speed = request.Speed,
                    Heading = request.Heading
                };

                session.Locations.Add(locationData);

                // 通过SignalR广播位置更新
                await _hubContext.Clients.All.SendAsync("LocationUpdate", new
                {
                    sessionId = request.SessionId,
                    latitude = request.Latitude,
                    longitude = request.Longitude,
                    timestamp = locationData.Timestamp,
                    accuracy = request.Accuracy,
                    speed = request.Speed,
                    driverName = $"司机_{request.SessionId.Substring(0, 8)}"
                });

                return Json(new { success = true });
            }

            return Json(new { success = false, message = "追踪会话无效" });
        }

        [HttpGet]
        public IActionResult GetTrackingHistory(string sessionId)
        {
            if (_trackingSessions.TryGetValue(sessionId, out var session))
            {
                return Json(session);
            }

            return Json(new { success = false, message = "会话未找到" });
        }
    }

    public class LocationUpdateRequest
    {
        public string SessionId { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Accuracy { get; set; }
        public double? Speed { get; set; }
        public double? Heading { get; set; }
    }
} 