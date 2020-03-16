using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
    [Table("Image")]
    class ImageEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Url { get; set; }

    }
}