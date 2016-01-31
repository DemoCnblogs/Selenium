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

namespace Demo.SeleniumTest.TestCase
{
    public class Lesson07_WindowProcess
    {
        /// <summary>
        /// 输出对象
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 构造函数，初始化输出对象
        /// </summary>
        /// <param name="output">注入输出对象</param>
        public Lesson07_WindowProcess(ITestOutputHelper output)
        {
            this._output = output;
        }

        /// <summary>
        /// demo1 : 获取目标定位对象
        /// </summary>
        [Fact(DisplayName = "Cnblogs.WindowProcess.Demo1", Skip = "Just Demo")]
        public void WindowProcess_Demo1()
        {
            // 1. 获取窗口定位对象
            IWebDriver driver = new FirefoxDriver();
            //省略部分代码... ...
            ITargetLocator locator = driver.SwitchTo();
            driver = locator.Window("windowName");
            //后续操作... ...
            driver.Quit();
        }

        /// <summary>
        /// demo2 : 根据标题定位元素
        /// </summary>
        [Fact(DisplayName = "Cnblogs.WindowProcess.Demo2")]
        public void WindowProcess_Demo2()
        {
            var articleName = "[小北De编程手记] : Lesson 02 - Selenium For C# 之 核心对象";

            _output.WriteLine("Step 01 : 启动浏览器并打开Lesson 01 - Selenium For C#");
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.cnblogs.com/NorthAlan/p/5155915.html";

            _output.WriteLine("Step 02 : 点击链接打开新页面。");
            var lnkArticle02 = driver.FindElement(By.LinkText(articleName));
            lnkArticle02.Click();

            _output.WriteLine("Step 03 : 根据标题获取新页面的句柄。");
            var oldWinHandle = driver.CurrentWindowHandle;
            foreach (var winHandle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(winHandle);
                if (driver.Title.Contains(articleName))
                {
                   break;
                }
            }

            _output.WriteLine("Step 04 : 验证新页面标题是否正确。");
            var articleTitle = driver.FindElement(By.Id("cb_post_title_url"));
            Assert.Equal<string>(articleName, articleTitle.Text);

            _output.WriteLine("Step 05 : 关闭浏览器。");
            driver.Quit();

        }

        /// <summary>
        /// demo3 : 处理Alert
        /// </summary>
        [Fact(DisplayName = "Cnblogs.WindowProcess.Demo3", Skip = "Just Demo")]
        public void WindowProcess_Demo3()
        {
            
            IWebDriver driver = new FirefoxDriver();
            //省略部分代码... ...
            var oldWinHandle = driver.CurrentWindowHandle;
            ITargetLocator locator = driver.SwitchTo();
            IAlert winAlert = locator.Alert();
            winAlert.Accept();                             //确定：Alert , Confirm, Prompt
            winAlert.Dismiss();                            //取消：Confirm, Prompt
            var text = winAlert.Text;                      //获取提示内容：Alert , Confirm, Prompt
            winAlert.SendKeys("input text.");             //输入提示文本：Prompt

            //后续操作... ...
            driver.Quit();

        }
    }
}
