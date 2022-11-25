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

public class NavigationHelper : HelperBase
{
    private string baseURL;        
public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

    public void GotoProfilePage()
    {
        driver.Navigate().GoToUrl("https://cybermos.ru/panel/user/config/");
    }
    
}