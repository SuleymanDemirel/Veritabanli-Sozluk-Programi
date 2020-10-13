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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string startupPath = System.IO.Directory.GetCurrentDirectory();
        static string imagesPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resimler\");

        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + startupPath + "\\sozlukdb.accdb");
        OleDbCommand komutt;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();

        DataSet ds = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select Türkçe from sozluk", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.Write(startupPath);
            Console.Write(imagesPath);
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select Türkçe from sozluk", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select Türkçe from sozluk where Türkçe like'" + textBox1.Text + "%'", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0]);
            }
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                textBox7.Text = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                timer3.Start();
            }
            else
            {
                timer3.Stop();
                textBox8.Text = "";
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                timer7.Start();
            }
            else
            {
                timer7.Stop();
                textBox15.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                timer2.Start();
            }
            else
            {
                timer2.Stop();
                textBox9.Text = "";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                timer5.Start();
            }
            else
            {
                timer5.Stop();
                textBox10.Text = "";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                timer4.Start();
            }
            else
            {
                timer4.Stop();
                textBox11.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            baglanti.Open();
            OleDbCommand komutgetir = new OleDbCommand("Select Almanca from sozluk where Türkçe=@p1", baglanti);
            komutgetir.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            OleDbDataReader dr = komutgetir.ExecuteReader();
            while (dr.Read())
            {
                textBox9.Text = dr[0].ToString();
            }
            string resimyolu = imagesPath + listBox1.SelectedItem.ToString() + ".png";
            pictureBox4.ImageLocation = resimyolu;
            baglanti.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komutgetir = new OleDbCommand("Select Ingilizce from sozluk where Türkçe=@p1", baglanti);
            komutgetir.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            OleDbDataReader dr = komutgetir.ExecuteReader();
            while (dr.Read())
            {
                textBox7.Text = dr[0].ToString();
            }
            string resimyolu = imagesPath + listBox1.SelectedItem.ToString() + ".png";
            pictureBox4.ImageLocation = resimyolu;
            baglanti.Close();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komutgetir = new OleDbCommand("Select Fransızca from sozluk where Türkçe=@p1", baglanti);
            komutgetir.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            OleDbDataReader dr = komutgetir.ExecuteReader();
            while (dr.Read())
            {
                textBox8.Text = dr[0].ToString();
            }
            string resimyolu = imagesPath + listBox1.SelectedItem.ToString() + ".png";
            pictureBox4.ImageLocation = resimyolu;
            baglanti.Close();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komutgetir = new OleDbCommand("Select Boşnakça from sozluk where Türkçe=@p1", baglanti);
            komutgetir.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            OleDbDataReader dr = komutgetir.ExecuteReader();
            while (dr.Read())
            {
                textBox11.Text = dr[0].ToString();
            }
            string resimyolu = imagesPath + listBox1.SelectedItem.ToString() + ".png";
            pictureBox4.ImageLocation = resimyolu;
            baglanti.Close();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komutgetir = new OleDbCommand("Select Arnavutça from sozluk where Türkçe=@p1", baglanti);
            komutgetir.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            OleDbDataReader dr = komutgetir.ExecuteReader();
            while (dr.Read())
            {
                textBox10.Text = dr[0].ToString();
            }
            string resimyolu = imagesPath + listBox1.SelectedItem.ToString() + ".png";
            pictureBox4.ImageLocation = resimyolu;
            baglanti.Close();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komutgetir = new OleDbCommand("Select Latince from sozluk where Türkçe=@p1", baglanti);
            komutgetir.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            OleDbDataReader dr = komutgetir.ExecuteReader();
            while (dr.Read())
            {
                textBox15.Text = dr[0].ToString();
            }
            string resimyolu = imagesPath + listBox1.SelectedItem.ToString() + ".png";
            pictureBox4.ImageLocation = resimyolu;
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

      
    }
}
