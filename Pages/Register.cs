
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static SkillSwap.Utilities.CommonMethods;

namespace SkillSwap.Pages
{
    class Register
    {
        private readonly IWebDriver driver;

        //Page Factory
        IWebElement Join => driver.FindElement(By.XPath("//button[contains(text(),'Join')]"));
        IWebElement FirstName => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[1]/input[1]"));
        IWebElement LastName => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[2]/input[1]"));
        IWebElement RegisterEmail => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[3]/input[1]"));
        IWebElement RegisterPassword => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[4]/input[1]"));
        IWebElement ConfirmRegisterPassword => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[5]/input[1]"));
        IWebElement AgreeTerms => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[6]/div[1]/div[1]/input[1]"));
        IWebElement JoinButton => driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        

        //Read Data from Excel
        private string firstName = ExcelLib.ReadData(1, "FirstName");
        private string lastName = ExcelLib.ReadData(1, "LastName");
        private string email = ExcelLib.ReadData(1, "Email");
        private string userpassword = ExcelLib.ReadData(1, "UserPassword");
        private string confirmregPassword = ExcelLib.ReadData(1, "ConfirmRegPassword");


        public Register(IWebDriver driver)
        {

            this.driver = driver;
        }

        public void RegisterUser()
        {
            JoinUser(firstName, lastName, email, userpassword, confirmregPassword);

        }

        public void JoinUser(string firstName, string lastName, string email, string userpassword, string confirmregPassword)
        {

            
            driver.Navigate().GoToUrl("http://localhost:5000");

            //click Join/Register

            Join.Click();

            //Enter details
            FirstName.SendKeys(firstName);


            LastName.SendKeys(lastName);


            RegisterEmail.SendKeys(email);


            RegisterPassword.SendKeys(userpassword);


            ConfirmRegisterPassword.SendKeys(confirmregPassword);


            AgreeTerms.Click();


            JoinButton.Click();


        }

    }
}
