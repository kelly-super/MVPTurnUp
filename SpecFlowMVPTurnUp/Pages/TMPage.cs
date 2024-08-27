using OpenQA.Selenium;
using SpecFlowMVPTurnUp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowMVPTurnUp.Pages
{
    public class TMPage
    {

        public readonly By cteateNew_button =  By.XPath("//a[contains(text(),'Create New')]");
        public readonly By typeCodeDropdown = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span");
        public  By typeCodeOption = By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]");
        public readonly By codeTextbox = By.Id("Code");
        public readonly By descriptionTextbox = By.Id("Description");
        public readonly By priceTagOverlap =By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]");
        public readonly By priceTextbox = By.Id("Price");
        public readonly By goTolastPage = By.XPath("//span[contains(text(),'Go to the last page')]");
        public readonly By lastRecordEditButton = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        public readonly By lastRecordDeleteButton = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]");
        public readonly By saveButton = By.Id("SaveButton");


        public void createNewAction(IWebDriver driver)
        {
            driver.FindElement(cteateNew_button).Click();
        }
        public void goToTheLastPage(IWebDriver driver)
        {
            driver.FindElement(goTolastPage).Click();
        }
        public void inputNewRecorInfod (IWebDriver driver, string typecode, string code, string desp, string price)
        {
           
            Wait.WaitToBeVisible(driver, "xpath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 3);
            driver.FindElement(typeCodeDropdown).Click();
                if (typecode == "T")
                {
                Wait.WaitToBeVisible(driver, "xpath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 3);
                typeCodeOption = By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]");
                }
                else
                {
                Wait.WaitToBeVisible(driver, "xpath", "//*[@id=\"TypeCode_listbox\"]/li[1]", 3);
                typeCodeOption = By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]");
                }
                driver.FindElement(typeCodeOption).Click();
                driver.FindElement(codeTextbox).Clear();
                driver.FindElement(codeTextbox).SendKeys(code);
                driver.FindElement(descriptionTextbox).Clear();
                driver.FindElement(descriptionTextbox).SendKeys(desp);
                driver.FindElement(priceTagOverlap).Click();
                driver.FindElement(priceTextbox).Clear();
                // driver.FindElement(priceTagOverlap).Click();
                driver.FindElement(priceTextbox).SendKeys(price);
                // driver.FindElement(saveButton).Click();
           
        }
        public void SaveNewRecord(IWebDriver driver)
        {
            driver.FindElement(saveButton).Click();
        }

        public void ClickTheLastRecordEditButton(IWebDriver driver)
        {
            driver.FindElement(lastRecordEditButton).Click();
        }

        public void DeleteTheLastRecord(IWebDriver driver) {
            driver.FindElement(lastRecordDeleteButton).Click();
           /* IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();*/
        }

    }
}
