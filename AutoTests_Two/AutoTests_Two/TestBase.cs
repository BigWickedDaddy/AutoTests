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
    private bool acceptNextAlert = true;
    protected AppManager app;

    [SetUp]
    public void SetupTest()
    {
        app = new AppManager();
    }
    
    [TearDown]
    public void TeardownTest()
    {
        app.Stop();
    }
    
}