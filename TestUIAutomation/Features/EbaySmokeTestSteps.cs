using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using TestUIAutomation.Extensions;
using TestUIAutomation.PageObjects;
namespace TestUIAutomation.Features
{
    [Binding]
    public class EbaySmokeTestSteps
    {
        IWebDriver driver = (IWebDriver)FeatureContext.Current["driver"];
        EBayHomePage homePage;
        EBayDetailPage detailPage;
        // int itemcount = 0;

        [Given(@"I navigate to ebay url")]
        public void GivenINavigateToEbayUrl()
        {
            // string chromeDriverPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Drivers");
            //  driver = new ChromeDriver(chromeDriverPath);
            //  driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.ebay.com.au/");
        }

        [When(@"I search for ""(.*)"" product")]
        public void WhenISearchForProduct(string itemName)
        {
            //driver.FindElement(By.Id("gh-ac")).SendKeys(itemName);
            //driver.FindElement(By.Id("gh-btn")).Click();
            homePage = new EBayHomePage(driver);
            homePage.EnterProductAndClickSearch(itemName);
        }

        [When(@"I click the item in search results")]
        public void WhenIClickTheItemInSearchResults()
        {
            //Utility.WaitAndClick(driver.FindElement(By.XPath("//ul[contains(@class,'srp-results')]/li[1]/div/div[2]/a")));
            homePage.SelectTheItemInSearchResults();
        }

        [When(@"I click the add to cart button")]
        public void WhenIClickTheAddToCartButton()
        {
            //  Utility.WaitAndClick(driver.FindElement(By.Id("atcRedesignId_btn")));
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
            //  Utility.WaitAndClick(driver.FindElement(By.XPath("//div[@class='clzBtnSection']//div[@role='button']")));

            detailPage = new EBayDetailPage(driver);
            detailPage.Addtocart();
            // itemcount++;
            detailPage.Closeaddcartwindow();

        }

        [Then(@"""(.*)"" items should be added to cart")]
        public void ThenItemsShouldBeAddedToCart(string expectedProductsCount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
            string actualProductsCountInCart = driver.FindElement(By.Id("gh-cart-n")).Text;
            Assert.IsTrue(actualProductsCountInCart == expectedProductsCount, "Actual Products in Cart is {0} but expected is {1}", actualProductsCountInCart, expectedProductsCount);

        }

        [When(@"I search for '(.*)'product")]
        public void WhenISearchForProducttable(string itemName)
        {
            homePage = new EBayHomePage(driver);
            homePage.EnterProductAndClickSearch(itemName);
        }

        //[Then(@"correct number of items should be added to cart")]
        //public void ThenCorrectNumberOfItemsShouldBeAddedToCart()
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
        //    string actualProductsCountInCart = driver.FindElement(By.Id("gh-cart-n")).Text;
        //    Assert.IsTrue(actualProductsCountInCart == itemcount.ToString(), "Actual Products in Cart is {0} but expected is {1}", actualProductsCountInCart, itemcount);
        //}
        [Then(@"'(.*)' number of items should be added to cart")]
        public void ThenNumberOfItemsShouldBeAddedToCart(string expectedProductCount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
            string actualProductsCountInCart = driver.FindElement(By.Id("gh-cart-n")).Text;
            Assert.IsTrue(actualProductsCountInCart == expectedProductCount, "Actual Products in Cart is {0} but expected is {1}", actualProductsCountInCart, expectedProductCount);
        }

    }
}
