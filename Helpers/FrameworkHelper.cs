using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlertFrameworkPractice3.Helpers
{
    public enum IdentifierType
    {
        Id,
        Name,
        ClassName,
        LinkText,
        PartialLinkText,
        Tagname,
        CssSelector,
        XPath
    }
    public static class FrameworkHelper
    {
        //class member
        private static IWebDriver _webDriver;
        internal static WebDriverWait wait;
        internal static IJavaScriptExecutor javascriptExecutor;

        //Property
        public static IWebDriver WebDriver
        {
            get
            {
                return _webDriver;
            }
            set
            {
                _webDriver = value;
                javascriptExecutor = (IJavaScriptExecutor)value;
            }
        }

        public static IWebElement GetElement(string locator, IdentifierType identifierType)
        {
            IWebElement element = null;
            switch (identifierType)
            {
                case IdentifierType.Id:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
                    element = WebDriver.FindElement(By.Id(locator));
                    break;
                case IdentifierType.Name:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator)));
                    element = WebDriver.FindElement(By.Name(locator));
                    break;
                case IdentifierType.ClassName:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator)));
                    element = WebDriver.FindElement(By.ClassName(locator));
                    break;
                case IdentifierType.LinkText:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator)));
                    element = WebDriver.FindElement(By.LinkText(locator));
                    break;
                case IdentifierType.PartialLinkText:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator)));
                    element = WebDriver.FindElement(By.PartialLinkText(locator));
                    break;
                case IdentifierType.Tagname:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator)));
                    element = WebDriver.FindElement(By.TagName(locator));
                    break;
                case IdentifierType.CssSelector:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
                    element = WebDriver.FindElement(By.CssSelector(locator));
                    break;
                case IdentifierType.XPath:
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                    element = WebDriver.FindElement(By.XPath(locator));
                    break;
            }
            return element;
        }


        public static void SetText(string text, string locator, IdentifierType identifierType)
        {
            IWebElement element = GetElement(locator, identifierType);
            element.SendKeys(text);
        }

        public static void SetTextUsingJavaScriptExecutor(string text, IWebElement element)
        {
            javascriptExecutor.ExecuteScript("arguments[0].value='" + text + "'", element);
        }

        public static string GetText(string locator, IdentifierType identifierType)
        {
            IWebElement element = GetElement(locator, identifierType);
            return element.Text;
        }

        public static string GetTextUsingJavaScriptExecutor(IWebElement element)
        {
            return javascriptExecutor.ExecuteScript("return arguments[0].value=", element).ToString();

        }

        public static void ClickElement(string locator, IdentifierType identifierType)
        {
            IWebElement element = GetElement(locator, identifierType);
            element.Click();
        }
       
        public static void HandlePopUpAlert(bool ok = false)
        {
            if (ok)
            {
                FrameworkHelper.WebDriver.SwitchTo().Alert().Accept();
            }
            FrameworkHelper.WebDriver.SwitchTo().Alert().Dismiss();
        }

        public static string GetAlertText()
        {
            string alertText = FrameworkHelper.WebDriver.SwitchTo().Alert().Text;
            return alertText;
        }

        public static void SetAlertText(string text)
        {
            var alert = FrameworkHelper.WebDriver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
        }
    }
}



