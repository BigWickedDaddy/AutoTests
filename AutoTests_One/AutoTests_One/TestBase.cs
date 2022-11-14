namespace AutoTests_One;

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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

    public void OpenProfilePage()
    {
        driver.Navigate()
            .GoToUrl(
                "https://shelly.kpfu.ru/e-ksu/main_blocks.startpage?p2=18999772456528481431361316924199&p_h=E0E43C185E595DFC142A11B90E81F52E");
        Thread.Sleep(2000);
    }

    public void LoginInto(AccountData user)
    {
        driver.FindElement(By.Name("p_login")).Click();
        driver.FindElement(By.Name("p_login")).Clear();
        driver.FindElement(By.Name("p_login")).SendKeys(user.Username);

        driver.FindElement(By.Name("p_pass")).Click();
        driver.FindElement(By.Name("p_pass")).Clear();
        driver.FindElement(By.Name("p_pass")).SendKeys(user.Password);
        
        driver.FindElement(By.XPath(
                "(.//*[normalize-space(text()) and normalize-space(.)='Елабужский институт КФУ'])[1]/following::div[1]"))
            .Click();
        driver.FindElement(By.XPath("//input[@value='Отправить']")).Click();
    }

    public void OpenLoginPage()
    {
        driver.Navigate().GoToUrl("https://kpfu.ru/");
        driver.FindElement(By.LinkText("Личный кабинет")).Click();
        driver.FindElement(By.XPath(
                "(.//*[normalize-space(text()) and normalize-space(.)='Елабужский институт КФУ'])[1]/following::div[1]"))
            .Click();
    }

    public void SendMail()
    {
        driver.FindElement(By.XPath("//div[@id='under-slider-menu']/div/a[3]/i")).Click();
        driver.Navigate().GoToUrl("https://shelly.kpfu.ru/e-ksu/private_message.myprocedure");
        driver.FindElement(By.Id("11749")).Click();
        driver.FindElement(By.LinkText("Ответить")).Click();
        driver.FindElement(By.Id("p_text")).Click();
        driver.FindElement(By.Id("p_text")).Clear();
        driver.FindElement(By.Id("p_text")).SendKeys("ты лох");
        driver.FindElement(By.XPath("//input[@value='Отправить сообщение']")).Click();
        driver.Navigate().GoToUrl("https://shelly.kpfu.ru/e-ksu/private_message.message_script");
        driver.Navigate().GoToUrl("https://shelly.kpfu.ru/e-ksu/private_message.myprocedure");
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