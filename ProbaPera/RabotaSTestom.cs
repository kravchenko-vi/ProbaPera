using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace ProbaPera
{
    class RabotaSTestom
    {
        private string URLKurs;
        private IWebDriver Browser; //new OpenQA.Selenium.Chrome.ChromeDriver();
        private string NameTest;
        public List<Error> Errors { get; }
        public RabotaSTestom(string nameTest)
        {
            if (nameTest != null)
            {
                Browser= new OpenQA.Selenium.Chrome.ChromeDriver();
                NameTest = nameTest;
                Errors = new List<Error>();
            }
        }
        public void OpenTest()
        {
            try
            {
                IWebElement Element = Browser.FindElement(By.PartialLinkText(NameTest));
                Element.Click();
            }
            catch (Exception e)
            {
                var err=new Error();
                err.DateError=DateTime.Now;
                err.ErrorText = e.ToString();
                err.Text = "Проблема с нахождением теста по имени";
                Errors.Add(err);
                
         
            }
          
            
             

        }
    }
}
