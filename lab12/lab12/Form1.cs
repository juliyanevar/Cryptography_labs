using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        RSA rsa = new RSA();
        ElGamal elGamal = new ElGamal();
        Stopwatch timer = new Stopwatch();
        Schnorr snorr = new Schnorr();
        BigInteger[] digitalSignRSA;
        BigInteger[,] digitalSignElGamal;
        BigInteger[,] digitalSignSnorr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Reset();
            timer.Start();
            digitalSignRSA = rsa.CreateDigitalSign(textBox1.Text);
            timer.Stop();
            textBox3.Text = RSA.res;
            textBox5.Text = timer.Elapsed.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Reset();
            timer.Start();
            textBox4.Text = $"Result of checking digital sign: {rsa.VerifyDigitalSign(textBox2.Text, digitalSignRSA)}";
            timer.Stop();
            textBox6.Text = timer.Elapsed.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer.Reset();
            timer.Start();
            digitalSignElGamal = elGamal.CreateDigitalSign(textBox1.Text);
            timer.Stop();
            textBox3.Text = ElGamal.res;
            textBox5.Text = timer.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer.Reset();
            timer.Start();
            textBox4.Text = $"Result of checking digital sign: {elGamal.VerifyDigitalSign(textBox2.Text, digitalSignElGamal)}";
            timer.Stop();
            textBox6.Text = timer.Elapsed.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer.Reset();
            timer.Start();
            digitalSignSnorr = snorr.CreateDigitalSign(textBox1.Text);
            timer.Stop();
            textBox3.Text = Schnorr.res;
            textBox5.Text = timer.Elapsed.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer.Reset();
            timer.Start();
            textBox4.Text = $"Result of checking digital sign: {snorr.VerifyDigitalSign(textBox2.Text, digitalSignSnorr)}";
            timer.Stop();
            textBox6.Text = timer.Elapsed.ToString();
        }
    }
}
