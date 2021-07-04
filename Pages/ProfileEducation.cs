using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;

namespace SkillSwap.Pages
{
    class ProfileEducation
    {
        private readonly IWebDriver driver;
        private LoginPage logIn;
        private ProfileDescription profileDescription;


        //page factory design pattern
        IWebElement AddNew => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        IWebElement College => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        IWebElement Country => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[11]"));
        IWebElement Title => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[8]"));
        IWebElement Degree => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        IWebElement Year => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[8]"));
        IWebElement Add => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        IWebElement AddedDegree => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]"));
        IWebElement Message => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]"));
        IWebElement EducationTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        IWebElement EditEducationBtn => driver.FindElement(By.XPath("//tbody/tr[1]/td[6]/span[1]/i[1]"));
        IWebElement ClearUniversityText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
        IWebElement EditUniversityText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
        IWebElement UpdateEducation => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[3]/input[1]"));
        IWebElement DeleteEducation => driver.FindElement(By.XPath("//tbody/tr[1]/td[6]/span[2]/i[1]"));



        //Read data from Excel
        private string university = ExcelLib.ReadData(1, "University");
        private string degree = ExcelLib.ReadData(1, "Degree");
        private string educationmessage = ExcelLib.ReadData(1, "EducationMessage");
        private string edituniversity = ExcelLib.ReadData(1, "EditUniversity");


        //Create a Constructor
        public ProfileEducation(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        //adding education details
        public void Education()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            ClickEducationTab();
            ClickAddNew();
            EnterCollege();
            SelectCountry();
            SelectTitle();
            EnterDegree();
            SelectYear();
            ClickAdd();
            //bool isMessage = ValidateEducationSavedMessage(educationmessage);
            //Assert.IsTrue(isMessage);
            ValidateEducationSavedMessage();
            //bool isEducation = ValidateAddedEducation();
            //Assert.IsTrue(isEducation);
            ValidateAddedEducation();
            EditEducation(edituniversity);
            DeleteNewEducation();
        }

        public void ClickEducationTab()
        {
            //click Education Tab
            EducationTab.Click();
        }

        public void ClickAddNew()
        {
            //click add new 
            AddNew.Click();
        }

        public void EnterCollege()
        {
            // enter College
            College.SendKeys(university);
        }

        public void EnterDegree()
        {
            // enter Degree
            Degree.SendKeys(degree);
        }

        public void SelectCountry()
        {
            //select country
            Country.Click();
        }

        public void SelectTitle()
        {
            //select title
            Title.Click();
        }

        public void SelectYear()
        {
            //select year
            Year.Click();
        }

        public void ClickAdd()
        {
            //click add 
            Add.Click();
        }

        public void ValidateEducationSavedMessage()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 30);
            /*
            if (Message.Text == educationmessage)
            {
                //Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }*/

            Assert.AreEqual(educationmessage, Message.Text);
        }

        public void ValidateAddedEducation()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]", 30);

            //validate Education is added
            /*
            if (AddedDegree.Text == degree)
            {
                //Console.WriteLine("Certificate is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Certificate is not added, test failed");
                return false;
            }*/

            Assert.AreEqual(degree, AddedDegree.Text);
        }

        public void EditEducation(string edituniversity)
        {
            //Edit Education Button
            EditEducationBtn.Click();

            //Edit Education
            ClearUniversityText.Clear();
            EditUniversityText.SendKeys(edituniversity);


            //Click Update Education
            UpdateEducation.Click();

        }

        public void DeleteNewEducation()
        {
           //Delete Education            
            DeleteEducation.Click();

        }


    }
}
