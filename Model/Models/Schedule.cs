using System;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Models
{
    class Schedule : ISchedule
    {
        public int Id { get; private set; }
        public string? Name { get; set; }
        public int Duration { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime StartTime { get; set; }
        public int DeviceId { get; set; }
        public IDevice? Device { get; }
        public string Weekdays { get; set; }

        public Schedule(int id, int duration, bool isEnabled, DateTime startTime, int deviceId, string weekdays)
        {
            this.Id = id;
            this.Duration = duration;
            this.IsEnabled = isEnabled;
            this.StartTime = startTime;
            this.DeviceId = deviceId;
            this.Weekdays = weekdays;
        }

        public Schedule(int id, string name, int duration, bool isEnabled, DateTime startTime, int deviceId, string weekdays)
        {
            this.Id = id;
            this.Duration = duration;
            this.IsEnabled = isEnabled;
            this.StartTime = startTime;
            this.DeviceId = deviceId;
            this.Weekdays = weekdays;
            this.Name = name;
        }
    }
}