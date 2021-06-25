using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System.Text;

namespace SkillSwap.Utilities
{
    public class CommonDriver
    {
        //intitialise driver
        public static IWebDriver driver;
        public static LoginPage LogIn;
        public static ExtentReports extent;
        public static ExtentHtmlReporter hTMLReporter;
        public static ExtentTest test;


        [OneTimeSetUp]
        public void Initialize()
        {
            hTMLReporter = new ExtentHtmlReporter(ConstantUtils.ReportsPath);
            hTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(hTMLReporter);

            //Defining the browser
            driver = new FirefoxDriver();

            //Maximise the window
            driver.Manage().Window.Maximize();

            NavigateUrl();

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



            //call the Login class
            //LogIn = new LoginPage(driver);
            //LogIn.LoginSteps();

        }

        public static string BaseUrl
        {
            get { return ConstantUtils.Url; }
        }


        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }


        [OneTimeTearDown]
        public void FinalSteps()
        {
            // close the driver
            driver.Close();
            driver.Quit();
            extent.Flush();
        }


    }
}