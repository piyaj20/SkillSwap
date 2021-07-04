using NUnit.Framework;
using SkillSwap.Pages;
using SkillSwap.Utilities;
using System;
using System.Linq;
using static SkillSwap.Utilities.CommonMethods;
using TechTalk.SpecFlow;

namespace SkillSwap.Steps
{
    [Binding]
    public class LoginPageSteps : CommonDriver
    {

        private readonly LoginPage logIn;
        private readonly Register register;


        public LoginPageSteps()
        {
            logIn = new LoginPage(driver);
            register = new Register(driver);
        }

        [Given("I am at the SignUp page")]
        public void GivenIAmAtTheSignUpPage()
        {
            register.ClickJoin();
            bool isJoinPage = register.ValidateYouAreAtRegistrationPage();
            Console.WriteLine("I am at the SignUp page");
            Assert.IsTrue(isJoinPage);
        }

        
        [When("I enter valid information")]
        public void WhenIEnterValidInformation()
        {
            register.JoinUser();
            Console.WriteLine("I enter valid information");
        }

        [When("I agree to the terms and conditions")]
        public void WhenIAgreeToTheTermsAndConditions()
        {
            register.ClickAgreeTermsAndConditions();
            Console.WriteLine("I agree to the terms and conditions");
        }

        [When("I click the Join button")]
        public void WhenIClickTheJoinButton()
        {
            register.ClickJoinButton();
            Console.WriteLine("I click the Join button");
        }

        [Then("I should be registered successfully")]
        public void ThenIAmRegisteredSuccessfully()
        {
            /*bool isRegistered = register.ValidateSuccessMessage();
            Console.WriteLine("I should be registered successfully");
            Assert.IsTrue(isRegistered);*/
            register.ValidateSuccessMessage();
            Console.WriteLine("I should be registered successfully");
        }
    

        [Given("I am at the Login page")]
        public void GivenIAmAtTheLoginPage()
        {
            logIn.ClickSignIn();
            bool isLoginPage = logIn.ValidateYouAreAtLoginPage();
            Console.WriteLine("I am at the Login page");
            Assert.IsTrue(isLoginPage);
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            logIn.EnterEmailandPassword();
            Console.WriteLine("I enter valid credentials");
        }

        [When("I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            logIn.ClickLogin();
            Console.WriteLine("I click the Login button");
        }

        [Then("I should be logged in successfully")]
        public void ThenIAmLoggedInSuccessfully()
        {
            bool isLoggedIn = logIn.ValidateLoggedInSuccessfully();
            Console.WriteLine("I should be logged in successfully");
            Assert.IsTrue(isLoggedIn);
        }

    }
}
