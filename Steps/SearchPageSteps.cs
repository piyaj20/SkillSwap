using OpenQA.Selenium;
using SkillSwap.Pages;
using SkillSwap.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SkillSwap.Steps
{
    [Binding]
    public class SearchPageSteps: CommonDriver
    {

        private readonly LoginPage logIn;
        private readonly SearchPage searchPage;

        public SearchPageSteps()
        {
            logIn = new LoginPage(driver);
            searchPage = new SearchPage(driver);
        }


        [Given("I am at the Search Page")]
        public void GivenIAmAtTheSearchPage()
        {
            logIn.LoginSteps();
            searchPage.ClickSearchIcon();
            searchPage.ValidateSearchPage();
            Console.WriteLine("I am at the Search Page");
        }
        
        [When("I enter search data in Search skills")]
        public void WhenIEnterSearchDataInSearchSkills()
        {
            searchPage.EnterSearchSkill();
            Console.WriteLine("I enter search data in Search skills");
        }

        [When("I click enter")]
        public void WhenIClickEnter()
        {
            searchPage.ClickEnter();
            Console.WriteLine("I click enter");
        }

        [Then("Search data should be displayed")]
        public void ThenSearchDataShouldBeDisplayed()
        {
            searchPage.ValidateSearchResult();
            Console.WriteLine("Search data should be displayed");
        }


        [When("I select filter")]
        public void WhenISelectFilter()
        {
            searchPage.ClickOnline();
            Console.WriteLine("I select filter");
        }
    }
}
