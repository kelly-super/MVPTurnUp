using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowMVPTurnUp.Pages;
using SpecFlowMVPTurnUp.Utility;

namespace SpecFlowMVPTurnUp.StepDefinitions
{
    [Binding]
    public class DataSourceXlsStepDefinitions : BaseTest
    {


        [Given(@"tha name of the fruit is '([^']*)'")]
        public void GivenThaNameOfTheFruitIs(string fruitName)
        {
            Console.WriteLine($"Fruit Name is :{fruitName}");
        }

        [Given(@"the fruit is of '([^']*)' in color")]
        public void GivenTheFruitIsOfInColor(string fruitColor)
        {
            Console.WriteLine($" Fruit color is {fruitColor}");
        }


    }
}
