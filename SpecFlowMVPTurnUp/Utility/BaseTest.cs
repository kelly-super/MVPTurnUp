using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowMVPTurnUp.Utility
{
    public class BaseTest
    {
       public static IWebDriver driver;

        public IWebDriver GetWebDriver() { 
            
            if( driver==null)
            {
             GetNewWebDriver();
            }
            return driver; 
           
        }

        public void GetNewWebDriver()
        {
            string browserType = getApplictionConfig("browserType");
            switch (browserType.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
        }
        public string getApplictionConfig(string key)
        {
            //get applicationConfig.json directory
            string configPath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName
                    + "\\Config\\ApplicationConfig.json";
            IConfiguration _iconfiguration = new ConfigurationBuilder().AddJsonFile(configPath).Build();
            return _iconfiguration[key];
        }        


    }
}
