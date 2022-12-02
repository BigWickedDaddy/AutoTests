using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using AutoTests_Two.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoTests_Two;

public class LoginHelper : HelperBase
{
    private bool isLoggedIn { get; set; }

    private string Username { get; set; }
    
    public LoginHelper(ApplicationManager applicationManager) : base(applicationManager)
    {
        
    }

    public void OpenLogInPage()
    {
        driver.Navigate().GoToUrl("https://cybermos.ru/panel/user/config/");
    }

    public void LogIn()
    {
        driver.FindElement(By.Name("Login")).Click();
        
    }

    public void GetAccKeys(AccountData user)
    {
        
        if (IsLoggedIn())
        {
            if (IsLoggedIn(user.Username))
            {
                return;
            }
            Logout();
        }
        
        driver.FindElement(By.Name("USER_LOGIN")).Click();
        driver.FindElement(By.Name("USER_LOGIN")).Clear();
        driver.FindElement(By.Name("USER_LOGIN")).SendKeys(user.Username);
        driver.FindElement(By.Name("USER_PASSWORD")).Click();
        driver.FindElement(By.Name("USER_PASSWORD")).Clear();
        driver.FindElement(By.Name("USER_PASSWORD")).SendKeys(user.Password);

        // Username = user.Username;
        // IsLoggedIn = true;
    }

    public void Logout()
    {
        // driver.Navigate().GoToUrl("https://cybermos.ru/panel/user/config/");
        driver.Navigate().GoToUrl("https://cybermos.ru/?logout=yes");
        // driver.Navigate().GoToUrl("https://cybermos.ru/");
        
    }

    public bool IsLoggedIn()
    {
        return isLoggedIn;
    }
    private bool IsLoggedIn(string newUsername)
    {
        return newUsername == Username;   
    }
    
    
}