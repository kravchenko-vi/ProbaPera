using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ProbaPera.ProhozdenieTests
{
    class SbrosPasswords
    {
        IWebDriver Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
        public void sbros(List<ProidennieTests> emails)
        {
            VhodAdmin();
            foreach (var email in emails)
            {
                poisk(email);
                smena();
            }
            Browser.Quit();

        }

        private void poisk(ProidennieTests us)
        {
            Browser.Url = "http://dorus.iro23.ru/admin/user.php";
            try
            {
                var id_removeall = Browser.FindElement(By.Id("id_removeall"));
                id_removeall.Click();
            }
            catch (Exception e)
            {
                
            } 
            
            var button = Browser.FindElement(By.LinkText("Показать больше ..."));
            button.Click();
            var id_email = Browser.FindElement(By.Name("email"));
            id_email.SendKeys(us.email);
            var id_addfilter = Browser.FindElement(By.Id("id_addfilter"));
            id_addfilter.Click();

            var user = Browser.FindElement(By.LinkText(us.name));
            user.Click();
     

        }

        private void smena()
        {
            

            var redact = Browser.FindElement(By.LinkText("Редактировать информацию"));
            redact.Click();
            var izmen = Browser.FindElement(By.LinkText("Нажмите, чтобы ввести текст"));
            izmen.Click();
           
            var id_newpassword = Browser.FindElement(By.Id("id_newpassword"));
            id_newpassword.SendKeys("123456");
            var id_submitbutton = Browser.FindElement(By.Id("id_submitbutton"));
            id_submitbutton.Click();
            
        }

       
        public void VhodAdmin()
        {
            Browser.Url = "http://dorus.iro23.ru/login/index.php";
            var login = Browser.FindElement(By.Id("username"));
            login.SendKeys("hde@kkidppo.ru");
            var pass = Browser.FindElement(By.Id("password"));
            pass.SendKeys("DAkh1596814");
            var button = Browser.FindElement(By.Id("loginbtn"));
            button.Click();
        }
    }
}
