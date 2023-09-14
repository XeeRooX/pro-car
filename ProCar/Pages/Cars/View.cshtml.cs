using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Services;
using ProCar.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace ProCar.Pages.Cars
{
    public class ViewModel : PageModel
    {
        private readonly ICarsService _carsService;
        private readonly IServerUploadService _uploadService;
        private readonly IConfiguration _configuration;
        private readonly IBotMessageService _botMessage;
        public Car Car { get; set; } = new();
        public bool IsConfirmed { get; set; }
        public int CountPhoto { get; set; }
        public ViewModel(ICarsService carsService, IServerUploadService uploadService, IConfiguration configuration, IBotMessageService botMessage)
        {
            _carsService = carsService;
            _uploadService = uploadService;
            _configuration = configuration;
            _botMessage = botMessage;
        }
        public IActionResult OnGet(int id)
        {
            Car = _carsService.GetById(id);
            if(Car == null)
            {
                return NotFound();
            }
            CountPhoto = _uploadService.CountCarPhotos(id);
            return Page();
        }

        public IActionResult OnPost(InputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Car = _carsService.GetById(model.Id);
            if (Car == null)
            {
                return NotFound();
            }
            CountPhoto = _uploadService.CountCarPhotos(model.Id);
            IsConfirmed = true;

            var car = _carsService.GetById(model.Id);
            var hostname = _configuration.GetValue<string>("ServerSecrets:Hostname");
            StringBuilder message = new StringBuilder("❗Новая заявка❗\n");
            message.AppendLine($"Информация об автомобиле 🚗");
            message.AppendLine($"{car.Brand.Name} {car.Model}");
            message.AppendLine($"🔗 Ссылка на автомобиль: https://{hostname}/Cars/View/{model.Id}/");
            message.AppendLine($"\n\U0001f9d1 Информация о клиенте");
            message.AppendLine($"📃 Имя: {model.Name}");
            message.AppendLine($"📞 Номер телефона: {model.Phone.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "")}");
            message.AppendLine($"📆 Аренда от: {model.RentFrom}");
            message.AppendLine($"📆 Аренда до: {model.RentBefore}");
            _botMessage.Send(message.ToString());

            //return RedirectToPage($"/Cars/View/{model.Id}");
            return Page();
        }
        public class InputModel
        {
            public int Id { get; set; }
            [StringLength(50)]
            public string Name { get; set; } = null!;
            public string RentFrom { get; set; } = null!;
            public string RentBefore { get; set; } = null!;
            public string Phone { get; set; } = null!;

        }
    }
    
}
