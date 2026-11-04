using Xunit;
using BPCalculator.Pages;

namespace BPCalculator.Tests;

public class BloodPressurePageTests
{
    
    [Fact]
    public void OnPost_InvalidBloodPressure()
    {
        
        var random = new Random(12345);

        for(int i = 0; i < 10; i++)
        {
            int systolic = random.Next(70, 101);
            int diastolic = random.Next(systolic, 101);
            
            var page = new BloodPressureModel();
            page.BP = new BloodPressure
            {
                Systolic = systolic,
                Diastolic = diastolic
            };

            page.OnPost();

            Assert.False(page.ModelState.IsValid);
        }

    }

    [Fact]
    public void Random_Range_Testing()
    {

        
        var random = new Random(12345);

        for(int i = 0; i < 10; i++)
        {
            int systolic = random.Next(BloodPressure.SystolicMin, BloodPressure.SystolicMax+1);
            int diastolic = random.Next(BloodPressure.DiastolicMin,Math.Min(BloodPressure.DiastolicMax + 1, systolic));
            
            var page = new BloodPressureModel();
            page.BP = new BloodPressure
            {
                Systolic = systolic,
                Diastolic = diastolic
            };

            page.OnPost();

            Assert.True(page.ModelState.IsValid);
        }
    }


    [Fact]
    public void OnPost_DefaultBloodPressure()
    {
        var page = new BloodPressureModel();
        page.OnGet();

        Assert.NotNull(page.BP);
        Assert.Equal(100, page.BP.Systolic);
        Assert.Equal(60, page.BP.Diastolic);

    }
}