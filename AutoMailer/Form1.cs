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
    public partial class Form1 : Form
    {
        public Form1()
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

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text.ToString());
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
                // SMTP user authentication
                oServer.User = "contact@wireimpulse.com";
                oServer.Password = "Wire2017";
                oServer.Port = 465;
                foreach (String email in listBox1.Items)
                {
                    SmtpMail oMail = new SmtpMail("TryIt");
                    oMail.From = new MailAddress("contact@wireimpulse.com");
                    oMail.To.Add(new MailAddress(email));

                    oMail.Subject = "test email sent from C#";
                    oMail.TextBody = "test body";

                    SmtpClient oSmtp = new SmtpClient();
                    oSmtp.SendMail(oServer, oMail);
                    Console.WriteLine("This email has been submitted to server successfully!");
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
