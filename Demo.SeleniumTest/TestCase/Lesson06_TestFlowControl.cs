using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.SeleniumTest
{
    public class Lesson06_TestFlowControl
    {
        /// <summary>
        /// 输出对象
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 构造函数，初始化输出对象
        /// </summary>
        /// <param name="output">注入输出对象</param>
        public Lesson06_TestFlowControl(ITestOutputHelper output)
        {
            this._output = output;
        }

        /// <summary>
        /// demo1 : 设置隐式等待同步策略
        /// </summary>
        [Fact(DisplayName = "Cnblogs.TestFlowControl.Demo1")]
        public void TestFlowControl_Demo1()
        {
            IWebDriver driver = new FirefoxDriver();   
            // 1. 隐式的等待 同步测试
            driver.Manage().Timeouts()
                .ImplicitlyWait(TimeSpan.FromSeconds(10))
                .SetPageLoadTimeout(TimeSpan.FromSeconds(10))
                .SetScriptTimeout(TimeSpan.FromSeconds(10));

            driver.Close();
        }


        /// <summary>
        /// demo2 :设置显示等待同步策略
        /// </summary>
        [Fact(DisplayName = "Cnblogs.TestFlowControl.Demo2")]
        public void TestFlowControl_Demo2()
        {
            IWebDriver driver = new FirefoxDriver();   
            //省略操作代码....
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("Object ID")));
        }

        /// <summary>
        /// demo3 : 扩展等待
        /// </summary>
        [Fact(DisplayName = "Cnblogs.TestFlowControl.Demo3")]
        public void TestFlowControl_Demo3()
        {
            IWebDriver driver = new FirefoxDriver();
            //省略操作代码....
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until<bool>(
                delegate(IWebDriver dir)
                {
                    var element = dir.FindElement(By.XPath(".//div[@id='divProcessBar']"));
                    return !element.Displayed;
                }
            );
        }

        /// <summary>
        /// demo4 : 扩展等待 升级版
        /// </summary>
        [Fact(DisplayName = "Cnblogs.TestFlowControl.Demo4")]
        public void TestFlowControl_Demo4()
        {
            IWebDriver driver = new FirefoxDriver();
            //省略操作代码....
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditionsExtension.ProcessBarDisappears());
        }
    }
}
