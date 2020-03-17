namespace planthydra_api.Model.Interfaces
{
    public interface IImage
    {
        int Id { get; }

        string FileName { get; set; }

        string Url { get; set; }
    }
}