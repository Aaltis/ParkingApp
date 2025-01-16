using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ParkingApp.Pages.ConfigModels;
using ParkingApp.Pages.Validators;

namespace ParkingApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ParkingService _service;
        private LicensePlateValidator _licencePlateValidator;

        [BindProperty]
        public string LicensePlate { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext dbContext, IOptions<Config> settings)
        {
            _logger = logger;
            _service = new ParkingService(dbContext, settings);
            _licencePlateValidator = new LicensePlateValidator(settings.Value.LicencePlateValidationPattern);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Validate the license plate
            if (!_licencePlateValidator.IsValidLicensePlate(LicensePlate))
            {
                ErrorMessage = "Väärä rekisterinumero. Anna suomlainen rekisterinumero (esim., ABC-123).";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }
            if (!_service.IsThereFreeSpace())
            {
                ErrorMessage = "Ei Tilaa.";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();

            }
            ErrorMessage = string.Empty;
            return RedirectToPage("/ChooseParkingSpace", new { licencePlate = LicensePlate });
        }
    }
}