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
    public class ShareSkillPageSteps : CommonDriver
    {
        private readonly LoginPage logIn;
        private readonly ShareSkillPage shareSkill;
        private readonly NavigateToManageListingPage manageListings;

        public ShareSkillPageSteps(ScenarioContext scenarioContext)
        {
            logIn = new LoginPage(driver);
            shareSkill = new ShareSkillPage(driver);
            manageListings = new NavigateToManageListingPage(driver);
        }

        [Given("I am at the Share Skill Page")]
        public void GivenIAmAtTheShareSkillPage()
        {
            logIn.LoginSteps();
            shareSkill.ClickShareSkill();
            shareSkill.ValidateYouAreAtShareSkillPage();
            Console.WriteLine("I am at the Share Skill Page");
        }

        [When("I enter data in all the mandatory fields")]
        public void WhenIEnterData()
        {
            shareSkill.EnterData();
            Console.WriteLine("I enter data in fields");
        }

        [When("I click on Save button")]
        public void WhenIClickOnSave()
        {
            shareSkill.ClickSaveButton();
            Console.WriteLine("I click save on Share Skill Page");
        }

        [Then("ShareSkill should be saved successfully")]
        public void ThenShareSkillShouldBeSavedSuccessfully()
        {
            shareSkill.ValidateServiceSavedSuccessfully();
            Console.WriteLine("ShareSkill should be saved");
        }



        [Given("I am at the Manage Listings Page")]
        public void GivenIAmAtTheManageListingsPage()
        {
            manageListings.ClickManageListings();
            manageListings.ValidateYouAreAtManageListingsPage();
            Console.WriteLine("I am at the Manage Listings Page");
        }

        [When("I click on edit icon")]
        public void WhenIClickOnEditIcon()
        {
            shareSkill.EditIcon();
            Console.WriteLine("I click on edit icon");
        }

        [When("I update the information on ShareSkill Page")]
        public void WhenIUpdateTheInformation()
        {
            shareSkill.UpdateData();
            Console.WriteLine("I update the information in fields");
        }

        [Then("ShareSkill should be updated successfully")]
        public void ThenShareSkillShouldBeUpdatedSuccessfully()
        {
            shareSkill.ValidateServiceUpdatedSuccessfully();
            Console.WriteLine("ShareSkill should be updated successfully");
        }



        [When("I click on delete icon")]
        public void WhenIClickOnDeleteIcon()
        {
            shareSkill.DeleteRecord();
            Console.WriteLine("I click on delete icon");
        }

        [When("I click Yes on Delete popup")]
        public void WhenIClickYesOnDeletePopup()
        {
            shareSkill.ClickYesonPopup();
            Console.WriteLine("I click Yes on Delete popup");
        }

        [Then("ShareSkill should be deleted successfully")]
        public void ThenShareSkillShouldBeDeletedSuccessfully()
        {
            shareSkill.ValidateServiceDeletedSuccessfully();
        }
    }
}
