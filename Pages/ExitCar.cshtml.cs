using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ParkingApp.Pages.ConfigModels;
using ParkingApp.Pages.Validators;

namespace ParkingApp.Pages
{
    public class ExitCarModel : PageModel
    {
        private readonly ILogger<ExitCarModel> _logger;
        private ParkingService _service;
        private LicensePlateValidator _licencePlateValidator;
        [BindProperty]
        public string LicensePlate { get; set; }
        public string ErrorMessage { get; set; }
        public string PriceMessage { get; set; }

        public ExitCarModel(ILogger<ExitCarModel> logger, AppDbContext dbContext, IOptions<Config> settings)
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
                ErrorMessage = "V‰‰r‰ rekisterinumero. Anna suomlainen rekisterinumero (esim., ABC-123).";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }
            try {
                var price= _service.GetParkingPrice(LicensePlate);
                PriceMessage = $"Parkkeerauksen hinta: {price}Ä";
            }
            catch (ParkingException ex)
            {
                ErrorMessage = ex.Message;
                ModelState.AddModelError(string.Empty, ErrorMessage); 
                return Page();
            }
            catch (Exception ex)
            {
                //dont show exception to user.
                _logger.LogError(ex.ToString());
            }
            return Page();

        }
    }
}
