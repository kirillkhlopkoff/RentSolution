using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSiteSolution.DATA.Entity.Apartment
{
    public class Apartment
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

        public string[] Photos { get; set; } = new string[8]; // Массив строк-ссылок на фотографии

        public string MainPhoto
        {
            get { return Photos?.FirstOrDefault(); }
        }
        /*public List<string> Photos { get; set; } = new List<string>(); // массив загруженных файлов
        public List<IFormFile> PhotoFiles { get; set; }

        [NotMapped]
        public string MainPhoto
        {
            get { return Photos?.FirstOrDefault(); }
        }*/

    }
}
