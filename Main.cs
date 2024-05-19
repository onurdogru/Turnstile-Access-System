// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.Main
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8

using EsdTurnikesi.Properties;
using Modbus.Device;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Utilities;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;


namespace EsdTurnikesi
{
    public class Main : Form
    {
        public string Gelen = string.Empty;
        public string Gelen2 = string.Empty;
        public string Gelen22 = string.Empty;
        public string GelenM3 = string.Empty;
        public bool esdAktif = true;
        public bool mifaredataaktif = true;
        public bool mifaredataaktif2 = true;
        public bool esddataaktif = true;
        public bool timerconverter = true;
        public string esdresult = string.Empty;
        public AyarForm AyarFrm;
        public Sifre SifreFrm;
        public EkAyarForm EkAyarFrm;
        private const byte SW_HIDE = 0;
        private const byte SW_SHOW = 1;
        private IntPtr ShellHwnd;
        public ushort[] readreg;
        public int esdSolAyak;
        public int esdSagAyak;
        public int esdCiftAyak;
        public int esdBileklik;
        public bool AyakAktif, bileklikAktif, vardiye1Aktif, vardiye2Aktif, vardiye3Aktif;
        public int yetki;
        private IContainer components;
        public Timer timerModbus;
        public Timer timerBekleme;
        public Timer timerESD;
        public Timer timerMifare;
        private Timer timerAdmin;
        public Timer timerTurnike;
        public Timer timerMifare2;
        public SerialPort mifarePort;
        public SerialPort esdPort;
        public SerialPort plcPort;
        private TableLayoutPanel tableLayoutPanel12;
        private TableLayoutPanel tableLayoutPanel9;
        private Label lblSolOlcum;
        private Label lblSagOlcum;
        private TableLayoutPanel tableLayoutPanel8;
        private PictureBox pictureSol;
        private PictureBox pictureSag;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblUyari;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel headerpanel;
        private Label top_label;
        private Panel sidepanel;
        private Panel logopanel;
        private PictureBox pictureBoxAlpnextlogo;
        private Button btnCikis;
        private Button btnAyar;
        private Button button_kullanici;
        private TableLayoutPanel tableLayoutPanel13;
        private Label lblSicil;
        private Label lblAdSoyad;
        private PictureBox pictureBox4;
        private Label label10;
        private Label lblTarih;
        private PictureBox pictureBox5;
        public SerialPort mifarePort2;
        private DateTime now;
        public DataTable dt;
        public SqlConnection sqlConnectionMain,sqlConnectionLocal,sqlConnectionMeyer;
        SqlCommand sqlCommand, comLogSelect, update, insert,mailCheck;
        SqlDataReader dr,drMail;
        SqlDataAdapter da;
        private TextBox txtCardID;
        public static int mailThreadSayac = 0;
        Int32 minute;
        int hour, mola, toplam_mola = 0, gecici_mola = 0, calisma_suresi = 0, 
            logID, toplam_calisma = 0, cardLenght,departmentID;
        string hexstring, result, result1, result2, result3, result4, sonuc, girisLog,
         date, time, sicilID, mail_Ad, mail_Soyad, cikis, yesterday,
         timeMail, vardiye1, vardiye2, vardiye3, vardiye3Saat, cardID,myCardID, zero,getPersonQuery,getMailQuery,getMailList;
        static string pass = "AtsOlC*54AtsOlC*54", mailBody;
        private bool flagGecis = true, flagMailDepartment, flagPass, flagConnectionSettings = true,networkUp,flagIn=true,  flagCard = true;
        public  bool flagConnection, esdAyakSonucSol=false, esdAyakSonucSag = false,flagMifarePort3=false;
        string connA = @"Data Source=192.168.0.8\MEYER;Initial Catalog=ALPPLAS_ESD_TURNIKE;User ID=esd;Password=" + pass + "; Connect Timeout = 5 ";
        string getDesktopURL;
        string connLocal;
        static string password = "123+asdF**"; // "F@7ihC52637*";
        static string username = "said.bilgehan@alpplas.com"; //"fatih.cengiz@alpplas.com"; "said.bilgehan@alpplas.com;;
        UInt64 decValueSon, decValue;
        static List<string> mailList;
        private Timer timerConnect;
        private Button button1;
        private Timer timerMail;
        public Timer timerCikis;
        string urlDesktop,cardWarningText,mailAdress;
        float esdValueLeft, esdValueRight;
        private Button button3;
        public SerialPort mifarePort3;
        private Button button2;
        string cardID3, getPersonQuery3, sicilID3, mail_Ad3, mail_Soyad3, myCardID3, mailAdress3;
        SqlCommand sqlCommand3;
        SqlDataReader dr3;
        DateTime now3;
        bool flagMailDepartment3;
        int departmentID3;

        ulong decValue3, decValueSon3;
        bool flagCard3=true,mifareDataAktif3=true;
        string hexstring3;
        string sonucM, resultM, resultM1, resultM2, resultM3, resultM4, zeroM;
        private Timer timerMifare3;
        int cardLenght3;

        string date3, time3, yesterday3, cikis3, girisLog3;
        SqlCommand comLogSelect3, insert3, update3;
        int minute3, hour3, calisma_suresi3, toplam_mola3, logID3,mesaiPeriyot = 0, mesaiPeriyot3 = 0;
        bool flagPass3;

        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref Main.tagLASTINPUTINFO plii);
        public Main()
        {

            this.AyarFrm = new AyarForm();
            this.AyarFrm.MainFrm = this;
            this.SifreFrm = new Sifre();
            this.SifreFrm.MainFrm = this;
            this.EkAyarFrm = new EkAyarForm();

            this.InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern byte ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string ClassName, string WindowName);

        private void Main_Load(object sender, EventArgs e)
        {

            //******** Mail mesaj tablosu  ********
            dt = new DataTable();/*
      dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Numara", typeof(int)),
      new DataColumn("Sicil Numarası", typeof(string)),
      new DataColumn("İsim",typeof(string)) });
      //   dt.Rows.Add(mailSayac, sicilID, mail_Ad); 
      //****************************/
            getUrlDesktop();
            sqlConnectionSettings();// sql conncetion open

            this.tableLayoutPanel2.BackgroundImage = (Image)Resources.personPanel3D;
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShellHwnd = Main.FindWindow("Shell TrayWnd", (string)null);
            IntPtr shellHwnd = this.ShellHwnd;
            int num1 = (int)Main.ShowWindow(this.ShellHwnd, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.lblUyari.ForeColor = System.Drawing.Color.Black;
            this.lblUyari.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyari.Text = "ESD ölçümü için personel kimlik kartınızı okutunuz...";
            foreach (string portName in SerialPort.GetPortNames())
            {
                this.AyarFrm.mifarecom.Items.Add((object)portName);
                this.AyarFrm.mifarecom2.Items.Add((object)portName);
                this.AyarFrm.mifarecom3.Items.Add((object)portName);
                this.AyarFrm.esdcom.Items.Add((object)portName);
                this.AyarFrm.plcCom.Items.Add((object)portName);
            }
            this.mifarePort3.PortName = Ayarlar.Default.mifareCom3;
            this.mifarePort3.ReceivedBytesThreshold = 1;
            this.mifarePort.PortName = Ayarlar.Default.mifareCom;
            this.mifarePort.BaudRate = Ayarlar.Default.mifareBaud;
            this.mifarePort.DataBits = Ayarlar.Default.mifaredataBits;
            this.mifarePort.StopBits = Ayarlar.Default.mifarestopBit;
            this.mifarePort.Parity = Ayarlar.Default.mifareParity;
            this.mifarePort.ReceivedBytesThreshold = 1;
            this.mifarePort2.PortName = Ayarlar.Default.mifareCom2;
            this.mifarePort2.BaudRate = Ayarlar.Default.mifareBaud2;
            this.mifarePort2.DataBits = Ayarlar.Default.mifaredataBits2;
            this.mifarePort2.StopBits = Ayarlar.Default.mifarestopBits2;
            this.mifarePort2.Parity = Ayarlar.Default.mifareParity2;
            this.mifarePort2.ReceivedBytesThreshold = 1;
            this.esdPort.PortName = Ayarlar.Default.esdCom;
            this.esdPort.BaudRate = Ayarlar.Default.esdBaud;
            this.esdPort.DataBits = Ayarlar.Default.esddataBits;
            this.esdPort.StopBits = Ayarlar.Default.esdstopBit;
            this.esdPort.Parity = Ayarlar.Default.esdParity;
            this.plcPort.PortName = Ayarlar.Default.plcCom;
            this.plcPort.BaudRate = Ayarlar.Default.plcBaud;
            this.plcPort.DataBits = Ayarlar.Default.plcdataBits;
            this.plcPort.StopBits = Ayarlar.Default.plcstopBit;
            this.plcPort.Parity = Ayarlar.Default.plcParity;
            this.timerModbus.Interval = Ayarlar.Default.timerModbus;
            this.timerAdmin.Interval = Ayarlar.Default.timerAdmin;
            this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
            this.timerESD.Interval = Ayarlar.Default.timerESD;
            this.timerMifare.Interval = Ayarlar.Default.timerMifare;
            this.timerMifare2.Interval = Ayarlar.Default.timerMifare2;
            this.timerTurnike.Interval = Ayarlar.Default.timerTurnike;
            this.AyakAktif = Ayarlar.Default.checkAyak;
            this.bileklikAktif = Ayarlar.Default.checkBileklik;
            this.vardiye1Aktif = Ayarlar.Default.checkVardiye1;
            this.vardiye2Aktif = Ayarlar.Default.checkVardiye2;
            this.vardiye3Aktif = Ayarlar.Default.checkVardiye3;
            this.yetki = 0;
            this.yetkidegistir();
            try
            {
                this.mifarePort.Open();
                this.mifarePort2.Open();
                this.mifarePort3.Open();
                this.esdPort.Open();
                this.plcPort.Open();
            }
            catch (Exception ex)
            {
                this.timerModbus.Enabled = false;
                int num2 = (int)MessageBox.Show("Port Hatası: " + ex.ToString());
            }
            new globalKeyboardHook()
            {
                HookedKeys = {
          Keys.Alt,
          Keys.RControlKey,
          Keys.LControlKey,
          Keys.Delete,
          Keys.Tab,
          Keys.Shift,
          Keys.F4
        }
            }.KeyDown += new KeyEventHandler(this.gkh_KeyDown);
        }

        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void timerMifare3_Tick(object sender, EventArgs e)
        {
            timerMifare3.Enabled = false;
            mifareDataAktif3 = false;
            HexConverterM3();

            if (getirM3())
            {
                if (flagConnection && !flagMifarePort3 )
                {
                    System.Threading.Thread thread_log = new System.Threading.Thread(() => logekleM3());
                    thread_log.Start();
                }
            }
            mifarePort3Refresh();
            mifareDataAktif3 = true;

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
 
            int num = (int)this.AyarFrm.ShowDialog();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*TimeSpan dateTimeSonuc = DateTime.Parse("01:55:00").Subtract(DateTime.Parse("00:00:00"));
            minute = int.Parse(dateTimeSonuc.Minutes.ToString());
            hour = int.Parse(dateTimeSonuc.Hours.ToString());
            calisma_suresi = hour * 60 + minute;
       //     MessageBox.Show(calisma_suresi.ToString());
            /*string date = DateTime.Now.ToString("dd.MM.yyyy");
            SqlConnection sqlConnection = new SqlConnection(connA);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                cardID = "000000057241801";

                string getMailQuery = "select * from  log_tb where sicil_ID='"+cardID+"' and tarih ='21.01.2022' and cikis_saat=''";

                SqlCommand cmd = new SqlCommand(getMailQuery, sqlConnection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(dr["giris_saat"].ToString());
                }
                else
                {
                    MessageBox.Show("kayit yok");
                }

            }
            sqlConnection.Close();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (getirM3()) {
                comLogSelect3 = new SqlCommand("SELECT * FROM log_tb where sicil_ID='" + myCardID3 + "' and tarih='11.02.2022' and cikis_saat='"+ null +"'", sqlConnectionMeyer);
            dr3 = comLogSelect3.ExecuteReader();
            if (dr3.Read())
            {

                girisLog3 = dr3["sicil_ID"].ToString();
                MessageBox.Show(girisLog3);
            }
                else
                {
                    MessageBox.Show("no");
                }
            }
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {

        }
        private void getUrlDesktop()
        {
            urlDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Software\esdLocalDb.mdf";
            getDesktopURL = urlDesktop;
            connLocal = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + getDesktopURL + "; Integrated Security = False; Connect Timeout = 5";
        }
        private void sqlConnectionSettings()
        {
          
            if (flagConnectionSettings == true)
            {
                this.sqlConnectionMain = new SqlConnection(AyarForm.conn);
                this.sqlConnectionMeyer = new SqlConnection(connA);
                connectionCheck();
                try
                {
                    sqlConnectionMain.Open();
                    sqlConnectionMeyer.Open();
                    
                }
                catch (Exception)
                {
               //     MessageBox.Show("Veri tabanı bağlantılarını kontrol ediniz. ");
                    flagConnection = false;
                    flagConnectionSettings = false;

                }

            }
        }

        public bool getir()//****Personel sicil numarası ve isim verisi 
        {

            if (this.sqlConnectionMain.State == ConnectionState.Open && flagConnection == true)
            {
                 cardID = zero + Gelen;
              //  MessageBox.Show(cardID.ToString());
                if (Ayarlar.Default.departmentListIndex != null)
                {
                    this.getPersonQuery = string.Format("SELECT s.SicilNo,s.Ad,s.SoyAd,b.ID as bolumID,u.CardID as CardID,s.Email as mailAdress,s.MesaiPeriyodu as mesaiPeriyodu FROM UserList u inner join Sicil s on u.UserID=s.UserID " +
                    "inner join cbo_Bolum b on b.ID=s.Bolum " +
                    "WHERE  u.CardID='" 
                    + cardID + "' and b.ID in ({0})", string.Join(", ", Ayarlar.Default.departmentListIndex.ToArray()));
                    this.sqlCommand = new SqlCommand(getPersonQuery, sqlConnectionMain);
                    this.dr = sqlCommand.ExecuteReader();
                }
                else
                {
                    return false;
                }

                if (dr.Read())
                {
                    if (mifaredataaktif2)
                    {
                        this.tableLayoutPanel2.Visible = true;
                    }
                    this.lblSicil.ForeColor = Color.White;
                    this.lblAdSoyad.ForeColor = Color.White;
                    this.departmentID = Int16.Parse(dr["bolumID"].ToString());
                    this.lblSicil.Text = "Sicil No : " + dr["SicilNo"].ToString();
                    this.lblAdSoyad.Text = "İsim : " + dr["Ad"].ToString() + " " + dr["SoyAd"];
                    this.sicilID = dr["SicilNo"].ToString();
                    this.mail_Ad = dr["Ad"].ToString();
                    this.mail_Soyad = dr["SoyAd"].ToString();
                    this.myCardID = dr["CardID"].ToString();
                    this.mailAdress = dr["mailAdress"].ToString();
                    this.mesaiPeriyot = Int16.Parse(dr["mesaiPeriyodu"].ToString());
                    this.now = DateTime.Now; 
                    this.lblTarih.Text = now.ToString("F");
                    this.lblTarih.ForeColor = Color.Green;
                    this.flagMailDepartment = Ayarlar.Default.mailDepartmentListIndex.Contains(departmentID);
                    this.Gelen = string.Empty;
                    this.zero = string.Empty;
                    this.sqlCommand.Dispose();
                    this.dr.Dispose();
                    insideControl();
                    if (flagPass == false)
                    {
                        return true;
                    }
                    else
                    {
                        this.lblUyari.ForeColor = Color.White;
                        this.lblUyari.BackColor = Color.Red;
                        this.lblUyari.Text = "2 kere giriş yapmaya çalıştınız!";
                        this.Gelen = string.Empty;
                        this.zero = string.Empty;
                        this.sqlCommand.Dispose();
                        this.dr.Dispose();
                        return false;
                    }

                }
                else
                {

                    if (mifaredataaktif2)
                    {
                        this.tableLayoutPanel2.Visible = true;
                    }
                    this.lblSicil.ForeColor = Color.White;
                    this.lblAdSoyad.ForeColor = Color.White;
                    this.lblSicil.Text = "Sicil No : Tanımsız";
                    this.lblAdSoyad.Text = "İsim : Tanımsız";
                    this.lblUyari.ForeColor = Color.White;
                    this.lblUyari.BackColor = Color.Red;
                    if (flagCard) 
                    {
                       this.lblUyari.Text = "Bu bölüme giriş hakkınız yoktur !";
                   }
                   else
                   {
                        this.lblUyari.Text = cardWarningText;
                        flagCard = true;
                   }
                    this.Gelen = string.Empty;
                    this.zero = string.Empty;
                    this.sqlCommand.Dispose();
                    this.dr.Dispose();
                    //  dr.Close();
                    /*  insert = new SqlCommand("INSERT INTO esd_turnike_tb" +
                          " (sicil_ID,isim,soyisim,tarih,giris_saat,cikis_saat,mola) VALUES" +
                          " ('" + cardID + "','" + lblAdSoyad.Text + "','" + null + "','" + date + "','" + time + "','" + null + "'," + 0 + ");", );
                      dr = insert.ExecuteReader();*/
                    //     girisUpdate();
                    //  dr.Close();
                      return false;
                }
            }
            else
            {
                myCardID = zero + Gelen;
                this.sqlConnectionSettings();
                if (flagConnection) 
                {
                    insideControl();
                }
               
                this.Gelen = string.Empty;
                this.zero = string.Empty;
                if (flagPass == false)
                {
                    return true;
                }
                else
                {
                    this.lblUyari.ForeColor = Color.White;
                    this.lblUyari.BackColor = Color.Red;
                    this.lblUyari.Text = "2 kere giriş yapmaya çalıştınız!";
                    this.Gelen = string.Empty;
                    this.zero = string.Empty;
                    return false;
                }
            }
        }


        public bool getirM3()//****Personel sicil numarası ve isim verisi çıkış için 
        {

            if (this.sqlConnectionMain.State == ConnectionState.Open && flagConnection == true)
            {
                 cardID3 = zeroM + GelenM3;
              //  MessageBox.Show(cardID3.ToString());
                if (Ayarlar.Default.departmentListIndex != null)
                {
                    this.getPersonQuery3 = string.Format("SELECT s.SicilNo,s.Ad,s.SoyAd,b.ID as bolumID,u.CardID as CardID,s.Email as mailAdress,s.MesaiPeriyodu as mesaiPeriyodu FROM UserList u inner join Sicil s on u.UserID=s.UserID " +
                    "inner join cbo_Bolum b on b.ID=s.Bolum " +
                    "WHERE  u.CardID='" + cardID3 + "' and b.ID in ({0})", string.Join(", ", Ayarlar.Default.departmentListIndex.ToArray()));
                    this.sqlCommand3 = new SqlCommand(getPersonQuery3, sqlConnectionMain);
                    this.dr3 = sqlCommand3.ExecuteReader();
                }
                else
                {
                    return false;
                }

                if (dr3.Read())
                {

                    this.sicilID3 = dr3["SicilNo"].ToString();
                    this.mail_Ad3 = dr3["Ad"].ToString();
                    this.mail_Soyad3 = dr3["SoyAd"].ToString();
                    this.myCardID3 = dr3["CardID"].ToString();
                    this.mailAdress3 = dr3["mailAdress"].ToString();
                    this.mesaiPeriyot3 = Int16.Parse(dr3["mesaiPeriyodu"].ToString());
                    this.departmentID3 = Int16.Parse(dr3["bolumID"].ToString());
                    this.now3 = DateTime.Now;
                    this.flagMailDepartment3 = Ayarlar.Default.mailDepartmentListIndex.Contains(departmentID3);
                    this.GelenM3 = string.Empty;
                    this.zeroM = string.Empty;
                    this.sqlCommand3.Dispose();
                    this.dr3.Dispose();
               
                }
                else
                {
                    if (flagCard3)
                    {
                        //this.lblUyari.Text = "Bu bölüme giriş hakkınız yoktur !";
                    }
                    else
                    {
                        //this.lblUyari.Text = cardWarningText;
                        flagCard3 = true;
                    }
                    this.GelenM3 = string.Empty;
                    this.zeroM = string.Empty;
                    this.sqlCommand3.Dispose();
                    this.dr3.Dispose();
                    return false;
                }
            }
            else
            {
                myCardID3 = zeroM + GelenM3;
                this.sqlConnectionSettings();            
                this.GelenM3 = string.Empty;
                this.zeroM = string.Empty;
            }
            return true;
        }
        public void logekle() // Personel giriş ve çıkış verisinin loglandığı kısım
        {
            date = DateTime.Now.ToString("dd.MM.yyyy");
            time = DateTime.Now.ToString("HH:mm:ss");
            yesterday = DateTime.Now.Date.AddDays(-1).ToString("dd.MM.yyyy");
            // giris ve sicil id kontrol
            comLogSelect = new SqlCommand("SELECT * FROM esd_turnike_tb where sicil_ID='" + myCardID + "' and tarih='" + date + "'", sqlConnectionMeyer);
            if (!dr.IsClosed)
            {
                dr.Close();
            }
            dr = comLogSelect.ExecuteReader();
            if (dr.Read())
            {
                toplam_mola = Int32.Parse(dr["mola"].ToString());
                cikis = dr["cikis_saat"].ToString();
                flagPass = Boolean.Parse(dr["gecis"].ToString());
                if (flagGecis)
                {
                    comLogSelect.Dispose();
                    dr.Close();
                    update = new SqlCommand("UPDATE esd_turnike_tb SET giris_saat='" + time + "', gecis=" + 1 + " WHERE sicil_ID='" + myCardID + "' and tarih='" + date + "'", sqlConnectionMeyer);
                    dr = update.ExecuteReader();
                    TimeSpan dateTimeSonuc = DateTime.Parse(time).Subtract(DateTime.Parse(cikis));
                    minute = int.Parse(dateTimeSonuc.Minutes.ToString());
                    hour = int.Parse(dateTimeSonuc.Hours.ToString());
                    mola = hour * 60 + minute;
                    toplam_mola = toplam_mola + mola;
                    //  MessageBox.Show("mola: " + mola.ToString() + "  toplam mola : " + toplam_mola.ToString());
                    update.Dispose();
                    dr.Close();
                    update = new SqlCommand("UPDATE esd_turnike_tb SET mola=" + toplam_mola + " WHERE sicil_ID='" + myCardID + "' and tarih='" + date + "'", sqlConnectionMeyer);
                    dr = update.ExecuteReader();
                    update.Dispose();
                    dr.Close();

                    //calışma süresi
                    vardiye3Saat = "22:45:00";
                    comLogSelect = new SqlCommand("SELECT Sum(calisma_süresi) as calisma_suresi FROM log_tb where sicil_ID='" + myCardID + "' and tarih='" + date + "' ", sqlConnectionMeyer);
                    dr = comLogSelect.ExecuteReader();
                    if (dr.Read())
                    {
                       // MessageBox.Show(Int16.Parse(dr["calisma_suresi"].ToString()).ToString());
                        toplam_calisma = Int16.Parse(dr["calisma_suresi"].ToString());
                        comLogSelect.Dispose();
                        dr.Close();
                    }
                }
                else if (flagGecis == false)
                {

                    comLogSelect.Dispose();
                    dr.Close();
                    update = new SqlCommand("UPDATE esd_turnike_tb SET cikis_saat='" + time + "',gecis=" + 0 + " WHERE sicil_ID='" + myCardID + "' and tarih='" + date + "'", sqlConnectionMeyer);
                    dr = update.ExecuteReader();
                    update.Dispose();
                    dr.Close();
                    //  MessageBox.Show("Cıkış yapıldı");
                }
                else
                {
                    //   MessageBox.Show("2 kere giriş yapıldı...");
                }
            }
            else if (flagGecis && flagMailDepartment && flagIn)
            {
                comLogSelect.Dispose();
                dr.Close();
                insert = new SqlCommand("INSERT INTO esd_turnike_tb (sicil_ID,isim,soyisim,tarih,giris_saat,cikis_saat,mola,gecis) VALUES ('" + myCardID + "','" + mail_Ad + "','" + mail_Soyad + "','" + date + "','" + time + "','" + null + "'," + 0 + "," + 1 + ");", sqlConnectionMeyer);
                dr = insert.ExecuteReader();
                comLogSelect.Dispose();
                dr.Close();
            }
            else if (flagGecis==false && flagMailDepartment && flagIn==false)
            {
                comLogSelect.Dispose();
                dr.Close();
                insert = new SqlCommand("INSERT INTO esd_turnike_tb (sicil_ID,isim,soyisim,tarih,giris_saat,cikis_saat,mola,gecis) VALUES ('" + myCardID + "','" + mail_Ad + "','" + mail_Soyad + "','" + date + "','" + null + "','" + time + "'," + 0 + "," + 0 + ");", sqlConnectionMeyer);
                dr = insert.ExecuteReader();
                comLogSelect.Dispose();
                dr.Close();
            }


            //insert log table 


            comLogSelect.Dispose();
            dr.Close();
            comLogSelect = new SqlCommand("SELECT * FROM log_tb where sicil_ID='" + myCardID + "' and tarih='" + date + "' and cikis_saat='" + null + "'", sqlConnectionMeyer);
            dr = comLogSelect.ExecuteReader();
            if (dr.Read())
            {
                if (!flagIn)
                {
                    girisLog = dr["giris_saat"].ToString();
                    logID = Int32.Parse(dr["logID"].ToString());
                    TimeSpan dateTimeSonuc = DateTime.Parse(time).Subtract(DateTime.Parse(girisLog));
                    minute = Int32.Parse(dateTimeSonuc.Minutes.ToString());
                    hour = Int32.Parse(dateTimeSonuc.Hours.ToString());
                    calisma_suresi = hour * 60 + minute;
                    comLogSelect.Dispose();
                    dr.Close();
                    update = new SqlCommand("UPDATE log_tb SET cikis_saat='" + time + "',calisma_süresi='" + calisma_suresi + "' WHERE sicil_ID='" + myCardID + "' and logID='" + logID + "'", sqlConnectionMeyer);
                    dr = update.ExecuteReader();
                    update.Dispose();
                    dr.Close();
                }
                else 
                {
                    girisLog = dr["giris_saat"].ToString();
                    logID = Int32.Parse(dr["logID"].ToString());
                    TimeSpan dateTimeSonuc = DateTime.Parse(time).Subtract(DateTime.Parse(girisLog));
                    minute = Int32.Parse(dateTimeSonuc.Minutes.ToString());
                    hour = Int32.Parse(dateTimeSonuc.Hours.ToString());
                    calisma_suresi = hour * 60 + minute;
                    comLogSelect.Dispose();
                    dr.Close();
                    update = new SqlCommand("UPDATE log_tb SET giris_saat='" + time + "',calisma_süresi='" + calisma_suresi + "' WHERE sicil_ID='" + myCardID + "' and logID='" + logID + "'", sqlConnectionMeyer);
                    dr = update.ExecuteReader();
                    update.Dispose();
                    dr.Close();
                }
   
            }
            else if (flagMailDepartment == true && flagIn)
            {
                comLogSelect.Dispose();
                dr.Close();
                insert = new SqlCommand("INSERT INTO log_tb (sicil_ID,tarih,giris_saat,cikis_saat,calisma_süresi) VALUES ('" + myCardID + "','" + date + "','" + time + "','" + null + "'," + 0 + ");", sqlConnectionMeyer);
                dr = insert.ExecuteReader();
                insert.Dispose();
                dr.Close();
            }
            else if (flagMailDepartment == true && !flagIn)
            {
                comLogSelect.Dispose();
                dr.Close();
                TimeSpan dateTimeSonuc = DateTime.Parse(time).Subtract(DateTime.Parse("00:00:00"));
                minute = Int32.Parse(dateTimeSonuc.Minutes.ToString());
                hour = Int32.Parse(dateTimeSonuc.Hours.ToString());
                calisma_suresi = hour * 60 + minute;
                insert = new SqlCommand("INSERT INTO log_tb (sicil_ID,tarih,giris_saat,cikis_saat,calisma_süresi) VALUES ('" + myCardID + "','" + date + "','00:00:00','" + time + "'," + calisma_suresi + ");", sqlConnectionMeyer);
                dr = insert.ExecuteReader();
                insert.Dispose();
                dr.Close();
            }
            comLogSelect.Dispose();
            dr.Close();
        } 
        /****************************/
        public void logekleM3()  // Personel giriş ve çıkış verisinin loglandığı kısım çıkış için
        {
            date3 = DateTime.Now.ToString("dd.MM.yyyy");
            time3 = DateTime.Now.ToString("HH:mm:ss");
            yesterday3 = DateTime.Now.Date.AddDays(-1).ToString("dd.MM.yyyy");
            // giris ve sicil id kontrol
            comLogSelect3 = new SqlCommand("SELECT * FROM esd_turnike_tb where sicil_ID='" + myCardID3 + "' and tarih='" + date3 + "'", sqlConnectionMeyer);
            dr3 = comLogSelect3.ExecuteReader();
            if (dr3.Read())
            {
                toplam_mola3 = Int32.Parse(dr3["mola"].ToString());
                cikis3 = dr3["cikis_saat"].ToString();
                flagPass3 = Boolean.Parse(dr3["gecis"].ToString());
                
                    comLogSelect3.Dispose();
                    dr3.Close();
                    update3 = new SqlCommand("UPDATE esd_turnike_tb SET cikis_saat='" + time3+ "',gecis=" + 0 + " WHERE sicil_ID='" + myCardID3 + "' and tarih='" + date3 + "'", sqlConnectionMeyer);
                    dr3 = update3.ExecuteReader();
                    update3.Dispose();
                    dr3.Close();
                    //  MessageBox.Show("Cıkış yapıldı");

            }
            else 
            {
                comLogSelect3.Dispose();
                dr3.Close();
                insert3 = new SqlCommand("INSERT INTO esd_turnike_tb (sicil_ID,isim,soyisim,tarih,giris_saat,cikis_saat,mola,gecis) VALUES ('" + myCardID3 + "','" + mail_Ad3 + "','" + mail_Soyad3 + "','" + date3 + "','" + null + "','" + time3 + "'," + 0 + "," + 0 + ");", sqlConnectionMeyer);
                dr3 = insert3.ExecuteReader();
                comLogSelect3.Dispose();
                dr3.Close();
            }


            //insert log table 


            comLogSelect3.Dispose();
            dr3.Close();
            comLogSelect3 = new SqlCommand("SELECT * FROM log_tb where sicil_ID='" + myCardID3 + "' and tarih='" + date3 + "' and cikis_saat='" + null + "'", sqlConnectionMeyer);
            dr3 = comLogSelect3.ExecuteReader();
            if (dr3.Read())
            {

                    girisLog3 = dr3["giris_saat"].ToString();
                    logID3 = Int32.Parse(dr3["logID"].ToString());
                    TimeSpan dateTimeSonuc = DateTime.Parse(time3).Subtract(DateTime.Parse(girisLog3));
                    minute3 = Int32.Parse(dateTimeSonuc.Minutes.ToString());
                    hour3 = Int32.Parse(dateTimeSonuc.Hours.ToString());
                    calisma_suresi3 = hour3 * 60 + minute3;
                    comLogSelect3.Dispose();
                    dr3.Close();
                    update3 = new SqlCommand("UPDATE log_tb SET cikis_saat='" + time3 + "',calisma_süresi='" + calisma_suresi3 + "' WHERE sicil_ID='" + myCardID3 + "' and logID='" + logID3 + "'", sqlConnectionMeyer);
                    dr3 = update3.ExecuteReader();
                    update3.Dispose();
                    dr3.Close();

            }                       
            else
            {
                comLogSelect3.Dispose();
                dr3.Close();
                TimeSpan dateTimeSonuc = DateTime.Parse(time3).Subtract(DateTime.Parse("00:00:00"));
                minute3 = Int32.Parse(dateTimeSonuc.Minutes.ToString());
                hour3 = Int32.Parse(dateTimeSonuc.Hours.ToString());
                calisma_suresi3 = hour3 * 60 + minute3;
                insert3 = new SqlCommand("INSERT INTO log_tb (sicil_ID,tarih,giris_saat,cikis_saat,calisma_süresi) VALUES ('" + myCardID3 + "','" + date3 + "','00:00:00','" + time3 + "'," + calisma_suresi3 + ");", sqlConnectionMeyer);
                dr3 = insert3.ExecuteReader();
                insert3.Dispose();
                dr3.Close();
            }
            comLogSelect3.Dispose();
            dr3.Close();
        }

        private void insideControl()//Personelin içeride olup olmadığını kontrol eden metot 
        {
            date = DateTime.Now.ToString("dd.MM.yyyy");
            if (!dr.IsClosed)
            {
                dr.Close();
            }
            comLogSelect = new SqlCommand("SELECT * FROM esd_turnike_tb where sicil_ID='" + myCardID + "' and tarih='" + date + "' and gecis=" + 1 + "", sqlConnectionMeyer);
            dr = comLogSelect.ExecuteReader();
            if (dr.Read() && flagGecis == true)
            {
                flagPass = true;
            }
            else
            {
                flagPass = false;
            }
            comLogSelect.Dispose();
            dr.Close();

        }
        private bool outsideControl()//Personelin dışarıda olup olmadığını kontrol eden metot
        {
            bool flagOut;
            if (!dr.IsClosed)
            {
                dr.Close();
            }
            date = DateTime.Now.ToString("dd.MM.yyyy");
            comLogSelect = new SqlCommand("SELECT * FROM esd_turnike_tb where sicil_ID='" + myCardID + "' and tarih='" + date + "' and gecis=" + 0 + "", sqlConnectionMeyer);
            dr = comLogSelect.ExecuteReader();
            if (dr.Read())
            {
                flagOut = true;
            }
            else
            {
                flagOut = false;
            }
            comLogSelect.Dispose();
            dr.Close();
            return flagOut;
        }


        private void mifarePort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (this.mifaredataaktif)
            {
                this.Invoke((Delegate)new EventHandler(this.EnableTimerMifare));
                int bytesToRead = this.mifarePort.BytesToRead;
                byte[] numArray = new byte[bytesToRead];
                this.mifarePort.Read(numArray, 0, bytesToRead);
                this.Gelen += Encoding.ASCII.GetString(numArray);
            }

        }
        private void HexConverter()//Kart idsini veritabanındaki gibi çevirme işlemi yapan metot 
        {
            this.connectionCheck();
                if (Gelen.Length >= 8 && Gelen.Length <= 14)
                {
                    decValue = UInt64.Parse(Gelen);
                }
                else if (Gelen.Length < 7)
                {
                    this.lblUyari.ForeColor = Color.Red;
                    cardWarningText = "Kartı hızlı çektiniz, lütfen kartı tekrar okutunuz";
                    this.Gelen = string.Empty;
                
                flagCard = false;
                }
                else
                {
                    this.lblUyari.ForeColor = Color.Red;
                    cardWarningText = "3 saniye sonra lütfen kartı tekrar okutunuz";
                    this.Gelen = string.Empty;
                flagCard = false;
                }
                this.Gelen = string.Empty;
                hexstring = decValue.ToString("X");
                if (hexstring.Length == 7 || hexstring.Length == 9)
                {
                    hexstring = "0" + decValue.ToString("X");
                }
                if (hexstring.Length == 8)
                {
                    result = hexstring.Substring(0, 2);
                    result1 = hexstring.Substring(2, 2);
                    result2 = hexstring.Substring(4, 2);
                    result3 = hexstring.Substring(6, 2);
                    sonuc = result3 + result2 + result1 + result;
                }
                else if (hexstring.Length == 10)
                {
                    result = hexstring.Substring(0, 2);
                    result1 = hexstring.Substring(2, 2);
                    result2 = hexstring.Substring(4, 2);
                    result3 = hexstring.Substring(6, 2);
                    result4 = hexstring.Substring(8, 2);
                    sonuc = result4 + result3 + result2 + result1 + result;
                }
            if (flagCard)
            {
                try
                {
                    decValueSon = UInt64.Parse(sonuc, System.Globalization.NumberStyles.HexNumber);
                    this.Gelen = decValueSon.ToString();
                    this.cardLenght = Gelen.Length;
                    decValueSon = 0;
                    hexstring = string.Empty;
                    sonuc = string.Empty;
                    result = string.Empty;
                    result1 = string.Empty;
                    result2 = string.Empty;
                    result3 = string.Empty;
                    result4 = string.Empty;
                    decValue = 0;
                    CardUpdate();
                    flagCard = true;
                }
                catch (Exception)
                {
                    decValueSon = 0;
                    hexstring = string.Empty;
                    sonuc = string.Empty;
                    result = string.Empty;
                    result1 = string.Empty;
                    result2 = string.Empty;
                    result3 = string.Empty;
                    result4 = string.Empty;
                    decValue = 0;
                }
               
            }
            else
            {
                decValueSon = 0;
                hexstring = string.Empty;
                sonuc = string.Empty;
                result = string.Empty;
                result1 = string.Empty;
                result2 = string.Empty;
                result3 = string.Empty;
                result4 = string.Empty;
                decValue = 0;
            }

        }

        private void HexConverterM3()//Kart idsini veritabanındaki gibi çevirme işlemi yapan metot çıkış için
        {
            this.connectionCheck();
            if (GelenM3.Length >= 8 && GelenM3.Length <= 14)
            {
                decValue3 = UInt64.Parse(GelenM3);
            }
            else if (GelenM3.Length < 7)
            {
               // this.lblUyari.ForeColor = Color.Red;
              //  cardWarningText = "Kartı hızlı çektiniz, lütfen kartı tekrar okutunuz";
                this.GelenM3 = string.Empty;
                flagCard3 = false;
            }
            else
            {
              // this.lblUyari.ForeColor = Color.Red;
               // cardWarningText = "3 saniye sonra lütfen kartı tekrar okutunuz";
                this.GelenM3 = string.Empty;
                flagCard3 = false;
            }
            this.GelenM3 = string.Empty;
            hexstring3 = decValue3.ToString("X");
            if (hexstring3.Length == 7 || hexstring3.Length == 9)
            {
                hexstring3 = "0" + decValue3.ToString("X");
            }
            if (hexstring3.Length == 8)
            {
                resultM = hexstring3.Substring(0, 2);
                resultM1 = hexstring3.Substring(2, 2);
                resultM2 = hexstring3.Substring(4, 2);
                resultM3 = hexstring3.Substring(6, 2);
                sonucM = resultM3 + resultM2 + resultM1 + resultM;
            }
            else if (hexstring3.Length == 10)
            {
                resultM = hexstring3.Substring(0, 2);
                resultM1 = hexstring3.Substring(2, 2);
                resultM2 = hexstring3.Substring(4, 2);
                resultM3 = hexstring3.Substring(6, 2);
                resultM4 = hexstring3.Substring(8, 2);
                sonucM = resultM4 + resultM3 + resultM2 + resultM1 + resultM;
            }
            if (flagCard3)
            {
                try
                {
                    decValueSon3 = UInt64.Parse(sonucM, System.Globalization.NumberStyles.HexNumber);
                    this.GelenM3 = decValueSon3.ToString();
                    this.cardLenght3 = GelenM3.Length;
                    decValueSon3 = 0;
                    hexstring3 = string.Empty;
                    sonucM = string.Empty;
                    resultM = string.Empty;
                    resultM1 = string.Empty;
                    resultM2 = string.Empty;
                    resultM3 = string.Empty;
                    resultM4 = string.Empty;
                    decValue3 = 0;
                    CardUpdateM3();
                    flagCard3 = true;
                }
                catch (Exception)
                {
                    decValueSon3 = 0;
                    hexstring3 = string.Empty;
                    sonucM = string.Empty;
                    resultM = string.Empty;
                    resultM1 = string.Empty;
                    resultM2 = string.Empty;
                    resultM3 = string.Empty;
                    resultM4 = string.Empty;
                    decValue3 = 0;
                }
            }
            else
            {
                decValueSon3 = 0;
                hexstring3 = string.Empty;
                sonucM = string.Empty;
                resultM = string.Empty;
                resultM1 = string.Empty;
                resultM2 = string.Empty;
                resultM3 = string.Empty;
                resultM4 = string.Empty;
                decValue3 = 0;
            }

        }

        private void CardUpdate()//Veritabanınındaki kart id si gibi ekstra kart idsi başına ekstra 0 ekleyen metot 
        {
            zero = "";
            for (int i = 0; i < 15 - cardLenght; i++)
            {
                zero = zero + "0";
            }
        }
        private void CardUpdateM3()//Veritabanınındaki kart id si gibi ekstra kart idsi başına ekstra 0 ekleyen metot çıkış için 
        {
            zeroM = "";
            for (int i = 0; i < 15 - cardLenght3; i++)
            {
                zeroM = zeroM + "0";
            }
        }

        private void mifarePort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            flagMifarePort3 = true;
            this.Invoke((Delegate)new EventHandler(this.EnableTimerMifare2));
            if (this.mifaredataaktif2)
            {
                int bytesToRead = this.mifarePort2.BytesToRead;
                byte[] numArray = new byte[bytesToRead];
                this.mifarePort2.Read(numArray, 0, bytesToRead);
                this.Gelen += Encoding.ASCII.GetString(numArray);
            }
        }

        private void mifarePort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            flagMifarePort3 = false;
            if (mifareDataAktif3)
            {
                this.Invoke((Delegate)new EventHandler(this.EnableTimerMifare3));
                int bytesToRead = this.mifarePort3.BytesToRead;
                byte[] numArray = new byte[bytesToRead];
                this.mifarePort3.Read(numArray, 0, bytesToRead);
                this.GelenM3 += Encoding.ASCII.GetString(numArray);
            }
         
        }

        private void girisUpdate()//personelin içeri/dışarı verisini tutan metot
        {
            flagGecis = true;
        }
        private void cikisUpdate()//personelin içeri/dışarı verisini tutan metot
        {
            flagGecis = false;
        }

        private void esdPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.esddataaktif)
            {
                this.Invoke((Delegate)new EventHandler(this.EnableTimerESD));
                int bytesToRead = this.esdPort.BytesToRead;
                byte[] numArray = new byte[bytesToRead];
                this.esdPort.Read(numArray, 0, bytesToRead);
                this.Gelen22 += Encoding.ASCII.GetString(numArray);

            }
       
        }

        private void EnableTimerESD(object sender, EventArgs e)
        {
            this.timerESD.Enabled = true;
        }

        private void EnableTimerMifare(object sender, EventArgs e)
        {
            this.timerMifare.Enabled = true;
        }

        private void EnableTimerMifare2(object sender, EventArgs e)
        {
            this.timerMifare2.Enabled = true;
        }

        private void EnableTimerMifare3(object sender, EventArgs e)
        {
            this.timerMifare3.Enabled = true;
        }
        private void timerModbus_Tick(object sender, EventArgs e)
        {
            try
            {
                IModbusSerialMaster ascii = (IModbusSerialMaster)ModbusSerialMaster.CreateAscii(this.plcPort);
                ascii.Transport.ReadTimeout = 300;
                this.readreg = ascii.ReadHoldingRegisters((byte)1, (ushort)4246, (ushort)2);
            }
            catch (Exception ex)
            {
                this.timerModbus.Enabled = false;
                int num = (int)MessageBox.Show("Modbus haberleşme hatası: " + ex.ToString());
            }
        }

        private void timerBekleme_Tick(object sender, EventArgs e)
        {
            this.esdAktif = false;
            this.timerBekleme.Enabled = false;
            this.lblTarih.Text = "";
            this.lblTarih.ForeColor = Color.Black;
            this.pictureSol.Image = (Image)Resources.footleftblack;
            this.pictureSag.Image = (Image)Resources.footrightblack;
            this.lblSolOlcum.Text = "";
            this.lblSagOlcum.Text = "";
            this.mifaredataaktif = true;
            try
            {
                this.mifarePort.DiscardInBuffer();
                this.mifarePort.DiscardOutBuffer();
            }
            catch (Exception)
            {
                this.mifarePort.Close();
                this.mifarePort.Open();
            }
        
            try
            {
                this.esdPort.DiscardInBuffer();
                this.esdPort.DiscardOutBuffer();
            }
            catch (Exception)
            {
                this.esdPort.Close();
                this.esdPort.Open();
            }
            this.Gelen2 = string.Empty;
            this.Gelen22 = string.Empty;
            if (flagConnection == true)
            {
                this.lblUyari.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.lblUyari.Text = "ESD ölçümü için personel kimlik kartınızı okutunuz...";
                this.lblUyari.BackColor = Color.Transparent;
                this.lblUyari.ForeColor = Color.Black;
            }
            else 
            {
                this.lblUyari.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.lblUyari.Text = "Veri tabanı bağlantısı yoktur. Bağlantı sağlanıncaya kadar kart okutmaya devam ediniz...";
                this.lblUyari.BackColor = Color.Blue;
                this.lblUyari.ForeColor = Color.White;
            }
            this.tableLayoutPanel2.Visible = false;
        }

        private void timerESD_Tick(object sender, EventArgs e)
        {
            this.timerESD.Enabled = false;
            this.esddataaktif = false;
            this.Gelen2 = this.Gelen22;
            this.Gelen22 = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            if (!this.esdAktif)
                return;
            this.Gelen2 = this.Gelen2.Trim();

            if (this.Gelen2.Length > 25 && this.AyakAktif)
            {
                string str1 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0002') + 1, this.Gelen2.IndexOf('\x0003') - 1);
                string str2 = str1.Substring(0, 3);
                string str3 = str1.Substring(4);

                if (str3 == "OVR" || str3 == "UNR")
                    str3 = "0";
                if (!(str2 == "RSG"))
                {
                    if (!(str2 == "RHG"))
                    {
                        if (!(str2 == "RSL"))
                        {
                            if (!(str2 == "RSR"))
                            {
                                if (str2 == "ERG")
                                    this.esdresult = str3;
                            }
                            else
                                this.esdSagAyak = Convert.ToInt32(str3);
                        }
                        else
                            this.esdSolAyak = Convert.ToInt32(str3);
                    }
                    else
                        this.esdBileklik = Convert.ToInt32(str3);
                }
                else
                    this.esdCiftAyak = Convert.ToInt32(str3);
                this.Gelen2 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0003'));
                this.Gelen2 = this.Gelen2.Substring(2);
                string str4 = this.Gelen2.Substring(2, this.Gelen2.IndexOf('\x0003') - 2);
                string str5 = str4.Substring(0, 3);
                string str6 = str4.Substring(4);
                if (str6 == "OVR" || str6 == "UNR")
                    str6 = "0";
                if (!(str5 == "RSG"))
                {
                    if (!(str5 == "RHG"))
                    {
                        if (!(str5 == "RSL"))
                        {
                            if (!(str5 == "RSR"))
                            {
                                if (str5 == "ERG")
                                    this.esdresult = str6;
                            }
                            else
                                this.esdSagAyak = Convert.ToInt32(str6);
                        }
                        else
                            this.esdSolAyak = Convert.ToInt32(str6);
                    }
                    else
                        this.esdBileklik = Convert.ToInt32(str6);
                }
                else
                    this.esdCiftAyak = Convert.ToInt32(str6);
                string str7 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0003')).Substring(2);
                string str8 = str7.Substring(2, str7.IndexOf('\x0003') - 2);
                string str9 = str8.Substring(0, 3);
                string str10 = str8.Substring(4);

                if (str10 == "OVR" || str10 == "UNR")
                    str10 = "0";
                if (!(str9 == "RSG"))
                {
                    if (!(str9 == "RHG"))
                    {
                        if (!(str9 == "RSL"))
                        {
                            if (!(str9 == "RSR"))
                            {
                                if (str9 == "ERG")
                                    this.esdresult = str10;
                            }
                            else
                                this.esdSagAyak = Convert.ToInt32(str10);
                        }
                        else
                            this.esdSolAyak = Convert.ToInt32(str10);
                    }
                    else
                        this.esdBileklik = Convert.ToInt32(str10);
                }
                else
                    this.esdCiftAyak = Convert.ToInt32(str10);
                if (this.esdSolAyak == 0)
                {
                    this.lblSolOlcum.Text = "OVER MOhm";
                    this.lblSolOlcum.ForeColor = Color.Red;
                    this.pictureSol.Image = (Image)Resources.footleftred;
                    this.lblSolOlcum.Visible = true;

                }
                else
                {
                    this.lblSolOlcum.Text = ((float)this.esdSolAyak / 1000f).ToString("N3") + " MOhm";
                    esdValueLeft = (float)this.esdSolAyak / 1000f;
                    if (esdValueLeft > 100 )
                    {
                        this.lblSolOlcum.ForeColor = Color.Red;
                        this.pictureSol.Image = (Image)Resources.footleftred;
                        esdresult = "FAIL";
                    }
                    else
                    {
                        this.lblSolOlcum.ForeColor = Color.Green;
                        this.pictureSol.Image = (Image)Resources.footleftgreen;
                        esdAyakSonucSol = true;
                    }
                    this.lblSolOlcum.Visible = true;

                }
                if (this.esdSagAyak == 0)
                {
                    this.lblSagOlcum.Text = "OVER MOhm";
                    this.lblSagOlcum.ForeColor = Color.Red;
                    this.pictureSag.Image = (Image)Resources.footrightred;
                    this.lblSagOlcum.Visible = true;
                }
                else
                {
                    this.lblSagOlcum.Text = ((float)this.esdSagAyak / 1000f).ToString("N3") + " MOhm";
                    esdValueRight = (float)this.esdSagAyak / 1000f;
                    if (esdValueRight > 100)
                    {
                        this.lblSagOlcum.ForeColor = Color.Red;
                        this.pictureSag.Image = (Image)Resources.footrightred;
                        esdresult = "FAIL";
                    }
                    else
                    {
                        this.lblSagOlcum.ForeColor = Color.Green;
                        this.pictureSag.Image = (Image)Resources.footrightgreen;
                        esdAyakSonucSag = true;
                    }
                    this.lblSagOlcum.Visible = true;
                }
                if (esdAyakSonucSol && esdAyakSonucSag)
                {
                    this.esdresult = "OK";
                    esdAyakSonucSol = false;
                    esdAyakSonucSag = false;
                }
                else
                {
                    this.esdresult = "FAIL";
                }
                if (this.esdresult == "OK" )
                {
                    this.esdresult = "PASS";
                    this.lblUyari.Text = "PASS";
                    this.lblUyari.Font = new Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold);
                    this.lblUyari.BackColor = Color.ForestGreen;
                    this.lblUyari.ForeColor = Color.White;
                    this.lblSolOlcum.ForeColor = Color.Green;
                    this.pictureSol.Image = (Image)Resources.footleftgreen;
                    this.lblSagOlcum.ForeColor = Color.Green;
                    this.pictureSag.Image = (Image)Resources.footrightgreen;
                    this.timerBekleme.Enabled = false;
                    this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
                    this.timerBekleme.Enabled = true;
                    now = DateTime.Now;
                    this.lblTarih.Text = now.ToString("F");
                    this.lblTarih.ForeColor = Color.ForestGreen;
                    this.tableLayoutPanel2.Visible = false;
                    this.turnikeGirisAc();
                    if (mesaiPeriyot > 2 && mesaiPeriyot < 8) 
                    {
                         logekle();
                    }
                    esdAyakSonucSol = false;
                    esdAyakSonucSag = false;
                }
                else
                {
                    this.esdresult = "FAIL";
                    this.lblUyari.Text = "FAIL";
                    this.lblUyari.BackColor = Color.Red;
                    this.lblUyari.ForeColor = Color.White;
                    esdAyakSonucSol = false;
                    esdAyakSonucSag = false;
                    /*    this.lblSolOlcum.ForeColor = Color.Red;
                        this.pictureSol.Image = (Image)Resources.footleftred;
                        this.lblSagOlcum.ForeColor = Color.Red;
                        this.pictureSag.Image = (Image)Resources.footrightred;*/
                    this.timerBekleme.Enabled = false;
                    this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
                    this.timerBekleme.Enabled = true;
                }
            }
            else if (this.Gelen2.Length < 12 && this.Gelen2.Length > 8)
            {
                string str1 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0002') + 1, this.Gelen2.IndexOf('\x0003') - 1);
                string str2 = str1.Substring(0, 3);
                string str3 = str1.Substring(4);
                if (str3 == "OVR" || str3 == "UNR")
                    str3 = "0";
                if (!(str2 == "RSG"))
                {
                    if (!(str2 == "RHG"))
                    {
                        if (!(str2 == "RSL"))
                        {
                            if (!(str2 == "RSR"))
                            {
                                if (str2 == "ERG")
                                    this.esdresult = str3;
                            }
                            else
                                this.esdSagAyak = Convert.ToInt32(str3);
                        }
                        else
                            this.esdSolAyak = Convert.ToInt32(str3);
                    }
                    else
                        this.esdBileklik = Convert.ToInt32(str3);
                }
                else
                    this.esdCiftAyak = Convert.ToInt32(str3);
                if (this.esdresult == "-10")
                {
                    this.lblUyari.Text = "Sağlıklı ölçüm için en az 1 saniye elinizi butonun üzerinde tutunuz!";
                    this.lblUyari.BackColor = Color.White;
                    this.lblUyari.ForeColor = Color.Black;
                    this.timerBekleme.Enabled = false;
                    this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
                    this.timerBekleme.Enabled = true;
                }
            }
            else if (this.Gelen2.Length < 22 && this.Gelen2.Length > 16 && this.bileklikAktif)
            {
                string str1 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0002') + 1, this.Gelen2.IndexOf('\x0003') - 1);
                string str2 = str1.Substring(0, 3);
                string str3 = str1.Substring(4);
                if (str3 == "OVR" || str3 == "UNR")
                    str3 = "0";
                if (!(str2 == "RSG"))
                {
                    if (!(str2 == "RHG"))
                    {
                        if (!(str2 == "RSL"))
                        {
                            if (!(str2 == "RSR"))
                            {
                                if (str2 == "ERG")
                                    this.esdresult = str3;
                            }
                            else
                                this.esdSagAyak = Convert.ToInt32(str3);
                        }
                        else
                            this.esdSolAyak = Convert.ToInt32(str3);
                    }
                    else
                        this.esdBileklik = Convert.ToInt32(str3);
                }
                else
                    this.esdCiftAyak = Convert.ToInt32(str3);
                this.Gelen2 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0003'));
                this.Gelen2 = this.Gelen2.Substring(2);
                string str4 = this.Gelen2.Substring(2, this.Gelen2.IndexOf('\x0003') - 2);
                string str5 = str4.Substring(0, 3);
                string str6 = str4.Substring(4);
                if (str6 == "OVR" || str6 == "UNR")
                    str6 = "0";
                if (!(str5 == "RSG"))
                {
                    if (!(str5 == "RHG"))
                    {
                        if (!(str5 == "RSL"))
                        {
                            if (!(str5 == "RSR"))
                            {
                                if (str5 == "ERG")
                                    this.esdresult = str6;
                            }
                            else
                                this.esdSagAyak = Convert.ToInt32(str6);
                        }
                        else
                            this.esdSolAyak = Convert.ToInt32(str6);
                    }
                    else
                        this.esdBileklik = Convert.ToInt32(str6);
                }
                else
                    this.esdCiftAyak = Convert.ToInt32(str6);
                if (this.esdBileklik == 0)
                    //this.lblElOlcum.Text = "OVER MOhm";
                    return;
                else
                // this.lblElOlcum.Text = ((float) this.esdBileklik / 1000f).ToString("N3") + " MOhm";
                if (this.esdresult == "OK")
                {
                    this.esdresult = "PASS";
                    this.lblUyari.Text = "PASS";
                    this.lblUyari.BackColor = Color.Green;
                    this.lblUyari.ForeColor = Color.White;
                    this.timerBekleme.Enabled = false;
                    this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
                    this.timerBekleme.Enabled = true;
                    this.turnikeGirisAc();
                }
                else
                {
                    this.esdresult = "B FAIL";
                    this.lblUyari.Text = "B FAIL";
                    this.lblUyari.BackColor = Color.Red;
                    this.lblUyari.ForeColor = Color.White;
                    this.timerBekleme.Enabled = false;
                    this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
                    this.timerBekleme.Enabled = true;
                }

            }
            this.Gelen2 = string.Empty;
        }



        private void EnableTimerBekleme(object sender, EventArgs e)
        {
            this.timerBekleme.Enabled = true;
        }

        private void timerConnect_Tick(object sender, EventArgs e)//Ağ bağlantı kontrolü
        {
            connectionCheck();
        }


        private void timerMifare_Tick(object sender, EventArgs e)
        {
            this.mifaredataaktif = false;
            this.timerMifare.Enabled = false;
            HexConverter();
            girisUpdate();
           

            if (this.getir() && !this.AyarFrm.Visible && !this.SifreFrm.Visible)
            {
                this.esddataaktif = true;
                this.esdAktif = true;
                this.flagIn = true;
                this.flagGecis = true;
                this.Invoke((Delegate)new EventHandler(this.EnableTimerBekleme));
                this.lblUyari.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                this.lblUyari.Text = (Ayarlar.Default.timerBekleme / 1000).ToString() + " saniye içerisinde ESD ölçümünü yapınız.";
                this.lblUyari.BackColor = Color.Yellow;
                this.lblUyari.ForeColor = Color.Black;

            }
            else
            {
                this.Invoke((Delegate)new EventHandler(this.EnableTimerBekleme));
            }
        }


        private void timerMifare2_Tick(object sender, EventArgs e)
        {
            this.mifaredataaktif2 = false;
            this.timerMifare2.Enabled = false;
            //this.mifaredataaktif = false;       
            cikisUpdate();
            HexConverter();
            if (getir())
            {
              
                this.flagGecis = false;
                this.flagIn = false;
              
             
                if (!outsideControl() && flagConnection && mesaiPeriyot > 2 && mesaiPeriyot < 8)
                {
                    logekle();
                    this.turnikeCikisAc();
                }
                else if (flagConnection && (mesaiPeriyot < 3 || mesaiPeriyot > 7))
                {
                    this.turnikeCikisAc();

                }
                else if (!flagConnection)
                {
                    this.turnikeCikisAc();
                }  
            }
            this.mifaredataaktif2 = true;
            //this.mifaredataaktif = true;
            lblTarih.Text = "";
            mifarePort2Refresh();
           //this.Invoke((Delegate)new EventHandler(this.EnableTimerBekleme));
        }

        private void mifarePort2Refresh() 
        {
            try
            {
                this.mifarePort2.DiscardInBuffer();
                this.mifarePort2.DiscardOutBuffer();
            }
            catch (Exception)
            {
                this.mifarePort2.Close();
                this.mifarePort2.Open();
            }
  
        }
        private void mifarePort3Refresh()
        {
            try
            {
                this.mifarePort3.DiscardInBuffer();
                this.mifarePort3.DiscardOutBuffer();
            }
            catch (Exception)
            {
                this.mifarePort3.Close();
                this.mifarePort3.Open();
            }

        }

        public void yetkidegistir()
        {
            if (this.yetki == 0)
            {
                this.btnCikis.Enabled = false;
                this.btnAyar.Enabled = false;
                this.top_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                this.top_label.Text = "ESD ÖLÇÜM İSTASYONU";
            }
            if (this.yetki == 1)
            {
                this.btnCikis.Enabled = true;
                this.btnAyar.Enabled = true;
                this.top_label.ForeColor = Color.Red;
                this.top_label.Text = "ESD ÖLÇÜM İSTASYONU ADMIN MODU";
                this.timerAdmin.Enabled = true;
            }

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)// l tuşuna basınca şifre ekranı gelmektedir
        {
            if (keyData != Keys.L)
                return false;
            if (this.yetki != 0)
            {
                this.timerAdmin.Enabled = false;
                this.yetki = 0;
                this.yetkidegistir();
            }
            else
            {
                try { int num = (int)this.SifreFrm.ShowDialog(); }
                catch (Exception) { }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void timerAdmin_Tick(object sender, EventArgs e)
        {
            Main.tagLASTINPUTINFO plii = new Main.tagLASTINPUTINFO();
            int num = 0;
            plii.cbSize = (uint)Marshal.SizeOf((object)plii);
            plii.dwTime = 0;
            if (Main.GetLastInputInfo(ref plii))
                num = Environment.TickCount - plii.dwTime;
            if (num <= 10000)
                return;
            this.timerAdmin.Enabled = false;
            this.yetki = 0;
            this.yetkidegistir();
        }

        public void turnikeGirisAc()
        {
            ModbusSerialMaster ascii = ModbusSerialMaster.CreateAscii(this.plcPort);
            ((IModbusSerialMaster)ascii).Transport.ReadTimeout = 300;
            ascii.WriteSingleCoil((byte)1, (ushort)1280, true);
            this.timerTurnike.Enabled = true;
        }

        public void turnikeCikisAc()
        {
             ModbusSerialMaster ascii = ModbusSerialMaster.CreateAscii(this.plcPort);
             ((IModbusSerialMaster) ascii).Transport.ReadTimeout = 300;
             ascii.WriteSingleCoil((byte) 1, (ushort) 1283, true);
            this.timerTurnike.Enabled = true;
        }

        private void turnikeTmr_Tick(object sender, EventArgs e)
        {
            ModbusSerialMaster ascii = ModbusSerialMaster.CreateAscii(this.plcPort);
            ((IModbusSerialMaster)ascii).Transport.ReadTimeout = 300;
            this.timerTurnike.Enabled = false;
            ascii.WriteSingleCoil((byte)1, (ushort)1280, false);
            ascii.WriteSingleCoil((byte)1, (ushort)1283, false);

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.sqlConnectionMain.Close();
            this.sqlConnectionMeyer.Close();
        }

        private void timerMail_Tick(object sender, EventArgs e)//Mail saatlerinin ayarlandığı kısım
        {
            
            this.button_kullanici.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.timeMail = DateTime.Now.ToString("HH:mm:ss");
            button_kullanici.Text = "  " + timeMail;
            
            this.vardiye1 = Ayarlar.Default.vardiyeSaat2;
        //    this.vardiye1 = (Int16.Parse(this.vardiye1.Substring(0, 2)) - 1).ToString() + this.vardiye1.Substring(2, 6);
            this.vardiye2 = Ayarlar.Default.vardiyeSaat4;
          //  this.vardiye2 = (Int16.Parse(this.vardiye2.Substring(0, 2)) - 1).ToString() + this.vardiye2.Substring(2, 6);
            this.vardiye3 = Ayarlar.Default.vardiyeSaat6;
          //  this.vardiye3 = "0" + (Int16.Parse(this.vardiye3.Substring(0, 2)) - 1).ToString() + this.vardiye3.Substring(2, 6);
            if (timeMail == this.vardiye1 && vardiye1Aktif == true)
            {
                listCheck();

            }
            else if (timeMail == this.vardiye2 && vardiye2Aktif == true)
            {
                listCheck();
            }
            else if (timeMail == this.vardiye3 && vardiye3Aktif == true)
            {
                listCheck();
            }
        }
      /*  private void addLogTb()
        {
            if (flagConnection == true)
            {
                
                SqlCommand insertLogTb = new SqlCommand("INSERT INTO log_tb (sicil_ID,tarih,giris_saat,cikis_saat,calisma_süresi) VALUES ('" + myCardID + "','" + date + "','" + null + "','" + time + "'," + 0 + ");", sqlConnectionMeyer);
                SqlDataReader sqlDtReaderLog = insertLogTb.ExecuteReader();
                sqlDtReaderLog.Close();
            }
        }*/
        private void mailListCheck()//Gönderilecek mail verisinin kontrol edildiği yer
        {
            if (flagConnection == true)
            {
                mailList = new List<string>();
                this.getMailList = "select mail from mail_tb";
                mailCheck = new SqlCommand(getMailList, sqlConnectionMeyer);
                drMail = mailCheck.ExecuteReader();
                while (drMail.Read())
                {
                    mailList.Add(drMail["mail"].ToString());
                }
                drMail.Close();
                mailCheck.Dispose();
            }
        }
        private void listCheck()//Gönderilecek personellerin liste halinde çekildiği metot
        {
            string girisSaat = "";
            int sonCalismaSaat = 0;
            List<string> cardIDList = new List<string>();
            List<int> calismaSuresiList = new List<int>();
            string dateM = DateTime.Now.ToString("dd.MM.yyyy");
            string cikisMailQuery = "select sum(calisma_süresi) as calisma_süresi,sicil_ID from log_tb where tarih ='" + dateM+ "' group by sicil_ID";
            SqlCommand cikisMailComm = new SqlCommand(cikisMailQuery, sqlConnectionMeyer);
            SqlDataReader reader = cikisMailComm.ExecuteReader();
            while (reader.Read())
            {
                calismaSuresiList.Add(Int16.Parse(reader["calisma_süresi"].ToString()));
                cardIDList.Add(reader["sicil_ID"].ToString());           
            }
            reader.Close();

            for (int i = 0; i < cardIDList.Count; i++)
            {
                string calismaSuresi = "select giris_saat from log_tb where sicil_ID='" + cardIDList[i] + "' and tarih ='" + dateM + "' and cikis_saat='' and giris_saat>'19.00.00'";
                SqlCommand calismaSuresiComm = new SqlCommand(calismaSuresi, sqlConnectionMeyer);
                reader = calismaSuresiComm.ExecuteReader();
                if (reader.Read())
                {
                    girisSaat = reader["giris_saat"].ToString();
                    TimeSpan dateTimeSonuc = DateTime.Parse("23:59:00").Subtract(DateTime.Parse(girisSaat));
                    minute = Int32.Parse(dateTimeSonuc.Minutes.ToString());
                    hour = Int32.Parse(dateTimeSonuc.Hours.ToString());
                    sonCalismaSaat = hour * 60 + minute;
                    calismaSuresiList[i] = sonCalismaSaat + calismaSuresiList[i] + 1;
                }
                reader.Close();
                if ((calismaSuresiList[i] - 435) < 0)
                {
                    calismaSuresiList[i] = 435 - calismaSuresiList[i];
                    SqlCommand updateCalismaSuresi = new SqlCommand("UPDATE esd_turnike_tb SET mail_kontrol = " + 1 + ", mola=" + calismaSuresiList[i] + " WHERE sicil_ID = '" + cardIDList[i] + "' and tarih = '" + dateM + "'", sqlConnectionMeyer);
                    reader = updateCalismaSuresi.ExecuteReader();
                    reader.Close();
                }
            }  


            this.getMailQuery = "SELECT e.sicil_ID As Kart_Numarası, isim as İsim, soyisim as Soyisim, e.tarih As Tarih, e.mola as [Mola Süresi],Min(l.giris_saat)as [Giris Saati],Max(e.cikis_saat)[Çıkış Saati] " +
                            "FROM esd_turnike_tb e inner join log_tb l on e.sicil_ID=l.sicil_ID  where mail_kontrol=" + 1 + " and e.tarih='" + dateM + "' and l.tarih='" + dateM + "' and l.giris_saat !='" + null + "' group by e.sicil_ID, isim ,soyisim,e.tarih,e.mola order by isim";
            da = new SqlDataAdapter(getMailQuery, sqlConnectionMeyer);
            if (dt != null)
            {
                da.Fill(dt);
                email_Send();
                da.Dispose();
                dt.Clear();
            }
        }


        private bool connectionCheck() //Network kontrol
        {
            networkUp  = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            this.flagConnection = networkUp;
            if (flagConnection == true)
            {
                flagConnectionSettings = true ;
            }
            else {
                flagConnectionSettings = false;
            }
            
          
            return networkUp;
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (this.yetki != 0)
            {
                this.timerAdmin.Enabled = false;
                this.yetki = 0;
                this.yetkidegistir();
            }
            else
            {
                int num = (int)this.SifreFrm.ShowDialog();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            girisUpdate();
        }

        private void btnCik_Click(object sender, EventArgs e)
        {
            cikisUpdate();
        }

        private void onayla_button_Click(object sender, EventArgs e)
        {
            //  this.Invoke((Delegate)new EventHandler(this.EnableTimerMifare3));
            /*   vardiye3Saat = "22:45:00";

                 comLogSelect = new SqlCommand("SELECT Sum(calisma_süresi) as calisma_suresi FROM log_tb where sicil_ID='" + 000000057708217 + "' and tarih='11.02.2022' ", sqlConnectionMeyer);
                 dr = comLogSelect.ExecuteReader();
                 if (dr.Read())
                 {
                     MessageBox.Show(dr["calisma_suresi"].ToString());
                     toplam_calisma = Int16.Parse(dr["calisma_suresi"].ToString());
                     comLogSelect.Dispose();
                     dr.Close();
                 }*/
            this.Invoke((Delegate)new EventHandler(this.timerMifare2_Tick));
            // timerESD.Enabled = false;

        }
        private void onayla_button_Click2(object sender, EventArgs e)
        {

            timerESD.Enabled = true;
            this.Invoke((Delegate)new EventHandler(this.timerMifare2_Tick));
            // timerESD.Enabled = false;

        }
        public void Email(string from_User_Name, string from_User_Pass, List<string> to_User_Name_List, string body)// Email yapısının kurulduğu metot
        {
            try
            {
                System.Threading.Thread.Sleep(10);
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(from_User_Name);
                foreach (string to_User_Name in to_User_Name_List)
                {
                    message.To.Add(new MailAddress(to_User_Name));
                }
                message.Subject = "ESD Turnikesi Takip Listesi";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 25;
                smtp.Timeout = 6000 * 5;
                smtp.Host = "smtp.alpplas.com";
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from_User_Name, from_User_Pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

               // MessageBox.Show("Success");
            }
            catch (Exception)
            {
                //  MessageBox.Show("Fail:" + ex);
                mailThreadSayac++;
                mailListCheck();
                // MessageBox.Show("Tekrar Gönderiliyor");
                //string[] to_User_Name = { "fatihcngz1903@outlook.com", "fatihcngz1703@outlook.com" }; // "fatihcngz1903@outlook.com", "serkan.baki@alpplas.com"
                System.Threading.Thread thread_mail = new System.Threading.Thread(() => Email(Ayarlar.Default.mailAdress, Ayarlar.Default.mailSifre, mailList, mailBody));
                thread_mail.Start();
                if (mailThreadSayac == 3)
                {
                    thread_mail.Abort();
                }

            }
        }
        public void email_Send()//mail içeriğinin ayarlandığı metot
        {
            StringBuilder sb = new StringBuilder();
            //Table start.
            sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'>");

            //Adding HeaderRow.
            sb.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.ColumnName + "</th>");
            }
            sb.Append("</tr>");


            //Adding DataRow.
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<td style='width:100px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }

            //Table end.
            sb.Append("</table>");
            mailBody = sb.ToString();

            string[] to_User_Name = { "fatihcngz1903@outlook.com", "fatihcngz1703@outlook.com" }; // "fatihcngz1903@outlook.com", "serkan.baki@alpplas.com" fatihcngz1903@outlook.com
            //Email(username, password, to_User_Name, textBox3.Text);
            mailListCheck();
           // MessageBox.Show("mail thread start");
            System.Threading.Thread thread_mail = new System.Threading.Thread(() => Email(Ayarlar.Default.mailAdress, Ayarlar.Default.mailSifre, mailList, mailBody));
            thread_mail.Start();
        }

        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.timerModbus = new System.Windows.Forms.Timer(this.components);
			this.timerBekleme = new System.Windows.Forms.Timer(this.components);
			this.timerESD = new System.Windows.Forms.Timer(this.components);
			this.timerMifare = new System.Windows.Forms.Timer(this.components);
			this.timerAdmin = new System.Windows.Forms.Timer(this.components);
			this.timerTurnike = new System.Windows.Forms.Timer(this.components);
			this.timerMifare2 = new System.Windows.Forms.Timer(this.components);
			this.mifarePort = new System.IO.Ports.SerialPort(this.components);
			this.esdPort = new System.IO.Ports.SerialPort(this.components);
			this.plcPort = new System.IO.Ports.SerialPort(this.components);
			this.mifarePort2 = new System.IO.Ports.SerialPort(this.components);
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.lblSolOlcum = new System.Windows.Forms.Label();
			this.lblSagOlcum = new System.Windows.Forms.Label();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.pictureSol = new System.Windows.Forms.PictureBox();
			this.pictureSag = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
			this.lblAdSoyad = new System.Windows.Forms.Label();
			this.lblSicil = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.lblUyari = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
			this.lblTarih = new System.Windows.Forms.Label();
			this.headerpanel = new System.Windows.Forms.Panel();
			this.top_label = new System.Windows.Forms.Label();
			this.sidepanel = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.btnCikis = new System.Windows.Forms.Button();
			this.btnAyar = new System.Windows.Forms.Button();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.button_kullanici = new System.Windows.Forms.Button();
			this.logopanel = new System.Windows.Forms.Panel();
			this.pictureBoxAlpnextlogo = new System.Windows.Forms.PictureBox();
			this.timerMail = new System.Windows.Forms.Timer(this.components);
			this.timerConnect = new System.Windows.Forms.Timer(this.components);
			this.timerCikis = new System.Windows.Forms.Timer(this.components);
			this.mifarePort3 = new System.IO.Ports.SerialPort(this.components);
			this.timerMifare3 = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel9.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureSol)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureSag)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel13.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tableLayoutPanel12.SuspendLayout();
			this.headerpanel.SuspendLayout();
			this.sidepanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			this.logopanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlpnextlogo)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.BackColor = System.Drawing.Color.PeachPuff;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.09561F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.067183F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.BackColor = System.Drawing.Color.PeachPuff;
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.09561F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.067183F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel4.TabIndex = 0;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.BackColor = System.Drawing.Color.PeachPuff;
			this.tableLayoutPanel5.ColumnCount = 3;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.09561F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.067183F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel5.TabIndex = 0;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.BackColor = System.Drawing.Color.PeachPuff;
			this.tableLayoutPanel6.ColumnCount = 3;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.09561F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.067183F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel6.TabIndex = 0;
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.BackColor = System.Drawing.Color.PeachPuff;
			this.tableLayoutPanel7.ColumnCount = 3;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.09561F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.067183F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel7.TabIndex = 0;
			// 
			// tableLayoutPanel10
			// 
			this.tableLayoutPanel10.BackColor = System.Drawing.Color.Firebrick;
			this.tableLayoutPanel10.ColumnCount = 3;
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.4956F));
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.504399F));
			this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel10.Name = "tableLayoutPanel10";
			this.tableLayoutPanel10.RowCount = 3;
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel10.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel10.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.MistyRose;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F);
			this.label2.Location = new System.Drawing.Point(33, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(316, 101);
			this.label2.TabIndex = 0;
			this.label2.Text = "label2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel11
			// 
			this.tableLayoutPanel11.BackColor = System.Drawing.Color.Firebrick;
			this.tableLayoutPanel11.ColumnCount = 3;
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.4956F));
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.504399F));
			this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel11.Name = "tableLayoutPanel11";
			this.tableLayoutPanel11.RowCount = 3;
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel11.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel11.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.MistyRose;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F);
			this.label3.Location = new System.Drawing.Point(33, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(1, 101);
			this.label3.TabIndex = 0;
			this.label3.Text = "label3";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerModbus
			// 
			this.timerModbus.Interval = 500;
			this.timerModbus.Tick += new System.EventHandler(this.timerModbus_Tick);
			// 
			// timerBekleme
			// 
			this.timerBekleme.Interval = 3000;
			this.timerBekleme.Tick += new System.EventHandler(this.timerBekleme_Tick);
			// 
			// timerESD
			// 
			this.timerESD.Interval = 1000;
			this.timerESD.Tick += new System.EventHandler(this.timerESD_Tick);
			// 
			// timerMifare
			// 
			this.timerMifare.Interval = 1000;
			this.timerMifare.Tick += new System.EventHandler(this.timerMifare_Tick);
			// 
			// timerAdmin
			// 
			this.timerAdmin.Interval = 1000;
			this.timerAdmin.Tick += new System.EventHandler(this.timerAdmin_Tick);
			// 
			// timerTurnike
			// 
			this.timerTurnike.Interval = 2000;
			this.timerTurnike.Tick += new System.EventHandler(this.turnikeTmr_Tick);
			// 
			// timerMifare2
			// 
			this.timerMifare2.Interval = 1000;
			this.timerMifare2.Tick += new System.EventHandler(this.timerMifare2_Tick);
			// 
			// mifarePort
			// 
			this.mifarePort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mifarePort_DataReceived);
			// 
			// esdPort
			// 
			this.esdPort.ReadTimeout = 100;
			this.esdPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.esdPort_DataReceived);
			// 
			// mifarePort2
			// 
			this.mifarePort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mifarePort2_DataReceived);
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.BackColor = System.Drawing.Color.Gainsboro;
			this.tableLayoutPanel9.ColumnCount = 3;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.82353F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.11765F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.29412F));
			this.tableLayoutPanel9.Controls.Add(this.lblSolOlcum, 0, 0);
			this.tableLayoutPanel9.Controls.Add(this.lblSagOlcum, 2, 0);
			this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel9.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.tableLayoutPanel9.Location = new System.Drawing.Point(411, 314);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(436, 18);
			this.tableLayoutPanel9.TabIndex = 4;
			// 
			// lblSolOlcum
			// 
			this.lblSolOlcum.AutoSize = true;
			this.lblSolOlcum.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblSolOlcum.Location = new System.Drawing.Point(127, 0);
			this.lblSolOlcum.Name = "lblSolOlcum";
			this.lblSolOlcum.Size = new System.Drawing.Size(56, 18);
			this.lblSolOlcum.TabIndex = 0;
			this.lblSolOlcum.Text = "left";
			this.lblSolOlcum.Visible = false;
			// 
			// lblSagOlcum
			// 
			this.lblSagOlcum.AutoSize = true;
			this.lblSagOlcum.Location = new System.Drawing.Point(250, 0);
			this.lblSagOlcum.Name = "lblSagOlcum";
			this.lblSagOlcum.Size = new System.Drawing.Size(74, 18);
			this.lblSagOlcum.TabIndex = 1;
			this.lblSagOlcum.Text = "right";
			this.lblSagOlcum.Visible = false;
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.BackColor = System.Drawing.Color.Gainsboro;
			this.tableLayoutPanel8.ColumnCount = 5;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.987155F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.98715F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.117309F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.18766F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.411967F));
			this.tableLayoutPanel8.Controls.Add(this.pictureSol, 1, 0);
			this.tableLayoutPanel8.Controls.Add(this.pictureSag, 3, 0);
			this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel8.Location = new System.Drawing.Point(411, 13);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(436, 295);
			this.tableLayoutPanel8.TabIndex = 3;
			// 
			// pictureSol
			// 
			this.pictureSol.BackColor = System.Drawing.Color.Gainsboro;
			this.pictureSol.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureSol.Image = global::EsdTurnikesi.Properties.Resources.footleftblack;
			this.pictureSol.Location = new System.Drawing.Point(24, 3);
			this.pictureSol.Name = "pictureSol";
			this.pictureSol.Size = new System.Drawing.Size(190, 289);
			this.pictureSol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureSol.TabIndex = 0;
			this.pictureSol.TabStop = false;
			// 
			// pictureSag
			// 
			this.pictureSag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureSag.Image = global::EsdTurnikesi.Properties.Resources.footrightblack;
			this.pictureSag.Location = new System.Drawing.Point(224, 3);
			this.pictureSag.Name = "pictureSag";
			this.pictureSag.Size = new System.Drawing.Size(182, 289);
			this.pictureSag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureSag.TabIndex = 1;
			this.pictureSag.TabStop = false;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.736842F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.57895F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.481979F));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel13, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.pictureBox4, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 338);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.60976F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.39024F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(390, 176);
			this.tableLayoutPanel2.TabIndex = 0;
			this.tableLayoutPanel2.Visible = false;
			// 
			// tableLayoutPanel13
			// 
			this.tableLayoutPanel13.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel13.ColumnCount = 2;
			this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.225806F));
			this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.77419F));
			this.tableLayoutPanel13.Controls.Add(this.lblAdSoyad, 1, 2);
			this.tableLayoutPanel13.Controls.Add(this.lblSicil, 1, 1);
			this.tableLayoutPanel13.Controls.Add(this.label10, 1, 3);
			this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel13.Location = new System.Drawing.Point(118, 45);
			this.tableLayoutPanel13.Name = "tableLayoutPanel13";
			this.tableLayoutPanel13.RowCount = 4;
			this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel13.Size = new System.Drawing.Size(254, 116);
			this.tableLayoutPanel13.TabIndex = 0;
			// 
			// lblAdSoyad
			// 
			this.lblAdSoyad.AutoSize = true;
			this.lblAdSoyad.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblAdSoyad.ForeColor = System.Drawing.Color.White;
			this.lblAdSoyad.Location = new System.Drawing.Point(11, 45);
			this.lblAdSoyad.Name = "lblAdSoyad";
			this.lblAdSoyad.Size = new System.Drawing.Size(0, 28);
			this.lblAdSoyad.TabIndex = 1;
			// 
			// lblSicil
			// 
			this.lblSicil.AutoSize = true;
			this.lblSicil.BackColor = System.Drawing.Color.Transparent;
			this.lblSicil.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblSicil.ForeColor = System.Drawing.SystemColors.Control;
			this.lblSicil.Location = new System.Drawing.Point(11, 11);
			this.lblSicil.Name = "lblSicil";
			this.lblSicil.Size = new System.Drawing.Size(0, 29);
			this.lblSicil.TabIndex = 0;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label10.ForeColor = System.Drawing.Color.White;
			this.label10.Location = new System.Drawing.Point(11, 79);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(221, 37);
			this.label10.TabIndex = 2;
			this.label10.Text = "ALPPLAS ENDÜSTRİYEL YATIRIMLAR A.Ş.";
			// 
			// pictureBox4
			// 
			this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox4.Image = global::EsdTurnikesi.Properties.Resources.personicon;
			this.pictureBox4.Location = new System.Drawing.Point(21, 45);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(91, 116);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 1;
			this.pictureBox4.TabStop = false;
			// 
			// lblUyari
			// 
			this.lblUyari.BackColor = System.Drawing.Color.Transparent;
			this.lblUyari.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblUyari.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblUyari.ForeColor = System.Drawing.Color.ForestGreen;
			this.lblUyari.Location = new System.Drawing.Point(11, 5);
			this.lblUyari.Name = "lblUyari";
			this.lblUyari.Size = new System.Drawing.Size(413, 92);
			this.lblUyari.TabIndex = 0;
			this.lblUyari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.56212F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.447527F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86972F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 2, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(317, 83);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.018421F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.41393F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.83559F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.00967F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 517);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = global::EsdTurnikesi.Properties.Resources.gifpgt;
			this.pictureBox1.Location = new System.Drawing.Point(3, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.pictureBox1.Size = new System.Drawing.Size(390, 295);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// tableLayoutPanel12
			// 
			this.tableLayoutPanel12.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel12.ColumnCount = 3;
			this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.882353F));
			this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96F));
			this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.882353F));
			this.tableLayoutPanel12.Controls.Add(this.lblUyari, 1, 1);
			this.tableLayoutPanel12.Controls.Add(this.lblTarih, 1, 2);
			this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel12.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.tableLayoutPanel12.Location = new System.Drawing.Point(411, 338);
			this.tableLayoutPanel12.Name = "tableLayoutPanel12";
			this.tableLayoutPanel12.RowCount = 4;
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.970149F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.02985F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel12.Size = new System.Drawing.Size(436, 176);
			this.tableLayoutPanel12.TabIndex = 5;
			// 
			// lblTarih
			// 
			this.lblTarih.AutoSize = true;
			this.lblTarih.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTarih.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblTarih.ForeColor = System.Drawing.Color.ForestGreen;
			this.lblTarih.Location = new System.Drawing.Point(11, 97);
			this.lblTarih.Name = "lblTarih";
			this.lblTarih.Size = new System.Drawing.Size(413, 58);
			this.lblTarih.TabIndex = 1;
			this.lblTarih.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// headerpanel
			// 
			this.headerpanel.BackColor = System.Drawing.Color.White;
			this.headerpanel.Controls.Add(this.top_label);
			this.headerpanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerpanel.Location = new System.Drawing.Point(317, 0);
			this.headerpanel.Name = "headerpanel";
			this.headerpanel.Size = new System.Drawing.Size(850, 83);
			this.headerpanel.TabIndex = 1;
			// 
			// top_label
			// 
			this.top_label.BackColor = System.Drawing.SystemColors.Window;
			this.top_label.Dock = System.Windows.Forms.DockStyle.Fill;
			this.top_label.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
			this.top_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.top_label.Location = new System.Drawing.Point(0, 0);
			this.top_label.Name = "top_label";
			this.top_label.Size = new System.Drawing.Size(850, 83);
			this.top_label.TabIndex = 0;
			this.top_label.Text = "ESD ÖLÇÜM İSTASYONU";
			this.top_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sidepanel
			// 
			this.sidepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
			this.sidepanel.Controls.Add(this.button3);
			this.sidepanel.Controls.Add(this.button2);
			this.sidepanel.Controls.Add(this.button1);
			this.sidepanel.Controls.Add(this.pictureBox5);
			this.sidepanel.Controls.Add(this.btnCikis);
			this.sidepanel.Controls.Add(this.btnAyar);
			this.sidepanel.Controls.Add(this.txtCardID);
			this.sidepanel.Controls.Add(this.button_kullanici);
			this.sidepanel.Controls.Add(this.logopanel);
			this.sidepanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.sidepanel.Location = new System.Drawing.Point(0, 0);
			this.sidepanel.Name = "sidepanel";
			this.sidepanel.Size = new System.Drawing.Size(317, 600);
			this.sidepanel.TabIndex = 0;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(3, 372);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(114, 35);
			this.button3.TabIndex = 9;
			this.button3.Text = "Hesapla";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Visible = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(123, 331);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(114, 35);
			this.button2.TabIndex = 8;
			this.button2.Text = "Hesapla";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(3, 331);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(114, 35);
			this.button1.TabIndex = 7;
			this.button1.Text = "Onayla";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.onayla_button_Click);
			// 
			// pictureBox5
			// 
			this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBox5.Image = global::EsdTurnikesi.Properties.Resources.esd;
			this.pictureBox5.Location = new System.Drawing.Point(0, 331);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.pictureBox5.Size = new System.Drawing.Size(317, 269);
			this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox5.TabIndex = 5;
			this.pictureBox5.TabStop = false;
			// 
			// btnCikis
			// 
			this.btnCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
			this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCikis.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCikis.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCikis.ForeColor = System.Drawing.Color.White;
			this.btnCikis.Image = global::EsdTurnikesi.Properties.Resources.ilogout;
			this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCikis.Location = new System.Drawing.Point(-3, 249);
			this.btnCikis.Name = "btnCikis";
			this.btnCikis.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.btnCikis.Size = new System.Drawing.Size(331, 76);
			this.btnCikis.TabIndex = 4;
			this.btnCikis.Text = "  ÇIKIŞ";
			this.btnCikis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCikis.UseVisualStyleBackColor = false;
			this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
			// 
			// btnAyar
			// 
			this.btnAyar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
			this.btnAyar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnAyar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAyar.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnAyar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAyar.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnAyar.ForeColor = System.Drawing.Color.White;
			this.btnAyar.Image = global::EsdTurnikesi.Properties.Resources.isettings;
			this.btnAyar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAyar.Location = new System.Drawing.Point(-3, 174);
			this.btnAyar.Name = "btnAyar";
			this.btnAyar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.btnAyar.Size = new System.Drawing.Size(331, 75);
			this.btnAyar.TabIndex = 3;
			this.btnAyar.Text = "  AYARLAR";
			this.btnAyar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAyar.UseVisualStyleBackColor = true;
			this.btnAyar.Click += new System.EventHandler(this.btnAyar_Click);
			// 
			// txtCardID
			// 
			this.txtCardID.Location = new System.Drawing.Point(127, 426);
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(136, 22);
			this.txtCardID.TabIndex = 6;
			this.txtCardID.Visible = false;
			// 
			// button_kullanici
			// 
			this.button_kullanici.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
			this.button_kullanici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button_kullanici.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button_kullanici.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.button_kullanici.FlatAppearance.BorderSize = 0;
			this.button_kullanici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_kullanici.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
			this.button_kullanici.ForeColor = System.Drawing.Color.White;
			this.button_kullanici.Image = global::EsdTurnikesi.Properties.Resources.saatK;
			this.button_kullanici.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button_kullanici.Location = new System.Drawing.Point(-3, 91);
			this.button_kullanici.Name = "button_kullanici";
			this.button_kullanici.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.button_kullanici.Size = new System.Drawing.Size(331, 76);
			this.button_kullanici.TabIndex = 2;
			this.button_kullanici.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button_kullanici.UseVisualStyleBackColor = false;
			// 
			// logopanel
			// 
			this.logopanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
			this.logopanel.Controls.Add(this.pictureBoxAlpnextlogo);
			this.logopanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.logopanel.Location = new System.Drawing.Point(0, 0);
			this.logopanel.Name = "logopanel";
			this.logopanel.Size = new System.Drawing.Size(317, 83);
			this.logopanel.TabIndex = 0;
			// 
			// pictureBoxAlpnextlogo
			// 
			this.pictureBoxAlpnextlogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxAlpnextlogo.Image = global::EsdTurnikesi.Properties.Resources.alpNEXT_Logo;
			this.pictureBoxAlpnextlogo.Location = new System.Drawing.Point(53, 12);
			this.pictureBoxAlpnextlogo.Name = "pictureBoxAlpnextlogo";
			this.pictureBoxAlpnextlogo.Size = new System.Drawing.Size(210, 55);
			this.pictureBoxAlpnextlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxAlpnextlogo.TabIndex = 0;
			this.pictureBoxAlpnextlogo.TabStop = false;
			this.pictureBoxAlpnextlogo.UseWaitCursor = true;
			// 
			// timerMail
			// 
			this.timerMail.Enabled = true;
			this.timerMail.Interval = 1000;
			this.timerMail.Tick += new System.EventHandler(this.timerMail_Tick);
			// 
			// timerConnect
			// 
			this.timerConnect.Enabled = true;
			this.timerConnect.Interval = 2000;
			this.timerConnect.Tick += new System.EventHandler(this.timerConnect_Tick);
			// 
			// timerCikis
			// 
			this.timerCikis.Interval = 500;
			// 
			// mifarePort3
			// 
			this.mifarePort3.PortName = "COM5";
			this.mifarePort3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mifarePort3_DataReceived);
			// 
			// timerMifare3
			// 
			this.timerMifare3.Interval = 200;
			this.timerMifare3.Tick += new System.EventHandler(this.timerMifare3_Tick);
			// 
			// Main
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(1167, 600);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.headerpanel);
			this.Controls.Add(this.sidepanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Main";
			this.Text = "Main";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.Load += new System.EventHandler(this.Main_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.tableLayoutPanel8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureSol)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureSag)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel13.ResumeLayout(false);
			this.tableLayoutPanel13.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tableLayoutPanel12.ResumeLayout(false);
			this.tableLayoutPanel12.PerformLayout();
			this.headerpanel.ResumeLayout(false);
			this.sidepanel.ResumeLayout(false);
			this.sidepanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			this.logopanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlpnextlogo)).EndInit();
			this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label label3;

        public struct tagLASTINPUTINFO
        {
            public uint cbSize;
            public int dwTime;
        }

     }
}
