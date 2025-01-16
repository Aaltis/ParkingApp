
using System.Text.RegularExpressions;

namespace ParkingApp.Pages.Validators;
public class LicensePlateValidator
{
    string _pattern;
    public LicensePlateValidator(string licencePlatePattern)
    {
        _pattern = licencePlatePattern ?? throw new ArgumentNullException(nameof(licencePlatePattern), "LicencePlatePattern cannot be null.");
    }
    public bool IsValidLicensePlate(string licensePlate)
    {

        return Regex.IsMatch(licensePlate, _pattern);
    }
}
