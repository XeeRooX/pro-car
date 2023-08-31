using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProCar.Models;
using ProCar.Services;

namespace ProCar.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICarTypeService _carTypeService;
        private readonly IBotMessageService _botService;

        public List<CarType> CarTypes { get; set; }
        public int CountTypes { get; set; }
        public int CountCars { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ICarTypeService carTypeService, IBotMessageService botService)
        {
            _carTypeService = carTypeService;
            _logger = logger;
            _botService = botService;
        }

        public async Task OnGet()
        {
            CarTypes = _carTypeService.GetTypesNotEmpty();
            CountTypes = 3;
            CountCars = 3;

            await _botService.Send("Вася");
        }

    }
}