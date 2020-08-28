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
using System.Xml.Serialization;

namespace EmlakOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-7HDI1FAU;Initial Catalog=siteler;Integrated Security=True");
        private void ShowData()
        {
            listView1.Items.Clear();
           
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From sitebilgi", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            
            while (oku.Read ())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems .Add   (oku["site"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());

                ekle.SubItems.Add(oku["notlar"].ToString());


                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        

        private void cbxsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxsite .Text=="Enes Sitesi")
            {
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;

            }
            if (cbxsite.Text == "Esmanur Sitesi")
            {
                button3.BackColor = Color.Red;
                button2.BackColor = Color.Gray;
                button1.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;

            }
            if (cbxsite.Text == "Elif Sitesi")
            {
                button4.BackColor = Color.Red;
                button2.BackColor = Color.Gray;
                button1.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;

            }
            if (cbxsite.Text == "Yusuf Sitesi")
            {
                button2.BackColor = Color.Red;
                button3.BackColor = Color.Gray;
                button1.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowData();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut=new SqlCommand ("Insert into sitebilgi(id,site,satkira,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar) values('" + tbxsira .Text.ToString()+ "','" + cbxsite .Text.ToString() + "','" + cbxsatkira .Text.ToString() + "','" + cbxodasayisi .Text.ToString() + "','" + tbxmetrekare.Text.ToString() + "','" + tbxfiyat .Text.ToString() + "','" + comboBox2 .Text.ToString() + "','" + comboBox1 .Text.ToString() + "','" + tbxadsoyad .Text.ToString() + "','" + tbxtel .Text.ToString() + "','" + tbxnotlar .Text.ToString() + "')",baglan );
            komut.ExecuteNonQuery();
            baglan.Close();
            ShowData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from sitebilgi where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            ShowData();

        }
        int id = 0;

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            tbxsira.Text = listView1.SelectedItems[0].SubItems[0].Text;
            cbxsite.Text = listView1.SelectedItems[0].SubItems[1].Text;
            cbxsatkira .Text = listView1.SelectedItems[0].SubItems[2].Text;
            cbxodasayisi .Text = listView1.SelectedItems[0].SubItems[3].Text;
            tbxmetrekare .Text = listView1.SelectedItems[0].SubItems[4].Text;
            tbxfiyat .Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox1 .Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboBox2 .Text = listView1.SelectedItems[0].SubItems[7].Text;
            tbxadsoyad .Text = listView1.SelectedItems[0].SubItems[8].Text;
            tbxtel.Text = listView1.SelectedItems[0].SubItems[9].Text;
            tbxnotlar .Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update sitebilgi set id='" + tbxsira.Text.ToString() + "',site='" + cbxsite.Text.ToString() + "', satkira = '" + cbxsatkira .Text.ToString() + "',oda='" + cbxodasayisi .Text.ToString() + "',metre='" + tbxmetrekare .Text.ToString() + "',fiyat='" + tbxfiyat .Text.ToString() + "',blok='" + comboBox2.Text.ToString() + "',no='" + comboBox1 .Text.ToString() + "',adsoyad='" + tbxadsoyad .Text.ToString() + "',telefon='" + tbxtel .Text.ToString() + "',notlar='" + tbxnotlar  .Text.ToString() + "'where id ="+id+"",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            ShowData();
        }
    }
}
