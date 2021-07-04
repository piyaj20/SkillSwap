using NUnit.Framework;
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
    public class NotificationPageSteps : CommonDriver
    {

        private readonly LoginPage logIn;
        private readonly NotificationPage notificationPage;

        public NotificationPageSteps()
        {
            logIn = new LoginPage(driver);
            notificationPage = new NotificationPage(driver);
        }

        [Given("I am at the Notification Page")]
        public void GivenIAmAtTheNotificationPage()
        {
            logIn.LoginSteps();
            notificationPage.ClickNotificationicon();
            notificationPage.ClickSeeAll();
            bool isNotificationPage = notificationPage.ValidateYouAreAtNotificationPage();
            Console.WriteLine("I am at the Notifications Page");
            Assert.IsTrue(isNotificationPage);
        }


        [When("I click Load More")]
        public void WhenIClickLoadMore()
        {
            notificationPage.ClickLoadMore();
            Console.WriteLine("I click Load More");
        }

        [Then("More notifications should be loaded")]
        public void ThenMoreNotificationsShouldBeLoaded()
        {
            notificationPage.ValidateMoreNotificationsLoaded();
            Console.WriteLine("More notifications should be loaded");
        }



        [When("I click Show Less")]
        public void WhenIClickShowLess()
        {
            notificationPage.ClickShowLess();
            Console.WriteLine("I click Show Less");
        }

        [Then("Less notifications should be displayed")]
        public void ThenLessNotificationsShouldBeDisplayed()
        {
            notificationPage.ValidateLessNotificationsDisplayed();
            Console.WriteLine("Less notifications should be displayed");
        }



        [When("I select a notification")]
        public void WhenISelectANotification()
        {
            notificationPage.SelectNotification();
            Console.WriteLine("I select a notification");
        }

        [Then("Notification should be selected")]
        public void ThenNotificationShouldBeSelected()
        {
            notificationPage.ValidateNotificationSelected();
        }



        [When("I unselect a notification")]
        public void WhenIUnSelectANotification()
        {
            notificationPage.UnselectNotification();
            Console.WriteLine("I unselect a notification");
        }

        [Then("Notification should be unselected")]
        public void ThenNotificationUnselected()
        {
            notificationPage.ValidateNotificationUnselected();
            Console.WriteLine("Notification should be unselected");
            
        }



        [When("I click Select all")]
        public void WhenIClickSelectAll()
        {
            notificationPage.ClickSelectAll();
            Console.WriteLine("I click Select all");
        }

        [Then("All notifications should be selected")]
        public void ThenAllNotificationsShouldBeSelected()
        {
            notificationPage.ValidateAllNotificationsSelected();
        }



        [When("I click Unselect all")]
        public void WhenIClickUnSelectAll()
        {
            notificationPage.ClickUnselectAll();
            Console.WriteLine("I click Unselect all");
        }

        [Then("All notifications should be unselected")]
        public void ThenAllNotificationsShouldBeUnSelected()
        {
            notificationPage.ValidateAllNotificationsUnselected();
        }


        [When("I click Mark selection as read")]
        public void WhenIClickMarkSelectionAsRead()
        {
            notificationPage.ClickMarkSelectionAsRead();
            Console.WriteLine("I click Mark selection as read");
        }

        [Then("Notification should be marked as read")]
        public void ThenNotificationMarkedAsRead()
        {
            notificationPage.ValidateMessage();
            Console.WriteLine("Notification should be marked as read");
            
        }



        [When("I click Delete selection")]
        public void WhenIClickDeleteSelection()
        {
            notificationPage.ClickDeleteSelection();
            Console.WriteLine("I click Delete selection");
        }

        [Then("Notification should be deleted")]
        public void NotificationDeleted()
        {
           notificationPage.ValidateMessage();
            Console.WriteLine("Notification should be deleted");
            
        }

    }
}
