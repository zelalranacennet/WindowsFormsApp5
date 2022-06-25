using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 20)
            {
                timer1.Stop();
                Form2 grs = new Form2();
                grs.Show();
                this.Hide();

            }
            else
            {
                progressBar1.Value++;
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            timer1.Start();
            progressBar1.Maximum = 22;
        }
    }
}
