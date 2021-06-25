using AventStack.ExtentReports;
using SkillSwap.Utilities;
using System;
using NUnit.Framework;
using SkillSwap.Pages;


namespace SkillSwap.Test
{
    [TestFixture]
    class ProfileTest : CommonDriver
    {

        private CommonMethods commonMethods;

        public ProfileTest()
        {
            commonMethods = new CommonMethods();
        }


        [Test]
        public void AvailabilityTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Availability method is called");

                //Profile Page object

                ProfilePage profileObj = new ProfilePage(driver);
                profileObj.Availability();

                test.Log(Status.Pass, "Availability updated successfully");
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
        public void HoursTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Hours method is called");

                //Profile Page object

                ProfilePage profileObj = new ProfilePage(driver);
                profileObj.Hours();

                test.Log(Status.Pass, "Hours updated successfully");
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
        public void EarnTargetTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EarnTarget method is called");

                //Profile Page object

                ProfilePage profileObj = new ProfilePage(driver);
                profileObj.EarnTarget();

                test.Log(Status.Pass, "EarnTarget updated successfully");
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
        public void ProfileDescriptionTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "ProfileDescription method is called");

                //Profile Description object

                ProfileDescription profileDescriptionObj = new ProfileDescription(driver);
                profileDescriptionObj.Description();

                test.Log(Status.Pass, "ProfileDescription updated successfully");
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
        public void LanguageTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Language method is called");

                //Language Test object

                ProfileLanguage profileLanguageObj = new ProfileLanguage(driver);
                profileLanguageObj.Language();

                test.Log(Status.Pass, "Language added successfully");
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
        public void SkillTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Skill method is called");

                //SkillTest object

                ProfileSkill profileSkillObj = new ProfileSkill(driver);
                profileSkillObj.Skills();

                test.Log(Status.Pass, "Skill added successfully");
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
        public void EducationTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Education method is called");

                //EducationTest object

                ProfileEducation profileEducationObj = new ProfileEducation(driver);
                profileEducationObj.Education();

                test.Log(Status.Pass, "Education added successfully");
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
        public void CertificationTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Certification method is called");

                //CertificationTest object

                ProfileCertification profileCertificationObj = new ProfileCertification(driver);
                profileCertificationObj.Certification();

                test.Log(Status.Pass, "Certification added successfully");
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
