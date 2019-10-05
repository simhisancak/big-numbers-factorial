using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;
using System.IO;

namespace big_numbers_factorial
{
    class Program
    {
        static void Main(string[] args)
        {

        basadon:
            string[] simhi = new string[6];
            Stopwatch watch = new Stopwatch();
            BigInteger ss = 0;

            Console.Clear();
            Console.Write("Lütfen Sayıyı Giriniz: ");
            
            long s = Convert.ToInt64( Console.ReadLine());
            
            watch.Start();
           
            ss = calculate.Factorial(s);

            simhi[0] = ("Simhi Sancak");
            simhi[1] = ("İşlem Tarihi: " + DateTime.Now.ToString());
            simhi[2] = ("Girilen Sayı: " + s);
            simhi[4] = ("Sonuç: " + Convert.ToString(ss));
            string masaustu_dizin = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "factorial log" + ".txt";
            if (!System.IO.File.Exists(masaustu_dizin))
            {
                FileStream fs = File.Create(masaustu_dizin);
                fs.Close();
                System.IO.File.WriteAllLines(masaustu_dizin, simhi);
            }
            else
            {
                System.IO.File.WriteAllLines(masaustu_dizin, simhi);
            }
            
            watch.Stop();
            

            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds );


            Console.Clear();
            Console.WriteLine("-------------Bitti-------------");
            Console.WriteLine();
            Console.WriteLine("Girilen Sayı: " + s);
            Console.WriteLine();
            Console.WriteLine("İşlem Süresi: " + elapsedTime);
            Console.WriteLine();
            Console.WriteLine("Dosya Yolu: " + masaustu_dizin);
            Console.WriteLine();
            Console.WriteLine("-------------Bitti-------------");
            Console.WriteLine();
            Console.WriteLine("Başa Dönmek İçin Herhangi Bir Tuşa Bas veya Çıkmak İçin ESC Tuşuna Bas");
           
            
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    goto basadon;
                }
            }
        }
    }
}
