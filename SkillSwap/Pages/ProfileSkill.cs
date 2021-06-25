using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;

namespace SkillSwap.Pages
{
    class ProfileSkill
    {
        private readonly IWebDriver driver;
        private LoginPage logIn;
        private ProfileDescription profileDescription;

        //Page Factory design
        IWebElement AddNew => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement Add => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        IWebElement Skill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        IWebElement SkillLevel => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));
        
        IWebElement AddedSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));
        IWebElement EditSkillBtn => driver.FindElement(By.XPath("//tbody/tr[1]/td[3]/span[1]/i[1]"));
        IWebElement ClearSkillText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
        IWebElement EditSkillText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]/html/body/div[1]/div"));
        IWebElement UpdateSkill => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]"));
        IWebElement DeleteSkill => driver.FindElement(By.XPath("//tbody/tr[1]/td[3]/span[2]/i[1]"));


        //Read data from Excel
        private string skill = ExcelLib.ReadData(1, "Skill");
        private string skillmessage = ExcelLib.ReadData(1, "SkillMessage");
        private string editskill = ExcelLib.ReadData(1, "EditSkill");


        //Create a Constructor
        public ProfileSkill(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        // adding a skill
        public void Skills()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            ClickSkillsTab();
            ClickAddNew();
            EnterSkill(skill);
            ChooseSkillLevel();
            ClickAdd();
            bool isMessage = ValidateSkillSavedMessage(skillmessage);
            Assert.IsTrue(isMessage);
            bool isSkill = ValidateAddedSkill(skill);
            Assert.IsTrue(isSkill);
            //EditSkill(editskill);
            DeleteNewSkill();
        }


        public void ClickSkillsTab()
        {
            //click skills tab
            SkillsTab.Click();            
        }

        public void ClickAddNew()
        {
            //click add new for skill
            AddNew.Click();
        }

        public void ClickAdd()
        {
            //click add for skill
            Add.Click();
        }


        public void EnterSkill(string skill)
        {
            //enter skill
            Skill.SendKeys(skill);
        }

        public void ChooseSkillLevel()
        {
            //choose skill level
            SkillLevel.Click();

        }

        public bool ValidateSkillSavedMessage(string skillmessage)
        {
            
            if (Message.Text == skillmessage)
            {
                //Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }
        }

        public bool ValidateAddedSkill(string skill)
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //validate skill is added
            if (AddedSkill.Text == skill)
            {
                //Console.WriteLine("Skill is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Skill is not added, test failed");
                return false;
            }
        }


        public void EditSkill(string editskill)
        {
            
            //Edit Skill Button
            EditSkillBtn.Click();

            //Edit Skill
            ClearSkillText.Clear();
            EditSkillText.SendKeys(editskill);

            //Click Update Skill
            UpdateSkill.Click();

        }

        public void DeleteNewSkill()
        {
           
            //Delete Skill            
            DeleteSkill.Click();

        }

    }
}
