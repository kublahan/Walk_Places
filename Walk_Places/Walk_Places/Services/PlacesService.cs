using Walk_Places.Data;
using Walk_Places.Models;

namespace Walk_Places.Services
{
    public class PlacesService
    {
        private readonly WalkPlacesDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PlacesService(WalkPlacesDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public void AddPlace(Place place, IFormFile photoFile)
        {
            if (photoFile != null && photoFile.Length > 0)
            {
                // Генерация уникального имени файла для избежания конфликтов
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);

                // Формирование пути к файлу
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/places", fileName);

                // Сохранение файла в указанный путь
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    photoFile.CopyTo(stream);
                }

                // Сохранение пути к файлу в базу данных
                place.PhotoPath = "images/places/" + fileName;
            }

            // Добавление места в базу данных
            _dbContext.Places.Add(place);
            _dbContext.SaveChanges();
        }
    }
}
