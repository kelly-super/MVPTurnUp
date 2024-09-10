using AventStack.ExtentReports.Utils;
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
        public  By typeCodeOption = By.XPath("//ul[@id='TypeCode_listbox']//li[text()='Time']");
        public readonly By codeTextbox = By.Id("Code");
        public readonly By descriptionTextbox = By.Id("Description");
        public readonly By priceTagOverlap =By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]");
        public readonly By priceTextbox = By.Id("Price");
        public readonly By goTolastPage = By.XPath("//span[contains(text(),'Go to the last page')]");
        public readonly By lastRecordEditButton = By.XPath("//table/tbody/tr[last()]/td/a[contains(@class, 'k-grid-Edit')]");
        public readonly By lastRecordDeleteButton = By.XPath("//table/tbody/tr[last()]/td/a[contains(@class, 'k-grid-Delete')]");
        public readonly By saveButton = By.Id("SaveButton");
        public readonly By item_count = By.XPath("//span[contains(@class,'k-pager-info')]");

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
           // driver.FindElement(priceTextbox).Clear();
            string price_text = driver.FindElement(priceTextbox).Text;
            if (price_text!=""&&price_text!=null) {
                driver.FindElement(priceTextbox).Clear();
                driver.FindElement(priceTagOverlap).Click();
            }

                driver.FindElement(priceTextbox).Click();
                driver.FindElement(priceTextbox).SendKeys(price);
               //  driver.FindElement(saveButton).Click();
           
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
            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();
        }

        public int getItemCount(IWebDriver driver)
        {
            int count = 0;
            IWebElement itemcount = driver.FindElement(item_count);
            string item_content = itemcount.Text;
            string sub_item_content = item_content.Substring(item_content.IndexOf("f"));
            sub_item_content = sub_item_content.Replace("f","").Replace("items","").Replace(" ", "");
            
            Console.WriteLine(sub_item_content);
            count = int.Parse(sub_item_content);
            return count;
        }

        public string getTheLastRecordTypeCode(IWebDriver driver)
        {
            IWebElement _typeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            return _typeCode.Text;
        }
        public string getTheLastRecordCode(IWebDriver driver)
        {
            IWebElement _code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return _code.Text;
        }
        public string getTheLastRecordDescription(IWebDriver driver)
        {
            IWebElement _description = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return _description.Text;
        }
        public string getTheLastRecordPrice(IWebDriver driver)
        {
            IWebElement _price = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return _price.Text;
        }
    }
}
