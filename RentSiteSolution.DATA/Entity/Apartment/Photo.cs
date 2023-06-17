

namespace RentSiteSolution.DATA.Entity.Apartment
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int ApartmentId { get; set; } // Внешний ключ для связи с квартирой
        public Apartment Apartment { get; set; } // Навигационное свойство квартиры
    }
}
