using Locales;
using OpenQA.Selenium;

namespace PageObjects
{
    /// <summary>
    /// Класс страницы Вакансии
    /// </summary>
    public class CarreersPage : BasePage
    {
        public CarreersPage(IWebDriver drv, Localization localization) : base(drv, localization)
        {
        }

        public AllJobsPage OpenAllJobs()
        {
            driver.FindElement(BtnViewJobs).Click();
            return new AllJobsPage(driver, Localization);
        }

        public static By BtnViewJobs => By.XPath($"//button[contains(text(),'{Locales.Locales.ViewJobs(Localization)}')]");
    }
}