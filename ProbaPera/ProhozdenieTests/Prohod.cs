using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;
using OpenQA.Selenium;

using System.Threading;

namespace ProbaPera.ProhozdenieTests
{
    class Prohod
    {
        private ProidennieTests user;
        private List<VoprosOtvet> VHlList;
        IWebDriver Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
        Random rand = new Random();
        public Prohod(List<ProidennieTests> users)
        {
            
                VHlList = otvets(@"C:\1\fcprya\Входная диагностика.xlsx");
                List<VoprosOtvet> PR1lList = otvets(@"C:\1\fcprya\Промежуточный контроль №1.xlsx");
                List<VoprosOtvet> PR2lList = otvets(@"C:\1\fcprya\Промежуточный контроль №2.xlsx");
                List<VoprosOtvet> INList = otvets(@"C:\1\fcprya\ИНВАРИАНТНЫЙ МОДУЛЬ.xlsx");
                List<VoprosOtvet> ITList = otvets(@"C:\1\fcprya\ВЫХОДНАЯ ДИАГНОСТИКА.xlsx");
                foreach (var user in users)
                {
                    this.user = user;






                    Vhod();

                try
                {

                    if (user.vh == 1)
                    {
                        List<int> numberQuesten = new List<int>();


                        int kol_vern = rand.Next(2, 5);
                        while (numberQuesten.Count < (10 - kol_vern))
                        {

                            int chislo = rand.Next(1, 10);
                            if (numberQuesten.Count(x => x == chislo) == 0)
                                numberQuesten.Add(chislo);
                        }







                        TestZahod("http://dorus.iro23.ru/mod/quiz/view.php?id=1758");
                        nachalo();
                        for (int i = 0; i < 10; i++)
                        {
                            if (!numberQuesten.Where((x => x == (i + 1))).Any())
                            {
                                Zadan(VHlList);



                            }
                            else
                            {
                                ZadanNeVerno();
                            }
                            var but = Browser.FindElement(By.Name("next"));
                            but.Click();
                        }

                        ZaconcitPopitku();
                    }

                }
                catch { }
                try
                {
                    if (user.pr1 == 1)
                    {
                        List<int> numberQuesten = new List<int>();


                        int kol_vern = rand.Next(6, 9);
                        while (numberQuesten.Count < (10 - kol_vern))
                        {

                            int chislo = rand.Next(1, 10);
                            if (numberQuesten.Count(x => x == chislo) == 0)
                                numberQuesten.Add(chislo);
                        }






                        TestZahod("http://dorus.iro23.ru/mod/quiz/view.php?id=1760");
                        nachalo();
                        for (int i = 0; i < 10; i++)
                        {
                            if (!numberQuesten.Where((x => x == (i + 1))).Any())
                            {
                                Zadan(PR1lList);



                            }
                            else
                            {
                                ZadanNeVerno();
                            }
                            var but = Browser.FindElement(By.Name("next"));
                            but.Click();
                        }

                        ZaconcitPopitku();
                    }


                }
                catch { }
                try
                {
                    if (user.pr2 == 1)
                    {
                        List<int> numberQuesten = new List<int>();


                        int kol_vern = rand.Next(6, 10);
                        while (numberQuesten.Count < (10 - kol_vern))
                        {

                            int chislo = rand.Next(1, 10);
                            if (numberQuesten.Count(x => x == chislo) == 0)
                                numberQuesten.Add(chislo);
                        }






                        TestZahod("http://dorus.iro23.ru/mod/quiz/view.php?id=1761");
                        nachalo();
                        for (int i = 0; i < 10; i++)
                        {
                            if (!numberQuesten.Where((x => x == (i + 1))).Any())
                            {
                                Zadan(PR2lList);



                            }
                            else
                            {
                                ZadanNeVerno();
                            }
                            var but = Browser.FindElement(By.Name("next"));
                            but.Click();
                        }

                        ZaconcitPopitku();
                    }
                }
                catch { }

                try
                {
                    if (user.inv == 1)
                    {
                        List<int> numberQuesten = new List<int>();


                        int kol_vern = rand.Next(9, 10);
                        while (numberQuesten.Count < (10 - kol_vern))
                        {

                            int chislo = rand.Next(1, 10);
                            if (numberQuesten.Count(x => x == chislo) == 0)
                                numberQuesten.Add(chislo);
                        }






                        TestZahod("http://dorus.iro23.ru/mod/quiz/view.php?id=1759");
                        nachalo();
                        for (int i = 0; i < 10; i++)
                        {

                            if (!numberQuesten.Where((x => x == (i + 1))).Any())
                            {
                                Zadan(INList);



                            }
                            else
                            {
                                ZadanNeVerno();
                            }

                            try
                            {

                                var but = Browser.FindElement(By.Name("next"));
                                but.Click();
                            }
                            catch
                            {
                                Browser.Navigate().Back();
                                var but = Browser.FindElement(By.Name("next"));
                                but.Click();
                            }
                        }

                        ZaconcitPopitku();
                    }
                }

                catch { }
                try
                {
                    if (user.itog == 1)
                    {
                        List<int> numberQuesten = new List<int>();


                        int kol_vern = rand.Next(6, 10);
                        while (numberQuesten.Count < (10 - kol_vern))
                        {

                            int chislo = rand.Next(1, 10);
                            if (numberQuesten.Count(x => x == chislo) == 0)
                                numberQuesten.Add(chislo);
                        }






                        TestZahod("http://dorus.iro23.ru/mod/quiz/view.php?id=1709");
                        nachalo();
                        for (int i = 0; i < 10; i++)
                        {
                            if (!numberQuesten.Where((x => x == (i + 1))).Any())
                            {
                                Zadan(ITList);



                            }
                            else
                            {
                                ZadanNeVerno();
                            }

                            try
                            {

                                var but = Browser.FindElement(By.Name("next"));
                                but.Click();
                            }
                            catch
                            {
                                Browser.Navigate().Back();
                                var but = Browser.FindElement(By.Name("next"));
                                but.Click();
                            }
                        }

                        ZaconcitPopitku();
                    }

                }
                catch { }

                    Logout();


                }
           
        }

        private void ZaconcitPopitku()
        {
            try
            {


                //var prodol = Browser.FindElement(By.CssSelector("input[value$='Закончить попытку...']"));
                //prodol.Click(); 
                var prodol = Browser.FindElement(By.CssSelector("input[value$='Отправить всё и завершить тест']"));
                prodol.Click();

                var prodo1 = Browser.FindElement(By.CssSelector("input[value$='btn btn - primary']"));
                prodo1.Click();
            }
            catch
            {

            }

        }




        private void Logout()
        {
            try
            {
                Browser.Url = "http://dorus.iro23.ru/login/index.php";
                var button = Browser.FindElement(By.LinkText("Выход"));
                button.Click();
            }
            catch (Exception e)
            {

            }

        }

        private List<VoprosOtvet> otvets(string path)
        {

            FileInfo newFile = new FileInfo(path);

            ExcelPackage pck = new ExcelPackage(newFile);
            //Add the Content sheet
            var ws = pck.Workbook.Worksheets.First();
            ws.View.ShowGridLines = false;
            List<VoprosOtvet> vprotv = new List<VoprosOtvet>();
            var end = ws.Cells.Where(c => c.Start.Column == 1 && !c.Value.ToString().Equals("")).Last().End.Row;
            for (int i = 1; i <= end; i++)
            {

                VoprosOtvet us = new VoprosOtvet();


                us.Vpr = ws.Cells[i, 1].Value.ToString();
                us.Otv = ws.Cells[i, 2].Value.ToString();


                vprotv.Add(us);
            }

            return vprotv;
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
        private void Vhod()
        {
            Browser.Url = "http://dorus.iro23.ru/login/index.php";
            var login = Browser.FindElement(By.Id("username"));
            login.SendKeys(user.email);
            var pass = Browser.FindElement(By.Id("password"));
            pass.SendKeys("123456");
            var button = Browser.FindElement(By.Id("loginbtn"));
            button.Click();
            Soglashenie();
        }

        private void TestZahod(string path)
        {
            Browser.Url = path;
            try
            {
                var prodol = Browser.FindElement(By.CssSelector("input[value$='Продолжить последнюю попытку']"));
                prodol.Click();
            }
            catch
            {
                try
                {
                    var prodol = Browser.FindElement(By.CssSelector("input[value$='Начать тестирование']"));
                    prodol.Click();


                    //var prodol = Browser.FindElement(By.("cmid"));
                    //prodol.Click();
                }
                catch
                {
                    try
                    {


                        var prodol = Browser.FindElement(By.CssSelector("input[value$='Пройти тест заново']"));
                        prodol.Click();
                    }
                    catch
                    {

                    }

                }
            }
        }

        private void nachalo()
        {
            Thread.Sleep(500);
            try
            {
                var but = Browser.FindElement(By.CssSelector("a[data-quiz-page$='0']"));
                //первый вариант без случайных 
                // var but = Browser.FindElement(By.Id("quiznavbutton1"));
                but.Click();
            }
            catch { }

        }
        private void ZadanNeVerno()
        {
            int kol_vern = rand.Next(1, 3);

            Thread.Sleep(500);
            var otvetsMoodle = Browser.FindElements(By.ClassName("m-l-1"));
            Thread.Sleep(500);
            try
            {
                otvetsMoodle[kol_vern].Click();
            }
            catch
            { }
        }

        private void Zadan(List<VoprosOtvet> list)
        {
            try
            {
                var but = Browser.FindElement(By.ClassName("qtext"));

                string textZad = but.Text;


                var otv = list.Where(x => textZad.Contains(x.Vpr)).Select(x => x.Otv).ToList();

                if (otv.Count == 0)
                    ZadanNeVerno();
                //  otv = list.Where(x => x.Vpr.Contains(textZad)).Select(x => x.Otv).ToList();

                var otvetsMoodle = Browser.FindElements(By.ClassName("m-l-1"));
                foreach (var row in otv)
                {
                    try
                    {
                        IWebElement est1 = null;
                        var est = otvetsMoodle.Where(x => x.Text.Contains(row));
                        if (est.Count() > 1)
                        {

                            est1 = est.Where(x => x.Text == row).First();

                        }

                        Thread.Sleep(500);
                        if (est1 != null)
                            est1.Click();
                        else
                            est.First().Click();
                        Thread.Sleep(500);
                    }
                    catch { }



                }
            }
            catch { }


        }
    }



    public class VoprosOtvet
    {
        public string Vpr { get; set; }
        public string Otv { get; set; }
    }
}