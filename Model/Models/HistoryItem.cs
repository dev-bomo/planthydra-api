using System;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Models
{
    class HistoryItem : IHistoryItem
    {
        public int Id { get; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public int DeviceId { get; set; }

        public IDevice? Device { get; }

        public int ScheduleId { get; set; }

        public ISchedule? Schedule { get; }

        public HistoryItem(int id, int duration, DateTime startTime, int deviceId, int scheduleId)
        {
            this.Id = id;
            this.Duration = duration;
            this.StartTime = startTime;
            this.DeviceId = deviceId;
            this.ScheduleId = scheduleId;
        }
    }
}