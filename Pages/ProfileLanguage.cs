using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;
using Microsoft.Office.Interop.Excel;

namespace SkillSwap.Pages
{
    class ProfileLanguage
    {
        private readonly IWebDriver driver;
        private LoginPage logIn;
        private ProfileDescription profileDescription;

        //Page Factory
        IWebElement AddNewLangBtn => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement AddLangText => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        IWebElement Languagedropdown => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]"));
        IWebElement LangLevel => driver.FindElement(By.XPath("//option[contains(text(),'Fluent')]"));
        IWebElement AddLang => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]"));
        IWebElement AddedLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement Message => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]"));
        
        IWebElement EditLangBtn => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[1]/i[1]"));
        IWebElement ClearLangText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
        IWebElement EditLangText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
        IWebElement UpdateLang => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]"));   
        IWebElement DeleteLang => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[2]/i[1]"));
        

        //Read Data from Excel
        private string language = ExcelLib.ReadData(1, "Language");
        private string validatelanguagemessage = ExcelLib.ReadData(1, "ValidateLanguageMessage");
        private string editlanguage = ExcelLib.ReadData(1, "EditLanguage");



        //Create a Constructor
        public ProfileLanguage(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        //adding language
        public void Language()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            ClickAddNewLanguage();
            EnterLanguage();
            ChooseLanguageLevel();
            ClickAdd();
            //bool isMessage = ValidateLanguageSavedMessage();
            //Assert.IsTrue(isMessage);
            ValidateLanguageSavedMessage();
            //bool isLanguage = ValidateAddedLanguage();
            //Assert.IsTrue(isLanguage);
            ValidateAddedLanguage();
            EditLanguage(editlanguage);
            //DeleteLanguage();
        }


        public void ClickAddNewLanguage()
        {
            //click add new for language
            AddNewLangBtn.Click();
        }

        public void EnterLanguage()
        {
            // enter language
            AddLangText.SendKeys(language);
        }

        public void ChooseLanguageLevel()
        {
            //choose language lavel
            Languagedropdown.Click();
            LangLevel.Click();
        }

        public void ClickAdd()
        {
            //click add for language
            AddLang.Click();
            Wait.ElementExists(driver, "XPath", "/html[1]/body[1]/div[1]/div[1]", 10);
            
        }

        public void ValidateLanguageSavedMessage()
        {
            /*
            if (Message.Text == validatelanguagemessage)
            {
                return true;
            }
            else
            {
                return false;
            }*/

            Assert.AreEqual(validatelanguagemessage, Message.Text);
        }

        public void ValidateAddedLanguage()
        {

            //validate language is added
            /*
            if (AddedLanguage.Text == language)
            {
                //Console.WriteLine("Language is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Language is not added, test failed");
                return false;
            }*/

            Assert.AreEqual(language, AddedLanguage.Text);
        }


        public void EditLanguage(string editlanguage)
        {
            //Edit Language Button
            EditLangBtn.Click();

            //Edit Language
            ClearLangText.Clear();
            EditLangText.SendKeys(editlanguage);

            //Click Add
            UpdateLang.Click();

        }

        public void DeleteLanguage()
        {
            
            //Delete Language            
            DeleteLang.Click();

        }
    }
}
