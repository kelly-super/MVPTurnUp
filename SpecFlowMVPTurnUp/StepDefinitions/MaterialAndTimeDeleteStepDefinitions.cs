using OpenQA.Selenium;
using SpecFlowMVPTurnUp.Pages;
using SpecFlowMVPTurnUp.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowMVPTurnUp.StepDefinitions
{
    [Binding]
    public class MaterialAndTimeDeleteStepDefinitions :BaseTest
    {
        private IWebDriver driver;
        private int record_count;
        LoginPage loginPage;
        TMPage tmPage;
        HomePage homePage;

        public MaterialAndTimeDeleteStepDefinitions(IWebDriver driver):base(driver) 
        {
            this.driver = driver;
        }

        [Given(@"user log in the system with username ""([^""]*)"" password ""([^""]*)"" and navigate to the MaterialTime Page")]
        public void GivenUserLogInTheSystemWithUsernamePasswordAndNavigateToTheMaterialTimePage(string hari, string p1)
        {
            string url = getApplictionConfig("url");
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);

            loginPage = new LoginPage();
            loginPage.LoginAction(driver, hari, p1);
            homePage = new HomePage();
            homePage.NavigateToTMPage(driver);
        }

        [Given(@"User select the last record")]
        public void GivenUserSelectTheLastRecord()
        {
       
            tmPage = new TMPage();
            tmPage.goToTheLastPage(driver);

        }     

        [Given(@"click the delete button")]
        public void GivenClickTheDeleteButton()
        {
            Thread.Sleep(1000);
            tmPage.DeleteTheLastRecord(driver);
        }

        [Given(@"confirm to delete")]
        public void GivenConfirmToDelete()
        {
            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();
        }

        [Then(@"verify the  record count should minus (.*)")]
        public void ThenVerifyTheRecordCountShouldMinus(int p0)
        {
            IWebElement refresh_button = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[5]/span"));
            refresh_button.Click();
            IWebElement items_count = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/span[2]"));
            Console.WriteLine(items_count.Text.ToString());
        }


    }
}
