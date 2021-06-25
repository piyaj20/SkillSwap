using AventStack.ExtentReports;
using SkillSwap.Utilities;
using System;
using NUnit.Framework;
using SkillSwap.Pages;

namespace SkillSwap.Test
{
    [TestFixture]
    class SearchTest : CommonDriver
    {

        private CommonMethods commonMethods;

        public SearchTest()
        {
            commonMethods = new CommonMethods();
        }
        
        [Test]
        public void SearchSkillsByAllCategoriesTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SearchSkillsByAllCategories method is called");

                //Search Page Objects
                SearchPage searchPageObj = new SearchPage(driver);
                searchPageObj.SearchSkillsByAllCategories();

                test.Log(Status.Pass, "SearchSkill by AllCategories successfully");
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
        public void SearchSkillsByFilterTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SearchSkillsByFilter method is called");

                //Search Page Objects
                SearchPage searchPageObj = new SearchPage(driver);
                searchPageObj.SearchSkillsByFilters();

                test.Log(Status.Pass, "SearchSkill by Filter successfully");
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
