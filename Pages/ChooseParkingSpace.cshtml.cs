using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ParkingApp.Pages;
using ParkingApp.Pages.ConfigModels;
using ParkingApp.Pages.Validators;

namespace ParkingApp
{
    public class ChooseParkingSpaceModel : PageModel
    {
        public string LicencePlate { get; set; }
        private readonly ILogger<ChooseParkingSpaceModel> _logger;
        private ParkingService _service;
        private LicensePlateValidator _licencePlateValidator;

        [BindProperty]
        public string ErrorMessage { get; set; }
        public List<ParkingSpace> FreeParkingSpaces { get; set; }

        public ChooseParkingSpaceModel(ILogger<ChooseParkingSpaceModel> logger, AppDbContext dbContext, IOptions<Config> settings)
        {
            _logger = logger;
            _service = new ParkingService(dbContext, settings);
            _licencePlateValidator = new LicensePlateValidator(settings.Value.LicencePlateValidationPattern);

        }

        public void OnGet(string licencePlate)
        {
            LicencePlate = licencePlate; // Capture the value from the query string
            FreeParkingSpaces=_service.GetFreeParkingPlaces();
        }
        public IActionResult OnPost(int spaceId, [FromQuery] string licencePlate)
        {
            if (string.IsNullOrEmpty(licencePlate))
            {
                return BadRequest("Licence plate is required.");
            }
            if (!_licencePlateValidator.IsValidLicensePlate(licencePlate))
            {
                ErrorMessage = "Invalid license plate. Please enter a valid Finnish license plate (e.g., ABC-123).";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }
            _service.ReserveParkingSpace(spaceId, licencePlate);

            return RedirectToPage();
        }
    }
}
