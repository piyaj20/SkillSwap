using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static SkillSwap.Utilities.CommonMethods;
using SkillSwap.Utilities;
using NUnit.Framework;
namespace SkillSwap.Pages
{
    class ProfileCertification
    {
        private readonly IWebDriver driver;
        private LoginPage logIn;
        private ProfileDescription profileDescription;


        //Page Factory design
        IWebElement AddNew => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        IWebElement Certificate => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        IWebElement CertifiedFrom => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input"));
        IWebElement Year => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option[13]"));
        IWebElement Add => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        IWebElement AddedCertificate => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));
        IWebElement CertificationsTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        IWebElement EditCertificationBtn => driver.FindElement(By.XPath("//tbody/tr[1]/td[4]/span[1]/i[1]"));
        IWebElement ClearCertificationText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/div[1]/input[1]"));
        IWebElement EditCertificationText => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/div[1]/input[1]"));
        IWebElement UpdateCertification => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]"));
        IWebElement DeleteCertification => driver.FindElement(By.XPath("//tbody/tr[1]/td[4]/span[2]/i[1]"));



        //Read data from Excel
        private string certificate = ExcelLib.ReadData(1, "Certificate");
        private string certifiedfrom = ExcelLib.ReadData(1, "CertifiedFrom");
        private string certificatemessage = ExcelLib.ReadData(1, "CertificateMessage");
        private string editcertificate = ExcelLib.ReadData(1, "EditCertificate");


        //Create a Constructor
        public ProfileCertification(IWebDriver driver)
        {
            this.driver = driver;
            logIn = new LoginPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        //adding a certification
        public void Certification()
        {
            logIn.LoginSteps();
            profileDescription.ValidateProfilePage();
            ClickCertificationsTab();
            ClickAddNew();
            EnterCertificate(certificate);
            EnterCertifiedFrom(certifiedfrom);
            SelectYear();
            ClickAdd();
            bool isMessage = ValidateCertificateSavedMessage(certificatemessage);
            Assert.IsTrue(isMessage);
            bool isCertificate = ValidateAddedCertificate(certificate);
            Assert.IsTrue(isCertificate);
            EditCertification(editcertificate);
            DeleteNewCertification();
        }

        public void ClickCertificationsTab()
        {
            //click Certifications Tab
            CertificationsTab.Click();
        }

        public void ClickAddNew()
        {
            //click add new for Certifications
            AddNew.Click();
        }

        public void EnterCertificate(string certificate)
        {
            // enter Certificate
            Certificate.SendKeys(certificate);
        }

        public void EnterCertifiedFrom(string certifiedfrom)
        {
            // enter Certified From
            CertifiedFrom.SendKeys(certifiedfrom);
        }


        public void SelectYear()
        {
            //select year
            Year.Click();
        }

        public void ClickAdd()
        {
            //click add for Certifications
            Add.Click();
        }

        public bool ValidateCertificateSavedMessage(string certificatemessage)
        {
            
            if (Message.Text == certificatemessage)
            {
                //Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }
        }

        public bool ValidateAddedCertificate(string certificate)
        {
            
            //validate Certificate is added
            if (AddedCertificate.Text == certificate)
            {
                //Console.WriteLine("Certificate is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Certificate is not added, test failed");
                return false;
            }
        }


        public void EditCertification(string editcertificate)
        {
            //Edit Education Button
            EditCertificationBtn.Click();

            //Edit Education
            ClearCertificationText.Clear();
            EditCertificationText.SendKeys(editcertificate);


            //Click Update Education
            UpdateCertification.Click();

        }

        public void DeleteNewCertification()
        {
            //Delete Education            
            DeleteCertification.Click();

        }

    }
}
