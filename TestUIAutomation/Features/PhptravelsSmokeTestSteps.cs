using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace TestUIAutomation.Features
{
    [Binding]
    public class PhptravelsSmokeTestSteps
    {
        IWebDriver driver = (IWebDriver)FeatureContext.Current["driver"];
        [Given(@"I navigate to phptravels url")]
        public void GivenINavigateToPhptravelsUrl()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
        }

        [When(@"i login using '(.*)' and '(.*)'")]
        public void WhenILoginUsingAnd(string username, string pwd)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
            //my acccount
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
            driver.FindElement(By.XPath("//nav//li[@id='li_myaccount']/a")).Click();
            //login

            driver.FindElement(By.XPath("//nav//li[@id='li_myaccount']/ul/li[1]/a")).Click();
            //username

            driver.FindElement(By.XPath("//*[@id='loginfrm']/div[1]/div[5]/div/div[1]/input")).SendKeys(username);
            //password

            driver.FindElement(By.XPath("//*[@id='loginfrm']/div[1]/div[5]/div/div[2]/input")).SendKeys(pwd);

            //login

            driver.FindElement(By.XPath("//*[@id='loginfrm']/button")).Click();

           

            

        }

        [Then(@"i should see a error on the screen")]
        public void ThenIShouldSeeAErrorOnTheScreen()
        {
            var errorText = driver.FindElement(By.XPath("//*[@id='loginfrm']/div[1]/div[2]/div")).Text;
            Assert.IsTrue(errorText == "Invalid Email or Password", "Expected value is : Error but Actual value is {0}", errorText);
        }



        [When(@"click on Hotels icon")]
        public void WhenClickOnHotelsIcon()
        {
            //hotel icon

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[contains(@href,'m-hotels')]//span")).Click();

        }
        [When(@"input '(.*)' and '(.*)' and '(.*)' and search")]
        public void WhenInputAndAndAndSearch(string hotelname, string startdate, string enddate)
        {
            // PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
            //hotel input
            driver.FindElement(By.XPath("//div[@id='s2id_autogen8']/a/span[1]")).Click();
            driver.FindElement(By.XPath("//div[@id='select2-drop']/div/input")).SendKeys(hotelname);
            //selecthotel
            driver.FindElement(By.XPath("//*[@id='select2-drop']/ul/li/ul/li[2]")).Click();

            //startdate
            driver.FindElement(By.XPath("//*[@id='dpd1']/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id='dpd1']/div/input")).SendKeys(startdate);
            //enddate
            driver.FindElement(By.XPath("//*[@id='dpd2']/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id='dpd2']/div/input")).SendKeys(enddate);
            //searchbutton
            driver.FindElement(By.XPath("//*[@id='hotels']/form/div[5]/button")).Click();
        }
        [When(@"select the available hotel and book")]
        public void WhenSelectTheAvailableHotelAndBook()
        {
            var element = driver.FindElement(By.XPath("//tbody/tr[1]//label"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            driver.FindElement(By.XPath("//tbody/tr[1]//label")).Click();
            driver.FindElement(By.XPath("//button[contains(text(),'Book Now')]")).Click();
            driver.FindElement(By.XPath("//button[contains(text(),'CONFIRM THIS BOOKING')]")).Click();
        }
        [Then(@"i should see a invoice on the screen")]
        public void ThenIShouldSeeAInvoiceOnTheScreen()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(90);
            var assertText = driver.FindElement(By.XPath("//*[@id='invoiceTable']/tbody/tr[2]/td/div[1]//div[3]")).Text;
            Assert.IsTrue(assertText == "INVOICE", "Expected value is : INVOICE but Actual value is {0}", assertText);
        }
    }
}
