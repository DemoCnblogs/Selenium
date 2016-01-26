using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using Xunit;

namespace Demo.SeleniumTest
{
    public class UnitTesCase
    {
        /// <summary>
        /// 访问博客园
        /// </summary>
        [Fact(DisplayName = "Cnblogs.Visit")]
        public void Visit_Cnblogs()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://www.cnblogs.com/NorthAlan";
            var lnkAutomation = driver.FindElement(By.XPath(".//div[@id='sidebar_postcategory']/ul/li/a[text()='自动化测试']"));
            lnkAutomation.Click();
        }
    }
}