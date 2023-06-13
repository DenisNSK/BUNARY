using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace BinaryReader26._01._23
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            Encoding Cod = Encoding.UTF8;
            if (radioButton1.Checked)
            {
                Cod = Encoding.UTF8;
            }
            else if (radioButton2.Checked)
            {
                Cod = Encoding.Unicode;
            }
            else if (radioButton3.Checked)
            {
                Cod = Encoding.ASCII;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;

                using (var stream = File.Open(s, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Cod, false))
                    {
                        writer.Write(textBox1.Text);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tempDirectory;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Encoding Cod = Encoding.UTF8;
            if (radioButton1.Checked)
            {
                Cod = Encoding.UTF8;
            }
            else if (radioButton2.Checked)
            {
                Cod = Encoding.Unicode;
            }
            else if (radioButton3.Checked)
            {
                Cod = Encoding.ASCII;
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog.FileName;

                using (var stream = File.Open(s, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Cod, false))
                    {
                        //reader.Read(textBox1.Text);
                        tempDirectory= reader.ReadString();
                        textBox1.Text = tempDirectory;
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
