using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    [Table("HistoryItem")]
    class HistoryEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public DeviceEntity Device { get; set; }

        public ScheduleEntity? Schedule { get; set; }

        public HistoryEntity(int duration, DateTime startTime, DeviceEntity device)
        {
            this.Duration = duration;
            this.StartTime = startTime;
            this.Device = device;
        }
    }
}