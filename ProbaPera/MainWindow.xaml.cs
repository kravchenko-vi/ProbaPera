using Microsoft.Win32;
using OfficeOpenXml;
using OpenQA.Selenium;
using ProbaPera.ProhozdenieTests;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProbaPera
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Error> Errors;
        public MainWindow()
        {
            InitializeComponent();
            Errors = new List<Error>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RabotaSTestom rabota = new RabotaSTestom("Промежуточный контроль №4");
            rabota.OpenTest();
            Errors.AddRange(rabota.Errors);
        }

        private List<Users> Excel()
        {


            FileInfo newFile = new FileInfo(GetPath());

            ExcelPackage pck = new ExcelPackage(newFile);
            //Add the Content sheet
            var ws = pck.Workbook.Worksheets.First();
            ws.View.ShowGridLines = false;
            List<Users> usr = new List<Users>();
            var end = ws.Cells.Where(c => c.Start.Column == 1 && !c.Value.ToString().Equals("")).Last().End.Row;
            for (int i = 1; i <= end; i++)
            {
                Users us = new Users();
                us.Login = ws.Cells[i, 1].Value.ToString();
                us.Pass = ws.Cells[i, 2].Value.ToString();
                us.NazvGrupp = ws.Cells[i, 11].Value.ToString();
                usr.Add(us);
            }

            //Headers


            return usr;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IWebDriver Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Url = "http://dorus.iro23.ru";
            List<Users> usr = new List<Users>();
            //usr.Add(new Users{Login = "исрафиловамв2020",Pass = "123456",NazvGrupp = "Дагестан РЯ группа №7"

            //});
            //usr.Add(new Users
            //{
            //    Login = "бибалаевазк2020",
            //    Pass = "123456",
            //    NazvGrupp = "Дагестан РЯ группа №7"

            //});
            usr = Excel();

            ZahodNaVebinar Zahod = new ZahodNaVebinar(usr, Browser, Course.Text);
        }

        private void Рандом_для_ФЦПРЯ_Click(object sender, RoutedEventArgs e)
        {

            SpisokTests sp = new SpisokTests(GetPath());
            List<ProidennieTests> list = sp.Excel();
              SbrosPasswords sbros = new SbrosPasswords();
              sbros.sbros(list);
            Prohod pr = new Prohod(list);

            //List < int > numberQuesten= new List<int>();
            //Random rand = new Random();
            //int kol_vern = rand.Next(10, 14);
            //while ( numberQuesten.Count < (20 - kol_vern))
            //{

            //   int chislo= rand.Next(1, 20);
            //   if(numberQuesten.Count(x => x==chislo)==0)
            //       numberQuesten.Add(chislo);
            //}
        }
        public string GetPath()
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }

        private void Course_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
