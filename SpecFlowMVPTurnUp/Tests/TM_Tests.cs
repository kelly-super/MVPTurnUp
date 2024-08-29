using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowMVPTurnUp.Pages;
using SpecFlowMVPTurnUp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowMVPTurnUp.Tests
{
    [TestFixture]
    public class TM_Tests :BaseTest
    {
     /*   public TM_Tests(IWebDriver driver) : base(driver)
        {
        }
*/
        // private IWebDriver driver;


        [SetUp]
        public void SetUpSteps()
        {
            // Open Chrome Browser
            BaseTest basetest = new BaseTest();
            driver = basetest.GetWebDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            string url = basetest.getApplictionConfig("url");
            string username = basetest.getApplictionConfig("username");
            string password = basetest.getApplictionConfig("password");
            driver.Navigate().GoToUrl(url);
            loginPageObj.LoginAction(driver, username, password);

            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            // TM page object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.createNewAction(driver);
            tMPageObj.inputNewRecorInfod(driver, "T", "2024082801", "this is a test", "$123");
            tMPageObj.SaveNewRecord(driver);
        }

        [Test]
        public void EditTime_Test()
        {
            // Edit Time Record
            TMPage tMPageObj = new TMPage();
            tMPageObj.goToTheLastPage(driver);
            tMPageObj.ClickTheLastRecordEditButton(driver);
            tMPageObj.inputNewRecorInfod(driver, "T", "2024082802", "this is a test2", "$123");
            tMPageObj.SaveNewRecord(driver);
        }

        [Test]
        public void DeleteTime_Test()
        {
            // Delete Time Record
            TMPage tMPageObj = new TMPage();
            tMPageObj.goToTheLastPage(driver);
            tMPageObj.DeleteTheLastRecord(driver);
            tMPageObj.DeleteTheLastRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
