using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;

namespace SkillSwap.Pages
{
    class ManageRequestsPage
    {
        private IWebDriver driver;
        private LoginPage logIn;

        //Page factory design
        IWebElement ManageRequests => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]"));
        IWebElement ReceivedRequests => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]"));
        IWebElement SentRequests => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]"));
        IWebElement ReceivedRequestsTitle => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/h2"));
        IWebElement SentRequestsTitle => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/h2"));
        IWebElement Accept => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]"));
        IWebElement Decline => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]"));
        IWebElement Withdraw => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button"));
        IWebElement Completed => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button"));
        IWebElement AcceptedRequestStatus => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        IWebElement DeclinedRequestStatus => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        IWebElement WithdrawnRequestStatus => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        IWebElement CompletedRequestStatus => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));



        //Read data from Excel
        private string acceptreceived = ExcelLib.ReadData(1, "AcceptReceivedRequest");
        private string declinereceived = ExcelLib.ReadData(1, "DeclineReceivedRequest");
        private string withdrawsent = ExcelLib.ReadData(1, "WithdrawSentRequest");
        private string completesent = ExcelLib.ReadData(1, "CompleteSentRequest");


        //Create a Constructor
        public ManageRequestsPage(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
        }

        //Received Request Actions - Accept
        public void AcceptReceivedRequest()
        {
            logIn.LoginSteps();
            ClickManageRequests();
            ClickReceivedRequests();
            ValidateAtReceivedRequestsPage();
            ClickAccept();
            ValidateAcceptedRequestStatus();
           
        }


        //Received Request Actions - Decline
        public void DeclineReceivedRequest()
        {
            logIn.LoginSteps();
            ClickManageRequests();
            ClickReceivedRequests();
            ValidateAtReceivedRequestsPage();
            ClickDecline();
            ValidateDeclinedRequestStatus();
           

        }
        public void ClickManageRequests()
        {
            ManageRequests.Click();
        }

        public void ClickReceivedRequests()
        {
            ReceivedRequests.Click();
        }

        public void ValidateAtReceivedRequestsPage()
        {
            bool isAtReceivedRequestsPage = ReceivedRequestsTitle.Displayed;
            Assert.IsTrue(isAtReceivedRequestsPage);
        }

        public void ClickAccept()
        {
            Accept.Click();
        }

        public void ValidateAcceptedRequestStatus()
        {
            /*
            if (ReceivedRequestStatus.Text == status)
            {
                return true;
            }
            else
            {
                return false;
            }*/

            Assert.AreEqual(acceptreceived, AcceptedRequestStatus.Text);

        }        

        public void ClickDecline()
        {
            Decline.Click();
        }

        public void ValidateDeclinedRequestStatus()
        {           
            Assert.AreEqual(declinereceived, DeclinedRequestStatus.Text);
        }



        //Sent Request Actions - Withdraw
        public void WithdrawSentRequest()
        {
            logIn.LoginSteps();
            ClickManageRequests();
            ClickSentRequests();
            ValidateAtSentRequestsPage();
            ClickWithdraw();

            //bool isStatusWithdrawn = ValidateSentRequestStatus(withdrawsent);
            //Assert.IsTrue(isStatusWithdrawn);
            ValidateWithdrawnRequestStatus();
        }


        //Sent Request Actions - Completed
        public void CompleteSentRequest()
        {
            logIn.LoginSteps();
            ClickManageRequests();
            ClickSentRequests();
            ValidateAtSentRequestsPage();
            ClickCompleted();
            ValidateCompletedRequestStatus();
           
        }


        public void ClickSentRequests()
        {
            SentRequests.Click();
        }

        public void ValidateAtSentRequestsPage()
        {
            bool isSentRequestsPage = SentRequestsTitle.Displayed;
            Assert.IsTrue(isSentRequestsPage);
        }

        public void ClickWithdraw()
        {
            Withdraw.Click();
        }

        public void ValidateWithdrawnRequestStatus()
        {
            Assert.AreEqual(withdrawsent, WithdrawnRequestStatus.Text);
        }

        public void ClickCompleted()
        {
            Completed.Click();
        }

        public void ValidateCompletedRequestStatus()
        {
            Assert.AreEqual(completesent, CompletedRequestStatus.Text);
        }

    }

}
