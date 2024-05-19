using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EsdTurnikesi
{
    public partial class EkAyarForm : Form
    {
  
        public string vardiyeSaat1 ,vardiyeSaat2, vardiyeSaat3, vardiyeSaat4, vardiyeSaat5, vardiyeSaat6,getMailQuery;
        DataTable data;
        AyarForm ayar;
        bool isOpen = false;
        byte indexDelete = 0;
        static string getDesktopURL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Software\esdLocalDb.mdf";
        string connLocal = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + getDesktopURL + "; Integrated Security = True; Connect Timeout = 20";
        string connA= @"Data Source=192.168.0.8\MEYER;Initial Catalog=ALPPLAS_ESD_TURNIKE;User ID=esd;Password=AtsOlC*54AtsOlC*54";

        private void btnMail_Click(object sender, EventArgs e)
        {
            checkBoxVardiye1.Checked = false;
            checkBoxVardiye2.Checked = false;
            checkBoxVardiye3.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Tekrar basmanız halinde tüm  veriler silenecek !";
            textBox1.Visible = true;
            indexDelete++;
            if (indexDelete == 2) 
            {
                Main main = new Main();
                SqlConnection sqlConncetion = new SqlConnection(connA);
                sqlConncetion.Open();
                if (sqlConncetion.State==ConnectionState.Open) {
                    string sqlComm = "delete from esd_turnike_tb";
                    SqlCommand sqlDelete = new SqlCommand(sqlComm,sqlConncetion);
                    SqlDataReader sqlDataReader = sqlDelete.ExecuteReader();
                    sqlDataReader.Close();
                    string sqlComm2 = "delete from log_tb";
                    sqlDelete = new SqlCommand(sqlComm2, sqlConncetion);
                    sqlDataReader = sqlDelete.ExecuteReader();
                    sqlDataReader.Close();
                    sqlConncetion.Close();
                    textBox1.Text = "Tüm verileri siindi !";
                    indexDelete = 0;
                }
            
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            indexDelete = 0;
            textBox1.Visible = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (isOpen) 
            {
                DataView dataView = data.DefaultView;
                dataView.RowFilter = string.Format("isim like '%{0}%'", txtName.Text);
                dataGridView1.DataSource = dataView.ToTable();
            }
          
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            ayar.DrawGroupBox(box, e.Graphics, Color.Orange, Color.White);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            SqlConnection sqlConnection = new SqlConnection(connA);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {

                this.getMailQuery = "SELECT e.sicil_ID As Kart_Numarası, isim as İsim, soyisim as Soyisim, e.tarih As Tarih, e.mola as [Toplam Mola],l.giris_saat as [Giris Saati],l.cikis_saat[Çıkış Saati] " +
                  "FROM esd_turnike_tb e inner join log_tb l on e.sicil_ID=l.sicil_ID  where e.tarih='" + date + "' and l.tarih='" + date + "' order by isim";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(getMailQuery, sqlConnection);
                data = new DataTable();
                sqlDataAdapter.Fill(data);
                dataGridView1.DataSource = data;
                isOpen = true;
            }
            sqlConnection.Close();
        }   
        
        public string[] saatler = new string[] {"00:00:00","01:00:00","02:00:00","03:00:00", "04:00:00",
                "05:00:00", "06:00:00", "07:00:00" , "08:00:00", "09:00:00", "10:00:00", "11:00:00" ,
                "12:00:00", "13:00:00", "14:00:00", "15:00:00", "16:00:00","17:00:00", "18:00:00", "19:00:00",
                "20:00:00", "21:00:00", "22:00:00", "23:55:00"};
      
      
        public EkAyarForm()
        {
            InitializeComponent();
            this.ayar = new AyarForm();
        }

        private void EkAyarForm_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            for (int i = 0; i < saatler.Length; i++)
            {
                comboBox1.Items.Add(saatler[i]);
                comboBox2.Items.Add(saatler[i]);
                comboBox3.Items.Add(saatler[i]);
                comboBox4.Items.Add(saatler[i]);
                comboBox5.Items.Add(saatler[i]);
                comboBox6.Items.Add(saatler[i]);
            }
            comboBox1.Text = Ayarlar.Default.vardiyeSaat1;
            comboBox2.Text = Ayarlar.Default.vardiyeSaat2;
            comboBox3.Text = Ayarlar.Default.vardiyeSaat3;
            comboBox4.Text = Ayarlar.Default.vardiyeSaat4;
            comboBox5.Text = Ayarlar.Default.vardiyeSaat5;
            comboBox6.Text = Ayarlar.Default.vardiyeSaat6;
            checkBoxVardiye1.Checked = Ayarlar.Default.checkVardiye1;
            checkBoxVardiye2.Checked = Ayarlar.Default.checkVardiye2;
            checkBoxVardiye3.Checked = Ayarlar.Default.checkVardiye3;

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            Ayarlar.Default.vardiyeSaat1 = vardiyeSaat1 = comboBox1.Text;
            Ayarlar.Default.vardiyeSaat2 = vardiyeSaat2 = comboBox2.Text;
            Ayarlar.Default.vardiyeSaat3 = vardiyeSaat3 = comboBox3.Text;
            Ayarlar.Default.vardiyeSaat4 = vardiyeSaat4 = comboBox4.Text;
            Ayarlar.Default.vardiyeSaat5 = vardiyeSaat5 = comboBox5.Text;
            Ayarlar.Default.vardiyeSaat6 = vardiyeSaat6 = comboBox6.Text;
            Ayarlar.Default.checkVardiye1 = checkBoxVardiye1.Checked;
            Ayarlar.Default.checkVardiye2 = checkBoxVardiye2.Checked;
            Ayarlar.Default.checkVardiye3 = checkBoxVardiye3.Checked;
            Ayarlar.Default.Save();
            MessageBox.Show("Kaydedildi !");
            this.Close();

        }
    }
}
