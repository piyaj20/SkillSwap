using AventStack.ExtentReports;
using SkillSwap.Utilities;
using System;
using NUnit.Framework;
using SkillSwap.Pages;

namespace SkillSwap.Test
{
    [TestFixture]
    class ManageRequestTest : CommonDriver
    {

        private CommonMethods commonMethods;

        public ManageRequestTest()
        {
            commonMethods = new CommonMethods();
        }


        [Test]
        public void AcceptRequestTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "AcceptRequest method is called");

                //Manage Requests Page Objects
                ManageRequestsPage manageRequestObj = new ManageRequestsPage(driver);
                manageRequestObj.AcceptReceivedRequest();

                test.Log(Status.Pass, "Received Request Accepted");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }


        [Test]
        public void DeclineRequest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeclineRequest method is called");

                //Manage Requests Page Objects
                ManageRequestsPage manageRequestObj = new ManageRequestsPage(driver);
                manageRequestObj.DeclineReceivedRequest();

                test.Log(Status.Pass, "Received Request Declined");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }


        [Test]
        public void WithdrawSentRequest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "WithdrawSentRequest method is called");

                //Manage Requests Page Objects
                ManageRequestsPage manageRequestObj = new ManageRequestsPage(driver);
                manageRequestObj.WithdrawSentRequest();

                test.Log(Status.Pass, "Sent Request Withdrawn");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }


        [Test]
        public void CompleteSentRequest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "CompleteSentRequest method is called");

                //Register page object

                //Manage Requests Page Objects
                ManageRequestsPage manageRequestObj = new ManageRequestsPage(driver);
                manageRequestObj.CompleteSentRequest();

                test.Log(Status.Pass, "Sent Request Completed");
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
