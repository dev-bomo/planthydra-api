using System.Collections.Generic;

namespace planthydra_api.Model.Interfaces
{
    public enum DeviceStatus
    {
        OFFLINE = 0,
        ONLINE = 1
    }

    public interface IDevice
    {
        int Id { get; }
        string Name { get; set; }
        DeviceStatus Status { get; set; }
        IEnumerable<ISchedule> Schedules { get; }
        IEnumerable<ISensorData> SensorDataItems { get; }
        IEnumerable<IPlant> Plants { get; }
    }
}