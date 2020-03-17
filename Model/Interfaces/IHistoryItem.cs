using System;

namespace planthydra_api.Model.Interfaces
{
    public interface IHistoryItem
    {
        int Id { get; }

        int Duration { get; set; }

        DateTime StartTime { get; set; }

        int DeviceId { get; set; }

        IDevice? Device { get; }

        int ScheduleId { get; set; }

        ISchedule? Schedule { get; }
    }
}