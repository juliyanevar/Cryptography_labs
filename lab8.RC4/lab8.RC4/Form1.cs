using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8.RC4
{
    public partial class Form1 : Form
    {
        byte[] key = new byte[] { 61, 60, 23, 22, 21, 20 };

        string Crypt(string data1, byte[] key)
        {
            byte[] data = Encoding.GetEncoding(1251).GetBytes(data1);
            int a, i, j, k, tmp;
            int[] S = new int[256];
            byte[] result = new byte[data.Length];

            for (i = 0; i < S.Length; i++)
            {
                S[i] = i;
            }

            for (j = i = 0; i < S.Length; i++)
            {
                j = (j + S[i] + key[i % key.Length]) % S.Length;
                tmp = S[i];
                S[i] = S[j];
                S[j] = tmp;
            }

            for (a = j = i = 0; i < data.Length; i++)
            {
                a = (a + 1) % S.Length;
                j = (j + S[a]) % S.Length;
                tmp = S[a];
                S[a] = S[j];
                S[j] = tmp;
                k = S[(S[a] + S[j]) % S.Length];
                result[i] = (byte)(data[i] ^ k);
            }

            return Encoding.GetEncoding(1251).GetString(result);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Crypt(textBox1.Text, key);
        }
    }
}
