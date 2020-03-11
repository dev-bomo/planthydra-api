using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planthydra_api.DataAccess.Models
{
    class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Url { get; set; }

        public Image(string fileName, string url)
        {
            this.FileName = fileName;
            this.Url = url;
        }
    }
}