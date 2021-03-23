using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {

        string file = "./file.txt";
        string file2 = "./file2.txt";
        string file3 = "./file3.txt";
        int key = 7;
        string keyWord = "enigma";
        char[,] table = new char[13, 2];

        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private void WriteFile(string path, string text)
        {
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
        }

        private string ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        private string Encryption(string path, int k)
        {
            string text = File.ReadAllText(path, Encoding.Default);
            //добавляем в алфавит маленькие буквы
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        private string Decription(string path, int k)
        {
            string text = File.ReadAllText(path, Encoding.Default).ToLower();
            
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index - k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        private string TrisemusTableEncryption(string text)
        {
            text = text.ToLower();

            string result = "";
            for (var i = 0; i < keyWord.Length; i++)
            {
                table[i / 2, i % 2] = keyWord[i];
            }

            char[] Alphabet = alfabet.ToLower().Except(keyWord).ToArray();

            for (var i = 0; i < Alphabet.Length; i++)
            {
                int position = i + keyWord.Length;
                table[position / 2, position % 2] = Alphabet[i];
            }

            for (var k = 0; k < text.Length; k++)
            {
                char symbol = text[k];
                // Пытаемся найти символ в таблице
                for (var i = 0; i < 13; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        if (symbol == table[i, j])
                        {
                            symbol = table[(i + 1) % 13, j]; // Смещаемся циклически на следующую строку таблицы и запоминаем новый символ
                            i = 13; // Завершаем цикл по строкам
                            break; // Завершаем цикл по колонкам
                        }
                    }
                }
                result += symbol;
            }
            return result;
        }

        private string TrisemusTableDecryption(string text)
        {
            text = text.ToLower();

            string result = "";
            for (var i = 0; i < keyWord.Length; i++)
            {
                table[i / 2, i % 2] = keyWord[i];
            }

            char[] Alphabet = alfabet.ToLower().Except(keyWord).ToArray();

            for (var i = 0; i < Alphabet.Length; i++)
            {
                int position = i + keyWord.Length;
                table[position / 2, position % 2] = Alphabet[i];
            }

            for (var k = 0; k < text.Length; k++)
            {
                char symbol = text[k];
                // Пытаемся найти символ в таблице
                for (var i = 0; i < 13; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        if (symbol == table[i, j])
                        {
                            symbol = table[(i + 12) % 13, j]; // Смещаемся циклически на следующую строку таблицы и запоминаем новый символ
                            i = 13; // Завершаем цикл по строкам
                            break; // Завершаем цикл по колонкам
                        }
                    }
                }
                result += symbol;
            }
            return result;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += ReadFromFile(file);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text += Encryption(file, key);
            WriteFile(file2, Encryption(file, key));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";            
            textBox2.Text += Decription(file2, key);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += ReadFromFile(file2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text += TrisemusTableEncryption(ReadFromFile(file));
            WriteFile(file3, TrisemusTableEncryption(ReadFromFile(file)));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Text += TrisemusTableDecryption(ReadFromFile(file3));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += ReadFromFile(file3);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
