using MVPInternMarsCompetition.Data;
using MVPInternMarsCompetition.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVPInternMarsCompetition.Pages
{
    public class LoginPage : BaseClass
    {
        public IWebElement SignInBtn => driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        public IWebElement Email => driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        public IWebElement Password => driver.FindElement(By.XPath("//INPUT[@type='password']"));
        public IWebElement LoginBtn => driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));

        public void SigninStep()
        {
            SignInBtn.Click();
            string text = File.ReadAllText(@"Data\Credentials.json");
            var credentials = JsonSerializer.Deserialize<Credentials>(text);

            Email.SendKeys(credentials.Username);
            Password.SendKeys(credentials.Password);
            LoginBtn.Click();
        }
    }
}
