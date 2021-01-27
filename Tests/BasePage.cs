using AlertFrameworkPractice3.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlertFrameworkPractice3.Tests
{
    public class BasePage
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void BeforeTest()
        {
            //FrameworkHelper.WebDriver = new ChromeDriver(@"D:\Drivers\chrome\chromedriver_win32");
            string path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\Driver\");
            FrameworkHelper.WebDriver = new ChromeDriver(path);
            FrameworkHelper.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            FrameworkHelper.WebDriver.Manage().Window.Maximize();
            FrameworkHelper.wait = new WebDriverWait(FrameworkHelper.WebDriver, TimeSpan.FromSeconds(30));
            NavigateToURL();
        }

        internal void NavigateToURL()
        {
            FrameworkHelper.WebDriver.Url = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        }

        [TearDown]
        public void AfterTest()
        {
            //FrameworkHelper.WebDriver.Quit();
            Console.WriteLine("life is beautiful");
        }
    }
}


