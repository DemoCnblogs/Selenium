using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.SeleniumTest
{
    public class Lesson02_CoreObject
    {
        /// <summary>
        /// 输出对象
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 构造函数，初始化输出对象
        /// </summary>
        /// <param name="output">注入输出对象</param>
        public Lesson02_CoreObject(ITestOutputHelper output)
        {
            this._output = output;
        }

        /// <summary>
        /// demo1 : 获取元素
        /// </summary>
        [Fact(DisplayName = "Cnblogs.CoreObject.Demo1")]
        public void CoreObject_Demo1()
        {
            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.cnblogs.com";
            driver.Manage().Window.Maximize();
            var title = driver.Title;
            var currentWinHandle = driver.CurrentWindowHandle;
            var winHandles = driver.WindowHandles;
            var pageSource = driver.PageSource;

            driver.Close();
        }
    }
}
