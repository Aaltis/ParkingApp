using Microsoft.Extensions.Options;
using ParkingApp.Pages.ConfigModels;
using ParkingApp.Pages.Validators;

namespace ParkingApp.Pages
{
    public class ParkingService
    {
        private ParkingSpaceRepository _repository;
        private readonly Config _configuration;

        public ParkingService(AppDbContext dbContext, IOptions<Config> configuration)
        {
            if (configuration == null || configuration.Value == null)
            {
                throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null or empty.");
            }

            _repository = new ParkingSpaceRepository(dbContext ?? throw new ArgumentNullException(nameof(dbContext), "DbContext cannot be null."));
            _configuration = configuration.Value;
        }

        internal List<Parking> GetAllParkings()
        {
            return _repository.GetAllParkingReservations();
        }

        internal bool IsThereFreeSpace()
        {
            int amount = _repository.GetAmountOfCars();
            if (amount >= _configuration.ParkingSpaces.Count)
            {
                return false;
            }
            else return true;
        }

        internal List<ParkingSpace> GetFreeParkingPlaces()
        {
            List<int> reservedParkingSpaceIds = _repository.GetReservedParkingPlaceIds();
            List<ParkingSpace> allparkingSpaces = _configuration.ParkingSpaces;
            return FreeParkingSpaceCalculator.GetParkingSpaces(allparkingSpaces, reservedParkingSpaceIds);
        }

        internal decimal GetParkingPrice(string licensePlate)
        {

            var parking = _repository.GetParkingPlace(licensePlate);
            if (parking == null)
            {
                throw new ParkingException("Autoa ei löytynyt rekisterikilvellä");
            }

            //secure datetime type.
            parking.ParkingTime = DateTime.SpecifyKind(parking.ParkingTime, DateTimeKind.Utc);

            var time = TimeDifferenceCalculator.GetTimeDifferenceInHours(parking.ParkingTime, DateTime.UtcNow);
            var pricelist = _configuration.HourPrices.Select(hr => hr.Rate).ToList();
            return ParkingPriceCalculator.CalculateParkingPrice(pricelist, time);
        }

        internal void ReserveParkingSpace(int spaceId, string licensePlate)
        {
            _repository.ReserveParkingSpace(spaceId, licensePlate);
        }
    }
}
