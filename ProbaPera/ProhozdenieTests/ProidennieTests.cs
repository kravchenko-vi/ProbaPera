using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using ProbaPera;

namespace ProbaPera
{
   public class ProidennieTests
    {
        public string name { get; set; }
        public string email { get; set; }
        public int  vh { get; set; }
        public int pr1 { get; set; }
        public int pr2 { get; set; }
        public int inv { get; set; }
        public int itog { get; set; }
    }
}
public class  SpisokTests
{
    private string path;

    public SpisokTests(string put)
    {
        path = put;
    }
    public List<ProidennieTests> Excel()
    {

        FileInfo newFile = new FileInfo(path);

        ExcelPackage pck = new ExcelPackage(newFile);
        //Add the Content sheet
        var ws = pck.Workbook.Worksheets.First();
        ws.View.ShowGridLines = false;
        List<ProidennieTests> usr = new List<ProidennieTests>();
        var end = ws.Cells.Where(c => c.Start.Column == 1 && !c.Value.ToString().Equals("")).Last().End.Row;
        for (int i = 2; i <= end; i++)
        {
            bool zapis = false;
            ProidennieTests us = new ProidennieTests();
            if (ws.Cells[i, 8].Value.ToString() == "-" || Convert.ToDouble(ws.Cells[i, 8].Value)<7)
            {
                us.inv = 1;
                zapis = true;
            }
            if (ws.Cells[i, 9].Value.ToString() == "-" || Convert.ToDouble(ws.Cells[i, 9].Value) < 1)
            {
                us.vh = 1;
                zapis = true;
            }
            if (ws.Cells[i, 10].Value.ToString() == "-" || Convert.ToDouble(ws.Cells[i, 10].Value) < 6)
            {
                us.pr1 = 1;
                zapis = true;
            }
            if (ws.Cells[i, 11].Value.ToString() == "-" || Convert.ToDouble(ws.Cells[i, 11].Value) < 6)
            {
                us.pr2 = 1;
                zapis = true;
            }
            if (ws.Cells[i, 12].Value.ToString() == "-" || Convert.ToDouble(ws.Cells[i, 12].Value) < 8)
            {
                us.itog = 1;
                zapis = true;
            }
            us.name = ws.Cells[i, 1].Value.ToString()+" "+ ws.Cells[i, 2].Value.ToString();
            us.email = ws.Cells[i, 6].Value.ToString();

            if(zapis)
            usr.Add(us);
        }

        //Headers


        return usr;
    }

}