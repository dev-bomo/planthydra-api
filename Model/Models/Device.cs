using System.Collections.Generic;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Models
{
    class Device : IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public IEnumerable<ISchedule> Schedules { get; private set; }
        public IEnumerable<ISensorData> SensorDataItems { get; private set; }
        public IEnumerable<IPlant> Plants { get; private set; }

        public Device(string name)
        {
            this.Name = name;
            this.Schedules = new List<ISchedule>();
            this.SensorDataItems = new List<ISensorData>();
            this.Plants = new List<IPlant>();
        }
    }
}