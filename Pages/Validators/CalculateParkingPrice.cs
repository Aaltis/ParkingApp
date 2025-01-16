namespace ParkingApp.Pages.Validators;

public class ParkingPriceCalculator
{
    public static decimal CalculateParkingPrice(List<decimal> prices, decimal hoursParked)
    {
        if (prices == null || prices.Count == 0)
        {
            throw new ArgumentException("Hintalista ei voi olla tyhjä.");
        }

        decimal totalCost = 0;
        int fullHours = (int)Math.Ceiling(hoursParked);
        int totalPrices = prices.Count;

        for (int i = 0; i < fullHours; i++)
        {
            if (i < totalPrices)
            {
                totalCost += prices[i];
            }
            else
            {
                totalCost += prices[totalPrices - 1]; 
            }
        }

        return totalCost;
    }
}

