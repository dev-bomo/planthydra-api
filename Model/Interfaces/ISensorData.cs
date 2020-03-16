using System;

namespace planthydra_api.Model.Interfaces
{
    public interface ISensorData
    {
        int Id { get; set; }

        string? Name { get; set; }

        int Duration { get; set; }

        DateTime StartTime { get; set; }

        string Schedule { get; set; }

        IDevice Device { get; set; }
    }
}