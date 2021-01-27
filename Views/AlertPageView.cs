using AlertFrameworkPractice3.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlertFrameworkPractice3.Views
{
    class AlertPageView
    {
        #region locators
        private string simpleAlertXPath = "//button[@onclick='myAlertFunction()']";
        private string confirmAlertXPath = "//button[@onclick='myConfirmFunction()']";
        private string errorMessageAfterClickingOkId = "confirm-demo";
        private string promptAlertXPath = "//button[@onclick='myPromptFunction()']";
        private string mesageAfterEnteringNameId = "prompt-demo";
        #endregion


        internal void ClickingonSimpleAlertBox()
        {
            FrameworkHelper.ClickElement(simpleAlertXPath, IdentifierType.XPath);
        }

        internal void ClickingonConfirmAlertBox()
        {
            FrameworkHelper.ClickElement(confirmAlertXPath, IdentifierType.XPath);
        }

        internal string GetErrorMessage()
        {
            var actualMessage = FrameworkHelper.GetText(errorMessageAfterClickingOkId, IdentifierType.Id);
            return actualMessage;
        }

        internal void ClickingonPromptAlertBox()
        {
            FrameworkHelper.ClickElement(promptAlertXPath, IdentifierType.XPath);
        }

        internal string GetPromptErrorMessage()
        {
            string text = FrameworkHelper.GetText(mesageAfterEnteringNameId, IdentifierType.Id);
            return text;
        }
    }
}
