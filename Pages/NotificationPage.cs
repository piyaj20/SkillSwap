using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;

namespace SkillSwap.Pages
{
    class NotificationPage
    {
        private readonly IWebDriver driver;
        private LoginPage logIn;

        //Page Factory

        IWebElement Notificationicon => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/div[1]"));

        IWebElement SeeAlllink => driver.FindElement(By.XPath("//a[contains(text(),'See All...')]"));

        IWebElement LoadMorelink => driver.FindElement(By.XPath("//a[contains(text(),'Load More...')]"));

        IWebElement ShowLesslink => driver.FindElement(By.XPath("//a[contains(text(),'...Show Less')]"));

        IWebElement SelectAllIcon => driver.FindElement(By.XPath("//body/div[@id='notification-section']/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/i[1]"));

        IWebElement UnSelectAllIcon => driver.FindElement(By.XPath("//body/div[@id='notification-section']/div[2]/div[1]/div[1]/div[3]/div[1]/div[2]/i[1]"));

        IWebElement Checkbox => driver.FindElement(By.XPath("//body/div[@id='notification-section']/div[2]/div[1]/div[1]/div[3]/div[2]/span[1]/span[1]/div[1]/div[1]/div[1]/div[1]/div[3]/input[1]"));

        IWebElement MarkasRead => driver.FindElement(By.XPath("//body/div[@id='notification-section']/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/i[1]"));

        IWebElement DeleteIcon => driver.FindElement(By.XPath("//body/div[@id='notification-section']/div[2]/div[1]/div[1]/div[3]/div[1]/div[3]/i[1]"));

        IWebElement Message => driver.FindElement(By.XPath("/html/body/div/div"));

        //Excel Read Message
        private string validatemessage = ExcelLib.ReadData(1, "NotificationMessage");

        public NotificationPage(IWebDriver driver)
        {

            this.driver = driver;
            logIn = new LoginPage(driver);

        }

        public void Notification()
        {
            logIn.LoginSteps();
            ClickNotificationicon();
            ClickSeeAll();
            ClickLoadMore();
            ClickShowLess();
            SelectNotification();
            UnselectNotification();
            ClickSelectAll();
            ClickUnselectAll();
            ClickMarkSelectionAsRead();
            ClickDeleteSelection();
            bool isNotificationDeleted = ValidateMessage(validatemessage);
            Assert.IsTrue(isNotificationDeleted);

        }

        public void ClickNotificationicon()
        {
            //Click Notification icon
            Notificationicon.Click();
        }

        public void ClickSeeAll()
        {
            //Click on See All link
            SeeAlllink.Click();
        }

        public void ClickLoadMore()
        {
            //Click on Load More link
            LoadMorelink.Click();
        }

        public void ClickShowLess()
        {
            //Click on Show Less link
            ShowLesslink.Click();
        }


        //selecting a notification
        public void SelectNotification()
        {
            if (!Checkbox.Selected)
            {
                Checkbox.Click();
            }

        }

        //unselecting a notification
        public void UnselectNotification()
        {
            if (Checkbox.Selected)
            {
                Checkbox.Click();
            }
        }

        //selecting all notifications
        public void ClickSelectAll()
        {
            //Click on SelectAll icon
            SelectAllIcon.Click();
        }

        //unselecting all notifications
        public void ClickUnselectAll()
        {
            //Click on UnSelectAll icon
            UnSelectAllIcon.Click();
        }

        public void ClickMarkSelectionAsRead()
        {
            SelectNotification();

            //Click on Mark as Read icon
            MarkasRead.Click();
        }

        //deleting selected notification
        public void ClickDeleteSelection()
        {
            SelectNotification();

            //Click on delete icon
            DeleteIcon.Click();     
            
        }

        public bool ValidateMessage(string validatemessage)
        {
           
            //validate notification is updated
            if (Message.Text == validatemessage)
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
