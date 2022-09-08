using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tzometsfarim.Utils
{
    public class CustomerActions
    {
        private static string _xPathEmail = "//*[@id=\"email\"]";
        private static string _xPathName = "//*[@id=\"customerFirstName\"]";
        private static string _xPathSurname = "//*[@id=\"customerLastName\"]";
        private static string _xPathCell = "//*[@id=\"phone\"]";
        private static string _xPathCity = "//*[@id=\"city\"]";
        private static string _xPathStreet = "//*[@id=\"street\"]";
        private static string _xPathHomeNumber = "//*[@id=\"homenum\"]";
        public static void AddPersonalDetails(IWebDriver driver, WebDriverWait wait, UserPersonalDetails userPersonalDetails)
        {

            var email = wait.Until(element => driver.FindElement(By.XPath(_xPathEmail)));
            var cell = wait.Until(element => driver.FindElement(By.XPath(_xPathCell)));
            var name = wait.Until(element => driver.FindElement(By.XPath(_xPathName)));
            var surname = wait.Until(element => driver.FindElement(By.XPath(_xPathSurname)));
            var city = wait.Until(element => driver.FindElement(By.XPath(_xPathCity)));
            var street = wait.Until(element => driver.FindElement(By.XPath(_xPathStreet)));
            var homeNum = wait.Until(element => driver.FindElement(By.XPath(_xPathHomeNumber)));

            email.SendKeys(userPersonalDetails.Email);
            cell.SendKeys(userPersonalDetails.Cell);
            city.SendKeys(userPersonalDetails.City);
            name.SendKeys(userPersonalDetails.Name);
            surname.SendKeys(userPersonalDetails.Surname);
            street.SendKeys(userPersonalDetails.Street);
            homeNum.SendKeys(userPersonalDetails.HomeNumber);

        }
    }
}
