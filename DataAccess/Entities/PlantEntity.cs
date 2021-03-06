using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
    [Table("Plant")]
    class PlantEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? MinLight { get; set; }
        public int? MaxLight { get; set; }

        public int? MinHum { get; set; }

        public int? MaxHum { get; set; }

        public int? MinTemp { get; set; }

        public int? MaxTemp { get; set; }

        public string DescriptionHtml { get; set; }

        public ImageEntity MainImage { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public List<ImageEntity> Images { get; set; }

        public List<DevicePlantEntity> DevicePlantRelations { get; set; }
    }
}