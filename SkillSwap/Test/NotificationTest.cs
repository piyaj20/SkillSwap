using AventStack.ExtentReports;
using SkillSwap.Utilities;
using System;
using NUnit.Framework;
using SkillSwap.Pages;

namespace SkillSwap.Test
{
    [TestFixture]
    class NotificationTest : CommonDriver
    {

        private CommonMethods commonMethods;

        public NotificationTest()
        {
            commonMethods = new CommonMethods();
        }


        [Test]
        public void NotificationFunction()
        {

            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Notification method is called");

                //Notification object

                NotificationPage notificationObj = new NotificationPage(driver);

                notificationObj.Notification();


                test.Log(Status.Pass, "Notification displayed successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }

    }
}
