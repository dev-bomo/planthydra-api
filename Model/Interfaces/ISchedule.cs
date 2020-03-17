using System;

namespace planthydra_api.Model.Interfaces
{
    public interface ISchedule
    {
        int Id { get; }

        string? Name { get; set; }

        int Duration { get; set; }

        bool IsEnabled { get; set; }

        DateTime StartTime { get; set; }

        string Weekdays { get; set; }

        int DeviceId { get; set; }

        IDevice? Device { get; }
    }
}