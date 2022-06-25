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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //veritabanına bağlama kodu//
        SqlConnection bagla = new SqlConnection("Data Source=zelal-cennet21;Initial Catalog=Stajkitap;Integrated Security=True");

        private void grntle()
        {//kendi yordamımız
            listView1.Items.Clear();//tablo da veri tekrarının olmaması icin siler//
            bagla.Open();
            //hangi tabloya bağlayacağımızı sağlayan kod//
            SqlCommand komut = new SqlCommand("select*from kitap ORDER BY kitapad ", bagla);//kitap tablo adı//
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                
                  ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kitapad"].ToString());
                ekle.SubItems.Add(oku["yazarad"].ToString());
                ekle.SubItems.Add(oku["yayınad"].ToString());
                listView1.Items.Add(ekle);
            }
            bagla.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            grntle();//görüldü yordamındakileri tanımla//
        }

        private void button2_Click_1(object sender, EventArgs e)
        {//yeni veri eklememizi sağlar//
            bagla.Open();
            SqlCommand komut = new SqlCommand("Insert into kitap (id,kitapad,yazarad,yayınad)Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", bagla);
            komut.ExecuteNonQuery();
            bagla.Close();
            grntle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
      // sıra nosunu yazarak arama yapma//
            listView1.Items.Clear();
            bagla.Open();
            SqlCommand komut = new SqlCommand("select*from kitap  where id like '%" + textBox1.Text + "%'", bagla);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {//tablo adlarını tanımlama//
                // []icerisindekiler veritabanındaki baslığa  göre yapılır//
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kitapad"].ToString());
                ekle.SubItems.Add(oku["yazarad"].ToString());
                ekle.SubItems.Add(oku["yayınad"].ToString());
                listView1.Items.Add(ekle);
            }
            bagla.Close();
        }//silmemizi sağlıyor//
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            bagla.Open();
            SqlCommand komut = new SqlCommand("Delete from kitap where id=(" + id + ")", bagla);
            komut.ExecuteNonQuery();
            bagla.Close();
            grntle();

        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {//listVievdeki tablodan id yani sıra no bölümüne tıkaldığında üsteki  textBoxlara sırasıyla bilgileiri girer//
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
             textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {//günçelememizi yani kayitli olan veriler üzerinde değişiklik yapmamızı sağlar//
            bagla.Open();
            SqlCommand komut = new SqlCommand("Update kitap set id='"+textBox1.Text.ToString()+"',kitapad='"+textBox2.Text.ToString()+ "',yazarad='"+textBox3.Text.ToString()+"', yayınad = '"+textBox4.Text.ToString()+"'where id=" +id+"",bagla);
            komut.ExecuteNonQuery();
            bagla.Close();
            grntle();
        }
    }
}
