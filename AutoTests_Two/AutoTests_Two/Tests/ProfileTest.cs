using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using AutoTests_Two.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutoTests_Two;

public class ProfileTest : TestBase
{
    [Test, TestCaseSource("GroupDataFromXmlFile")]
    public void ProfileTeste(ProfileData newProfileData)
    {
        // ApplicationManager.LoginHelper.OpenLogInPage();
        // ApplicationManager.LoginHelper.GetAccKeys(user);
        // ApplicationManager.LoginHelper.LogIn();

        // var newProfileData = new ProfileData("NightMode","testovoe_message");

        ApplicationManager.NavigationHelper.GotoProfilePage();
        ApplicationManager.ProfileHelper.GetNewNotes(newProfileData);
        ApplicationManager.ProfileHelper.SaveProfileChanges();
            
        var profileData = ApplicationManager.ProfileHelper.GetProfileData();
            
        Assert.AreEqual(profileData.about ,newProfileData.about);
        Assert.AreEqual(profileData.nickname,newProfileData.nickname);
    }
    
    public static IEnumerable<ProfileData> GroupDataFromXmlFile()
    {
        var path =
            @"/Users/olegsolovyanenko/RiderProjects/GenerateTestData/GenerateTestData/bin/Debug/net6.0/ProfileData.xml";
        var stream = new StreamReader(path);
        var serializer = new XmlSerializer(typeof(List<ProfileData>));
        var data = serializer.Deserialize(stream) as List<ProfileData>;
        return data;
    }

}