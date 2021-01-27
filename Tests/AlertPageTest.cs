using AlertFrameworkPractice3.Helpers;
using AlertFrameworkPractice3.Views;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlertFrameworkPractice3.Tests
{
    class AlertPageTest : BasePage
    {
        [Test]
        public void VerifyAlertPageViewTest()
        { 
            AlertPageView alertPageView = new AlertPageView();
            alertPageView.ClickingonSimpleAlertBox();
            Thread.Sleep(2000);
            Assert.AreEqual("I am an alert box!", FrameworkHelper.GetAlertText());
            FrameworkHelper.HandlePopUpAlert();
            Thread.Sleep(2000);

            alertPageView.ClickingonConfirmAlertBox();
            Thread.Sleep(2000);
            Assert.AreEqual("Press a button!", FrameworkHelper.GetAlertText());
            FrameworkHelper.HandlePopUpAlert();
            Thread.Sleep(2000);
            string actualMessage = alertPageView.GetErrorMessage();
            Assert.AreEqual("You pressed Cancel!", alertPageView.GetErrorMessage());
            Console.WriteLine(alertPageView.GetErrorMessage());

            alertPageView.ClickingonPromptAlertBox();
            Thread.Sleep(2000);
            FrameworkHelper.SetAlertText("Asim");
            Thread.Sleep(2000);
            Assert.AreEqual("You have entered 'Asim' !", alertPageView.GetPromptErrorMessage());
        }
    }
}
