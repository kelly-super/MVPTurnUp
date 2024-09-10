using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowMVPTurnUp.Pages
{
    public class HomePage
    {
   
        public readonly By administratorTab = By.XPath("//li[@class='dropdown']//a[text()='Administration ']");
        public readonly By materialAndTimeOption = By.XPath("//ul[@class='dropdown-menu']//a[text()='Time & Materials']");
        public readonly By  helloUser = By.XPath("//form[@id='logoutForm']//a[starts-with(text(),'Hello')]");

        public void NavigateToTMPage(IWebDriver driver)
        {
            driver.FindElement(administratorTab).Click();
            driver.FindElement(materialAndTimeOption).Click();
        }

        public string getMessage(IWebDriver driver)
        {
            return driver.FindElement(helloUser).Text;
        }

    }
}
