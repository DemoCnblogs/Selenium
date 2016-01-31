using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.SeleniumTest
{
    /// <summary>
    /// 自定义的扩展条件
    /// </summary>
    public class ExpectedConditionsExtension
    {
        /// <summary>
        /// 等待进度条消失
        /// </summary>
        /// <param name="dir">WebDriver对象</param>
        /// <returns>操作Func对象</returns>
        public static Func<IWebDriver, bool> ProcessBarDisappears()
        {
            return delegate(IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.XPath(".//div[@id='divProcessBar']"));
                }
                catch (NoSuchElementException) { return true; }
                return !element.Displayed;
            };
        }
    }
}
