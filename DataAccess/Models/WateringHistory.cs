using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    class WateringHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public Device Device { get; set; }

        public WateringSchedule? Schedule { get; set; }

        public WateringHistory(int duration, DateTime startTime, Device device)
        {
            this.Duration = duration;
            this.StartTime = startTime;
            this.Device = device;
        }
    }
}