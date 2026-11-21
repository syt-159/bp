using Reqnroll;
using System;
using Xunit;
using BPCalculator;

namespace BPCalculator.Tests.StepDefinitions;

[Binding]
public class BloodPressureSteps
{
    private int _systolic;

    [Given(@"the systolic pressure is (.*)")]
    public void GivenTheSystolicPressureIs(int systolic)
    {
        _systolic = systolic;
    }

    private int _diastolic;

    [Given(@"the diastolic pressure is (.*)")]
    public void GivenTheDiastolicPressureIs(int diastolic)
    {
        _diastolic = diastolic;
    }

    private BPCategory _actualCategory;
    [When(@"the blood pressure category is calculated")]
    public void WhenTheBloodPressureCategoryIsCalculated()
    {
        BloodPressure bp = new BloodPressure
        {
            Systolic = _systolic,
            Diastolic = _diastolic
        };

        _actualCategory = bp.Category;
    }

    [Then(@"the category should be (.*)")]
    public void ThenTheCategoryShouldBe(string expected)
    {
        BPCategory expectedCategory = Enum.Parse<BPCategory>(expected);

        Assert.Equal(expectedCategory, _actualCategory);
    }
}
