using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowMVPTurnUp.Pages;
using SpecFlowMVPTurnUp.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowMVPTurnUp.StepDefinitions
{
    [Binding]
    public class MaterialAndTimeEditStepDefinitions:BaseTest
    {
        private IWebDriver driver;
        LoginPage loginPage;
        TMPage tmPage;
        HomePage homePage;
        public MaterialAndTimeEditStepDefinitions(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }

        [Given(@"user logined in the system with username ""([^""]*)"" password ""([^""]*)"" and navigate to the MaterialTime Page")]
        public void GivenUserLoginedInTheSystemWithUsernamePasswordAndNavigateToTheMaterialTimePage(string hari, string p1)
        {

            string url = getApplictionConfig("url");
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);

            loginPage = new LoginPage();
            loginPage.LoginAction(driver, hari, p1);
            homePage = new HomePage();
            homePage.NavigateToTMPage(driver);
        }

        [Given(@"User select the last record,click edit button")]
        public void GivenUserSelectTheLastRecordClickEditButton()
        {
            Thread.Sleep(2000);
            tmPage = new TMPage();
            tmPage.goToTheLastPage(driver);
            tmPage.ClickTheLastRecordEditButton(driver);


        }

        [Given(@"edit the'([^']*)' '([^']*)' and '([^']*)' and '([^']*)'")]
        public void GivenEditTheAndAnd(string typecode, string code, string description, string price)
        {
            try
            {
                tmPage.inputNewRecorInfod(driver, typecode, code, description, price);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"click the save button")]
        public void ThenClickTheSaveButton()
        {

            tmPage.SaveNewRecord(driver);
        }

         [Then(@"verify the '([^']*)' is changed")]
        public void ThenVerifyTheIsChanged(string p0)
        {

            tmPage.goToTheLastPage(driver);
            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]"));
            if (lastRecord.Text.Contains(p0))
            {
                Assert.Pass("Edit successfully");
            }
            else
            {
                Assert.Fail("Edit failed");
            }
        }     

    }
}
