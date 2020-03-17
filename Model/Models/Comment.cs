using System.Collections.Generic;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Models
{
    class Comment : IComment
    {
        public int Id { get; private set; }

        public string Sinopsis { get; set; }
        public string DescriptionHtml { get; set; }
        public int PlantId { get; set; }
        public IPlant? Plant { get; }

        public IEnumerable<IImage> Pictures { get; }

        public Comment(int id, string sinopsis, string descriptionHtml, int plantId)
        {
            this.Id = id;
            this.Sinopsis = sinopsis;
            this.DescriptionHtml = descriptionHtml;
            this.PlantId = plantId;
            this.Pictures = new List<IImage>();
        }
    }
}