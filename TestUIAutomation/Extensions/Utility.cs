
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestUIAutomation.Extensions
{
    public static class Utility
    {
        public static void WaitAndClick(IWebElement elm)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(elm);
            wait.Timeout = TimeSpan.FromSeconds(90);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool element = wait.Until<bool>((d) =>
            {
                try
                {
                    if (d.Displayed & d.Enabled)
                    {
                        d.Click();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    string a = e.Message;
                    return false;
                }
            });
        }
    }
}