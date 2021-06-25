using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;

namespace SkillSwap.Pages
{
    class SearchPage
    {
        private IWebDriver driver;
        private LoginPage logIn;

        //page factory design
        IWebElement SearchIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/i"));
        IWebElement SearchSkillsTextBox => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input"));
        IWebElement SearchedSkillResult => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p"));
        IWebElement FilterOnline => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]"));

        //Read data from Excel
        private string searchskill = ExcelLib.ReadData(1, "SearchSkill");


        //Create a Constructor
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
        }

        // searching a skill from all categories
        public void SearchSkillsByAllCategories()
        {
            logIn.LoginSteps();
            ClickSearchIcon();
            EnterSearchSkill(searchskill);
            bool isSearchResult = ValidateSearchResult(searchskill);
            Assert.IsTrue(isSearchResult);
        }

        //searching a skill using filter
        public void SearchSkillsByFilters()
        {
            logIn.LoginSteps();
            ClickSearchIcon();
            ClickOnline();
            EnterSearchSkill(searchskill);
            bool isSearchResult = ValidateSearchResult(searchskill);
            Assert.IsTrue(isSearchResult);
        }
        public void ClickSearchIcon()
        {
            //click search icon
            SearchIcon.Click();
        }

        public void EnterSearchSkill(string searchskill)
        {
            //enter skill to search
            SearchSkillsTextBox.SendKeys(searchskill);

            //Click enter
            SearchSkillsTextBox.SendKeys(Keys.Enter);
        }

        public void ClickOnline()
        {
            //click online filter
            FilterOnline.Click();
        }

        public void ClickSearchedSkill()
        {

            //Click search skill
            SearchedSkillResult.Click();
        }


        public bool ValidateSearchResult(string searchskill)
        {
            
            //validate search skill result
            if (SearchedSkillResult.Text == searchskill)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
