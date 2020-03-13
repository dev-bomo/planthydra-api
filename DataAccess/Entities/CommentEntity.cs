using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    [Table("Comment")]
    class CommentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Sinopsis { get; set; }

        public string DescriptionHtml { get; set; }

        public PlantEntity Plant { get; set; }

        public List<ImageEntity> Pictures { get; set; }

        public CommentEntity(string sinopsis, string description, PlantEntity plant)
        {
            this.Sinopsis = sinopsis;
            this.DescriptionHtml = description;
            this.Plant = plant;
            this.Pictures = new List<ImageEntity>();
        }
    }
}