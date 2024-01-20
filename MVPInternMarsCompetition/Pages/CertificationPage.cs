using MVPInternMarsCompetition.Data;
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
    public class CertificationPage : BaseClass
    {
        public IWebElement AddNewBtn => driver.FindElement(By.XPath("(//div[@class='ui teal button '])[3]"));
        public IWebElement AddBtn => driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        public ReadOnlyCollection<IWebElement> CertificationRecords => driver.FindElements(By.XPath("//div[@data-tab='fourth']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        public IWebElement DeleteIcn => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement CertificationTab => driver.FindElement(By.XPath("//a[@data-tab='fourth']"));
        public IWebElement CertificateTxt => driver.FindElement(By.Name("certificationName"));
        public IWebElement FromTxt => driver.FindElement(By.Name("certificationFrom"));
        public IWebElement YearDdn => driver.FindElement(By.Name("certificationYear"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//INPUT[@class='ui button'][@value='Cancel']"));
        public IWebElement CertificateLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]"));
        public IWebElement FromLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        public IWebElement YearLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]"));
        public IWebElement CertificateLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[1]"));
        public IWebElement FromLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[2]"));
        public IWebElement YearLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[3]"));
        public IWebElement CertificateLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[1]"));
        public IWebElement FromLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[2]"));
        public IWebElement YearLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[3]"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement EditIcn => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[4]/span[1]/i"));
        public IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        public ReadOnlyCollection<IWebElement> AddNewFields => driver.FindElements(By.XPath("//DIV[@class='fields']"));
        
        public void ClearAllCertificationRecords()
        {
            CertificationTab.Click();

            //tbody count
            int records = CertificationRecords.Count();
            Console.WriteLine(records);
            //loop first delete icon
            for (int i = 0; i < records; i = i + 1)
            {
                Console.WriteLine(i);
                DeleteIcn.Click();
                Thread.Sleep(2000);
            }
        }

        public void AddCertification(string certificate, string from, string year)
        {
            CertificationTab.Click();
            AddNewBtn.Click();
            CertificateTxt.SendKeys(certificate);

            //create select element object 
            FromTxt.SendKeys(from);

            var selectElement = new SelectElement(YearDdn);
            selectElement.SelectByValue(year);
            AddBtn.Click();
        }

        public void CancelAddingCertificationRecord()
        {
            CertificationTab.Click();
            Thread.Sleep(3000);
            AddNewBtn.Click();
            CancelBtn.Click();
        }

        //Edit education
        public void EditCertificationSingleField(string value, string field)
        {
            Thread.Sleep(1000);
            EditIcn.Click();

            switch (field)
            {
                case "Certificate":
                    CertificateTxt.Clear();
                    CertificateTxt.SendKeys(value);
                    break;
                case "From":
                    FromTxt.Clear();
                    FromTxt.SendKeys(value);
                    break;

                case "Year":
                    var selectElement = new SelectElement(YearDdn);
                    selectElement.SelectByValue(value);
                    break;
            }
            UpdateBtn.Click();
        }

        public void EditCertificationRecord(string updatedCertificate, string updatedFrom, string updatedYear)
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            CertificateTxt.Clear();
            CertificateTxt.SendKeys(updatedCertificate);

            FromTxt.Clear();
            FromTxt.SendKeys(updatedFrom);

            var selectElement = new SelectElement(YearDdn);
            selectElement.SelectByValue(updatedYear);

            UpdateBtn.Click();
        }

        //Delete certification
        public void DeleteCertificationRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }

        public void AddNewCertificationRecordWithoutRequirdFeilds(string certificate, string from, string year)
        {
            CertificationTab.Click();
            AddNewBtn.Click();
            if (certificate != null)
            {
                CertificateTxt.SendKeys(certificate);
            }

            //create select element object 

            if(from != null)
            {
                FromTxt.SendKeys(from);
            }

            var selectElement = new SelectElement(YearDdn);
            if (year !=null)
            {
                selectElement.SelectByValue(year);
            }
            AddBtn.Click();
        }

        public void EditExistingCertificationRecordWithOutChangingAnyFields()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            UpdateBtn.Click();
        }
    }
}
