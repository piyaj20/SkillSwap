using AventStack.ExtentReports;
using SkillSwap.Utilities;
using System;
using NUnit.Framework;
using SkillSwap.Pages;


namespace SkillSwap.Test
{
    [TestFixture]
    class ShareSkillTest : CommonDriver

    {

        /* static void Main(string[] args)
         {

         }   
        */

        private CommonMethods commonMethods;

        public ShareSkillTest()
        {
            commonMethods = new CommonMethods();
        }            
              
        
                         
        [Test]
        public void AddShareSkill()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "AddShareSkill method is called");

                //Share Skill page object

                ShareSkillPage shareskillObj = new ShareSkillPage(driver);
                shareskillObj.createShareSkill();

                test.Log(Status.Pass, "Share Skill added successfully");
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
        public void EditShareSkill()
        {

            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EditShareSkill method is called");

                //Manage Listings object

                NavigateToManageListingPage managelistingsObj = new NavigateToManageListingPage(driver);

                managelistingsObj.ClickManageListings(driver);


                //Edit Share Skill object

                ShareSkillPage shareskillObj = new ShareSkillPage(driver);

                shareskillObj.EditShareSkill(driver);

                test.Log(Status.Pass, "ShareSkill updated successfully");
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
        public void DeleteShareSkill()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeleteShareSkill method is called");

                //Manage Listings object

                NavigateToManageListingPage managelistingsObj = new NavigateToManageListingPage(driver);

                managelistingsObj.ClickManageListings(driver);


                //Delete Share Skill object

                ShareSkillPage shareskillObj = new ShareSkillPage(driver);

                shareskillObj.DeleteShareSkill(driver);

                test.Log(Status.Pass, "ShareSkill deleted successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }


        /*
        [Test]
        public void NavigateToManageListings()
        {

            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "NavigateToManageListings method is called");

                //Manage Listings object

                NavigateToManageListingPage managelistingsObj = new NavigateToManageListingPage();

                managelistingsObj.ClickManageListings(driver);

                test.Log(Status.Pass, "At Manage Listings Page");
                test.Pass("Test Passed");

            }

            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }*/     
    }
}





