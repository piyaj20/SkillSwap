using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SkillSwap.Utilities;
using System;
using static SkillSwap.Utilities.CommonMethods;

namespace SkillSwap.Pages
{

    public class LoginPage
    {
        private readonly IWebDriver driver;


        //Page Factory design
        IWebElement SignIn => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
        IWebElement EmailAddress => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        IWebElement Password => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        IWebElement LoginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]"));
        IWebElement SignOut => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button"));

        //Read Excel value
        private string emailAddress = ExcelLib.ReadData(1, "EmailAddress");
        private string password = ExcelLib.ReadData(1, "Password");


        //Create a Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoginSteps()
        {
            ClickSignIn();
            EnterEmailandPassword();
            ClickLogin();
            //bool isLoggedIn = ValidateLoggedInSuccessfully();
            //Assert.IsTrue(isLoggedIn);
        }

        public void ClickSignIn()
        {
            //click sign in 
            SignIn.Click();
        }

        public bool ValidateYouAreAtLoginPage()
        {
            return LoginButton.Displayed;

        }

        public void EnterEmailandPassword()
        {
            
            try
            {

                //Enter email address
                EmailAddress.SendKeys(emailAddress);

                //Enter password
                Password.SendKeys(password);                

            }

            catch (Exception msg)
            {
                Assert.Fail("Test Failed at Login Page", msg.Message);
            }
        }

        public void ClickLogin()
        {
            //Click Login
            LoginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public bool ValidateLoggedInSuccessfully()
        {
            return SignOut.Displayed;
        }
    }
}
