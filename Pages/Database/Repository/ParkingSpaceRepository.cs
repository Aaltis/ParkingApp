using ParkingApp.Pages.ConfigModels;

namespace ParkingApp.Pages
{
    public class ParkingSpaceRepository
    {
        private readonly AppDbContext _dbContext;
        public ParkingSpaceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "AppDbContext cannot be null.");
        }
        public int GetAmountOfCars()
        {
            return _dbContext.Parking.Count();

        }
        public List<int> GetReservedParkingPlaceIds()
        {
            return _dbContext.Parking.Select(x => x.ParkingPlacesId).ToList();

        }

        internal void ReserveParkingSpace(int spaceId, string licensePlate)
        {
            var space = _dbContext.Parking.FirstOrDefault(p => p.ParkingPlacesId == spaceId);
            _dbContext.Parking.Add(new Parking { ParkingPlacesId = spaceId, LicensePlate = licensePlate, ParkingTime = DateTime.UtcNow }); ;
            _dbContext.SaveChanges();
        }

        internal List<Parking> GetAllParkingReservations()
        {
            return _dbContext.Parking.ToList();
        }

        internal Parking? GetParkingPlace(string licensePlate)
        {
            return _dbContext.Parking.Where(x=>x.LicensePlate.Equals(licensePlate)).SingleOrDefault();
        }
    }
}
