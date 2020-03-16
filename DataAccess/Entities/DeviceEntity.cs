using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    enum DeviceStatus
    {
        ONLINE = 1,
        OFFLINE = 2
    }

    [Table("Device")]
    class DeviceEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public List<ScheduleEntity> Schedules { get; set; }
        public List<SensorDataEntity> SensorDataItems { get; set; }
        public List<DevicePlantEntity> DevicePlantRelations { get; set; }

    }
}