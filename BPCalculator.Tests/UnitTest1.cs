using System.ComponentModel.DataAnnotations;

namespace BPCalculator.Tests;

public class UnitTest1
{
    //Boundary Value Testing
    [Theory]
    // Systolic boundary value tests
    [InlineData(69, 40, false)]   // Below minimum
    [InlineData(70, 40, true)]    // At minimum
    [InlineData(190, 40, true)]   // At maximum
    [InlineData(191, 40, false)]  // Above maximum

    // Diastolic boundary value tests
    [InlineData(120, 39, false)]  // Below minimum
    [InlineData(120, 40, true)]   // At minimum
    [InlineData(120, 100, true)]  // At maximum
    [InlineData(120, 101, false)] // Above maximum
    public void Boundary_Range_Testing(
        int systolic,
        int diastolic,
        bool expectedValid)
    {
        var bp = new BloodPressure
        {
            Systolic = systolic,
            Diastolic = diastolic,
        };

        var results = new List<ValidationResult>();
        var context = new ValidationContext(bp);

        bool isValid = Validator.TryValidateObject(
            bp,
            context,
            results,
            validateAllProperties: true
        );

        Assert.Equal(expectedValid, isValid);
    }

}
