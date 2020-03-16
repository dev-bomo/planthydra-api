using System.Collections.Generic;

namespace planthydra_api.Model.Interfaces
{
    public enum DeviceStatus
    {
        ONLINE,
        OFFLINE
    }

    public interface IDevice
    {
        int Id { get; set; }
        string Name { get; set; }
        DeviceStatus Status { get; set; }
        IEnumerable<ISchedule> Schedules { get; }
        IEnumerable<ISensorData> SensorDataItems { get; }
        IEnumerable<IPlant> Plants { get; }
    }
}