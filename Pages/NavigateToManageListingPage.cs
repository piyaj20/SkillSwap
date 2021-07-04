using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace SkillSwap.Pages
{
    class NavigateToManageListingPage
    {

        private IWebDriver driver;
        private LoginPage logIn;

        //Page Factory

        //Finding the Manage Listings tab
        IWebElement ManageListingstab => driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]"));

        // Finding the Edit Icon
        IWebElement Edit => driver.FindElement(By.XPath("//tbody/tr[1]/td[8]/div[1]/button[2]/i[1]"));


        //Create a Constructor
        public NavigateToManageListingPage(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);

        }


        public void ClickManageListings()

        {
            logIn.LoginSteps();

            //Click Manage Listings tab

            ManageListingstab.Click();
        }

        public bool ValidateYouAreAtManageListingsPage()
        {
            return Edit.Displayed;
        }

    }   

}

