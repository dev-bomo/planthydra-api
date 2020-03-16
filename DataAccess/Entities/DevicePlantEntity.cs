using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    [Table("DevicePlant")]
    class DevicePlantEntity
    {
        public int DeviceId { get; set; }
        public int PlantId { get; set; }
        public PlantEntity Plant { get; set; }
        public DeviceEntity Device { get; set; }
    }
}