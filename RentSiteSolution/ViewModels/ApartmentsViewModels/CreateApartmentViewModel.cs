using RentSiteSolution.DATA.Entity.Apartment;
using System.ComponentModel.DataAnnotations;

namespace RentSiteSolution.ViewModels.ApartmentsViewModels
{
    public class CreateApartmentViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public string Details { get; set; }

        //public ICollection<Photo> Photos { get; set; } // Коллекция фотографий для квартиры

        /*[Display(Name = "Фотографии")]
        public List<IFormFile> Photos { get; set; } // Список загруженных фотографий*/

        public IFormFile Avatar { get; set; }
    }
}
