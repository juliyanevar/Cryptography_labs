using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;

namespace lab11
{
    public partial class Form1 : Form
    {
        static Stopwatch timer = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        public string GetHash(string input)
        {
            timer.Reset();
            timer.Start();
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            timer.Stop();

            return Convert.ToBase64String(hash);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = GetHash(textBox1.Text);
            textBox3.Text = timer.Elapsed.ToString();
        }
    }
}
