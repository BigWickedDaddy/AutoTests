using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoTests_One
{
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
    
    public class GroupData
    {
        public GroupData(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Header { get; set;}

        public string Footer { get; set; }
    }
    
    [TestFixture]
    public class UntitledTestCase: TestBase
    {
        // [Test]
        // public void TheUntitledTestCaseTest()
        // {
        //     AccountData user = new AccountData("OYSolovyanenko", "gmqamyhkg");
        //     GroupData group = new GroupData("New Group") { Header = "sds", Footer = "dsfsd"};
        //
        //     OpenLoginPage();
        //     LoginInto(user);
        //     OpenProfilePage();
        // }

        [Test]
        public void TheUntitledTestCaseTestSecond()
        {
            AccountData user = new AccountData("OYSolovyanenko", "gmqamyhkg");
            GroupData group = new GroupData("New Group") { Header = "sds", Footer = "dsfsd"};

            OpenLoginPage();
            LoginInto(user);
            OpenProfilePage();

            SendMail();
        }
    }
    
}

///Users/olegsolovyanenko/Downloads/chromedriver
/// /Users/olegsolovyanenko/RiderProjects/AutoTests_One/AutoTests_One/bin/Debug/net6.0
// driver = new ChromeDriver("/Users/olegsolovyanenko/RiderProjects/AutoTests_One/AutoTests_One/bin/Debug/net6.0");


