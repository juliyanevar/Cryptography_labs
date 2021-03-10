using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        public static double countInformationWithMistake(int N, double p)
        {
            double q = 1 - p;
            double result = 0;
            result = -p * Math.Log(p,2)- q * Math.Log(q,2);
            return N * (1 - result);
        }

        public static double EntropySennon(string resultText, Regex regex)
        {
            double entropy = 0;
            double v = 0;

            double count = resultText.Count();
            char[] ch = resultText.ToCharArray().Distinct().OrderBy(i => i).ToArray();

            for (int i = 0; i < ch.Length; i++)
            {
                Console.WriteLine("Символ: {0}. Количество: {1}. Вероятность: {2}%.",
                    ch[i], resultText.ToCharArray().Count(x => x == ch[i]), (resultText.ToCharArray().Count(x => x == ch[i]) / count) * 100);
                entropy += (resultText.ToCharArray().Count(x => x == ch[i]) / count) * Math.Log((resultText.ToCharArray().Count(x => x == ch[i]) / count), 2);
                v += resultText.ToCharArray().Count(x => x == ch[i]) / count;
            }
            Console.WriteLine("Общая вероятность: " + v);

            return -entropy;
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Julia\Documents\учеба\6 сем\КМЗИ\labs\lab2\lab2\file0.txt";
            string file = File.ReadAllText(path, Encoding.Default);
            Regex regex = new Regex(@"[А-Яа-я]");
            double ruEntr;
            String resultText = "";
            MatchCollection matches = regex.Matches(file);
            foreach (Match match in matches)
                resultText += match;
            ruEntr = EntropySennon(resultText, regex);
            Console.WriteLine("RU: энтропия: " + ruEntr.ToString());
            Console.WriteLine();

            regex = new Regex(@"[0-1]");
            string binText = "";
            String resultTextBin = "";
            double ruBinEntr;
            for (int i = 0; i < resultText.Length; i++)
            {
                binText += Convert.ToString((int)resultText[i], 2) + " ";
            }
            matches = regex.Matches(binText);
            foreach (Match match in matches)
                resultTextBin += match;
            ruBinEntr = EntropySennon(resultTextBin, regex);
            Console.WriteLine("RU BIN: энтропия: " + ruBinEntr.ToString()+"\n");
            Console.WriteLine();

            path = @"C:\Users\Julia\Documents\учеба\6 сем\КМЗИ\labs\lab2\lab2\file1.txt";
            file = File.ReadAllText(path, Encoding.Default);
            regex = new Regex(@"[A-Za-z]");
            double enEntr;
            resultText = "";
            matches = regex.Matches(file);
            foreach (Match match in matches)
                resultText += match;
            enEntr = EntropySennon(resultText, regex);
            Console.WriteLine("EN: энтропия: " + enEntr.ToString());
            Console.WriteLine();

            regex = new Regex(@"[0-1]");
            binText = "";
            resultTextBin = "";
            double enBinEntr;
            for (int i = 0; i < resultText.Length; i++)
            {
                binText += Convert.ToString((int)resultText[i], 2) + " ";
            }
            matches = regex.Matches(binText);
            foreach (Match match in matches)
                resultTextBin += match;
            enBinEntr = EntropySennon(resultTextBin, regex);
            Console.WriteLine("EN BIN: энтропия: " + enBinEntr.ToString()+"\n");
            Console.WriteLine();


            string FIO = "Невар Юлия Валерьевна";
            string FIOEn = "Nevar Julia Valeryevna";
            String FIOBinRu = "";
            for (int i = 0; i < FIO.Length; i++)
            {
                FIOBinRu += Convert.ToString((int)FIO[i], 2) + " ";
            }
            String FIOBinEn = "";
            for (int i = 0; i < FIOEn.Length; i++)
            {
                FIOBinEn += Convert.ToString((int)FIOEn[i], 2) + " ";
            }
            Console.WriteLine("Количество информации RU:" + ruEntr*FIO.Length);
            Console.WriteLine("Количество информации RU bin:" + ruBinEntr*FIOBinRu.Length);
            byte[] bytesASCIIRu = Encoding.ASCII.GetBytes(FIO);
            string ASCIIRu = "";
            foreach (var b in bytesASCIIRu)
                ASCIIRu += b;
            Console.WriteLine("Количество информации RU ASCII:" + ruBinEntr* ASCIIRu.Length);
            Console.WriteLine();


            Console.WriteLine("Количество информации EN:" + enEntr*FIOEn.Length);
            Console.WriteLine("Количество информации EN bin:" + enBinEntr* FIOBinEn.Length);
            byte[] bytesASCIIEn = Encoding.ASCII.GetBytes(FIOEn);
            string ASCIIEn = "";
            foreach (var b in bytesASCIIEn)
                ASCIIEn += b;
            Console.WriteLine("Количество информации EN ASCII:" + enBinEntr*ASCIIEn.Length);
            Console.WriteLine();


            Console.WriteLine("RU Error 0,1: " + countInformationWithMistake(ASCIIRu.Length, 0.9));
            Console.WriteLine("RU Error 0,5: " + countInformationWithMistake(ASCIIRu.Length, 0.5));
            Console.WriteLine("RU Error 1: " + countInformationWithMistake(ASCIIRu.Length, 1));
            Console.WriteLine("EN Error 0,1: " + countInformationWithMistake(ASCIIEn.Length, 0.9));
            Console.WriteLine("EN Error 0,5: " + countInformationWithMistake(ASCIIEn.Length, 0.5));
            Console.WriteLine("EN Error 1: " + countInformationWithMistake(ASCIIEn.Length, 1));


            Console.ReadKey();
        }
    }
}
