using System.Collections.Generic;

namespace planthydra_api.Model.Interfaces
{
    public interface IComment
    {
        int Id { get; }
        string Sinopsis { get; set; }
        string DescriptionHtml { get; set; }
        int PlantId { get; set; }
        IPlant? Plant { get; }
        IEnumerable<IImage> Pictures { get; }
    }
}