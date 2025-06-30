namespace GPS_Tracker_Demo.Models
{
    public class LocationData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        public double? Accuracy { get; set; }
        public double? Speed { get; set; }
        public double? Heading { get; set; }
    }

    public class TrackingSession
    {
        public string SessionId { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<LocationData> Locations { get; set; } = new List<LocationData>();
        public bool IsActive { get; set; }
    }
} 