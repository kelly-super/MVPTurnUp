using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SpecFlowMVPTurnUp.Pages
{
    
    public class LoginPage
    {
        

       public readonly By username_input = By.Id("UserName");
        public readonly By password_input = By.Id("Password");
        public readonly By login_button = By.XPath("//input[@type='submit' and @value='Log in']");
        public readonly By error_li = By.XPath("//*[@id=\"loginForm\"]/form/div[1]/ul/li");

        //*[@id="loginForm"]/form/div[1]/ul/li/text()
        public void LoginAction(IWebDriver driver,string username, string password)
        {

            driver.FindElement(username_input).Clear(); 
            driver.FindElement(username_input).SendKeys(username);
            driver.FindElement(password_input).Clear();
            driver.FindElement(password_input).SendKeys(password);
            driver.FindElement(login_button).Click();
        }


    }
}
