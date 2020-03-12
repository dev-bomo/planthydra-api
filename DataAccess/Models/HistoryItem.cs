using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    class HistoryItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public Device Device { get; set; }

        public ScheduleItem? Schedule { get; set; }

        public HistoryItem(int duration, DateTime startTime, Device device)
        {
            this.Duration = duration;
            this.StartTime = startTime;
            this.Device = device;
        }
    }
}