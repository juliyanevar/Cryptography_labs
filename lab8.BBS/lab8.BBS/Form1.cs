using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8.BBS
{
    public partial class Form1 : Form
    {
        int p, q;
        int x = 3;
        int N = 256;
        double result = -1;


        double BBS(int p, int q)
        {
            int n = p * q;
            if (result == -1)
            {
                result = Math.Pow(x, 2) % n;
            }
            else
            {
                result = Math.Pow(result, 2) % n;
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
            p = Int32.Parse(textBox2.Text);
            q = Int32.Parse(textBox3.Text);

            for (int i = 0; i < N; i++)
            {
                textBox1.Text += BBS(p, q).ToString()+" ";
            }
            
        }
    }
}
