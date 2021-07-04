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
        IWebElement Chat => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]"));
        IWebElement SearchBox => driver.FindElement(By.XPath("//*[@id='chatRoomContainer']/div/div[1]/div/div[1]/input"));
        IWebElement ChatTextBox => driver.FindElement(By.XPath("//*[@id='chatTextBox']"));
        IWebElement Send => driver.FindElement(By.XPath("//*[@id='btnSend']"));
        IWebElement Seller => driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]"));
        IWebElement SentMessage => driver.FindElement(By.XPath("//*[text()='Hello I want to trade my skill']"));


        //Read data from Excel
        private string chatmessage = ExcelLib.ReadData(1, "ChatMessage");
        private string sellername = ExcelLib.ReadData(1, "SellerName");

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
            EnterChatMessage();
            ClickSend();
            ValidateMessageSent();
            
        }

        public void ClickChat()
        {
            //click chat item
            Chat.Click();
        }

        public void EnterChatMessage()
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

        public void EnterSellerName()
        {
            //enter message in chat text box
            SearchBox.SendKeys(sellername);
            Seller.Click();

        }

        public bool ValidateYouAreInChatRoom()
        {
            //Wait.ElementExists(driver, "XPath", "//*[@id='chatTextBox']", 10);
            return ChatTextBox.Displayed;

        }

        public void ValidateMessageSent()
        {
            //validate message is sent to seller
            /*if (SentMessage.Text == chatmessage)
            {
                return true;
            }
            else
            {
                return false;
            }*/

            Assert.AreEqual(chatmessage, SentMessage.Text);
        }
    }
}