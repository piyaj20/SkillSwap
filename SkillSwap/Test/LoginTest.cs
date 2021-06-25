using AventStack.ExtentReports;
using SkillSwap.Utilities;
using System;
using NUnit.Framework;
using SkillSwap.Pages;


namespace SkillSwap.Test
{
    [TestFixture]
    class LoginTest : CommonDriver
    {

        private CommonMethods commonMethods;

        public LoginTest()
        {
            commonMethods = new CommonMethods();
        }


        [Test]
        public void SignUp()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "RegisterUser method is called");

                //Register page object

                Register registerObj = new Register(driver);
                registerObj.RegisterUser();

                test.Log(Status.Pass, "User Registered Successfully");
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
        public void Login()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Login method is called");


                //SignInPage objects
                LoginPage loginobj = new LoginPage(driver);
                loginobj.LoginSteps();

                test.Log(Status.Pass, "User login successful");
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
        public void ChangePassword()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "ChangePassword method is called");


                //SignInPage objects
                ChangePasswordPage changepasswordobj = new ChangePasswordPage(driver);
                changepasswordobj.ChangePassword();

                test.Log(Status.Pass, "Password changed successful");
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
