using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;

namespace SkillSwap.Pages
{
    class ProfilePage
    {

        private readonly IWebDriver driver;
        private LoginPage logIn;
        private ProfileDescription profileDescription;

        //Page Factory design

        IWebElement AvailabilityIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
        IWebElement PartTime => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]"));
        IWebElement FullTime => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]"));
        IWebElement HoursIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        IWebElement LessThan30Hours => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[2]"));
        IWebElement MoreThan30Hours => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[3]"));
        IWebElement AsNeeded => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[4]"));
        IWebElement EarnTargetIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        IWebElement LessThan500 => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[2]"));
        IWebElement Between500And1000 => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[3]"));
        IWebElement MoreThan1000 => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[4]"));
        IWebElement Message => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]"));

        //Read from Excel
        private string availability = ExcelLib.ReadData(1, "Availability");
        private string hours = ExcelLib.ReadData(1, "Hours");
        private string earntarget = ExcelLib.ReadData(1, "EarnTarget");
        private string availabilitymessage = ExcelLib.ReadData(1, "AvailabilityMessage");
        private string hoursmessage = ExcelLib.ReadData(1, "HoursMessage");
        private string earntargetmessage = ExcelLib.ReadData(1, "EarnTargetMessage");



        //Create a Constructor
        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        //selecting availability
        public void Availability()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            ClickAvailability();
            SelectAvailability();
            //bool isAvailability = ValidateSuccessMessage(availabilitymessage);
            //Assert.IsTrue(isAvailability);
            ValidateSuccessMessage();
        }

        //selecting hours
        public void Hours()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            ClickHours();
            SelectHours();
            //bool isHours = ValidateSuccessMessage(hoursmessage);
            //Assert.IsTrue(isHours);
        }

        //selecting earn target
        public void EarnTarget()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            ClickEarnTarget();
            SelectEarnTarget();
            //bool isEarnTarget = ValidateSuccessMessage(earntargetmessage);
            //Assert.IsTrue(isEarnTarget);
        }

        public void ClickAvailability()
        {
            //click availability icon
            AvailabilityIcon.Click();
        }

        public void SelectAvailability()
        {
            if (availability == "Part Time")
            {
                PartTime.Click();
            }
            else
            {
                FullTime.Click();
            }
        }

        public void ClickHours()
        {
            // click hours icon
            HoursIcon.Click();
        }

        public void SelectHours()
        {
            switch (hours)
            {
                case "Less than 30hours a week":

                    LessThan30Hours.Click();
                    break;

                case "More than 30hours a week":

                    MoreThan30Hours.Click();
                    break;

                default:

                    AsNeeded.Click();
                    break;
            }

        }

        public void ClickEarnTarget()
        {
            //click earn target
            EarnTargetIcon.Click();
        }

        public void SelectEarnTarget()
        {
            switch (earntarget)
            {
                case "Less than $500 per month":

                    LessThan500.Click();
                    break;

                case "Between $500 and $1000 per month":

                    Between500And1000.Click();
                    break;

                default:

                    MoreThan1000.Click();
                    break;
            }
        }

        public void ValidateSuccessMessage()

        {
            //validate updation message
            /*
            if (Message.Text == message)
            {

                return true;
            }
            else
            {

                return false;
            }*/

             Assert.AreEqual(availabilitymessage, Message.Text);

        }

    }
}

