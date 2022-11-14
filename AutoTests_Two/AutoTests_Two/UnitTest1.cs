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

public class AccountData
{
    public AccountData(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public string Username {get; set;}

    public string Password { get; set; }
        
}

[TestFixture]
    public class UntitledTestCase : TestBase
    {
        AccountData user = new AccountData("solovyanenko2002@mail.ru", "26h6kBa9fthinPJ");

        [Test]
        public void First()
        {
            OpenLogInPage();
            GetAccKeys(user);
            LogIn();
        }
        
        [Test]
        public void Second()
        {
            OpenLogInPage();
            GetAccKeys(user);
            LogIn();
            GotoProfilePage();
            GetNewNotes();
            SaveProfileChanges();
        }
        
    }