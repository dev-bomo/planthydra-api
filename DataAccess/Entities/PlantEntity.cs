using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
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

        public List<DeviceEntity> Devices { get; set; }

        public ImageEntity MainImage { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public List<ImageEntity> Images { get; set; }

        public PlantEntity(string name, string description, ImageEntity image)
        {
            this.Name = name;
            this.DescriptionHtml = description;
            this.MainImage = image;
            this.Devices = new List<DeviceEntity>();
            this.Comments = new List<CommentEntity>();
            this.Images = new List<ImageEntity>();
        }
    }
}