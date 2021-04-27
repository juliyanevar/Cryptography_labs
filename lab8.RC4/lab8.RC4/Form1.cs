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


        string Crypt(string data, byte[] key)
        {
            return Encoding.GetEncoding(1251).GetString(Crypt(Encoding.GetEncoding(1251).GetBytes(data), key));
        }

        byte[] Crypt(byte[] data, byte[] key)
        {
            int a, i, j, k, tmp;
            int[] box = new int[256];
            byte[] result = new byte[data.Length];

            for (i = 0; i < box.Length; i++)
            {
                box[i] = i;
            }

            for (j = i = 0; i < box.Length; i++)
            {
                j = (j + box[i] + key[i % key.Length]) % box.Length;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }

            for (a = j = i = 0; i < data.Length; i++)
            {
                a = (a + 1) % box.Length;
                j = (j + box[a]) % box.Length;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[(box[a] + box[j]) % box.Length];
                result[i] = (byte)(data[i] ^ k);
            }

            return result;
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
