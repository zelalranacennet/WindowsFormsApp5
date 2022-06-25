using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source=zelal-cennet21;Initial Catalog=Stajkitap;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                string sql = "select*from parola where ad=@adi AND sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, bag);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    
                    Form1 fr = new Form1();
                    fr.Show();
                    this.Hide();
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("hatalı giriş");
                
            }
        }

        
    }
}
