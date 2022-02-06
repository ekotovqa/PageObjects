using NUnit.Framework;
using PageObjects;
using Locales;

namespace Tests
{
    public class CareersPageTests : BaseTest
    {
        [Test]
        [TestCase(Localization.ru, 5)]
        [TestCase(Localization.ru, 4)]
        [TestCase(Localization.de, 4)]
        [TestCase(Localization.com, 6)]
        public void NumberAllJobsTest(Localization local, int expectedResultJobs) 
        {
            var testPage = new VeeamMainPage(driver, local);
            testPage
                .Open()
                .OpenCompanySection()
                .OpenCareersSubMenu();
            if (driver.WindowHandles.Count > 1)
            {
                driver.SwitchTo().Window(driver.WindowHandles[1]);
            }
            var carrersPage = new CarreersPage(driver, local);
            carrersPage.OpenAllJobs();
            var allJobsPage = new AllJobsPage(driver, local);
            if (local == Localization.ru)
            {
                allJobsPage.SelectDepartment("Разработка продуктов").SelectLanguage("Английский");
                int actualResultJobs = driver.FindElements(AllJobsPage.JobCard).Count;
                Assert.AreEqual(expectedResultJobs, actualResultJobs, $"Фактическое число вакансиий:{actualResultJobs} не соответствует ожидаемому: {expectedResultJobs}");
                driver.SwitchTo().Window(driver.WindowHandles[0]);
            }
            else
            {
                ///TODO реализация для com, de
            }            
        }

        [Test]
        [TestCase(5)]
        [TestCase(4)]
        [TestCase(2)]
        public void SimpleNumberAllJobsTest(int expectedResultJobs)
        {
            var allJobsPage = new AllJobsPage(driver, Localization.ru);
            allJobsPage.Open();
            allJobsPage.SelectDepartment("Разработка продуктов").SelectLanguage("Английский");
            int actualResultJobs = driver.FindElements(AllJobsPage.JobCard).Count;
            Assert.AreEqual(expectedResultJobs, actualResultJobs, $"Фактическое число вакансиий:{actualResultJobs} не соответствует ожидаемому: {expectedResultJobs}");
        }
    }
}
