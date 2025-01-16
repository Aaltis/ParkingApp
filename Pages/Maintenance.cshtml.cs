using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ParkingApp.Pages.ConfigModels;

namespace ParkingApp.Pages
{
    public class MaintenanceModel : PageModel
    {
        private readonly ParkingService _service;
        private readonly IOptions<Config> _config;

        public int FreeSpacesCount { get; set; }
        public List<Parking> ParkedCars { get; set; }

        public MaintenanceModel(AppDbContext dbContext, IOptions<Config> config)
        {
            _service = new ParkingService(dbContext, config);
            _config = config;
        }

        public void OnGet()
        {

            FreeSpacesCount =_service.GetFreeParkingPlaces().Count;

            ParkedCars = _service.GetAllParkings();
        }
    }
}
