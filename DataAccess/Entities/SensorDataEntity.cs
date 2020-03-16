using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    enum SensorDataType
    {
        TEMPERATURE = 1,
        HUMIDITY = 2,
        LIGHT = 3
    }

    [Table("SensorData")]
    class SensorDataEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public SensorDataType Type { get; set; }

        public int Value { get; set; }

        public DateTime Time { get; set; }

    }
}