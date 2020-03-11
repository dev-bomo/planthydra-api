using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    enum SensorDataType
    {
        TEMPERATURE,
        HUMIDITY,
        LIGHT
    }
    class SensorData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public SensorDataType Type { get; set; }

        public int Value { get; set; }

        public DateTime Time { get; set; }

        public SensorData(SensorDataType type, int value, DateTime time)
        {
            this.Type = type;
            this.Value = value;
            this.Time = time;
        }
    }
}