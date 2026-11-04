using System.ComponentModel.DataAnnotations;

namespace BPCalculator.Tests;

public class BloodPressureTests
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

    [Fact]
    public void Random_Range_Testing()
    {

        var random = new Random(12345);

        for(int i = 0; i < 50; i++)
        {
        int systolic = random.Next(BloodPressure.SystolicMin, BloodPressure.SystolicMax+1);
        int diastolic = random.Next(BloodPressure.DiastolicMin,Math.Min(BloodPressure.DiastolicMax + 1, systolic));
        // Console.WriteLine($"Systolic: {systolic}, Diastolic: {diastolic}");
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

        Assert.True(isValid);
        }
    }

    //Boundary category Testing
    [Theory]
    [InlineData(89, 59, BPCategory.Low)]
    [InlineData(89, 60, BPCategory.Ideal)]
    [InlineData(90, 60, BPCategory.Ideal)]
    [InlineData(119, 79, BPCategory.Ideal)]
    [InlineData(120, 79, BPCategory.PreHigh)]
    [InlineData(119, 80, BPCategory.PreHigh)]
    [InlineData(139, 89, BPCategory.PreHigh)]
    [InlineData(140, 89, BPCategory.High)]
    [InlineData(139, 90, BPCategory.High)]
    [InlineData(189, 90, BPCategory.High)]
    [InlineData(189, 99, BPCategory.High)]
    public void Boundary_Category_Testing(
        int systolic,
        int diastolic,
        BPCategory expectedCate)
    {
        var bp = new BloodPressure
        {
            Systolic = systolic,
            Diastolic = diastolic,
        };

        BPCategory cate = bp.Category;

        Assert.Equal(expectedCate, cate);
    }
        

}
