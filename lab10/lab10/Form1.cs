using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography;
using System.Diagnostics;

namespace lab10
{
    public partial class Form1 : Form
    {
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] crypted;
        static Stopwatch timer = new Stopwatch();
        int[] elGamalCrypted;

        public Form1()
        {
            InitializeComponent();
        }

        static public byte[] RSACrypt(byte[] Data, RSAParameters RSAKey)
        {
            timer.Reset();
            timer.Start();
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, false);
                }
                timer.Stop();
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                timer.Stop();
                return null;
            }
        }

        static public string RSADecrypt(byte[] Data, RSAParameters RSAKey)
        {
            timer.Reset();
            timer.Start();
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, false);
                }
                timer.Stop();
                return Encoding.UTF8.GetString(decryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                timer.Stop();
                return null;
            }
        }

        public static int[] ElGamalCrypt(string text, int p, int g, int y)
        {
            timer.Reset();
            timer.Start();
            var bigP = new BigInteger(p);
            var bigG = new BigInteger(g);
            var bigY = new BigInteger(y);
            var rand = new Random();
            var byteText = Encoding.GetEncoding(1251).GetBytes(text);
            var result = new List<int>();

            foreach (var m in byteText)
            {
                var bigM = new BigInteger(m); // Open text symbol
                var k = new BigInteger(rand.Next(1, p - 1));

                var r = BigInteger.ModPow(bigG, k, bigP);
                var c = (bigM * BigInteger.Pow(bigY, (int)k)) % bigP;

                result.Add((int)r);
                result.Add((int)c);
            }
            timer.Stop();
            return result.ToArray();
        }

        public static string ElGamalDecrypt(int[] text, int p, int x)
        {
            timer.Reset();
            timer.Start();
            var bigP = new BigInteger(p);
            var result = new List<byte>();

            for (int i = 0; i < text.Length; i += 2)
            {
                var r = new BigInteger(text[i]);
                var c = new BigInteger(text[i + 1]);

                var m = (c * BigInteger.Pow(r, p - 1 - x)) % bigP;
                result.Add((byte)m);
            }
            timer.Stop();
            return Encoding.GetEncoding(1251).GetString(result.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            byte[] text = Encoding.UTF8.GetBytes(textBox1.Text);
            crypted = RSACrypt(text, RSA.ExportParameters(false));
            textBox2.Text = Convert.ToBase64String(crypted);
            textBox3.Text = timer.Elapsed.ToString();

            //string decryptedText = RSADecrypt(crypted, RSA.ExportParameters(true));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string decryptedText = RSADecrypt(crypted, RSA.ExportParameters(true));
            textBox2.Text = decryptedText;
            textBox4.Text = timer.Elapsed.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            elGamalCrypted = ElGamalCrypt(textBox1.Text, 593, 123, 162);
            string elGamalCryptedText = string.Join(", ", elGamalCrypted);
            textBox2.Text = elGamalCryptedText;
            textBox3.Text = timer.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = ElGamalDecrypt(elGamalCrypted, 593, 8);
            textBox4.Text = timer.Elapsed.ToString();
        }
    }
}
