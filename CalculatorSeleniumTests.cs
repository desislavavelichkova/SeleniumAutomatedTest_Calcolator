using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Calculator
{
    public class CalculatorSeleniumTests
    {
        IWebDriver driver;
        IWebElement firstNumber;
        IWebElement secondNumber;
        IWebElement operation;
        IWebElement calculateBtn;
        IWebElement resetBtn;
        IWebElement result;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            firstNumber = driver.FindElement(By.Id("number1"));
            secondNumber = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculateBtn = driver.FindElement(By.Id("calcButton"));
            resetBtn = driver.FindElement(By.Id("resetButton"));
            result = driver.FindElement(By.Id("result"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestCase("1", "+", "2", "Result: 3")]
        [TestCase("1", "-", "2", "Result: -1")]
        [TestCase("1", "*", "2", "Result: 2")]
        [TestCase("6", "/", "2", "Result: 3")]
        public void TestCalculator_PositiveValidInteger(string num1, string op, string num2, string expectedResult)
        {
            resetBtn.Click();
            if (num1 != "")
            {
                firstNumber.SendKeys(num1);
            }
            if (op != "")
            {
                operation.SendKeys(op);
            }
            if (num2 != "")
            {
                secondNumber.SendKeys(num2);
            }

            calculateBtn.Click();            
            Assert.AreEqual(expectedResult, result.Text);

        }
        [TestCase("1.22", "+", "2.11", "Result: 3.33")]
        [TestCase("1.899", "-", "0.888", "Result: 1.011")]
        [TestCase("2.222", "*", "2.666", "Result: 5.923852")]
        [TestCase("6.6666", "/", "-2.2e222", "Result: -3.03027272727e-222")]
        public void TestCalculator_PositiveValidDecimal(string num1, string op, string num2, string expectedResult)
        {
            resetBtn.Click();
            if (num1 != "")
            {
                firstNumber.SendKeys(num1);
            }
            if (op != "")
            {
                operation.SendKeys(op);
            }
            if (num2 != "")
            {
                secondNumber.SendKeys(num2);
            }

            calculateBtn.Click();
            Assert.AreEqual(expectedResult, result.Text);

        }

        [TestCase("1.2e2", "+", "2.11", "Result: 122.11")]
        [TestCase("1.8e99", "-", "0.888", "Result: 1.8e+99")]
        [TestCase("2.2e22", "*", "2.666", "Result: 5.8652e+22")]
        [TestCase("1.5e53", "/", "-125", "Result: -1.2e+51")]
        public void TestCalculator_ExponentialNumbers(string num1, string op, string num2, string expectedResult)
        {
            resetBtn.Click();
            if (num1 != "")
            {
                firstNumber.SendKeys(num1);
            }
            if (op != "")
            {
                operation.SendKeys(op);
            }
            if (num2 != "")
            {
                secondNumber.SendKeys(num2);
            }

            calculateBtn.Click();
            Assert.AreEqual(expectedResult, result.Text);

        }

        [TestCase("", "+", "2", "Result: invalid input")]
        [TestCase("", "-", "2", "Result: invalid input")]
        [TestCase("1", "*", "", "Result: invalid input")]
        [TestCase("1", "/", "", "Result: invalid input")]
        [TestCase("1", "/", "qwe", "Result: invalid input")]
        [TestCase("qqqq", "/", "2", "Result: invalid input")]
        [TestCase("qqqq", "/", "ddd", "Result: invalid input")]
        [TestCase("1.3", "/", "ssss", "Result: invalid input")]
        public void TestCalculator_InvalidInputs(string num1, string op, string num2, string expectedResult)
        {
            resetBtn.Click();
            if (num1 != "")
            {
                firstNumber.SendKeys(num1);
            }
            if (op != "")
            {
                operation.SendKeys(op);
            }
            if (num2 != "")
            {
                secondNumber.SendKeys(num2);
            }

            calculateBtn.Click();
            Assert.AreEqual(expectedResult, result.Text);

        }

        [TestCase("1", "@", "2", "Result: invalid operation")]
        [TestCase("1", "dsd", "2", "Result: invalid operation")]
        [TestCase("1", "@####", "2", "Result: invalid operation")]
        [TestCase("1", "", "2", "Result: invalid operation")]
        [TestCase("1", "!!!!", "2", "Result: invalid operation")]

        public void TestCalculator_InvalidOperation(string num1, string op, string num2, string expectedResult)
        {
            resetBtn.Click();
            if (num1 != "")
            {
                firstNumber.SendKeys(num1);
            }
            if (op != "")
            {
                operation.SendKeys(op);
            }
            if (num2 != "")
            {
                secondNumber.SendKeys(num2);
            }

            calculateBtn.Click();
            Assert.AreEqual(expectedResult, result.Text);

        }
        [TestCase("Infinity", "+", "2", "Result: Infinity")]
        [TestCase("Infinity", "-", "2", "Result: Infinity")]
        [TestCase("Infinity", "*", "2", "Result: Infinity")]
        [TestCase("Infinity", "/", "2", "Result: Infinity")]

        [TestCase("1", "+", "Infinity", "Result: Infinity")]
        [TestCase("1", "-", "Infinity", "Result: -Infinity")]
        [TestCase("1", "*", "Infinity", "Result: Infinity")]
        [TestCase("1", "/", "Infinity", "Result: 0")]

        [TestCase("Infinity", "+", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "-", "Infinity", "Result: invalid calculation")]
        [TestCase("Infinity", "*", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "/", "Infinity", "Result: invalid calculation")]

        public void TestCalculator_InfinityInput(string num1, string op, string num2, string expectedResult)
        {
            resetBtn.Click();
            if (num1 != "")
            {
                firstNumber.SendKeys(num1);
            }
            if (op != "")
            {
                operation.SendKeys(op);
            }
            if (num2 != "")
            {
                secondNumber.SendKeys(num2);
            }

            calculateBtn.Click();
            Assert.AreEqual(expectedResult, result.Text);

        }
    }
}