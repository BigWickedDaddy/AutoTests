using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoTests_Two;

public class TestBase
{
    private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;
    private bool acceptNextAlert = true;

    [SetUp]
    public void SetupTest()
    {
        driver = new ChromeDriver("/Users/olegsolovyanenko/RiderProjects/AutoTests_One/AutoTests_One/bin/Debug/net6.0");
        baseURL = "https://www.google.com/";
        verificationErrors = new StringBuilder();
    }

    [TearDown]
    public void TeardownTest()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }

        Assert.AreEqual("", verificationErrors.ToString());
    }

    public void SaveProfileChanges()
    {
        driver.FindElement(By.Name("save")).Click();
    }

    public void GetNewNotes()
    {
        driver.FindElement(By.Name("PERSONAL_NOTES")).Click();
        driver.FindElement(By.Name("PERSONAL_NOTES")).Clear();
        driver.FindElement(By.Name("PERSONAL_NOTES")).SendKeys("testovoe message");
        driver.FindElement(By.XPath("//div[@id='main']/main/main/div/form/div/div/div/div[2]")).Click();
    }

    public void GotoProfilePage()
    {
        driver.Navigate().GoToUrl("https://cybermos.ru/panel/user/config/");
    }

    public void LogIn()
    {
        driver.FindElement(By.Name("Login")).Click();
    }

    public void GetAccKeys(AccountData user)
    {
        driver.FindElement(By.Name("USER_LOGIN")).Click();
        driver.FindElement(By.Name("USER_LOGIN")).Clear();
        driver.FindElement(By.Name("USER_LOGIN")).SendKeys(user.Username);
        driver.FindElement(By.Name("USER_PASSWORD")).Click();
        driver.FindElement(By.Name("USER_PASSWORD")).Clear();
        driver.FindElement(By.Name("USER_PASSWORD")).SendKeys(user.Password);
    }

    public void OpenLogInPage()
    {
        driver.Navigate().GoToUrl("https://cybermos.ru/panel/user/config/");
    }

    private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }

            return alertText;
        }
        finally
        {
            acceptNextAlert = true;
        }
    }
}