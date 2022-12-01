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

public class ProfileHelper : HelperBase
{
    public ProfileHelper(ApplicationManager applicationManager) : base(applicationManager)
    {
        
    }
    
    public void SaveProfileChanges()
    {
        driver.FindElement(By.Name("save")).Click();
    }

    public void GetNewNotes(ProfileData profileData)
    {
        driver.FindElement(By.Name("PERSONAL_NOTES")).Click();
        driver.FindElement(By.Name("PERSONAL_NOTES")).Clear();
        driver.FindElement(By.Name("PERSONAL_NOTES")).SendKeys(profileData.about);
        driver.FindElement(By.XPath("//div[@id='main']/main/main/div/form/div/div/div/div[2]")).Click();
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