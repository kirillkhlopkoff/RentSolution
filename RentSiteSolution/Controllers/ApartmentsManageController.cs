using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentSiteSolution.DATA.Entity.Apartment;
using RentSiteSolution.DATA.Entity.Identity;
using RentSiteSolution.DATA;

namespace RentSiteSolution.Controllers
{
    public class ApartmentsManageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ApartmentsManageController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        // Метод для вывода списка всех квартир // исправить на вывод квартир данного пользователя
        public IActionResult Index()
        {
            var apartments = _context.Apartments.ToList();
            return View(apartments);
        }

        // Метод для создания новой квартиры (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Метод для создания квартиры (POST)
        [HttpPost]
        public async Task<ActionResult<Apartment>> Create(Apartment apartment)
        {
            // Получение текущего пользователя
            User currentUser = _userManager.GetUserAsync(HttpContext.User).Result;

            // Присвоение UserId квартире
            apartment.UserId = currentUser.Id;
            apartment.Author = currentUser.FirstName;

            // Другая логика сохранения квартиры в базе данных
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyApartments", "ApartmentsShow");
        }

        // Метод для добавления фотографий к квартире (GET)
        public IActionResult AddPhoto(int id)
        {
            var apartment = _context.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }

        // Метод для добавления фотографий к квартире (POST)
        [HttpPost]
        public async Task<IActionResult> AddPhoto(int id, IFormFileCollection files)
        {
            var apartment = _context.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var uniqueFileName = Path.GetRandomFileName() + "_" + file.FileName;
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "photos"); // Путь к папке "photos"

                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var photo = new Photo
                    {
                        Name = uniqueFileName,
                        Url = filePath,
                        ApartmentId = apartment.Id
                    };

                    _context.Photos.Add(photo);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", new { id = apartment.Id });
        }

        // Метод для редактирования квартиры (GET)
        public IActionResult Edit(int id)
        {
            var apartment = _context.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }

        [HttpPost]
        public IActionResult Edit(Apartment apartment)
        {
            // Получение текущего пользователя
            User currentUser = _userManager.GetUserAsync(HttpContext.User).Result;

            var existingApartment = _context.Apartments.Find(apartment.Id);
            if (/*ModelState.IsValid && */existingApartment != null && currentUser.Id == existingApartment.UserId)
            {
                if (apartment.Title != null)
                {
                    existingApartment.Title = apartment.Title;
                }
                if (apartment.Address != null)
                {
                    existingApartment.Address = apartment.Address;
                }
                if (apartment.Price != null)
                {
                    existingApartment.Price = apartment.Price;
                }
                if (apartment.Rooms != null)
                {
                    existingApartment.Rooms = apartment.Rooms;
                }
                if (apartment.Description != null)
                {
                    existingApartment.Description = apartment.Description;
                }
                if (apartment.City != null)
                {
                    existingApartment.City = apartment.City;
                }
                if (apartment.Details != null)
                {
                    existingApartment.Details = apartment.Details;
                }

                _context.Apartments.Update(existingApartment);
                _context.SaveChanges();
                return RedirectToAction("MyApartments", "ApartmentsShow");
            }
            return RedirectToAction("Edit", "ApartmentsManage", new { id = apartment.Id });
        }

        // Метод для удаления квартиры
        public IActionResult Delete(int id)
        {
            // Получение текущего пользователя
            User currentUser = _userManager.GetUserAsync(HttpContext.User).Result;

            var apartment = _context.Apartments.Find(id);
            if (apartment.UserId == currentUser.Id)
            {
                if (apartment == null)
                {
                    return NotFound();
                }
                _context.Apartments.Remove(apartment);
                _context.SaveChanges();
            }
            return RedirectToAction("MyApartments", "ApartmentsShow");
        }
    }
}
