using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Models
{
    class Image : IImage
    {
        public int Id { get; private set; }

        public string FileName { get; set; }
        public string Url { get; set; }

        public Image(int id, string fileName, string url)
        {
            this.Id = id;
            this.FileName = fileName;
            this.Url = url;
        }
    }
}