using System;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using SkillSwap.Utilities;
using static SkillSwap.Utilities.CommonMethods;


namespace SkillSwap.Hooks
{
    [Binding]
    public class GeneralHooks: CommonDriver
    {
        private static ScenarioContext scenarioContextObject;
        private static ExtentReports extent;
        private static ExtentHtmlReporter hTMLReporter;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private CommonMethods commonMethods;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            hTMLReporter = new ExtentHtmlReporter(ConstantUtils.ReportsPath);
            hTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(hTMLReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {

            if (null != featureContext)
            {
                featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                scenarioContextObject = scenarioContext;

                scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "Register");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "SignIn");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "ProfilePage");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "AddSkill");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "ManageListings");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "Notification");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "SearchSkill");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "ServiceDetail");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "Chat");
            ExcelLib.PopulateInCollection(ConstantUtils.DataFilePath, "ManageRequests");

            //launch the browser
            Initialize();

            NavigateUrl();
        }


        [AfterStep]
        public void AfterStep()
        {
            //Screenshot in Base64 format
            ScenarioBlock currentScenarioBlock = scenarioContextObject.CurrentScenarioBlock;
            commonMethods = new CommonMethods();
            var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(scenarioContextObject.ScenarioInfo.Title.Trim());
            switch (currentScenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<Given>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace, mediaEntity);


                    }
                    else
                    {
                        scenario.CreateNode<Given>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");
                        
                    }
                    break;

                case ScenarioBlock.When:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<When>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace, mediaEntity);

                    }
                    else
                    {
                        scenario.CreateNode<When>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;

                case ScenarioBlock.Then:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<Then>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace, mediaEntity);

                    }
                    else
                    {
                        scenario.CreateNode<Then>(scenarioContextObject.StepContext.StepInfo.Text).Pass("Test Passed", mediaEntity);

                    }
                    break;

                default:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<And>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace, mediaEntity);

                    }
                    else
                    {
                        scenario.CreateNode<And>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");
                    }
                    break;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {

            // close the browser
            FinalSteps();

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

    }
}