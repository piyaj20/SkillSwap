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
        //initialise driver
        public static IWebDriver driver;        

        public void Initialize()
        {
           
            //Defining the browser
            driver = new FirefoxDriver();

            //Maximise the window
            driver.Manage().Window.Maximize();

            NavigateUrl();
           
        }

        public static string BaseUrl
        {
            get { return ConstantUtils.Url; }
        }


        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }


        public void FinalSteps()
        {
            // close the driver
            driver.Close();
            driver.Quit();
        }

    }
}