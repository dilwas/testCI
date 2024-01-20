using MVPInternMarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.CacheStorage;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPInternMarsCompetition.Pages
{
    public class EducationPage : BaseClass
    {
        public IWebElement AddNewBtn => driver.FindElement(By.XPath("(//div[@class='ui teal button '])[2]"));
        public IWebElement AddBtn => driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        public ReadOnlyCollection<IWebElement> EducationRecords => driver.FindElements(By.XPath("//div[@data-tab='third']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        public IWebElement DeleteIcn => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement EducationTab => driver.FindElement(By.XPath("//a[@data-tab='third']"));
        public IWebElement UniversityNameTxt => driver.FindElement(By.Name("instituteName"));
        public IWebElement CountryDdn => driver.FindElement(By.Name("country"));
        public IWebElement TitleDdn => driver.FindElement(By.Name("title"));
        public IWebElement DegreeTxt => driver.FindElement(By.Name("degree"));
        public IWebElement YearDdn => driver.FindElement(By.Name("yearOfGraduation"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//INPUT[@class='ui button'][@value='Cancel']"));
        public IWebElement UniversityNameLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        public IWebElement CountryLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]"));
        public IWebElement TitleLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]"));
        public IWebElement DegreeLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[4]"));
        public IWebElement YearLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[5]"));
        public IWebElement UniversityNameLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[2]"));
        public IWebElement CountryLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[1]"));
        public IWebElement TitleLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[3]"));
        public IWebElement DegreeLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[4]"));
        public IWebElement YearLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[5]"));
        public IWebElement UniversityNameLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[2]"));
        public IWebElement CountryLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[1]"));
        public IWebElement TitleLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[3]"));
        public IWebElement DegreeLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[4]"));
        public IWebElement YearLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[5]"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement EditIcn => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[6]/span[1]/i"));
        public IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        public ReadOnlyCollection<IWebElement> AddNewFields => driver.FindElements(By.XPath("//DIV[@class='fields']"));
        
        public void ClearAllEducationRecords()
        {
            EducationTab.Click();

            //tbody count
            int records = EducationRecords.Count();
            Console.WriteLine(records);
            //loop first delete icon
            for (int i = 0; i < records; i = i + 1)
            {
                Console.WriteLine(i);
                DeleteIcn.Click();
                Thread.Sleep(2000);
            }
        }

        public void AddEducation(string universityName, string country, string title, string year, string degree)
        {
            EducationTab.Click();
            AddNewBtn.Click();
            UniversityNameTxt.SendKeys(universityName);

            //create select element object 
            var selectElement = new SelectElement(CountryDdn);
            selectElement.SelectByValue(country);

            selectElement = new SelectElement(TitleDdn);
            selectElement.SelectByValue(title);

            DegreeTxt.SendKeys(degree);

            selectElement = new SelectElement(YearDdn);
            selectElement.SelectByValue(year);

            AddBtn.Click();
        }

        public void CancelAddingEducationRecord()
        {
            EducationTab.Click();
            Thread.Sleep(3000);
            AddNewBtn.Click();
            CancelBtn.Click();
        }

        //Edit education
        public void EditEducationSingleField(string value, string field)
        {
            Thread.Sleep(1000);
            EditIcn.Click();

            switch (field)
            {
                case "University":
                    UniversityNameTxt.Clear();
                    UniversityNameTxt.SendKeys(value);
                    break;
                case "Country":
                    var selectElement = new SelectElement(CountryDdn);
                    selectElement.SelectByValue(value);
                    break;
                case "Title":
                    selectElement = new SelectElement(TitleDdn);
                    selectElement.SelectByValue(value);
                    break;
                case "YearOfGraduation":
                    selectElement = new SelectElement(YearDdn);
                    selectElement.SelectByValue(value);
                    break;
                case "Degree":
                    DegreeTxt.Clear();
                    DegreeTxt.SendKeys(value);
                    break;
            }
            UpdateBtn.Click();
        }

        public void EditEducationRecord(string updatedUniversityName, string updatedCountry, string updatedTitle, string updatedYear, string updatedDegree)
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            UniversityNameTxt.Clear();
            UniversityNameTxt.SendKeys(updatedUniversityName);
            var selectElement = new SelectElement(CountryDdn);
            selectElement.SelectByValue(updatedCountry);

            selectElement = new SelectElement(TitleDdn);
            selectElement.SelectByValue(updatedTitle);

            selectElement = new SelectElement(YearDdn);
            selectElement.SelectByValue(updatedYear);

            DegreeTxt.Clear();
            DegreeTxt.SendKeys(updatedDegree);
            UpdateBtn.Click();
        }

        //Delete education
        public void DeleteEducationRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }

        public void AddNewEducationRecordWithoutRequirdFeilds(string universityName, String country, string title, string year, string degree)
        {
            EducationTab.Click();
            AddNewBtn.Click();
            if (universityName != null)
            {
                UniversityNameTxt.SendKeys(universityName);
            }

            //create select element object 
            var selectElement =new SelectElement(CountryDdn);
            if (country != null)
            {
               selectElement.SelectByValue(country);
            }

            selectElement =new SelectElement(TitleDdn);
             if (title != null)
            {
              selectElement.SelectByValue(title);
            }

            if(degree != null)
            {
                DegreeTxt.SendKeys(degree);
            }

            selectElement = new SelectElement(YearDdn);
            if (year !=null)
            {
                selectElement.SelectByValue(year);
            }
            AddBtn.Click();
        }

        public void EditExistingEducationRecordWithOutChangingAnyFields()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            UpdateBtn.Click();
        }
    }
}
