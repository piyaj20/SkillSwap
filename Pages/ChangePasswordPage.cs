using NUnit.Framework;
using OpenQA.Selenium;
using SkillSwap.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkillSwap.Utilities.CommonMethods;

namespace SkillSwap.Pages
{
    class ChangePasswordPage
    {
        private readonly IWebDriver driver;
        private LoginPage LogIn;

        //page factory design pattern
        IWebElement ProfileName => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]"));
        IWebElement ChangePass => driver.FindElement(By.XPath("//a[contains(text(),'Change Password')]"));
        IWebElement CurrentPass => driver.FindElement(By.XPath("//body/div[4]/div[1]/div[2]/form[1]/div[1]/input[1]"));
        IWebElement NewPass => driver.FindElement(By.XPath("//body/div[4]/div[1]/div[2]/form[1]/div[2]/input[1]"));
        IWebElement ConfirmPass => driver.FindElement(By.XPath("//body/div[4]/div[1]/div[2]/form[1]/div[3]/input[1]"));
        IWebElement SavePassword => driver.FindElement(By.XPath("//body/div[4]/div[1]/div[2]/form[1]/div[4]/button[1]"));
       


        //Read Data from Excel
        private string currentpassword = ExcelLib.ReadData(1, "CurrentPassword");
        private string newpassword = ExcelLib.ReadData(1, "NewPassword");
        private string confirmpassword = ExcelLib.ReadData(1, "ConfirmPassword");


        //Create a Constructor
        public ChangePasswordPage(IWebDriver driver)
        {
            this.driver = driver;
            LogIn = new LoginPage(driver);
        }

        public void ChangePassword()
        {
            LogIn.LoginSteps();
            ClickChangePassword();
            EnterPasswordDetails(currentpassword, newpassword, confirmpassword);
            ClickSavePassword();

        }


        public void ClickChangePassword()
        {

            Wait.ElementExists(driver, "XPath", "//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]", 5);


            ProfileName.Click();

            ChangePass.Click();

        }

        public void EnterPasswordDetails(string currentpassword, string newpassword, string confirmpassword)
        {
            try
            {

                CurrentPass.SendKeys(currentpassword);

                NewPass.SendKeys(newpassword);

                ConfirmPass.SendKeys(confirmpassword);
            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed at ChangePassword page", msg.Message);
            }

        }

        public void ClickSavePassword()
        {
            SavePassword.Click();
        }
        
    }
}
