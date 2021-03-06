using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
    [Table("HistoryItem")]
    class HistoryEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public int DeviceId { get; set; }

        public DeviceEntity Device { get; set; }

        public int ScheduleId { get; set; }

        public ScheduleEntity? Schedule { get; set; }

    }
}