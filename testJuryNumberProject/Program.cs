using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace testJuryNumberProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string SS = "G0 X500.2365 Y300.12354 Z-50.25648 F2500";
            ST_Znach (SS);
            List<double> test = new List<double>() { 
                0.1000f,
                0.00100f,
                115f,
                1234.5678f,
                0.0126f,
                .0789f
            };
            bool isNeedDot = false;
            string writePath = @"C:\Users\ЮРИЙ\eclipse-workspace\COMPACT\ttt.cnc";
            try {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    
                    float v = float.Parse("234.456", CultureInfo.InvariantCulture);
                    var printer = new NumberPrinter(isNeedDot, 2);
                    sw.WriteLine(printer.Print(v));
                }

                {
                    //sw.WriteLine(text);
                   // var printer = new NumberPrinter(isNeedDot, 2);
                   // foreach (var value in test)
                   //     sw.WriteLine(printer.Print(value));
                }           

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            {
                //bool isNeedDot = true;

                //Console.WriteLine("DOT - 1");
                //var printer = new NumberPrinter(isNeedDot, 1);
                //foreach (var value in test)
                // Console.WriteLine( printer.Print(value));
                // Console.WriteLine("DOT - 2");
                //printer = new NumberPrinter(isNeedDot, 2);
                //foreach (var value in test)
                // Console.WriteLine(printer.Print(value));
                //Console.WriteLine("DOT - 3");
                //printer = new NumberPrinter(isNeedDot, 3);
                // foreach (var value in test)
                //    Console.WriteLine(printer.Print(value));



                // Console.ReadKey();
            } 
        }
        public static string ST_Znach (string S)
        {
            bool isNeedDot = true;
            string RED = "XYZ"; // Редактируемые значения
            string S2 = "YZABCF"; //
            string V = string.Empty; // строка на выходе
            string U, C;
            int a = 0 , b = 0; // a - первое вхождение RED (начало числа)
                               // b - первое вхождение S2 (конец числа)
            var printer = new NumberPrinter(isNeedDot, 2);
            for (int i = 0; i < RED.Length; i++)
            {
                a = S.IndexOf(RED[i]);
                V += S.Substring(b , a + 1) ;
                for (int j = 0; j < S2.Length; j++)
                {
                    b = S.IndexOf(S2[j]);
                    C = S.Substring(a + 1, b-a-1);
                    C = printer.Print(float.Parse(C));
                    S = S.Substring(a + 1, S.Length - a - 1);
                    V += C;
                }
            }
            return V;
        }
    }
}
