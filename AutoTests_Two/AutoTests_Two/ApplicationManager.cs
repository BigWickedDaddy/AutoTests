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

public class ApplicationManager
{
    private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;

    private NavigationHelper navigation;

    public AppManager()
    {
        driver = new ChromeDriver("/Users/olegsolovyanenko/RiderProjects/AutoTests_One/AutoTests_One/bin/Debug/net6.0");
        driver.Manage().Window.Maximize();
        baseURL = "https://www.google.com/";
        verificationErrors = new StringBuilder();
        navigation = new NavigationHelper(this, baseURL);
    }
    
    public void Stop()
    {
        driver.Quit();
    }
    
    //Property
    public IWebDriver Driver
    {
        get
        {
            return driver;
        }
    }
    public NavigationHelper Navigation
    {
        get
        {
            return navigation;
        }
    }

}