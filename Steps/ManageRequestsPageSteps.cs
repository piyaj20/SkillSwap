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

    public class ManageRequestsPageSteps : CommonDriver
    {
        
        private readonly LoginPage logIn;
        private readonly ManageRequestsPage manageRequests;

        public ManageRequestsPageSteps()
        {
            logIn = new LoginPage(driver);
            manageRequests = new ManageRequestsPage(driver);
        }

        [Given("I am at Received Requests page")]
        public void GivenIAmAtReceivedRequestsPage()
        {
            logIn.LoginSteps();
            manageRequests.ClickManageRequests();
            manageRequests.ClickReceivedRequests();
            manageRequests.ValidateAtReceivedRequestsPage();
            Console.WriteLine("I am at Received Requests Page");
        }        

        [When("I click on Accept")]
        public void WhenIClickOnAccept()
        {
            manageRequests.ClickAccept();
            Console.WriteLine("I click Accept");
        }

        [Then("Request should be accepted")]
        public void ThenRequestShouldBeAccepted()
        {
            manageRequests.ValidateAcceptedRequestStatus();
            Console.WriteLine("Request should be accepted");
        }



        [When("I click on Decline")]
        public void WhenIClickOnDecline()
        {
            manageRequests.ClickDecline();
            Console.WriteLine("I click Decline");
        }

        [Then("Request should be declined")]
        public void ThenRequestShouldBeDeclined()
        {
            manageRequests.ValidateDeclinedRequestStatus();
            Console.WriteLine("Request should be declined");
        }



        [Given("I am at Sent Requests page")]
        public void GivenIAmAtSentRequestsPage()
        {
            logIn.LoginSteps();
            manageRequests.ClickManageRequests();
            manageRequests.ClickSentRequests();
            manageRequests.ValidateAtSentRequestsPage();
            Console.WriteLine("I am at Sent Requests Page");
        }

        [When("I click on Withdraw")]
        public void WhenIClickOnWithdraw()
        {
            manageRequests.ClickWithdraw();
            Console.WriteLine("I click Withdraw");
        }

        [Then("Request should be withdrawn")]
        public void ThenRequestShouldBeWithdrawn()
        {
            manageRequests.ValidateWithdrawnRequestStatus();
            Console.WriteLine("Request should be withdrawn");
        }



        [When("I click on Completed")]
        public void WhenIClickOnCompleted()
        {
            manageRequests.ClickCompleted();
            Console.WriteLine("I click Completed");
        }

        [Then("Request should be completed")]
        public void ThenRequestShouldBeCompleted()
        {
            manageRequests.ValidateCompletedRequestStatus();
            Console.WriteLine("Request should be completed");
        }
    }
}
