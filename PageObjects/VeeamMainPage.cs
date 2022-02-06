using Locales;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects
{
    /// <summary>
    /// Класс главной страницы
    /// </summary>
    public class VeeamMainPage : BasePage
    {
        static Uri Uri { get; set; }
        public VeeamMainPage(IWebDriver drv, Localization localization) : base(drv, localization)
        {

            switch (Localization)
            {
                case Localization.ru:
                    Uri = new Uri("https://veeam.com/ru");
                    break;
                case Localization.com:
                    Uri = new Uri("https://veeam.com");
                    break;
                case Localization.de:
                    Uri = new Uri("https://veeam.com/de");
                    break;
            }
        }

        public VeeamMainPage Open()
        {
            driver.Navigate().GoToUrl(Uri);
            return this;
        }

        /// <summary>
        /// Метод открывает секцию меню Компания
        /// </summary>
        /// <returns></returns>
        public CompanySectionMainPage OpenCompanySection()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(CompanySection)).Build().Perform();
            return new CompanySectionMainPage(driver, Localization);
        }

        static By CompanySection => By.XPath($"//span[@class='main-navigation__item-title' and contains(text(),'{Locales.Locales.Company(Localization)}')]");
    }
}
