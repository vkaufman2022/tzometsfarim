using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tzometsfarim.Utils
{
    public class BookActions
    {
        public static void AddToCartAndContinue(IWebDriver driver,WebDriverWait wait,string XpathButton,string cssContinueToBuy)
        {
            var addToCartButton = wait.Until(product => product.FindElement(By.XPath(XpathButton)));
            addToCartButton.Click();
            var continueToBuy = wait.Until(elemnt => driver.FindElement(By.CssSelector(cssContinueToBuy)));
            continueToBuy.Click();
        }
        
    }
}
