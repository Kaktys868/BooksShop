namespace BooksShop.DTO
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
    public class CreateCityDto
    {
        public string CityName { get; set; }
    }
}
