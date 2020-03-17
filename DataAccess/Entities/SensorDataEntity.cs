using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
    [Table("SensorData")]
    class SensorDataEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int Type { get; set; }

        public int Value { get; set; }

        public DateTime Time { get; set; }

    }
}