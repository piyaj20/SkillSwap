using AventStack.ExtentReports;
using SkillSwap.Utilities;
using System;
using NUnit.Framework;
using SkillSwap.Pages;

namespace SkillSwap.Test
{
    [TestFixture]
    class ChatTest : CommonDriver
    {

        private CommonMethods commonMethods;

        public ChatTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        public void SendChatTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SendChat method is called");

                //Chat Page objects
                ChatPage chatPageObj = new ChatPage(driver);
                chatPageObj.ChatWithSeller();

                test.Log(Status.Pass, "Chat sent successfully");
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
