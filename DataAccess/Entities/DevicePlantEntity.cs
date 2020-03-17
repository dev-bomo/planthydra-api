using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
    [Table("DevicePlant")]
    class DevicePlantEntity
    {
        public int DeviceId { get; set; }
        public int PlantId { get; set; }
        public PlantEntity Plant { get; set; }
        public DeviceEntity Device { get; set; }
    }
}