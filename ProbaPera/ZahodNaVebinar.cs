using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;
namespace ProbaPera

{
    class ZahodNaVebinar
    {
     
        private IWebDriver Browser;
        public ZahodNaVebinar(List<Users> usr, IWebDriver _Browser,string Course)
        {
            if (usr != null)
            {
                Browser = _Browser;
                foreach (var row in usr)
                {
                    Browser.Url = "http://dorus.iro23.ru/login/index.php";
                    Vhod(row.Login, row.Pass);
                    Thread.Sleep(1000);

                    Soglashenie();


                    Browser.Url = " http://dorus.iro23.ru/course/view.php?id="+Course;
                    OpenVebinar(row.NazvGrupp);
                    Logout();
                }
            }
        }

        private void Soglashenie()
        {
            var sgl = Browser.FindElement(By.CssSelector("h2"));
            string text = sgl.GetAttribute("textContent");
            if (text == "Пользовательское соглашение")
            {
                
                var button = Browser.FindElement(By.CssSelector("input[value='Да']")); ;
                button.Click();
            }
        }

        private void OpenVebinar(string Nazv)
        {
            int i = 0;
            
            var NameVebinar = Browser.FindElements(By.CssSelector(".instancename"));
            foreach (var row in NameVebinar)
            {
                string text = row.GetAttribute("textContent");
             
                int index = -1;
                index = text.IndexOf(Nazv);

                if (index != -1)
                {
                    
                     row.Click();
                     break;
                }
            }

            try
            {
                Thread.Sleep(1000);
                var buttonVhod = Browser.FindElement(By.Id("join_button_input"));
                buttonVhod.Click();
            }
            catch
            {
            }




        }
        private void Vhod(string Login, string Pass)
        {
            var login=Browser.FindElement(By.Id("username"));
            login.SendKeys(Login);
            var pass = Browser.FindElement(By.Id("password"));
            pass.SendKeys(Pass); 
            var button = Browser.FindElement(By.Id("loginbtn"));
            button.Click();

        }

        private void Logout()
        {
            try
            {

          
            Browser.Url = "http://dorus.iro23.ru/login/index.php";
            var button = Browser.FindElement(By.LinkText("Выход"));
            button.Click();
            }
            catch 
            {
            }
        }

    }
}
