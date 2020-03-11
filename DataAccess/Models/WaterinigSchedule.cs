using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    class WateringSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Duration { get; set; }

        public DateTime StartTime { get; set; }

        public string Schedule { get; set; }

        public Device Device { get; set; }

        public WateringSchedule(int duration, DateTime startTime,
        string schedule, Device device)
        {
            this.Duration = duration;
            this.StartTime = startTime;
            this.Schedule = schedule;
            this.Device = device;
        }
    }
}