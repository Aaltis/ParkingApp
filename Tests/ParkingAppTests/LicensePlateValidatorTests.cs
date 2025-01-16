using NUnit.Framework;
using ParkingApp.Pages.Validators;

namespace ParkingAppTests
{
    public class LicensePlateValidatorTests
    {
        LicensePlateValidator _licensePlateValidator;
        [SetUp]
        public void Setup()
        {
            //test with defaul finnish licence plate pattern.
            _licensePlateValidator = new LicensePlateValidator("^[A-Z]{1,3}-\\d{1,3}$");
        }

        [Test]
        public void BasicLicencePlate_Pass()
        {
            Assert.IsTrue(_licensePlateValidator.IsValidLicensePlate("ABC-123"));
        }
        [Test]
        public void ShortPlate_Pass()
        {
            Assert.IsTrue(_licensePlateValidator.IsValidLicensePlate("A-1"));
        }
        [Test]
        public void TooManyCharacters_Fail()
        {
            Assert.IsFalse(_licensePlateValidator.IsValidLicensePlate("ABCD-123"));
        }
        [Test]
        public void NoHyphen_Fail()
        {
            Assert.IsFalse(_licensePlateValidator.IsValidLicensePlate("ABC123"));
        }
    }
}