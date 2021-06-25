using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using SkillSwap.Utilities;
using static SkillSwap.Utilities.CommonMethods;
using AutoItX3Lib;


namespace SkillSwap.Pages
{
    class ShareSkillPage
    {
        private readonly IWebDriver driver;
        private LoginPage logIn;

        //Page Factory

        //Finding the Share Skill Button
        IWebElement ShareSkillButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));

        IWebElement Title => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));

        IWebElement Description => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));

        IWebElement GraphicsDesign => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[2]"));

        IWebElement DigitalMarketing => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[3]"));

        IWebElement WritingTranslation => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[4]"));

        IWebElement VideoAnimation => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[5]"));

        IWebElement MusicAudio => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[6]"));

        IWebElement ProgrammingTech => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]"));

        IWebElement Business => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[8]"));

        IWebElement FunLifestyle => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[9]"));

        IWebElement SubCategory => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[2]"));

        IWebElement Tags => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

        IWebElement HourlyBasisService => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));

        IWebElement OneOffService => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));

        IWebElement Onsite => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));

        IWebElement Online => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        IWebElement StartDate => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));

        IWebElement EndDate => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));

        IWebElement SkillExchange => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));

        IWebElement Credit => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        IWebElement CreditServiceCharge => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input"));

        IWebElement SkillExchangeTag => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));

        IWebElement Active => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        IWebElement Hidden => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));

        IWebElement SaveButton => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));


        //Finding the Edit Button
        IWebElement Edit => driver.FindElement(By.XPath("//tbody/tr[1]/td[8]/div[1]/button[2]/i[1]"));

        IWebElement EditTitle => driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/input[1]"));

        IWebElement EditDescription => driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[2]/div[1]/div[2]/div[1]/textarea[1]"));

        IWebElement SaveB => driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[11]/div[1]/input[1]"));

        IWebElement UpdateTitle => driver.FindElement(By.XPath("//tbody/tr[1]/td[3]"));


        //Finding the delete Button
        IWebElement Delete => driver.FindElement(By.XPath("//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]"));

        IWebElement DeleteYes => driver.FindElement(By.XPath("//button[contains(text(),'Yes')]"));

        IWebElement Message => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]"));
        
             
        //Read Data from Excel
        private string title = ExcelLib.ReadData(1, "Title");
        private string description = ExcelLib.ReadData(1, "Description");
        private string category = ExcelLib.ReadData(1, "Category");
        private string tags = ExcelLib.ReadData(1, "Tags");
        private string serviceType = ExcelLib.ReadData(1, "ServiceType");
        private string locationType = ExcelLib.ReadData(1, "LocationType");
        private string skillTrade = ExcelLib.ReadData(1, "SkillTrade");
        private string active = ExcelLib.ReadData(1, "Active");
        private string skillExchangeTag = ExcelLib.ReadData(1, "SkillExchangeTag");
        private string creditServiceCharge = ExcelLib.ReadData(1, "CreditServiceCharge");
        private int addDaysToStartDate = Convert.ToInt32(ExcelLib.ReadData(1, "AddDaysInCurrentDateToStart"));
        private int addDaysToEndDate = Convert.ToInt32(ExcelLib.ReadData(1, "AddDaysInCurrentDateToEnd"));

        //Edit
        private string editTitle = ExcelLib.ReadData(1, "EditTitle");
        private string editDescription = ExcelLib.ReadData(1, "EditDescription");

        //Delete
        private string deleteMessage = ExcelLib.ReadData(1, "DeleteMessage");


        public ShareSkillPage(IWebDriver driver)
        {

            this.driver = driver;
            logIn = new LoginPage(driver);
        }



        public void createShareSkill()

        {
            logIn.LoginSteps();
            ClickShareSkill();
            EnterTitle(title);
            EnterDescription(description);
            SelectCategory(category);
            SelectSubCategory();
            EnterTags(tags);
            SelectServiceType(serviceType);
            SelectLocationType(locationType);
            EnterStartDate(addDaysToStartDate);
            EnterEndDate(addDaysToStartDate, addDaysToEndDate);
            SelectSkillTrade(skillTrade, skillExchangeTag, creditServiceCharge);
            //WorkSamples();
            SelectActive(active);
            ClickSaveButton();
        }

        public void ClickShareSkill()
        {
            
            //Click Share Skill Button from Profile Page

            ShareSkillButton.Click();
        }

        public void EnterTitle(string title)
        {
            
            //Enter Title
            Title.SendKeys(title);

        }

        public void EnterDescription(string description)
        {
            
            //Enter Description
            Description.SendKeys(description);
        }

        public void SelectCategory(string category)
        {
            
            switch (category)
            {
                    case "Graphics & Design":

                        GraphicsDesign.Click();
                        break;

                    case "Digital Marketing":
                        DigitalMarketing.Click();
                        break;

                    case "Writing & Translation":
                        WritingTranslation.Click();
                        break;

                    case "Video & Animation":
                        VideoAnimation.Click();
                        break;


                    case "Music & Audio":
                        MusicAudio.Click();
                        break;

                    case "Programming & Tech":
                        ProgrammingTech.Click();
                        break;

                    case "Business":
                        Business.Click();
                        break;


                    default:
                        FunLifestyle.Click();
                        break;

            }
        }

        public void SelectSubCategory()
        {
            
            SubCategory.Click();

        }

        public void EnterTags(string tags)
        {
            
            //Enter Tags
            Tags.SendKeys(tags);
            Tags.SendKeys(Keys.Enter);
        }           
    
        
        public void SelectServiceType(string serviceType)
        {
            
            if (serviceType == "Hourly basis service")
            {
                HourlyBasisService.Click();

            }
            else
            {
                OneOffService.Click();

            }          

        }

        public void SelectLocationType(string locationType)
        {
            
            if (locationType == "On-site")
            {
                    Onsite.Click();

            }
            else
            {
                    Online.Click();
            }
        }

        public void EnterStartDate(int addDaysToStartDate)
        {
            
            DateTime currentDate = DateTime.Now;

            StartDate.Clear();
            
            StartDate.SendKeys(currentDate.AddDays(addDaysToStartDate).ToString("yyyy-MM-dd"));
            

        }

        public void EnterEndDate(int addDaysToStartDate, int addDaysToEndDate)
        {
                            
            DateTime currentDate = DateTime.Now;
            EndDate.Clear();

              if (addDaysToStartDate > addDaysToEndDate)
              {
                    EndDate.SendKeys(currentDate.AddDays(addDaysToStartDate).ToString("yyyy-MM-dd"));
              }
              else
              {
                    EndDate.SendKeys(currentDate.AddDays(addDaysToEndDate).ToString("yyyy-MM-dd"));
              }
        }

        public void SelectSkillTrade(string skillTrade, string skillExchangeTag, string creditServiceCharge)
        {
           
            if (skillTrade == "Skill-exchange")
            {
                    SkillExchange.Click();
                    SkillExchangeTag.SendKeys(skillExchangeTag);
                    SkillExchangeTag.SendKeys(Keys.Enter);
            }
            else
            {
                    Credit.Click();
                    CreditServiceCharge.Clear();
                    CreditServiceCharge.SendKeys(creditServiceCharge);
            }
        }

        /*
        public void WorkSamples()
        {
            WorkSample.Click();
            //WorkSample.SendKeys(@"E:\Users\priyanka\Screenshot\Work-Samples.jpg");

            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("File Upload");
            autoIt.Send(ConstantUtils.WorkSamplePath);
            autoIt.Send("{ENTER}");   
        }*/

        public void SelectActive(string active)
        {
            
            if (active == "Active")
            {
                    Active.Click();
            }
            else
            {
                    Hidden.Click();
            }
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();

        }





        public void EditShareSkill(IWebDriver driver)
        {
            EditRecord(driver);
            ValidateServiceUpdatedSuccessfully(editTitle);           

        }

        public void EditRecord(IWebDriver driver)
        {
            
            //Edit Manage Listings            

            Edit.Click();

            EditTitle.Clear();

            EditTitle.SendKeys(editTitle);

            //Edit Description

            EditDescription.Clear();

            EditDescription.SendKeys(editDescription);

            SaveB.Click();

        }


        public bool ValidateServiceUpdatedSuccessfully(string editTitle)
        {
            
            //Wait.ElementExists(driver, "XPath", "//tbody/tr[1]/td[3]", 5);

            if (UpdateTitle.Text == editTitle)
            {
                return true;

            }
            else
            {
                return false;
            }

        }





        public void DeleteShareSkill(IWebDriver driver)
        {

            DeleteRecord(driver);
            ValidateServiceDeletedSuccessfully();
           
        }

        public void DeleteRecord(IWebDriver driver)
        {
            var deleteskillPage = new ShareSkillPage(driver);
            PageFactory.InitElements(driver, deleteskillPage);


            //Delete Manage Listings            

            deleteskillPage.Delete.Click();

            deleteskillPage.DeleteYes.Click();

        }


        public bool ValidateServiceDeletedSuccessfully()
        {
            var deleteskillPage = new ShareSkillPage(driver);
            PageFactory.InitElements(driver, deleteskillPage);

            if (deleteskillPage.Message.Displayed)
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
