using Locales;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Locales;

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
            ///пример использования явного ожидания
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(BtnViewJobs));
            driver.FindElement(BtnViewJobs).Click();
            return new AllJobsPage(driver, Localization);
        }

        public static By BtnViewJobs => By.XPath($"//button[contains(text(),'{Locales.Locales.ViewJobs(Localization)}')]");
    }
}