using NUnit.Framework;
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
    public class ProfilePageSteps: CommonDriver
    {
        private readonly ProfileDescription profileDescription;
        private readonly ProfileLanguage profileLanguage;
        private readonly ProfileSkill profileSkill;
        private readonly ProfileCertification profileCertification;
        private readonly ProfileEducation profileEducation;
        private readonly ProfilePage profilePage;
        private readonly LoginPage logIn;
        private readonly ChangePasswordPage changePasswordPage;

        public ProfilePageSteps()
        {
            profileDescription = new ProfileDescription(driver);
            profileLanguage = new ProfileLanguage(driver);
            profileSkill = new ProfileSkill(driver);
            profileCertification = new ProfileCertification(driver);
            profileEducation = new ProfileEducation(driver);
            profilePage = new ProfilePage(driver);
            logIn = new LoginPage(driver);
            changePasswordPage = new ChangePasswordPage(driver);
        }

        [Given("I am at the Profile Page")]
        public void GivenIAmAtTheProfilePage()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            Console.WriteLine("I am at the Profile Page");
        }

        [When("I click description icon")]
        public void WhenIClickDescriptionIcon()
        {
            profileDescription.ClickDescriptionIcon();
            Console.WriteLine("I click description icon");
        }

        [When("I enter description")]
        public void WhenIEnterDescription()
        {
            profileDescription.EnterDescription();
            Console.WriteLine("I enter description");
        }

        [When("I click save")]
        public void WhenIClickSave()
        {
            profileDescription.ClickSave();
            Console.WriteLine("I click save");
        }

        [Then("Description saved message should be displayed")]
        public void ThenDescriptionSavedMessageDisplayed()
        {
            profileDescription.ValidateDescriptionSavedMessage();
            Console.WriteLine("Description saved message should be displayed");
        }

        [Then("Saved description should be displayed on the profile page")]
        public void ThenSavedDescriptionDisplayedOnTheProfilePage()
        {
            profileDescription.ValidateSavedDescription();
            Console.WriteLine("Saved description should be displayed on the profile page");
        }


        [When("I click availability icon")]
        public void WhenIClickAvailabilityIcon()
        {
            profilePage.ClickAvailability();
            Console.WriteLine("I click availability icon");
        }

        [When("I select availability")]
        public void WhenISelectAvailability()
        {

            profilePage.SelectAvailability();
            Console.WriteLine("I select availability");
        }

        [Then("Availability updated message should be displayed")]
        public void ThenAvailabilityUpdatedMessageDisplayed()
        {
            profilePage.ValidateSuccessMessage();
            Console.WriteLine("Availability updated message should be displayed");
            
        }


        [When("I click hours icon")]
        public void WhenIClickHoursIcon()
        {
            profilePage.ClickHours();
            Console.WriteLine("I click hours icon");
        }

        [When("I select hours")]
        public void WhenISelectHours()
        {

            profilePage.SelectHours();
            Console.WriteLine("I select hours");
        }

        [Then("Hours updated message should be displayed")]
        public void ThenHoursUpdatedMessageDisplayed()
        {
            profilePage.ValidateSuccessMessage();
            Console.WriteLine("Hours updated message should be displayed");
            
        }


        [When("I click earn target icon")]
        public void WhenIClickEarnTargetIcon()
        {
            profilePage.ClickEarnTarget();
            Console.WriteLine("I click earn target icon");
        }

        [When("I select earn target")]
        public void WhenISelectEarnTarget()
        {
            profilePage.SelectEarnTarget();
            Console.WriteLine("I select earn target");
        }

        [Then("Earn Target updated message should be displayed")]
        public void ThenEarnTargetUpdatedMessageDisplayed()
        {
            profilePage.ValidateSuccessMessage();
            Console.WriteLine("Earn Target updated message should be displayed");            
        }


        [When("I click Add New in languages")]
        public void WhenIClickAddNewLanguage()
        {
            profileLanguage.ClickAddNewLanguage();
            Console.WriteLine("I click Add New in languages");
        }

        [When("I enter language")]
        public void WhenIEnterLanguage()
        {
            profileLanguage.EnterLanguage();
            Console.WriteLine("I enter language");
        }

        [When("I choose language level")]
        public void WhenIChooseLanguageLeve()
        {
            profileLanguage.ChooseLanguageLevel();
            Console.WriteLine("I choose language level");
        }

        [When("I click Add in languages")]
        public void WhenIClikAddLanguage()
        {
            profileLanguage.ClickAdd();
            Console.WriteLine("I click add in languages");
        }

        [Then("Language saved message should be displayed")]
        public void ThenLanguageSavedMessageDisplayed()
        {
            profileLanguage.ValidateLanguageSavedMessage();
            Console.WriteLine("Language saved message should be displayed");
            
        }

        [Then("Added language should be displayed on the profile page")]
        public void ThenAddedLanguageDisplayedOnTheProfilePage()
        {
            profileLanguage.ValidateAddedLanguage();
            Console.WriteLine("Added language should be displayed on the profile page");            
        }


        [When("I click skills tab")]
        public void WhenIClickSkillsTab()
        {
            profileSkill.ClickSkillsTab();
            Console.WriteLine("I click skills tab");
        }

        [When("I click Add New in skills")]
        public void WhenIClickAddNewSkill()
        {
            profileSkill.ClickAddNew();
            Console.WriteLine("I click Add New in skills");
        }

        [When("I enter skill")]
        public void WhenIEnterSkill()
        {
            profileSkill.EnterSkill();
            Console.WriteLine("I enter skill");
        }

        [When("I choose skill level")]
        public void WhenIChooseSkillLevel()
        {
            profileSkill.ChooseSkillLevel();
            Console.WriteLine("I choose skill level");
        }

        [When("I click Add in skills")]
        public void WhenIClikAddSkill()
        {
            profileSkill.ClickAdd();
            Console.WriteLine("I click add in skills");
        }

        [Then("Skill saved message should be displayed")]
        public void ThenSkillSavedMessageDisplayed()
        {
            profileSkill.ValidateSkillSavedMessage();
            Console.WriteLine("Skill saved message should be displayed");            
        }

        [Then("Added skill should be displayed on the profile page")]
        public void ThenAddedSkillDisplayedOnTheProfilePage()
        {
            profileSkill.ValidateAddedSkill();
            Console.WriteLine("Added skill should be displayed on the profile page");            
        }


        [When("I click certifications tab")]
        public void WhenIClickCertificationsTab()
        {
            profileCertification.ClickCertificationsTab();
            Console.WriteLine("I click certifications tab");
        }

        [When("I click Add New in certifications")]
        public void WhenIClickAddNewCertification()
        {
            profileCertification.ClickAddNew();
            Console.WriteLine("I click Add New in certifications");
        }

        [When("I enter certificate")]
        public void WhenIEnterCertificate()
        {
            profileCertification.EnterCertificate();
            Console.WriteLine("I enter certificate");
        }

        [When("I enter certified from")]
        public void WhenIEnterCertifiedFrom()
        {
            profileCertification.EnterCertifiedFrom();
            Console.WriteLine("I enter certified from");
        }

        [When("I select year")]
        public void WhenISelectYear()
        {

            profileCertification.SelectYear();
            Console.WriteLine("I select year");
        }

        [When("I click Add in certifications")]
        public void WhenIClickAddCertification()
        {

            profileCertification.ClickAdd();
            Console.WriteLine("I click Add in certifications");
        }

        [Then("Certification saved message should be displayed")]
        public void ThenCertificationSavedMessageDisplayed()
        {
            profileCertification.ValidateCertificateSavedMessage();
            Console.WriteLine("Certification saved message should be displayed");            
        }

        [Then("Added certification should be displayed on the profile page")]
        public void ThenAddedCertificationDisplayedOnTheProfilePage()
        {
            profileCertification.ValidateAddedCertificate();
            Console.WriteLine("Added certification should be displayed on the profile page");            
        }


        [When("I click education tab")]
        public void WhenIClickEducationTab()
        {
            profileEducation.ClickEducationTab();
            Console.WriteLine("I click education tab");
        }

        [When("I click Add New in education")]
        public void WhenIClickAddNewEducation()
        {
            profileEducation.ClickAddNew();
            Console.WriteLine("I click Add New in education");
        }

        [When("I enter college")]
        public void WhenIEnterCollege()
        {
            profileEducation.EnterCollege();
            Console.WriteLine("I enter college");
        }

        [When("I select country")]
        public void WhenISelectCountry()
        {
            profileEducation.SelectCountry();
            Console.WriteLine("I select country");
        }

        [When("I select title")]
        public void WhenISelectTitle()
        {
            profileEducation.SelectTitle();
            Console.WriteLine("I select title");
        }

        [When("I enter degree")]
        public void WhenIEnterDegree()
        {
            profileEducation.EnterDegree();
            Console.WriteLine("I enter degree");
        }

        [When("I select year of graduation")]
        public void WhenISelectYearOfGraduation()
        {
            profileEducation.SelectYear();
            Console.WriteLine("I select year of graduation");
        }

        [When("I click Add in education")]
        public void WhenIClickAddEducation()
        {
            profileEducation.ClickAdd();
            Console.WriteLine("I click Add in education");
        }

        [Then("Education saved message should be displayed")]
        public void ThenEducationSavedMessageDisplayed()
        {
            profileEducation.ValidateEducationSavedMessage();
            Console.WriteLine("Education saved message should be displayed");            
        }

        [Then("Added education should be displayed on the profile page")]
        public void ThenAddedEducationDisplayedOnTheProfilePage()
        {
            profileEducation.ValidateAddedEducation();
            Console.WriteLine("Added education should be displayed on the profile page");            
        }


        [Given("I am at the change password Page")]
        public void GivenIAmAtChangePasswordPage()
        {
            logIn.LoginSteps();
            changePasswordPage.ClickChangePassword();
            changePasswordPage.ValidateYouAreAtChangePasswordPage();
            Console.WriteLine("I am at the change password Page");            
        }

        [When("I enter valid credential")]
        public void WhenIEnterValidCredentials()
        {
            changePasswordPage.EnterPasswordDetails();
            Console.WriteLine("I enter valid credential");
        }

        [When("I click Save button")]
        public void WhenIClickSaveButton()
        {
            changePasswordPage.ClickSavePassword();
            Console.WriteLine("I click Save button");
        }

        [Then("Password changed message should be displayed")]
        public void ThenPasswordChangedMessageDisplayed()
        {
            changePasswordPage.ValidateSuccessMessage();
            Console.WriteLine("Password changed message should be displayed");            
        }

    }
}
