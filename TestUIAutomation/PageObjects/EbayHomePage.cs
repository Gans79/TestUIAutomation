using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestUIAutomation.Extensions;
namespace TestUIAutomation.PageObjects
{
    public class EBayHomePage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "gh-ac")]
        private IWebElement txtItemName;
        [FindsBy(How = How.Id, Using = "gh-btn")]
        private IWebElement btnSearch;
        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'srp-results')]/li[1]/div/div[2]/a")]
        private IWebElement lnkItemInSearchResult;
#pragma warning disable 0649
        public EBayHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
        }
        public void EnterProductAndClickSearch(string productName)
        {
            txtItemName.SendKeys(productName);
            Utility.WaitAndClick(btnSearch);
        }
        public void SelectTheItemInSearchResults()
        {
            Utility.WaitAndClick(lnkItemInSearchResult);
        }
    }
}
