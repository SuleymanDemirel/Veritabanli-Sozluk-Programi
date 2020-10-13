using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace sozlukprogrami
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\Documents\Visual Studio 2015\Projects\sozlukprogrami\sozlukprogrami\bin\Debug\sozlukdb.accdb");

        OleDbCommand komutt;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        private void dblistele()
        {
            tablo.Clear();
            baglanti.Open();
            komutt = new OleDbCommand("Select * from sozluk", baglanti);
            adtr = new OleDbDataAdapter(komutt);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dblistele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komutt = new OleDbCommand("DELETE FROM sozluk where Türkçe=@Türkçe", baglanti);
            komutt.Parameters.AddWithValue("@Türkçe", textBox1.Text);
            komutt.ExecuteNonQuery();
            baglanti.Close();
            dblistele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komutt = new OleDbCommand("INSERT INTO sozluk (Türkçe,Ingilizce,Almanca,Fransızca,Boşnakça,Arnavutça,Latince) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", baglanti);
            komutt.ExecuteNonQuery();
            baglanti.Close();
            dblistele();
        }
    }
}
