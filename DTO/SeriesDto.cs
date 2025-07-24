namespace BooksShop.DTO
{
    public class SeriesDto
    {
        public int SeriesId { get; set; }
        public string SeriesName { get; set; }
        public string SeriesDescription { get; set; }
    }

    public class CreateSeriesDto
    {
        public string SeriesName { get; set; }
        public string SeriesDescription { get; set; }
    }
}
