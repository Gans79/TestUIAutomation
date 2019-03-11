using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
namespace TestUIAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        private static IWebDriver driver;
        [BeforeFeature]
        public static void DriverSetup()
        {
            string chromeDriverPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Drivers");
            driver = new ChromeDriver(chromeDriverPath);
            driver.Manage().Window.Maximize();
            FeatureContext.Current["driver"] = driver;
        }
        [AfterFeature]
        public static void AfterScenario()
        {
            driver.Quit();
        }
    }
}