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

public class LoginTest : TestBase
{
    AccountData user = new AccountData("solovyanenko2002@mail.ru", "26h6kBa9fthinPJ");

    [Test]
    public void LoginInto()
    {
        ApplicationManager.LoginHelper.OpenLogInPage();
        ApplicationManager.LoginHelper.GetAccKeys(user);
        ApplicationManager.LoginHelper.LogIn();
    }
}