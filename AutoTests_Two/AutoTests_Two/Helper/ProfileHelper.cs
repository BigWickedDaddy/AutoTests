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
    
    public ProfileData GetProfileData()
    {
        var nickaname = driver.FindElement(By.Name("UF_NICK")).GetAttribute("value");
        var about = driver.FindElement(By.Name("PERSONAL_NOTES")).GetAttribute("value");
        
        return new ProfileData(nickaname, about);
    }

}