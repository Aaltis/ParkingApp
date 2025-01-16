using ParkingApp.Pages.ConfigModels;

namespace ParkingApp.Pages
{
    public class FreeParkingSpaceCalculator
    {
        //change reservedParkingSpaceIds to hashmap if you need more speed
        public static List<ParkingSpace> GetParkingSpaces(List<ParkingSpace> allparkingSpaces, List<int> reservedParkingSpaceIds)
        {
            return allparkingSpaces
                .Where(space => !reservedParkingSpaceIds.Contains(space.Id))
                .ToList();
        }
    }
}
