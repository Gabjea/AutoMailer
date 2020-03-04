using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMailer
{
    public partial class Popup : Form
    {
        public Popup(string r)
        {
          
            InitializeComponent();
            label1.Text = r;
        
            this.Width += 15+Math.Abs(this.Width-label1.Width);
            label1.Location = new Point(this.Width / 2 - label1.Size.Width / 2, 30);
            button3.Location = new Point(this.Width / 2-button3.Size.Width/2,button3.Location.Y);
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Popup_Load(object sender, EventArgs e)
        {
        
        }
    }
}
