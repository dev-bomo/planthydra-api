using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    class Plant
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

        public List<Device> Devices { get; set; }

        public Image MainImage { get; set; }

        public List<PlantComment> Comments { get; set; }

        public List<Image> Images { get; set; }

        public Plant(string name, string description, Image image)
        {
            this.Name = name;
            this.DescriptionHtml = description;
            this.MainImage = image;
            this.Devices = new List<Device>();
            this.Comments = new List<PlantComment>();
            this.Images = new List<Image>();
        }
    }
}