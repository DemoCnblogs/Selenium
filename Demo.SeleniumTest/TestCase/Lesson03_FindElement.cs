using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Demo.SeleniumTest
{
    public class Lesson03_FindElement
    {
        /// <summary>
        /// 输出对象
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 构造函数，初始化输出对象
        /// </summary>
        /// <param name="output">注入输出对象</param>
        public Lesson03_FindElement(ITestOutputHelper output)
        {
            this._output = output;
        }

        /// <summary>
        /// demo1 : 获取元素
        /// </summary>
        [Fact(DisplayName = "Cnblogs.CheckNavBar.Demo1")]
        public void CheckNavBar_GetElement()
        {
            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : 寻找需要检查的页面元素。");
            var divMain = driver.FindElement(By.Id("main"));
            var lnkHome = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));
            var lnkEssence = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[2]/a"));
            var lnkCandidate = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[3]/a"));
            var lnkNews = driver.FindElement(By.XPath(".//ul[@class='post_nav_block']/li[4]/a"));

            _output.WriteLine("Step 03 : 检查导航条文字信息。");
            Assert.Equal<string>("首页", lnkHome.Text);
            Assert.Equal<string>("精华", lnkEssence.Text);
            Assert.Equal<string>("候选", lnkCandidate.Text);
            Assert.Equal<string>("新闻", lnkNews.Text);

            _output.WriteLine("Step 04 : 关闭浏览器。");
            driver.Close();
        }


        [Fact(DisplayName = "Cnblogs.CheckNavBar.Demo2")]
        public void CheckNavBar_GetElements()
        {
            _output.WriteLine("Step 00 : 准备测试数据。");
            var testDatas = new List<string>() { "首页", "精华", "候选", "新闻" };      //准备测试数据

            _output.WriteLine("Step 01 : 启动浏览器并打开博客园首页。");
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.cnblogs.com";

            _output.WriteLine("Step 02 : 寻找需要检查的页面元素。");
            var divMain = driver.FindElement(By.Id("main"));
            var lnkNavList = driver.FindElements(By.XPath(".//ul[@class='post_nav_block']/li[1]/a"));

            _output.WriteLine("Step 03 : 检查导航条文字信息。");
            for (var i = 0; i < lnkNavList.Count; i++)
            {
                Assert.Equal<string>(testDatas[i], lnkNavList[i].Text);
            }

            _output.WriteLine("Step 04 : 关闭浏览器。");
            driver.Close();
        }
    }
}
