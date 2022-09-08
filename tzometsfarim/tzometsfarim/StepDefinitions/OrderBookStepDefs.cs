using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Xml.Linq;
using tzometsfarim.Utils;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Support.UI;
using Ocelot.Infrastructure;
using Telerik.JustMock;

namespace tzometsfarim.StepDefinitions
{
    [Binding]
    public sealed class OrderBookStepDefs
    {
        private IWebDriver _driver;
        private Context _context;
        IWebElement _menuPage;
        private string _menuClassName = "menu";
        private string _menuAttributeAriaPressed = "aria-pressed";
        private string _cssSelectorForProducts = "div.products.product-cube.col-md-2";
        private string _productId1 = "222130";
        private string _productId2 = "171234";
        private string _xPathForAddToCartButton1 = "//*[@id=\"jumptohere\"]/section/div[2]/div/div[3]/div/button";
        private string _xPathForAddToCartButton2 = "//*[@id=\"jumptohere\"]/section/div[2]/div/div[5]/div/button";
        private string _cssSelectorForContinueToBuyButton = "button.link-button.oprs";
        private string _xPathCart = "//*[@id=\"header\"]/nav/div/div/div[2]/a/img";
        private string _xPathConitueToPay = "//*[@id=\"jumptohere\"]/section/div[2]/div[1]/p[1]/a/img";
        private WebDriverWait _wait;
        private string _dataProductIdAttribute = "data-prodid";


        public OrderBookStepDefs(Context context)
        {
            _context = context;
        }

        [Given(@"in (.*) browser user navigate to site - (.*)")]
        public void GivenInBroswerUserNavigateToSite(string browser,string url)
        {

            switch(browser)
            {
                case "chrome":
                    _driver=_context.chromeDriver;
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--lang=he-IL");            
                    break;
                default:
                    Assert.Fail($"{browser} not supported browser");
                    break;
            }
            try
            {
                _driver.Navigate().GoToUrl(url);
                _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 2));
            }catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }


        [When(@"in menu user choses (.*) , then (.*)")]
        public void WhenUserChoosesThenThen(string locatorText1, string locatorText2)
        {
            try
            {
                _menuPage = _wait.Until(page => _driver.FindElement(By.ClassName(_menuClassName)));
                _menuPage.Click();
                var areaPressed = _menuPage.GetAttribute(_menuAttributeAriaPressed);
                if (areaPressed.Equals("true"))
                {
                    var element2 = _wait.Until(element => _menuPage.FindElement(By.XPath($"//*[contains(text(),'{locatorText1}')]")));
                    element2.Click();
                    var element3 = _wait.Until(element => element2.FindElement(By.XPath($"//*[contains(text(),'{locatorText2}')]")));
                    element3.Click();
                }

            }catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        [When(@"on (.*) page user adds two books to cart")]
        public void WhenOnSalesPageUserAddsBooksToCart(string page)
        {
            try
            {
                var products = _wait.Until(element=>_driver.FindElements(By.CssSelector(_cssSelectorForProducts)));
                foreach (var product in products)
                {
                    if (product.GetAttribute(_dataProductIdAttribute).Equals(_productId1))
                    {
                        BookActions.AddToCartAndContinue(_driver,_wait, _xPathForAddToCartButton1, _cssSelectorForContinueToBuyButton);
                    }
                    if (product.GetAttribute(_dataProductIdAttribute).Equals(_productId2))
                    {
                        BookActions.AddToCartAndContinue(_driver, _wait, _xPathForAddToCartButton2, _cssSelectorForContinueToBuyButton);
                    }
                }
            }catch (Exception e)
            {
                Console.WriteLine("Failed to add books to cart and continue",e);
            }
        }

        [When(@"user checkout to cart and filled the following fileds")]
        public void WhenUserCheckoutToCartAndFilledTheFollowingFileds(Table table)
        {
            try
            {
                var userDetails = table.CreateInstance<UserPersonalDetails>();
                var cart = _wait.Until(element => _driver.FindElement(By.XPath(_xPathCart)));
                if (cart.Displayed)
                {
                    cart.Click();
                }
                else
                    Assert.Fail("Cart object is missing on a page");
                var continueToPay = _wait.Until(element => _driver.FindElement(By.XPath(_xPathConitueToPay)));
                if (continueToPay.Displayed)
                {
                    continueToPay.Click();
                }
                else
                    Assert.Fail("Continue To Pay button is missing on a page");

                CustomerActions.AddPersonalDetails(_driver, _wait, userDetails);
            }catch(Exception e)
            {
                Console.WriteLine("Failed to fill customer personal details", e);

            }

        }


    }
}