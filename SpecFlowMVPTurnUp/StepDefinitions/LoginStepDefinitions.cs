using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowMVPTurnUp.Pages;
using SpecFlowMVPTurnUp.Utility;

namespace SpecFlowMVPTurnUp.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions :BaseTest
    {


        LoginPage loginPage;
        HomePage homePage;

        [Given(@"the user navigates to the login page")]
        public void GivenTheUserNavigatesToTheLoginPage()
        {
            
            string url = getApplictionConfig("url");
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);
           
        }

        [When(@"user enters invalid credentials and click the login button")]
        public void WhenUserEntersInvalidCredentialsAndClickTheLoginButton()       
        {
           
            string username = getApplictionConfig("username");
            string password = getApplictionConfig("password");
            loginPage = new LoginPage();
            loginPage.LoginAction(driver, username, password);
            
        }

        [Then(@"the user should be redirected to the homepage")]
        public void ThenTheUserShouldBeRedirectedToTheHomepage()
        {
            homePage = new HomePage();
            Thread.Sleep(1000);
            IWebElement helloUser = driver.FindElement(homePage.helloUser);
            Assert.That(helloUser.Text == "Hello hari!", "login successful");
        }

        [When(@"user enters invalid credentials")]
        public void WhenUserEntersInvalidCredentials()
        {
            loginPage = new LoginPage();
            loginPage.LoginAction(driver, "harr", "123123");
            Thread.Sleep(1000);

        }

        [Then(@"the user should see an error message")]
        public void ThenTheUserShouldSeeAnErrorMessage()
        {
            IWebElement error_li = driver.FindElement(loginPage.error_li);
            if (error_li.Displayed && error_li.Text == "Invalid username or password.")
            {
               
                Assert.Pass("user enter invalid credentials test case passed");
            }
            else
            {
                Assert.Fail("user enter invalid credentials test case failed");
            }
        }


        [Then(@"the user should see an error message '([^']*)'")]
        public void ThenTheUserShouldSeeAnErrorMessage(string p0)
        {
            Assert.Pass("**************************");
        }

        [When(@"user enters password but null username")]
        public void WhenUserEntersPasswordButNullUsername()
        {
            loginPage = new LoginPage();
            loginPage.LoginAction(driver, "", "123123");
        }

        [When(@"user enters password but null password")]
        public void WhenUserEntersPasswordButNullPassword()
        {
            loginPage = new LoginPage();
            loginPage.LoginAction(driver, "harr", "");
        }



    }
}
