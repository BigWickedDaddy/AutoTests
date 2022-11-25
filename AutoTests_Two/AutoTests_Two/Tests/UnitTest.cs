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

[TestFixture]
    public class UntitledTestCase : TestBase
    {
        AccountData user = new AccountData("solovyanenko2002@mail.ru", "26h6kBa9fthinPJ");

        [Test]
        public void LoginInto()
        {
            ApplicationManager.LoginHelper.OpenLogInPage();
            ApplicationManager.LoginHelper.GetAccKeys(user);
            ApplicationManager.LoginHelper.LogIn();
        }
        
        [Test]
        public void ProfileData()
        {
            // ApplicationManager.LoginHelper.OpenLogInPage();
            // ApplicationManager.LoginHelper.GetAccKeys(user);
            // ApplicationManager.LoginHelper.LogIn();

            var newProfileData = new ProfileData("NightMode","testovoe_message");

            ApplicationManager.NavigationHelper.GotoProfilePage();
            ApplicationManager.ProfileHelper.GetNewNotes(newProfileData);
            ApplicationManager.ProfileHelper.SaveProfileChanges();
            
            var profileData = ApplicationManager.ProfileHelper.GetProfileData();
            
            Assert.AreEqual(profileData.about ,newProfileData.about);
            Assert.AreEqual(profileData.nickname,newProfileData.nickname);
        }
    }