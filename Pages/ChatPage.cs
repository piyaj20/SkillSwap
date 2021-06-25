using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;

namespace SkillSwap.Pages
{
    class ChatPage
    {

        private readonly IWebDriver driver;
        private readonly SearchPage searchPage;
        private readonly ServiceDetailPage serviceDetailPage;

        //page factory design pattern
        IWebElement ChatTextBox => driver.FindElement(By.XPath("//*[@id='chatTextBox']"));
        IWebElement Send => driver.FindElement(By.XPath("//*[@id='btnSend']"));
        IWebElement SentMessage => driver.FindElement(By.XPath("//*[text()='Hello I want to trade my skill']"));


        //Read data from Excel
        private string chatmessage = ExcelLib.ReadData(1, "ChatMessage");

        //Create a Constructor
        public ChatPage(IWebDriver driver)
        {
            this.driver = driver;
            searchPage = new SearchPage(driver);
            serviceDetailPage = new ServiceDetailPage(driver);
        }

        //sending message to seller
        public void ChatWithSeller()
        {
            searchPage.SearchSkillsByAllCategories();
            searchPage.ClickSearchedSkill();
            serviceDetailPage.ValidateYouAreAtServiceDetailPage();
            serviceDetailPage.ClickChat();
            ValidateYouAreOnChatPage();
            EnterChatMessage(chatmessage);
            ClickSend();
            bool isMessageSent = ValidateMessageSent(chatmessage);
            Assert.IsTrue(isMessageSent);
        }

        public void EnterChatMessage(string chatmessage)
        {
            //enter message in chat text box
            ChatTextBox.SendKeys(chatmessage);

        }
        public void ClickSend()
        {
            //click send
            Send.Click();
        }

        public void ValidateYouAreOnChatPage()
        {
            bool isChatRoom = ChatTextBox.Displayed;
            Assert.IsTrue(isChatRoom);
        }

        public bool ValidateMessageSent(string chatmessage)
        {
            //validate message is sent to seller
            if (SentMessage.Text == chatmessage)
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