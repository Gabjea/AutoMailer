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
using System.Runtime.InteropServices;

namespace AutoMailer
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Config_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "config.txt";
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            string[] config = {textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text};
            File.WriteAllLines(fullPath, config);
            this.Close();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            string fileName = "config.txt";
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            string[] lines = File.ReadAllLines(fullPath);
            int k = 0;
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = lines[k++];
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
