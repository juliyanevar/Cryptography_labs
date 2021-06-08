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

namespace lab14
{
    public partial class Form1 : Form
    {
        string srcFilename = "", destFilename = "", filename = "", matrixFilename = "";

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                filename = openFileDialog1.FileName;
            else return;
            label2.Text = filename;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream readStream;
            try
            {
                readStream = new FileStream(filename, FileMode.Open);
            }
            catch (IOException)
            {
                MessageBox.Show("Opening file error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = LSB.ExtractText(new Bitmap(readStream));
            readStream.Close();
            textBox2.Text = result;
            filename = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream readStream;
            try
            {
                readStream = new FileStream(srcFilename, FileMode.Open);
            }
            catch (IOException)
            {
                MessageBox.Show("Opening file error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap result = LSB.HideText(textBox1.Text, new Bitmap(readStream));
            readStream.Close();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                destFilename = saveFileDialog1.FileName;
            }
            else return;
            FileStream writeStream;
            try
            {
                writeStream = new FileStream(destFilename, FileMode.Create);
            }
            catch (IOException)
            {
                MessageBox.Show("Opening file error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            result.Save(writeStream, System.Drawing.Imaging.ImageFormat.Bmp);
            writeStream.Close();
            srcFilename = ""; destFilename = "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                srcFilename = openFileDialog1.FileName;
            else return;
            label1.Text = srcFilename;
        }
    }
}
