using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowMVPTurnUp.Hooks;
using SpecFlowMVPTurnUp.Pages;
using SpecFlowMVPTurnUp.Utility;
using System;

namespace SpecFlowMVPTurnUp.StepDefinitions
{
    [Binding]
    public sealed class MaterialAndTimeStepDefinitions : BaseTest
    {
        private IWebDriver driver;
        LoginPage loginPage;
        TMPage tmPage;
        HomePage homePage;
        public MaterialAndTimeStepDefinitions(IWebDriver driver):base(driver) 
        {
            this.driver = driver;
        }
        [Given(@"user login the system with username ""([^""]*)"" password ""([^""]*)"" and navigate to the MaterialTime Page")]
        public void GivenUserLoginTheSystemWithUsernamePasswordAndNavigateToTheMaterialTimePage(string hari, string p1)
        {

            string url = getApplictionConfig("url");
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);

            loginPage = new LoginPage();
            loginPage.LoginAction(driver, hari, p1);
            homePage = new HomePage();
            homePage.NavigateToTMPage(driver);
        }

        [Given(@"click the createNew button")]
        public void GivenClickTheCreateNewButton()
        {
            tmPage = new TMPage();
            tmPage.createNewAction(driver);
        }

        [When(@"enter the information and click the save button")]
        public void WhenEnterTheInformationAndClickTheSaveButton(Table table)
        {
            try
            {
                //Pass the value in parameters
                foreach (TableRow row in table.Rows)
                {
                    tmPage.inputNewRecorInfod(driver, row[0], row[1], row[2], row[3]);
                    tmPage.SaveNewRecord(driver);
                }
            }
            catch (Exception ex) { 
            Assert.Fail(ex.Message);
            }
        }

        [Then(@"a new record should be created")]
        public void ThenANewRecordShouldBeCreated(Table table)
        {
            try
            {
                foreach (TableRow row in table.Rows)
                {
                    tmPage.goToTheLastPage(driver);

                    //get the code column value of the last record 
                    IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                    Console.WriteLine("**********************" + lastRecord.Text);
                    /*if (lastRecord.Text != row[0])
                    {
                        Console.WriteLine(" record " + row[0] + " is created successfully");
                        Assert.Pass(lastRecord.Text + "is created successfully");
                    }
                    else
                    {
                        Console.WriteLine(" record " + row[0] + " created failed");
                        Assert.Fail(lastRecord.Text + "is created failed");
                    }*/
                     Assert.That(lastRecord.Text != row[0], "create successfully");
                }
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }


         

    }
}
