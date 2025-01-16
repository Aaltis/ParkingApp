namespace ParkingApp.Pages
{
    public class Parking
    {
        public int Id { get; set; }
        public int ParkingPlacesId { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ParkingTime { get; set; }
    }
}