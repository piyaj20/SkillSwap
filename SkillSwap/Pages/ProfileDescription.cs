using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;

namespace SkillSwap.Pages
{
    class ProfileDescription
    {
        private readonly IWebDriver driver;
        private LoginPage logIn;

        //Page Factory
        IWebElement DescriptionText => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3"));
        IWebElement DescriptionIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        IWebElement DescriptionTextBox => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        IWebElement Save => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
        IWebElement SavedDescription => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        //Read Data from Excel
        private string profiledescription = ExcelLib.ReadData(1, "ProfileDescription");
        private string descriptionmessage = ExcelLib.ReadData(1, "DescriptionMessage");


        //Create a Constructor
        public ProfileDescription(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
        }

        //adding profile description
        public void Description()
        {
            logIn.LoginSteps();
            ValidateProfilePage();
            ClickDescriptionIcon();
            EnterDescription(profiledescription);
            ClickSave();
            bool isMessage = ValidateDescriptionSavedMessage(descriptionmessage);
            Assert.IsTrue(isMessage);
            bool isDescription = ValidateSavedDescription(profiledescription);
            Assert.IsTrue(isDescription);
        }

        public void ValidateProfilePage()
        {
            bool isProfilePage = DescriptionText.Displayed;
            Assert.IsTrue(isProfilePage);
        }

        public void ClickDescriptionIcon()
        {
            //click description icon
            DescriptionIcon.Click();
        }

        public void EnterDescription(string profiledescription)
        {
            //enter description
            DescriptionTextBox.Clear();
            DescriptionTextBox.SendKeys(profiledescription);
        }

        public void ClickSave()
        {
            //click save
            Save.Click();

        }

        public bool ValidateDescriptionSavedMessage(string descriptionmessage)
        {
            
            if (Message.Text == descriptionmessage)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        public bool ValidateSavedDescription(string profiledescription)
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 500);

            //validate description is saved
            if (SavedDescription.Text == profiledescription)
            {
                //Console.WriteLine("Description is saved, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Description is not saved, test failed");
                return false;
            }
        }
    }
}
