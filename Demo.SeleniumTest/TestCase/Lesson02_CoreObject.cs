using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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

            _output.WriteLine("Step 02 : 获取并输出部分页面信息。");
            _output.WriteLine(string.Format("Current window handle: {0}", driver.CurrentWindowHandle));
            _output.WriteLine(string.Format("Window handle count: {0}", driver.WindowHandles.Count));
            _output.WriteLine(string.Format("Current window title: {0}", driver.Title));

            _output.WriteLine("Step 03 : 验证博客园站点的 Title 是否正确。");
            Assert.Equal<string>("博客园 - 开发者的网上家园", driver.Title);

            _output.WriteLine("Step 04 : 关闭当前页面。");
            driver.Close();
        }
    }
}
