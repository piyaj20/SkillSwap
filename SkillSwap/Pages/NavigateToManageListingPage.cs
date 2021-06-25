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

        // Finding the Manage Listings Page Title
        IWebElement ManageListings => driver.FindElement(By.XPath("//h2[contains(text(),'Manage Listings')]"));


        //Create a Constructor
        public NavigateToManageListingPage(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);

        }



        public bool ClickManageListings(IWebDriver driver)

        {
            logIn.LoginSteps();

            //Click Manage Listings tab

            ManageListingstab.Click();


            //Validate at Manage Listings Page

            if (ManageListings.Text == "Manage Listings")
            {

                return true;
            }
            else
            {
                return false;
            }

            //Assert.That(managelistPage.ManageListings.Text == "Manage Listings");

            //Assert.Pass("Test Passed");

        }
    }

}

