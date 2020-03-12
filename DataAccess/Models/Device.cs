using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    enum DeviceStatus
    {
        ONLINE,
        OFFLINE
    }

    class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }

        public List<ScheduleItem> Schedules { get; set; }
        public List<SensorData> SensorDataItems { get; set; }

        public List<Plant> Plants { get; set; }

        public Device(string name)
        {
            this.Name = name;
            this.Schedules = new List<ScheduleItem>();
            this.SensorDataItems = new List<SensorData>();
            this.Plants = new List<Plant>();
        }

    }
}