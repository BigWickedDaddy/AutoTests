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
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        private NavigationHelper _navigationHelper;

        public IWebDriver Driver => _driver;
        
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public NavigationHelper NavigationHelper => _navigationHelper;

        private ApplicationManager()
        {
            _driver = new ChromeDriver("/Users/alexandronischenko/RiderProjects/AutoTest_One/packages/Selenium.WebDriver.ChromeDriver.106.0.5249.6100/driver/mac64arm");
            _baseUrl = "https://www.google.com/";
            _verificationErrors = new StringBuilder();
            _navigationHelper = new NavigationHelper(this, _baseUrl);

        }
        
        ~ApplicationManager()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        
        public void Stop()
        {
            _driver.Quit();
        }
        
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                var newInstance = new ApplicationManager();
                newInstance._navigationHelper.GotoProfilePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
    }