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
   
        public readonly By administratorTab = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span");

        public readonly By materialAndTimeOption = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        public readonly By  helloUser = By.XPath("//body/div[3]/div[1]/div[1]/form[1]/ul[1]/li[1]/a[1]");

        public void NavigateToTMPage(IWebDriver driver)
        {
            driver.FindElement(administratorTab).Click();
            driver.FindElement(materialAndTimeOption).Click();
        }



    }
}
