using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SocialTrade
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            
            //Navigate to google page
            driver.Navigate().GoToUrl("https://www.socialtrade.biz/login.aspx");

            //Find the Search text box UI Element
            IWebElement element = driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$txtEmailID"));

            //Perform Ops
            element.SendKeys("61031202");

            //Close the browser
            driver.Close();
        }


    }
    public static class Utlity
    {
        public static void WaitForElementToAppear(this ISearchContext driver, By locator)
        {
            driver.TimerLoop(() => driver.FindElement(locator).Displayed, false, "Timeout: Element not visible at: " + locator);
        }

        public static void TimerLoop(this ISearchContext driver, Func<bool> isComplete, bool exceptionCompleteResult, string timeoutMsg)
        {

            const int timeoutinteger = 10;

            for (int second = 0; ; second++)
            {
                try
                {
                    if (isComplete())
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg);
                }
                catch (Exception ex)
                {
                    if (exceptionCompleteResult)
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg, ex);
                }
                Thread.Sleep(100);
            }
        }
    }
}
