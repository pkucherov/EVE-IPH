using System;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour.My
{

    // The following events are available for MyApplication:
    // 
    // Startup: Raised when the application starts, before the startup form is created.
    // Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    // UnhandledException: Raised if the application encounters an unhandled exception.
    // StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    // NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    internal partial class MyApplication
    {

        private void MyApplication_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
        {

            if (!string.IsNullOrEmpty(Public_Variables.ErrorTracker))
            {
                Public_Variables.WriteMsgToLog(e.Exception.ToString() + Constants.vbCrLf + "Error Tracking: " + Public_Variables.ErrorTracker);
            }
            else
            {
                Public_Variables.WriteMsgToLog(e.Exception.ToString());
            }

            var f2 = new frmError();
            Public_Variables.frmErrorText = "An Unhandled Exception has occured and EVE Isk per Hour will now close.";
            Public_Variables.frmErrorText += Environment.NewLine + "This error occured in EVE IPH Version: " + MyProject.Application.Info.Version.ToString();
            Public_Variables.frmErrorText += Environment.NewLine + Environment.NewLine + "Please fill out the following information so I can reproduce the bug";
            Public_Variables.frmErrorText += Environment.NewLine + Environment.NewLine + "What is your Operating System? ";
            Public_Variables.frmErrorText += Environment.NewLine + "What tab or screen did the error occur? ";
            Public_Variables.frmErrorText += Environment.NewLine + "What are the steps to reproduce the Error? ";
            Public_Variables.frmErrorText += Environment.NewLine + "Web link to a screenshot of your error: ";
            Public_Variables.frmErrorText += Environment.NewLine + "In addition to a screenshot, copy the data below and send to developer.";
            Public_Variables.frmErrorText += Environment.NewLine + Environment.NewLine + "Source: " + e.Exception.Source;
            Public_Variables.frmErrorText += Environment.NewLine + "Message: " + e.Exception.Message + Constants.vbCrLf;
            Public_Variables.frmErrorText += "Raw Error Text: " + e.Exception.ToString() + Constants.vbCrLf;
            if (!string.IsNullOrEmpty(Public_Variables.ErrorTracker))
            {
                Public_Variables.frmErrorText += "Error Tracking: " + Public_Variables.ErrorTracker;
            }

            f2.ShowDialog();

        }
    }

}