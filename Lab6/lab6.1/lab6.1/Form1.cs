using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox3.Text!="" && textBox4.Text != "" && textBox5.Text != "")
            {
                string res;
                var enigma = new Enigma();
                var encoded = enigma.Crypt(textBox1.Text, 1, 0, 1, out res);
                textBox2.Text= encoded;
                //textBox2.Text += res;
            }
        }
    }
}
