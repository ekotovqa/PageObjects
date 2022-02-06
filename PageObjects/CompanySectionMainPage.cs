using Locales;
using OpenQA.Selenium;

namespace PageObjects
{
    /// <summary>
    /// Класс секции Компания меню главной страницы
    /// </summary>
    public class CompanySectionMainPage : VeeamMainPage
    {

        public CompanySectionMainPage(IWebDriver drv, Localization localization) : base(drv, localization)
        {
        }

        public CarreersPage OpenCareersSubMenu()
        {
            driver.FindElement(MainMenuCompanySection).Click();
            return new CarreersPage(driver, Localization);
        }
        public static By MainMenuCompanySection => By.XPath($"//a[@class='list-of-links__link' and contains(text(),'{Locales.Locales.Careers(Localization)}')]");
    }
}