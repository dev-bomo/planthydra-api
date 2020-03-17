using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
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