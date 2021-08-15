using NUnit.Framework;
using OpenQA.Selenium;


namespace veeamTest
{
    public class Tests
    {
        private IWebDriver Browser;

        private readonly By _AllDepartmentsButton = By.XPath("//button[text()='Все отделы']");
        private readonly By _SelectedDepartmentButton = By.LinkText("Разработка продуктов");

        private readonly By _AllLanguagesButton = By.XPath("//Button[text()='Все языки']");
        private readonly By _SelectedLangaugeButton = By.XPath("//Label[text()='Английский']");

        private int _ExpectedVacanciesQuantity=6;




        [SetUp]
        public void Setup()
        {
            Browser = new OpenQA.Selenium.Opera.OperaDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");
        }

        [Test]
        public void Test1()
        {
            Browser.FindElement(_AllDepartmentsButton).Click();
            Browser.FindElement(_SelectedDepartmentButton).Click();

            Browser.FindElement(_AllLanguagesButton).Click();
            Browser.FindElement(_SelectedLangaugeButton).Click();

            Assert.AreEqual(_ExpectedVacanciesQuantity, GetVacanciesQuantity());

        }

        [TearDown]

        public void TearDown()
        {
            Browser.Close();
        }

        public int GetVacanciesQuantity()
        {
            return Browser.FindElements(By.LinkText("ПОДРОБНЕЕ")).Count;
        }






    }
}
