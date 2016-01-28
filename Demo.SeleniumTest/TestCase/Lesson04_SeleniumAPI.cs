
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Demo.SeleniumTest
{
    public class Lesson04_SeleniumAPI
    {
        /// <summary>
        /// 输出对象
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 构造函数，初始化输出对象
        /// </summary>
        /// <param name="output">注入输出对象</param>
        public Lesson04_SeleniumAPI(ITestOutputHelper output)
        {
            this._output = output;
        }

        /// <summary>
        /// demo1 : 检查首页文本
        /// </summary>
        [Fact(DisplayName = "Cnblogs.SeleniumAPI.Demo1")]
        public void SeleniumAPI_Demo1()
        {
            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : 寻找需要检查的页面元素。");
            var lnkHome = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));
            var value = lnkHome.GetAttribute("class");
            lnkHome.GetCssValue("font-family");
            lnkHome.GetCssValue("color");
            
            _output.WriteLine(string.Format("导航内栏内容：{0}", lnkHome.Text));

            _output.WriteLine("Step 04 : 关闭浏览器。");
            driver.Close();
        }


        /// <summary>
        /// demo2 : 检查首页文本的属性，字体和颜色
        /// </summary>
        [Fact(DisplayName = "Cnblogs.SeleniumAPI.Demo2")]
        public void SeleniumAPI_Demo2()
        {
            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : 寻找需要检查的页面元素。");
            var lnkHome = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));
            
            lnkHome.GetCssValue("color");

            _output.WriteLine(string.Format("导航内栏内容：{0}", lnkHome.Text));
            _output.WriteLine(string.Format("classs属性内容：{0}", lnkHome.GetAttribute("class")));
            _output.WriteLine(string.Format("字体：{0}", lnkHome.GetCssValue("font-family")));
            _output.WriteLine(string.Format("颜色：{0}", lnkHome.GetCssValue("color")));

            _output.WriteLine("Step 04 : 关闭浏览器。");
            driver.Close();
        }

        /// <summary>
        /// demo3 : 首页查询
        /// </summary>
        [Fact(DisplayName = "Cnblogs.SeleniumAPI.Demo3")]
        public void SeleniumAPI_Demo3()
        {
            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : 寻找需要操作的页面元素。");
            var txtSearch = driver.FindElement(By.Id("zzk_q"));
            var btnSearch = driver.FindElement(By.XPath(".//input[@type='button' and @value='找找看']"));

            _output.WriteLine("Step 03 : 输入查询文本");
            txtSearch.SendKeys("小北De编程手记");

            _output.WriteLine("Step 04 : 点击查询");
            btnSearch.Click();

            System.Threading.Thread.Sleep(5000);

            _output.WriteLine("Step 05 : 关闭浏览器。");
            driver.Close();
        }
    }
}
