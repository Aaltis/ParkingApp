namespace ParkingApp.Pages.Validators
{
    public class TimeDifferenceCalculator
    {
        public static decimal GetTimeDifferenceInHours(DateTime startTime, DateTime endTime)
        {
            if (startTime.Kind != DateTimeKind.Utc || endTime.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Both times must be in UTC.");
            }
            if (endTime < startTime)
            {
                throw new ArgumentException("End time cannot be earlier than start time.");
            }
            // Calculate the time difference
            TimeSpan timeDifference = endTime - startTime;

            // Convert the total hours to decimal
            decimal hours = (decimal)timeDifference.TotalHours;

            return hours;
        }
    }
}