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
    public class ChatPageSteps : CommonDriver
    {

        private readonly LoginPage logIn;
        private readonly ServiceDetailPage serviceDetailPage;
        private readonly ChatPage chatPage;
        private readonly SearchPage searchPage;

        public ChatPageSteps()
        {
            logIn = new LoginPage(driver);
            serviceDetailPage = new ServiceDetailPage(driver);
            chatPage = new ChatPage(driver);
            searchPage = new SearchPage(driver);
        }

        [Given("I am at the Service Detail Page")]
        public void GivenIAmAtTheServiceDetailPage()
        {
            searchPage.SearchSkillsByAllCategories();
            searchPage.ClickSearchedSkill();
            bool isServiceDetailPage = serviceDetailPage.ValidateYouAreAtServiceDetailPage();
            Console.WriteLine("I am at the Service Detail Page");
            Assert.IsTrue(isServiceDetailPage);
        }


        [When("I click on Chat button")]
        public void WhenIClickChatButton()
        {
            serviceDetailPage.ClickChat();
            Console.WriteLine("I click Chat button");
        }

        [When("I enter message in the chat box")]
        public void WhenIntEnterMessageInTheChatBox()
        {
            chatPage.EnterChatMessage();
            Console.WriteLine("I enter message in the chat box");
        }

        [When("I click on Send")]
        public void WhenIClickSend()
        {
            chatPage.ClickSend();
            Console.WriteLine("I click send");

        }

        [Then("Message should be sent to that user")]
        public void ThenMessageShouldBeSent()
        {
            chatPage.ValidateMessageSent();
        }


        [Given("I am on the Chat Page")]
        public void GivenIAmOnTheChatPage()
        {
            logIn.LoginSteps();
            chatPage.ClickChat();
            bool isChatRoom = chatPage.ValidateYouAreInChatRoom();
            Console.WriteLine("I am in the Chat room");
            Assert.IsTrue(isChatRoom);
        }

        [When("I enter seller name in search box")]
        public void WhenIEnterSellerNameInSearchBox()
        {
            chatPage.EnterSellerName();
            Console.WriteLine("I enter seller name in search box");
        }

        [Then("Chat History with that seller should be visible")]
        public void ThenChatHistoryShouldBeVisible()
        {
            chatPage.ValidateMessageSent();
            Console.WriteLine("Chat History with the seller should be visible");
          
        }
    }
}
