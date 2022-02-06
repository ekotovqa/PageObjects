using Locales;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace PageObjects
{   
    /// <summary>
    /// Класс страницы Все вакансии
    /// </summary>
    public class AllJobsPage : BasePage
    {
        public static Uri Uri { get; set; } = new Uri("https://careers.veeam.ru/vacancies");

        public AllJobsPage(IWebDriver drv, Localization localization) : base(drv, localization)
        {
        }

        public AllJobsPage Open()
        {
            driver.Navigate().GoToUrl(Uri);
            return this;
        }

        /// <summary>
        /// Метод устанавливает отдел в фильтре
        /// </summary>
        /// <param name="department">Выбираемый отдел</param>
        /// <returns></returns>
        public AllJobsPage SelectDepartment(string department) 
        {
            driver.FindElement(BtnAllDepartments).Click();
            driver.FindElement(BtnDepartment(department)).Click();
            return this;
        }

        /// <summary>
        /// Метод устанавливает язык в фильтре
        /// </summary>
        /// <param name="language">Выбираемый язык</param>
        /// <returns></returns>
        public AllJobsPage SelectLanguage(string language)
        {
            driver.FindElement(BtnAllLanguages).Click();
            if (!driver.FindElement(LabelLanguage(language)).Selected)
            {
                driver.FindElement(LabelLanguage(language)).Click();
            }
            return this;
        }

        public AllJobsPage SelectLanguage(List<string> language)
        {   
            // TODO реализация выбора нескольких языков
            return this;
        }

        public static By BtnAllDepartments => By.XPath("//button[contains(text(),'Все отделы')]");
        public static By BtnDepartment(string department) => By.XPath($"//a[contains(text(),'{department}')]");
        public static By BtnAllLanguages => By.XPath("//button[contains(text(),'Все языки')]");
        public static By LabelLanguage(string language) => By.XPath($"//label[contains(text(),'{language}')]");
        public static By JobCard => By.XPath("//a[contains(@class,'card')]");





    }
}