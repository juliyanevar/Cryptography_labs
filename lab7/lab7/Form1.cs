using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        DES_EEE2CryptoEncode encode = new DES_EEE2CryptoEncode();
        DES_EEE2CryptoDecode decode = new DES_EEE2CryptoDecode();
        string crypted, uncrypted;

        public Form1()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crypted = encode.Encode(textBox1.Text, textBox3.Text, textBox4.Text);
            textBox2.Text = crypted;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            uncrypted = decode.Decode(crypted, textBox3.Text, textBox4.Text);
            textBox2.Text = uncrypted;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
