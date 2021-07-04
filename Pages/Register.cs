
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;

namespace SkillSwap.Pages
{
    class Register
    {
        private readonly IWebDriver driver;

        //Page Factory
        IWebElement Join => driver.FindElement(By.XPath("//button[contains(text(),'Join')]"));
        IWebElement FirstName => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[1]/input[1]"));
        IWebElement LastName => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[2]/input[1]"));
        IWebElement RegisterEmail => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[3]/input[1]"));
        IWebElement RegisterPassword => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[4]/input[1]"));
        IWebElement ConfirmRegisterPassword => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[5]/input[1]"));
        IWebElement AgreeTerms => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[6]/div[1]/div[1]/input[1]"));
        IWebElement JoinButton => driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));


        //Read Data from Excel
        private string firstName = ExcelLib.ReadData(1, "FirstName");
        private string lastName = ExcelLib.ReadData(1, "LastName");
        private string email = ExcelLib.ReadData(1, "Email");
        private string userpassword = ExcelLib.ReadData(1, "UserPassword");
        private string confirmregPassword = ExcelLib.ReadData(1, "ConfirmRegPassword");
        private string successmessage = ExcelLib.ReadData(1, "RegistrationMessage");

        public Register(IWebDriver driver)
        {

            this.driver = driver;
        }

        public void RegisterUser()
        {
            ClickJoin();
            ValidateYouAreAtRegistrationPage();
            JoinUser();
            ClickAgreeTermsAndConditions();
            ClickJoinButton();
            ValidateSuccessMessage();

        }

        public void ClickJoin()
        {
            //click Join/Register
            Join.Click();
        }

        public bool ValidateYouAreAtRegistrationPage()
        {
            return JoinButton.Displayed;

        }
        public void JoinUser()
        {

            //Enter details
            FirstName.SendKeys(firstName);


            LastName.SendKeys(lastName);


            RegisterEmail.SendKeys(email);


            RegisterPassword.SendKeys(userpassword);


            ConfirmRegisterPassword.SendKeys(confirmregPassword);

        }

        public void ClickAgreeTermsAndConditions()
        {
            //Click on AgreeTermsAndConditions
            AgreeTerms.Click();

        }

        public void ClickJoinButton()
        {
            //Click Join button
            JoinButton.Click();

        }

        public void ValidateSuccessMessage()
        {
            // validate registration message
            /*
            if (Message.Text == successmessage)
            {
                return true;
            }
            else
            {
                return false;
            }*/

            Assert.AreEqual(successmessage, Message.Text);
        }

    }
}

    

