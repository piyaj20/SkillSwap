using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;


namespace SkillSwap.Pages
{
    class ServiceDetailPage
    {
        private readonly IWebDriver driver;
        private SearchPage searchPage;

        //page factory design pattern
        IWebElement ChatButton => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[1]/div/div[1]/div/a"));
        IWebElement Request => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]"));
        IWebElement MessageTextBox => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea"));
        IWebElement Yes => driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/button[1]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        //Read data from Excel
        private string messagetoseller = ExcelLib.ReadData(1, "MessageToSeller");
        private string sentrequestmessage = ExcelLib.ReadData(1, "SentRequestMessage");



        //Create a Constructor
        public ServiceDetailPage(IWebDriver driver)
        {
            this.driver = driver;
            searchPage = new SearchPage(driver);
        }


        public void SendServiceRequest()
        {
            searchPage.SearchSkillsByAllCategories();
            searchPage.ClickSearchedSkill();
            bool isServicePage = ValidateYouAreAtServiceDetailPage();
            Assert.IsTrue(isServicePage);
            EnterMessageToSeller();
            ClickRequest();
            ClickYes();
            //bool isRequestSent = ValidateRequestSent(sentrequestmessage);
            //Assert.IsTrue(isRequestSent);
            ValidateRequestSent();

        }



        public bool ValidateYouAreAtServiceDetailPage()
        {
            return ChatButton.Displayed;

        }

        public void ClickChat()
        {
            //click chat button
            ChatButton.Click();
        }


        public void EnterMessageToSeller()
        {
            //enter message in message text box
            MessageTextBox.SendKeys(messagetoseller);

        }

        public void ClickRequest()
        {
            //click request button
            Request.Click();
        }

        
        public void ClickYes()
        {
            //click yes on confirm popup
            Yes.Click();
        }

        public void ValidateRequestSent()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 1000);
            //validate request is sent
            /*
            if (Message.Text == sentrequestmessage)
            {
                return true;
            }
            else
            {
                return false;
            }*/

             Assert.AreEqual(sentrequestmessage, Message.Text);

        }
        
    }
}
