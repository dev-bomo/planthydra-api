using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    [Table("Comment")]
    class CommentEntity
    {
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Sinopsis { get; set; }

        public string DescriptionHtml { get; set; }

        public PlantEntity Plant { get; set; }

        public List<ImageEntity> Pictures { get; set; }

        public CommentEntity()
        {
            this.Pictures = new List<ImageEntity>();
        }
    }
}