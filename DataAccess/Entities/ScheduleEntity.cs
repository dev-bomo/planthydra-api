using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    [Table("ScheduleItem")]
    class ScheduleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public string Schedule { get; set; }

        public DeviceEntity Device { get; set; }

    }
}