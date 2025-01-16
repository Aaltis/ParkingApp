namespace ParkingApp.Pages.ConfigModels
{
    public class Config
    {
        public List<HourRate> HourPrices { get; set; }
        public List<ParkingSpace> ParkingSpaces { get; set; }
        public string LicencePlateValidationPattern { get; set; }
    }
}
