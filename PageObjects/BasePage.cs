using OpenQA.Selenium;
using Locales;

namespace PageObjects
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public static Localization Localization { get; set; }

        public BasePage(IWebDriver drv, Localization localization) 
        { 
            driver = drv;
            Localization = localization;
        }    
    }
}