using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EASendMail;

namespace AutoMailer
{
    public partial class AutoMailer : Form
    {
        public AutoMailer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
            
         
            for (int i = 8; i <= 60; i++)
                comboBox2.Items.Add(i);

            comboBox1.SelectedIndex =8;
            comboBox2.SelectedIndex = 6;
            richTextBox1.SelectionFont = new Font(comboBox1.SelectedItem.ToString(), Int32.Parse(comboBox2.SelectedItem.ToString()));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
                listBox1.Items.Add(textBox1.Text);
            else MessageBox.Show("Te rog sa introduci un email!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

                richTextBox1.SelectAll();
                richTextBox1.SelectionFont = new Font(comboBox1.SelectedItem.ToString(),Int32.Parse(comboBox2.SelectedItem.ToString()));
                
                 richTextBox1.Refresh();
            
            
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionFont = new Font(comboBox1.SelectedItem.ToString(), Int32.Parse(comboBox2.SelectedItem.ToString()));
            richTextBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                SmtpServer oServer = new SmtpServer("mail.wireimpulse.com");
                oServer.User = "contact@wireimpulse.com";
                oServer.Password = "Wire2017";
                oServer.ConnectType = SmtpConnectType.ConnectTryTLS;
                oServer.Port = 465;
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                foreach (String email in listBox1.Items)
                {
                    SmtpMail oMail = new SmtpMail("TryIt");
                    oMail.From = new MailAddress("contact@wireimpulse.com");
                    oMail.To.Add(new MailAddress(email));

                    oMail.Subject = textBox2.Text;
                    oMail.TextBody = richTextBox1.Text;

                    SmtpClient oSmtp = new SmtpClient();
                    oSmtp.SendMail(oServer, oMail);
                    Console.WriteLine("This email has been submitted to server successfully!");
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {



        }

        private void button5_Click(object sender, EventArgs e)
        {
            Config f = new Config();
            f.Show();
        }
    }
}
