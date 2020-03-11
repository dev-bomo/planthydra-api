using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    class PlantComment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Sinopsis { get; set; }

        public string DescriptionHtml { get; set; }

        public Plant Plant { get; set; }

        public List<Image> Pictures { get; set; }

        public PlantComment(string sinopsis, string description, Plant plant)
        {
            this.Sinopsis = sinopsis;
            this.DescriptionHtml = description;
            this.Plant = plant;
            this.Pictures = new List<Image>();
        }
    }
}