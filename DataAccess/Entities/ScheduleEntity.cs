using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
    [Table("ScheduleItem")]
    class ScheduleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsEnabled { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public string Weekdays { get; set; }

        public int DeviceId { get; set; }

        public DeviceEntity Device { get; set; }

    }
}