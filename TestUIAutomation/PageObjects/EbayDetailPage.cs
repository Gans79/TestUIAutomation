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
    class EBayDetailPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "atcRedesignId_btn")]
        private IWebElement btnAddtocart;
        [FindsBy(How = How.XPath, Using = "//div[@class='clzBtnSection']//div[@role='button']")]
        private IWebElement btnClose;
        public EBayDetailPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
        }
        public void Addtocart()
        {
            Utility.WaitAndClick(btnAddtocart);
        }
        public void Closeaddcartwindow()
        {
            Utility.WaitAndClick(btnClose);
        }
    }
}
