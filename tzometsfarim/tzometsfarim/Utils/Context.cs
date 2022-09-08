using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace tzometsfarim.Utils
{
    public class Context
    {
        private static readonly IConfiguration _config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
        public IWebDriver chromeDriver = new ChromeDriver(_config.GetSection("driver").Value);
        //public IWebDriver fireFoxDriver = new ChromeDriver(@"C:\Users\W10-VIVI\Geckodriver");

    }
}
