using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using tzometsfarim.Utils;

namespace tzometsfarim
{
    [Binding]
    public class Hooks
    {
        private Context _context;
        public Hooks(Context context)
        {
            _context = context;
        }

        [AfterScenario]
        public void AfterEachScenario()
        {
            _context.chromeDriver.Close();      
            _context.chromeDriver.Quit();
            _context.chromeDriver.Dispose();
        }
    }
}
