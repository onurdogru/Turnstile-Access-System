// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.AyarForm
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace EsdTurnikesi
{
    public class AyarForm : Form
    {
        public Main MainFrm;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label1;
        public ComboBox mifarecom;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        public ComboBox mifareParity;
        public ComboBox mifareStop;
        public ComboBox mifareData;
        public ComboBox mifareBaud;
        private GroupBox groupBox2;
        private Label label2;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        public ComboBox esdParity;
        public ComboBox esdStop;
        public ComboBox esdData;
        public ComboBox esdBaud;
        public ComboBox esdcom;
        private Button btnKaydet;
        private GroupBox groupBox4;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        public ComboBox plcParity;
        public ComboBox plcStop;
        public ComboBox plcData;
        public ComboBox plcBaud;
        public ComboBox plcCom;
        private GroupBox groupBox5;
        private CheckBox checkBox1;
        private Label label19;
        private Label label18;
        private TextBox plcModbusTimer;
        private GroupBox groupBox6;
        private CheckBox checkAyak;
        private Label label33;
        private Label label32;
        private TextBox txtTimerBekleme;
        private CheckBox checkBileklik;
        private Label label25;
        private Label label23;
        private Label label21;
        private TextBox txtTimerAdmin;
        private TextBox txtTimerMifare;
        private Label label24;
        private TextBox txtTimerESD;
        private Label label22;
        private Label label20;
        private TextBox txtAdminSifre;
        private Label label26;
        private CheckBox checkBox2;
        private Label label29;
        private TextBox txtTimerTurnike;
        private Label label28;
        private GroupBox groupBox7;
        private GroupBox groupBox9;
        private Label label38;
        private TextBox txtTimerMifare2;
        private Label label39;
        private GroupBox groupBox10;
        private Label label31;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        public ComboBox mifareParity2;
        public ComboBox mifareStop2;
        public ComboBox mifareData2;
        public ComboBox mifareBaud2;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private TextBox txtDatabaseName;
        private TextBox txtServerName;
        private Label label43;
        private Label label42;
        private Label label41;
        private Label label40;
        private CheckBox checkBox4;
        private Button btnKontrol;
        public ComboBox mifarecom2;

        public static string conn = @"Data Source=" + Ayarlar.Default.ServerName + ";Initial Catalog=" + Ayarlar.Default.DatabaseName +
            ";User ID=" + Ayarlar.Default.UserName + ";Password=" + Ayarlar.Default.Password + "; Connect Timeout = 5" ;
        private Label label11;
        private GroupBox groupBox3;
        private Label label44;
        private TextBox txtMail;
        private Button btnEkle;
        private ComboBox cmbMail;
        private Label label12;
        private Button btnSil;
        private Button btnEkAyar;
        string pass = "AtsOlC*54AtsOlC*54";
        public string connA = @"Data Source=192.168.0.8\MEYER;Initial Catalog=ALPPLAS_ESD_TURNIKE;User ID=esd;Password=AtsOlC*54AtsOlC*54; Connect Timeout = 5";
        static string getDesktopURL = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Software\esdLocalDb.mdf";
        public string connLocal = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + getDesktopURL + "; Integrated Security = True; Connect Timeout = 30";
        private bool firstTouch = true, flagConnetionAyar;
        SqlConnection sqlConnection, sqlConnectionMeyer;
        SqlCommand sqlCommand;
        private Button btnbolumAyar;
        private Label label30;
        private TextBox txtMailSifre;
        private TextBox txtG_Mail;
        private Label label27;
        private GroupBox groupBox8;
        private Label label45;
        public ComboBox mifarecom3;
        SqlDataReader sqlDataReader;

        public AyarForm()
        {
            this.InitializeComponent();
        }
        public AyarForm(Main main)
        {
            this.InitializeComponent();
        }

        public void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Orange, Color.White);
        }


        public void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush, 4);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));


            }

        }


        private void AyarForm_Load(object sender, EventArgs e)
        {
            flagConnetionAyar = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            this.listUpdate();
            this.mifarecom3.Text = Ayarlar.Default.mifareCom3;
            this.mifarecom.Text = Ayarlar.Default.mifareCom;
            this.mifareBaud.Text = Ayarlar.Default.mifareBaud.ToString();
            this.mifareData.Text = Ayarlar.Default.mifaredataBits.ToString();
            this.mifareStop.Text = Ayarlar.Default.mifarestopBit.ToString();
            this.mifareParity.Text = Ayarlar.Default.mifareParity.ToString();
            this.mifarecom2.Text = Ayarlar.Default.mifareCom2;
            this.mifareBaud2.Text = Ayarlar.Default.mifareBaud2.ToString();
            this.mifareData2.Text = Ayarlar.Default.mifaredataBits2.ToString();
            this.mifareStop2.Text = Ayarlar.Default.mifarestopBits2.ToString();
            this.mifareParity2.Text = Ayarlar.Default.mifareParity2.ToString();
            this.esdcom.Text = Ayarlar.Default.esdCom;
            this.esdBaud.Text = Ayarlar.Default.esdBaud.ToString();
            this.esdData.Text = Ayarlar.Default.esddataBits.ToString();
            this.esdStop.Text = Ayarlar.Default.esdstopBit.ToString();
            this.esdParity.Text = Ayarlar.Default.esdParity.ToString();
            this.txtServerName.Text = Ayarlar.Default.ServerName;
            this.txtDatabaseName.Text = Ayarlar.Default.DatabaseName;
            this.txtUserName.Text = Ayarlar.Default.UserName;
            this.txtPassword.Text = Ayarlar.Default.Password.ToString();
            this.plcCom.Text = Ayarlar.Default.plcCom;
            this.plcBaud.Text = Ayarlar.Default.plcBaud.ToString();
            this.plcData.Text = Ayarlar.Default.plcdataBits.ToString();
            this.plcStop.Text = Ayarlar.Default.plcstopBit.ToString();
            this.plcParity.Text = Ayarlar.Default.plcParity.ToString();
            this.plcModbusTimer.Text = Ayarlar.Default.timerModbus.ToString();
            this.txtTimerBekleme.Text = Ayarlar.Default.timerBekleme.ToString();
            this.txtTimerAdmin.Text = Ayarlar.Default.timerAdmin.ToString();
            this.txtTimerESD.Text = Ayarlar.Default.timerESD.ToString();
            this.txtTimerMifare.Text = Ayarlar.Default.timerMifare.ToString();
            this.txtTimerMifare2.Text = Ayarlar.Default.timerMifare2.ToString();
            this.txtG_Mail.Text = Ayarlar.Default.mailAdress.ToString();
            this.txtAdminSifre.Text = Ayarlar.Default.adminSifre.ToString();
            this.txtMailSifre.Text = Ayarlar.Default.mailSifre.ToString();
            this.txtTimerTurnike.Text = Ayarlar.Default.timerTurnike.ToString();
            this.checkBox1.Checked = this.MainFrm.timerModbus.Enabled;
            this.checkAyak.Checked = Ayarlar.Default.checkAyak;
            if (Ayarlar.Default.checkBileklik)
                this.checkBileklik.Checked = true;
            else
                this.checkBileklik.Checked = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                this.MainFrm.timerModbus.Enabled = false;
                this.MainFrm.timerBekleme.Enabled = false;
                this.MainFrm.timerESD.Enabled = false;
                this.MainFrm.timerMifare.Enabled = false;
                this.MainFrm.timerMifare2.Enabled = false;
                this.MainFrm.timerTurnike.Enabled = false;
                this.MainFrm.mifarePort.Close();
                this.MainFrm.mifarePort2.Close();
                this.MainFrm.mifarePort3.Close();
                this.MainFrm.esdPort.Close();
                this.MainFrm.plcPort.Close();
                Ayarlar.Default.mifareCom3 = this.mifarecom3.Text;
                Ayarlar.Default.mifareCom = this.mifarecom.Text;
                Ayarlar.Default.mifareBaud = Convert.ToInt32(this.mifareBaud.Text);
                Ayarlar.Default.mifaredataBits = Convert.ToInt32(this.mifareData.Text);
                switch (this.mifareStop.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.mifarestopBit = StopBits.None;
                        break;
                    case 1:
                        Ayarlar.Default.mifarestopBit = StopBits.One;
                        break;
                    case 2:
                        Ayarlar.Default.mifarestopBit = StopBits.Two;
                        break;
                    case 3:
                        Ayarlar.Default.mifarestopBit = StopBits.OnePointFive;
                        break;
                    default:
                        Ayarlar.Default.mifarestopBit = StopBits.One;
                        break;
                }
                switch (this.mifareParity.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.mifareParity = Parity.None;
                        break;
                    case 1:
                        Ayarlar.Default.mifareParity = Parity.Odd;
                        break;
                    case 2:
                        Ayarlar.Default.mifareParity = Parity.Even;
                        break;
                    case 3:
                        Ayarlar.Default.mifareParity = Parity.Mark;
                        break;
                    case 4:
                        Ayarlar.Default.mifareParity = Parity.Space;
                        break;
                    default:
                        Ayarlar.Default.mifareParity = Parity.None;
                        break;
                }
                Ayarlar.Default.mifareCom2 = this.mifarecom2.Text;
                Ayarlar.Default.mifareBaud2 = Convert.ToInt32(this.mifareBaud2.Text);
                Ayarlar.Default.mifaredataBits2 = Convert.ToInt32(this.mifareData2.Text);

                switch (this.mifareStop2.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.mifarestopBits2 = StopBits.None;
                        break;
                    case 1:
                        Ayarlar.Default.mifarestopBits2 = StopBits.One;
                        break;
                    case 2:
                        Ayarlar.Default.mifarestopBits2 = StopBits.Two;
                        break;
                    case 3:
                        Ayarlar.Default.mifarestopBits2 = StopBits.OnePointFive;
                        break;
                    default:
                        Ayarlar.Default.mifarestopBits2 = StopBits.One;
                        break;
                }
                switch (this.mifareParity2.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.mifareParity2 = Parity.None;
                        break;
                    case 1:
                        Ayarlar.Default.mifareParity2 = Parity.Odd;
                        break;
                    case 2:
                        Ayarlar.Default.mifareParity2 = Parity.Even;
                        break;
                    case 3:
                        Ayarlar.Default.mifareParity2 = Parity.Mark;
                        break;
                    case 4:
                        Ayarlar.Default.mifareParity2 = Parity.Space;
                        break;
                    default:
                        Ayarlar.Default.mifareParity2 = Parity.None;
                        break;
                }
                Ayarlar.Default.esdCom = this.esdcom.Text;
                Ayarlar.Default.esdBaud = Convert.ToInt32(this.esdBaud.Text);
                Ayarlar.Default.esddataBits = Convert.ToInt32(this.esdData.Text);
                switch (this.esdStop.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.esdstopBit = StopBits.None;
                        break;
                    case 1:
                        Ayarlar.Default.esdstopBit = StopBits.One;
                        break;
                    case 2:
                        Ayarlar.Default.esdstopBit = StopBits.Two;
                        break;
                    case 3:
                        Ayarlar.Default.esdstopBit = StopBits.OnePointFive;
                        break;
                    default:
                        Ayarlar.Default.esdstopBit = StopBits.One;
                        break;
                }
                switch (this.esdParity.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.esdParity = Parity.None;
                        break;
                    case 1:
                        Ayarlar.Default.esdParity = Parity.Odd;
                        break;
                    case 2:
                        Ayarlar.Default.esdParity = Parity.Even;
                        break;
                    case 3:
                        Ayarlar.Default.esdParity = Parity.Mark;
                        break;
                    case 4:
                        Ayarlar.Default.esdParity = Parity.Space;
                        break;
                    default:
                        Ayarlar.Default.esdParity = Parity.None;
                        break;
                }
                Ayarlar.Default.plcCom = this.plcCom.Text;
                Ayarlar.Default.plcBaud = Convert.ToInt32(this.plcBaud.Text);
                Ayarlar.Default.plcdataBits = Convert.ToInt32(this.plcData.Text);
                switch (this.plcStop.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.plcstopBit = StopBits.None;
                        break;
                    case 1:
                        Ayarlar.Default.plcstopBit = StopBits.One;
                        break;
                    case 2:
                        Ayarlar.Default.plcstopBit = StopBits.Two;
                        break;
                    case 3:
                        Ayarlar.Default.plcstopBit = StopBits.OnePointFive;
                        break;
                    default:
                        Ayarlar.Default.plcstopBit = StopBits.One;
                        break;
                }
                switch (this.plcParity.SelectedIndex)
                {
                    case 0:
                        Ayarlar.Default.plcParity = Parity.None;
                        break;
                    case 1:
                        Ayarlar.Default.plcParity = Parity.Odd;
                        break;
                    case 2:
                        Ayarlar.Default.plcParity = Parity.Even;
                        break;
                    case 3:
                        Ayarlar.Default.plcParity = Parity.Mark;
                        break;
                    case 4:
                        Ayarlar.Default.plcParity = Parity.Space;
                        break;
                    default:
                        Ayarlar.Default.plcParity = Parity.None;
                        break;
                }
                Ayarlar.Default.ServerName = this.txtServerName.Text;
                Ayarlar.Default.DatabaseName = this.txtDatabaseName.Text;
                Ayarlar.Default.UserName = this.txtUserName.Text;
                Ayarlar.Default.Password = this.txtPassword.Text;
                Ayarlar.Default.timerModbus = Convert.ToInt32(this.plcModbusTimer.Text);
                Ayarlar.Default.timerBekleme = Convert.ToInt32(this.txtTimerBekleme.Text);
                Ayarlar.Default.timerMifare = Convert.ToInt32(this.txtTimerMifare.Text);
                Ayarlar.Default.timerMifare2 = Convert.ToInt32(this.txtTimerMifare2.Text);
                Ayarlar.Default.timerESD = Convert.ToInt32(this.txtTimerESD.Text);
                Ayarlar.Default.timerTurnike = Convert.ToInt32(this.txtTimerTurnike.Text);
                Ayarlar.Default.checkAyak = this.checkAyak.Checked;
                Ayarlar.Default.checkBileklik = this.checkBileklik.Checked;
                Ayarlar.Default.mailAdress = this.txtG_Mail.Text;
                Ayarlar.Default.adminSifre = this.txtAdminSifre.Text;
                Ayarlar.Default.mailSifre = this.txtMailSifre.Text;
                Ayarlar.Default.Save();
                this.MainFrm.mifarePort3.PortName = Ayarlar.Default.mifareCom3;
                this.MainFrm.mifarePort.PortName = Ayarlar.Default.mifareCom;
                this.MainFrm.mifarePort.BaudRate = Ayarlar.Default.mifareBaud;
                this.MainFrm.mifarePort.DataBits = Ayarlar.Default.mifaredataBits;
                this.MainFrm.mifarePort.StopBits = Ayarlar.Default.mifarestopBit;
                this.MainFrm.mifarePort.Parity = Ayarlar.Default.mifareParity;
                this.MainFrm.mifarePort2.PortName = Ayarlar.Default.mifareCom2;
                this.MainFrm.mifarePort2.BaudRate = Ayarlar.Default.mifareBaud2;
                this.MainFrm.mifarePort2.DataBits = Ayarlar.Default.mifaredataBits2;
                this.MainFrm.mifarePort2.StopBits = Ayarlar.Default.mifarestopBits2;
                this.MainFrm.mifarePort2.Parity = Ayarlar.Default.mifareParity2;
                this.MainFrm.esdPort.PortName = Ayarlar.Default.esdCom;
                this.MainFrm.esdPort.BaudRate = Ayarlar.Default.esdBaud;
                this.MainFrm.esdPort.DataBits = Ayarlar.Default.esddataBits;
                this.MainFrm.esdPort.StopBits = Ayarlar.Default.esdstopBit;
                this.MainFrm.esdPort.Parity = Ayarlar.Default.esdParity;
                this.MainFrm.plcPort.PortName = Ayarlar.Default.plcCom;
                this.MainFrm.plcPort.BaudRate = Ayarlar.Default.plcBaud;
                this.MainFrm.plcPort.DataBits = Ayarlar.Default.plcdataBits;
                this.MainFrm.plcPort.StopBits = Ayarlar.Default.plcstopBit;
                this.MainFrm.plcPort.Parity = Ayarlar.Default.plcParity;
                this.MainFrm.timerModbus.Interval = Ayarlar.Default.timerModbus;
                this.MainFrm.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
                this.MainFrm.timerMifare.Interval = Ayarlar.Default.timerMifare;
                this.MainFrm.timerMifare2.Interval = Ayarlar.Default.timerMifare2;
                this.MainFrm.timerESD.Interval = Ayarlar.Default.timerESD;
                this.MainFrm.timerTurnike.Interval = Ayarlar.Default.timerTurnike;
                this.MainFrm.AyakAktif = Ayarlar.Default.checkAyak;
                this.MainFrm.bileklikAktif = Ayarlar.Default.checkBileklik;
                try
                {
                    this.MainFrm.mifarePort.Open();
                }
                catch (Exception)
                {
                    int num = (int)MessageBox.Show("mifareport hatası: ");
                }
                try
                {
                    this.MainFrm.mifarePort2.Open();
                }
                catch (Exception)
                {
                    int num = (int)MessageBox.Show("mifareport2 hatası: ");
                }
                try
                {
                    this.MainFrm.mifarePort3.Open();
                }
                catch (Exception)
                {
                    int num = (int)MessageBox.Show("mifareport3 hatası: ");
                }
                try
                {
                    this.MainFrm.esdPort.Open();
                }
                catch (Exception)
                {
                    int num = (int)MessageBox.Show("esdport hatası: ");
                }
                try
                {
                    this.MainFrm.plcPort.Open();
                }
                catch (Exception)
                {
                    int num = (int)MessageBox.Show("plcport hatası: ");
                }
                try
                {
                    this.txtServerName.Text = Ayarlar.Default.ServerName;
                    this.txtDatabaseName.Text = Ayarlar.Default.DatabaseName;
                    this.txtUserName.Text = Ayarlar.Default.UserName;
                    this.txtPassword.Text = Ayarlar.Default.Password;
                    conn = @"Data Source=" + txtServerName.Text + ";Initial Catalog=" + txtDatabaseName.Text +
                       ";User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text;
                    sqlConnection = new SqlConnection(conn);
                    sqlConnection.Open();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("sql connection hatası: " + ex.ToString());
                }
                this.MainFrm.timerModbus.Enabled = this.checkBox1.Checked;
                int num1 = (int)MessageBox.Show("Diğer bütün ayarlar başarıyla kaydedildi.");

                this.Close();
            }
            catch (Exception ex)
            {
                this.MainFrm.timerModbus.Enabled = false;
                int num = (int)MessageBox.Show("Sql connection ya da port hatası: " + ex.ToString());
            }

        }

        private void txtMail_MouseClick(object sender, MouseEventArgs e)
        {
            if (firstTouch == true)
            {
                txtMail.Text = "";

                if (txtMail.Text == "" && firstTouch == true)
                {
                    txtMail.ForeColor = Color.Black;
                    txtMail.Text = "@alpplas.com";
                    firstTouch = false;
                }

            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.txtAdminSifre.Enabled = true;
                this.txtAdminSifre.PasswordChar = char.MinValue;
                this.txtMailSifre.Enabled = true;
                this.txtMailSifre.PasswordChar = char.MinValue;

            }
            else
            {
                this.txtAdminSifre.Enabled = false;
                this.txtAdminSifre.PasswordChar = '*';
                this.txtMailSifre.Enabled = false;
                this.txtMailSifre.PasswordChar = '*';
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (this.checkBox4.Checked)
            {
                this.txtServerName.Enabled = true;
                this.txtDatabaseName.Enabled = true;
                this.txtUserName.Enabled = true;
                this.txtPassword.Enabled = true;
                this.txtPassword.PasswordChar = char.MinValue;
                this.btnKontrol.Enabled = true;
                this.btnKontrol.FlatAppearance.BorderColor = Color.White;
            }
            else
            {
                this.txtServerName.Enabled = false;
                this.txtDatabaseName.Enabled = false;
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
                this.txtPassword.PasswordChar = '*';
                this.btnKontrol.Enabled = false;
                this.btnKontrol.FlatAppearance.BorderColor = Color.Black;
            }
        }
        private void btnKontrol_Click(object sender, EventArgs e)
        {
            conn = @"Data Source=" + txtServerName.Text + ";Initial Catalog=" + txtDatabaseName.Text + ";User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + "";

            try
            {
                sqlConnection = new SqlConnection(conn);
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Bağlantı Başarılı ' Tamam ' tuşuna basılınca program tekrar başlayacaktır");
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    Application.Restart();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + " Bağlantı Başarısız Lütfen Connection String Kontrolünü Yapınız !");
            }

        }
        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                conn = @"Data Source=" + txtServerName.Text + ";Initial Catalog=" + txtDatabaseName.Text + ";User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + "";
                try
                {
                    sqlConnection = new SqlConnection(conn);
                    sqlConnection.Open();
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lütfen Server Kontolü Yapınız ! " + ex.ToString());
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mifareParity = new System.Windows.Forms.ComboBox();
            this.mifareStop = new System.Windows.Forms.ComboBox();
            this.mifareData = new System.Windows.Forms.ComboBox();
            this.mifareBaud = new System.Windows.Forms.ComboBox();
            this.mifarecom = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.esdParity = new System.Windows.Forms.ComboBox();
            this.esdStop = new System.Windows.Forms.ComboBox();
            this.esdData = new System.Windows.Forms.ComboBox();
            this.esdBaud = new System.Windows.Forms.ComboBox();
            this.esdcom = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.plcParity = new System.Windows.Forms.ComboBox();
            this.plcStop = new System.Windows.Forms.ComboBox();
            this.plcData = new System.Windows.Forms.ComboBox();
            this.plcBaud = new System.Windows.Forms.ComboBox();
            this.plcCom = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.plcModbusTimer = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtTimerMifare2 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTimerESD = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTimerMifare = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtTimerTurnike = new System.Windows.Forms.TextBox();
            this.txtTimerBekleme = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtTimerAdmin = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBileklik = new System.Windows.Forms.CheckBox();
            this.checkAyak = new System.Windows.Forms.CheckBox();
            this.txtAdminSifre = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtMailSifre = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnKontrol = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.mifareParity2 = new System.Windows.Forms.ComboBox();
            this.mifareStop2 = new System.Windows.Forms.ComboBox();
            this.mifareData2 = new System.Windows.Forms.ComboBox();
            this.mifareBaud2 = new System.Windows.Forms.ComboBox();
            this.mifarecom2 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtG_Mail = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.cmbMail = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEkAyar = new System.Windows.Forms.Button();
            this.btnbolumAyar = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label45 = new System.Windows.Forms.Label();
            this.mifarecom3 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mifareParity);
            this.groupBox1.Controls.Add(this.mifareStop);
            this.groupBox1.Controls.Add(this.mifareData);
            this.groupBox1.Controls.Add(this.mifareBaud);
            this.groupBox1.Controls.Add(this.mifarecom);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(52, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(296, 194);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş Mifare Okuyucu Com :";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Parity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "StopBit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "DataBits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "BaudRate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "ComPort:";
            // 
            // mifareParity
            // 
            this.mifareParity.FormattingEnabled = true;
            this.mifareParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.mifareParity.Location = new System.Drawing.Point(124, 159);
            this.mifareParity.Margin = new System.Windows.Forms.Padding(4);
            this.mifareParity.Name = "mifareParity";
            this.mifareParity.Size = new System.Drawing.Size(124, 31);
            this.mifareParity.TabIndex = 2;
            // 
            // mifareStop
            // 
            this.mifareStop.FormattingEnabled = true;
            this.mifareStop.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.mifareStop.Location = new System.Drawing.Point(124, 126);
            this.mifareStop.Margin = new System.Windows.Forms.Padding(4);
            this.mifareStop.Name = "mifareStop";
            this.mifareStop.Size = new System.Drawing.Size(124, 31);
            this.mifareStop.TabIndex = 2;
            // 
            // mifareData
            // 
            this.mifareData.FormattingEnabled = true;
            this.mifareData.Items.AddRange(new object[] {
            "8",
            "7"});
            this.mifareData.Location = new System.Drawing.Point(124, 93);
            this.mifareData.Margin = new System.Windows.Forms.Padding(4);
            this.mifareData.Name = "mifareData";
            this.mifareData.Size = new System.Drawing.Size(124, 31);
            this.mifareData.TabIndex = 2;
            // 
            // mifareBaud
            // 
            this.mifareBaud.FormattingEnabled = true;
            this.mifareBaud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "7200",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.mifareBaud.Location = new System.Drawing.Point(124, 60);
            this.mifareBaud.Margin = new System.Windows.Forms.Padding(4);
            this.mifareBaud.Name = "mifareBaud";
            this.mifareBaud.Size = new System.Drawing.Size(124, 31);
            this.mifareBaud.TabIndex = 2;
            // 
            // mifarecom
            // 
            this.mifarecom.FormattingEnabled = true;
            this.mifarecom.Location = new System.Drawing.Point(124, 27);
            this.mifarecom.Margin = new System.Windows.Forms.Padding(4);
            this.mifarecom.Name = "mifarecom";
            this.mifarecom.Size = new System.Drawing.Size(124, 31);
            this.mifarecom.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.esdParity);
            this.groupBox2.Controls.Add(this.esdStop);
            this.groupBox2.Controls.Add(this.esdData);
            this.groupBox2.Controls.Add(this.esdBaud);
            this.groupBox2.Controls.Add(this.esdcom);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(409, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox2.Size = new System.Drawing.Size(247, 194);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ESD Cihazı Com Ayar :";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "StopBit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 95);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 23);
            this.label8.TabIndex = 3;
            this.label8.Text = "DataBits:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 23);
            this.label9.TabIndex = 3;
            this.label9.Text = "BaudRate:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 3;
            this.label10.Text = "ComPort:";
            // 
            // esdParity
            // 
            this.esdParity.FormattingEnabled = true;
            this.esdParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.esdParity.Location = new System.Drawing.Point(108, 159);
            this.esdParity.Margin = new System.Windows.Forms.Padding(4);
            this.esdParity.Name = "esdParity";
            this.esdParity.Size = new System.Drawing.Size(124, 31);
            this.esdParity.TabIndex = 2;
            // 
            // esdStop
            // 
            this.esdStop.FormattingEnabled = true;
            this.esdStop.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.esdStop.Location = new System.Drawing.Point(108, 126);
            this.esdStop.Margin = new System.Windows.Forms.Padding(4);
            this.esdStop.Name = "esdStop";
            this.esdStop.Size = new System.Drawing.Size(124, 31);
            this.esdStop.TabIndex = 2;
            // 
            // esdData
            // 
            this.esdData.FormattingEnabled = true;
            this.esdData.Location = new System.Drawing.Point(108, 93);
            this.esdData.Margin = new System.Windows.Forms.Padding(4);
            this.esdData.Name = "esdData";
            this.esdData.Size = new System.Drawing.Size(124, 31);
            this.esdData.TabIndex = 2;
            // 
            // esdBaud
            // 
            this.esdBaud.FormattingEnabled = true;
            this.esdBaud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "7200",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.esdBaud.Location = new System.Drawing.Point(108, 60);
            this.esdBaud.Margin = new System.Windows.Forms.Padding(4);
            this.esdBaud.Name = "esdBaud";
            this.esdBaud.Size = new System.Drawing.Size(124, 31);
            this.esdBaud.TabIndex = 2;
            // 
            // esdcom
            // 
            this.esdcom.FormattingEnabled = true;
            this.esdcom.Location = new System.Drawing.Point(108, 27);
            this.esdcom.Margin = new System.Windows.Forms.Padding(4);
            this.esdcom.Name = "esdcom";
            this.esdcom.Size = new System.Drawing.Size(124, 31);
            this.esdcom.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 2;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(52, 714);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(319, 93);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Ayarları Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.plcParity);
            this.groupBox4.Controls.Add(this.plcStop);
            this.groupBox4.Controls.Add(this.plcData);
            this.groupBox4.Controls.Add(this.plcBaud);
            this.groupBox4.Controls.Add(this.plcCom);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.Location = new System.Drawing.Point(731, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox4.Size = new System.Drawing.Size(247, 194);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PLC Com Ayar :";
            this.groupBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 161);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 23);
            this.label13.TabIndex = 3;
            this.label13.Text = "Parity:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 128);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 23);
            this.label14.TabIndex = 3;
            this.label14.Text = "StopBit:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 95);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 23);
            this.label15.TabIndex = 3;
            this.label15.Text = "DataBits:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 62);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 23);
            this.label16.TabIndex = 3;
            this.label16.Text = "BaudRate:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 30);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.label17.TabIndex = 3;
            this.label17.Text = "ComPort:";
            // 
            // plcParity
            // 
            this.plcParity.FormattingEnabled = true;
            this.plcParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.plcParity.Location = new System.Drawing.Point(108, 159);
            this.plcParity.Margin = new System.Windows.Forms.Padding(4);
            this.plcParity.Name = "plcParity";
            this.plcParity.Size = new System.Drawing.Size(124, 31);
            this.plcParity.TabIndex = 2;
            // 
            // plcStop
            // 
            this.plcStop.FormattingEnabled = true;
            this.plcStop.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.plcStop.Location = new System.Drawing.Point(108, 126);
            this.plcStop.Margin = new System.Windows.Forms.Padding(4);
            this.plcStop.Name = "plcStop";
            this.plcStop.Size = new System.Drawing.Size(124, 31);
            this.plcStop.TabIndex = 2;
            // 
            // plcData
            // 
            this.plcData.FormattingEnabled = true;
            this.plcData.Location = new System.Drawing.Point(108, 93);
            this.plcData.Margin = new System.Windows.Forms.Padding(4);
            this.plcData.Name = "plcData";
            this.plcData.Size = new System.Drawing.Size(124, 31);
            this.plcData.TabIndex = 2;
            // 
            // plcBaud
            // 
            this.plcBaud.FormattingEnabled = true;
            this.plcBaud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "7200",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.plcBaud.Location = new System.Drawing.Point(108, 60);
            this.plcBaud.Margin = new System.Windows.Forms.Padding(4);
            this.plcBaud.Name = "plcBaud";
            this.plcBaud.Size = new System.Drawing.Size(124, 31);
            this.plcBaud.TabIndex = 2;
            // 
            // plcCom
            // 
            this.plcCom.FormattingEnabled = true;
            this.plcCom.Location = new System.Drawing.Point(108, 27);
            this.plcCom.Margin = new System.Windows.Forms.Padding(4);
            this.plcCom.Name = "plcCom";
            this.plcCom.Size = new System.Drawing.Size(124, 31);
            this.plcCom.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.plcModbusTimer);
            this.groupBox5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox5.Location = new System.Drawing.Point(574, 590);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox5.Size = new System.Drawing.Size(247, 84);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Modbus Timer :";
            this.groupBox5.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 55);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(217, 27);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Modbus Timer Aktif";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(193, 26);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 23);
            this.label19.TabIndex = 2;
            this.label19.Text = "mS";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 26);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 23);
            this.label18.TabIndex = 1;
            this.label18.Text = "Timer:";
            // 
            // plcModbusTimer
            // 
            this.plcModbusTimer.Location = new System.Drawing.Point(77, 23);
            this.plcModbusTimer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.plcModbusTimer.Name = "plcModbusTimer";
            this.plcModbusTimer.Size = new System.Drawing.Size(109, 32);
            this.plcModbusTimer.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.txtTimerMifare2);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.txtTimerESD);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.txtTimerMifare);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.txtTimerTurnike);
            this.groupBox6.Controls.Add(this.txtTimerBekleme);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.txtTimerAdmin);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox6.Location = new System.Drawing.Point(65, 466);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox6.Size = new System.Drawing.Size(272, 215);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Timer Ayarları :";
            this.groupBox6.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(199, 180);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(39, 23);
            this.label38.TabIndex = 5;
            this.label38.Text = "mS";
            // 
            // txtTimerMifare2
            // 
            this.txtTimerMifare2.Location = new System.Drawing.Point(127, 176);
            this.txtTimerMifare2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTimerMifare2.Name = "txtTimerMifare2";
            this.txtTimerMifare2.Size = new System.Drawing.Size(61, 32);
            this.txtTimerMifare2.TabIndex = 3;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(11, 180);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(113, 23);
            this.label39.TabIndex = 4;
            this.label39.Text = "T.Ç Mifare:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(199, 149);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 23);
            this.label29.TabIndex = 2;
            this.label29.Text = "mS";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(199, 26);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 23);
            this.label23.TabIndex = 2;
            this.label23.Text = "mS";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(197, 57);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 23);
            this.label21.TabIndex = 2;
            this.label21.Text = "mS";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(199, 118);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 23);
            this.label25.TabIndex = 2;
            this.label25.Text = "mS";
            // 
            // txtTimerESD
            // 
            this.txtTimerESD.Location = new System.Drawing.Point(127, 54);
            this.txtTimerESD.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTimerESD.Name = "txtTimerESD";
            this.txtTimerESD.Size = new System.Drawing.Size(61, 32);
            this.txtTimerESD.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 57);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(107, 23);
            this.label20.TabIndex = 1;
            this.label20.Text = "Timer ESD:";
            // 
            // txtTimerMifare
            // 
            this.txtTimerMifare.Location = new System.Drawing.Point(127, 23);
            this.txtTimerMifare.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTimerMifare.Name = "txtTimerMifare";
            this.txtTimerMifare.Size = new System.Drawing.Size(61, 32);
            this.txtTimerMifare.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 26);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 23);
            this.label22.TabIndex = 1;
            this.label22.Text = "T.G Mifare:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(197, 88);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(39, 23);
            this.label33.TabIndex = 2;
            this.label33.Text = "mS";
            // 
            // txtTimerTurnike
            // 
            this.txtTimerTurnike.Location = new System.Drawing.Point(127, 146);
            this.txtTimerTurnike.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTimerTurnike.Name = "txtTimerTurnike";
            this.txtTimerTurnike.Size = new System.Drawing.Size(61, 32);
            this.txtTimerTurnike.TabIndex = 0;
            // 
            // txtTimerBekleme
            // 
            this.txtTimerBekleme.Location = new System.Drawing.Point(127, 84);
            this.txtTimerBekleme.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTimerBekleme.Name = "txtTimerBekleme";
            this.txtTimerBekleme.Size = new System.Drawing.Size(61, 32);
            this.txtTimerBekleme.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 149);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 23);
            this.label28.TabIndex = 1;
            this.label28.Text = "T. Turnike:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 88);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(123, 23);
            this.label32.TabIndex = 1;
            this.label32.Text = "T. Bekleme:";
            // 
            // txtTimerAdmin
            // 
            this.txtTimerAdmin.Location = new System.Drawing.Point(127, 115);
            this.txtTimerAdmin.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTimerAdmin.Name = "txtTimerAdmin";
            this.txtTimerAdmin.Size = new System.Drawing.Size(61, 32);
            this.txtTimerAdmin.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 118);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 23);
            this.label24.TabIndex = 1;
            this.label24.Text = "T. Admin:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 26);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(149, 27);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Şifre Değiştir";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBileklik
            // 
            this.checkBileklik.AutoSize = true;
            this.checkBileklik.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBileklik.ForeColor = System.Drawing.Color.White;
            this.checkBileklik.Location = new System.Drawing.Point(422, 783);
            this.checkBileklik.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBileklik.Name = "checkBileklik";
            this.checkBileklik.Size = new System.Drawing.Size(199, 38);
            this.checkBileklik.TabIndex = 3;
            this.checkBileklik.Text = "Bileklik Aktif";
            this.checkBileklik.UseVisualStyleBackColor = true;
            // 
            // checkAyak
            // 
            this.checkAyak.AutoSize = true;
            this.checkAyak.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkAyak.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkAyak.ForeColor = System.Drawing.Color.White;
            this.checkAyak.Location = new System.Drawing.Point(422, 741);
            this.checkAyak.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkAyak.Name = "checkAyak";
            this.checkAyak.Size = new System.Drawing.Size(176, 38);
            this.checkAyak.TabIndex = 3;
            this.checkAyak.Text = "Ayak Aktif";
            this.checkAyak.UseVisualStyleBackColor = true;
            // 
            // txtAdminSifre
            // 
            this.txtAdminSifre.Enabled = false;
            this.txtAdminSifre.Location = new System.Drawing.Point(12, 84);
            this.txtAdminSifre.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtAdminSifre.Name = "txtAdminSifre";
            this.txtAdminSifre.PasswordChar = '*';
            this.txtAdminSifre.Size = new System.Drawing.Size(117, 32);
            this.txtAdminSifre.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 57);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(126, 23);
            this.label26.TabIndex = 1;
            this.label26.Text = "Admin Şifre:";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.txtMailSifre);
            this.groupBox7.Controls.Add(this.checkBox2);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.txtAdminSifre);
            this.groupBox7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox7.Location = new System.Drawing.Point(374, 466);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox7.Size = new System.Drawing.Size(179, 208);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Şifre Ayarları :";
            this.groupBox7.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 131);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(126, 23);
            this.label30.TabIndex = 5;
            this.label30.Text = "Admin Şifre:";
            // 
            // txtMailSifre
            // 
            this.txtMailSifre.Enabled = false;
            this.txtMailSifre.Location = new System.Drawing.Point(12, 158);
            this.txtMailSifre.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMailSifre.Name = "txtMailSifre";
            this.txtMailSifre.PasswordChar = '*';
            this.txtMailSifre.Size = new System.Drawing.Size(117, 32);
            this.txtMailSifre.TabIndex = 4;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.btnKontrol);
            this.groupBox9.Controls.Add(this.checkBox4);
            this.groupBox9.Controls.Add(this.label43);
            this.groupBox9.Controls.Add(this.label42);
            this.groupBox9.Controls.Add(this.label41);
            this.groupBox9.Controls.Add(this.label40);
            this.groupBox9.Controls.Add(this.txtPassword);
            this.groupBox9.Controls.Add(this.txtUserName);
            this.groupBox9.Controls.Add(this.txtDatabaseName);
            this.groupBox9.Controls.Add(this.txtServerName);
            this.groupBox9.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox9.Location = new System.Drawing.Point(858, 387);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Size = new System.Drawing.Size(532, 331);
            this.groupBox9.TabIndex = 13;
            this.groupBox9.TabStop = false;
            this.groupBox9.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label11
            // 
            this.label11.AllowDrop = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Image = global::EsdTurnikesi.Properties.Resources.isettings;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(142, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(283, 47);
            this.label11.TabIndex = 16;
            this.label11.Text = "Server Settings";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKontrol
            // 
            this.btnKontrol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKontrol.Enabled = false;
            this.btnKontrol.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnKontrol.FlatAppearance.BorderSize = 2;
            this.btnKontrol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKontrol.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKontrol.ForeColor = System.Drawing.Color.White;
            this.btnKontrol.Location = new System.Drawing.Point(273, 254);
            this.btnKontrol.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnKontrol.Name = "btnKontrol";
            this.btnKontrol.Size = new System.Drawing.Size(235, 54);
            this.btnKontrol.TabIndex = 15;
            this.btnKontrol.Text = "Server Kontrol";
            this.btnKontrol.UseVisualStyleBackColor = true;
            this.btnKontrol.Click += new System.EventHandler(this.btnKontrol_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBox4.Location = new System.Drawing.Point(32, 266);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(228, 32);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "Bağlantı Ayarları";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            this.checkBox4.Click += new System.EventHandler(this.checkBox4_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label43.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label43.Location = new System.Drawing.Point(12, 212);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(131, 28);
            this.label43.TabIndex = 7;
            this.label43.Text = "Pasword : ";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label42.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label42.Location = new System.Drawing.Point(12, 169);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(161, 28);
            this.label42.TabIndex = 6;
            this.label42.Text = "User Name : ";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label41.Location = new System.Drawing.Point(12, 126);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(226, 28);
            this.label41.TabIndex = 5;
            this.label41.Text = "Database Name : ";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label40.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label40.Location = new System.Drawing.Point(12, 87);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(183, 28);
            this.label40.TabIndex = 4;
            this.label40.Text = "Server Name : ";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(275, 209);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(233, 36);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(275, 165);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(233, 36);
            this.txtUserName.TabIndex = 2;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtDatabaseName.Enabled = false;
            this.txtDatabaseName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDatabaseName.ForeColor = System.Drawing.Color.White;
            this.txtDatabaseName.Location = new System.Drawing.Point(275, 123);
            this.txtDatabaseName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(233, 36);
            this.txtDatabaseName.TabIndex = 1;
            // 
            // txtServerName
            // 
            this.txtServerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.txtServerName.Enabled = false;
            this.txtServerName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtServerName.ForeColor = System.Drawing.Color.White;
            this.txtServerName.Location = new System.Drawing.Point(275, 79);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(233, 36);
            this.txtServerName.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.label31);
            this.groupBox10.Controls.Add(this.label34);
            this.groupBox10.Controls.Add(this.label35);
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Controls.Add(this.label37);
            this.groupBox10.Controls.Add(this.mifareParity2);
            this.groupBox10.Controls.Add(this.mifareStop2);
            this.groupBox10.Controls.Add(this.mifareData2);
            this.groupBox10.Controls.Add(this.mifareBaud2);
            this.groupBox10.Controls.Add(this.mifarecom2);
            this.groupBox10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox10.Location = new System.Drawing.Point(1040, 15);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox10.Size = new System.Drawing.Size(299, 194);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Çıkış Mifare Okuyucu Com :";
            this.groupBox10.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 161);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(69, 23);
            this.label31.TabIndex = 3;
            this.label31.Text = "Parity:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(9, 128);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(81, 23);
            this.label34.TabIndex = 3;
            this.label34.Text = "StopBit:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 95);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(94, 23);
            this.label35.TabIndex = 3;
            this.label35.Text = "DataBits:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 62);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(110, 23);
            this.label36.TabIndex = 3;
            this.label36.Text = "BaudRate:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(9, 30);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 23);
            this.label37.TabIndex = 3;
            this.label37.Text = "ComPort:";
            // 
            // mifareParity2
            // 
            this.mifareParity2.FormattingEnabled = true;
            this.mifareParity2.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.mifareParity2.Location = new System.Drawing.Point(119, 159);
            this.mifareParity2.Margin = new System.Windows.Forms.Padding(4);
            this.mifareParity2.Name = "mifareParity2";
            this.mifareParity2.Size = new System.Drawing.Size(124, 31);
            this.mifareParity2.TabIndex = 2;
            // 
            // mifareStop2
            // 
            this.mifareStop2.FormattingEnabled = true;
            this.mifareStop2.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.mifareStop2.Location = new System.Drawing.Point(119, 126);
            this.mifareStop2.Margin = new System.Windows.Forms.Padding(4);
            this.mifareStop2.Name = "mifareStop2";
            this.mifareStop2.Size = new System.Drawing.Size(124, 31);
            this.mifareStop2.TabIndex = 2;
            // 
            // mifareData2
            // 
            this.mifareData2.FormattingEnabled = true;
            this.mifareData2.Items.AddRange(new object[] {
            "8",
            "7"});
            this.mifareData2.Location = new System.Drawing.Point(119, 93);
            this.mifareData2.Margin = new System.Windows.Forms.Padding(4);
            this.mifareData2.Name = "mifareData2";
            this.mifareData2.Size = new System.Drawing.Size(124, 31);
            this.mifareData2.TabIndex = 2;
            // 
            // mifareBaud2
            // 
            this.mifareBaud2.FormattingEnabled = true;
            this.mifareBaud2.Items.AddRange(new object[] {
            "2400",
            "4800",
            "7200",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.mifareBaud2.Location = new System.Drawing.Point(119, 60);
            this.mifareBaud2.Margin = new System.Windows.Forms.Padding(4);
            this.mifareBaud2.Name = "mifareBaud2";
            this.mifareBaud2.Size = new System.Drawing.Size(124, 31);
            this.mifareBaud2.TabIndex = 2;
            // 
            // mifarecom2
            // 
            this.mifarecom2.FormattingEnabled = true;
            this.mifarecom2.Location = new System.Drawing.Point(119, 27);
            this.mifarecom2.Margin = new System.Windows.Forms.Padding(4);
            this.mifarecom2.Name = "mifarecom2";
            this.mifarecom2.Size = new System.Drawing.Size(124, 31);
            this.mifarecom2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtG_Mail);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.btnSil);
            this.groupBox3.Controls.Add(this.label44);
            this.groupBox3.Controls.Add(this.txtMail);
            this.groupBox3.Controls.Add(this.btnEkle);
            this.groupBox3.Controls.Add(this.cmbMail);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(76, 236);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(679, 177);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mail Adresleri :";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // txtG_Mail
            // 
            this.txtG_Mail.ForeColor = System.Drawing.Color.Black;
            this.txtG_Mail.Location = new System.Drawing.Point(113, 125);
            this.txtG_Mail.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtG_Mail.Name = "txtG_Mail";
            this.txtG_Mail.Size = new System.Drawing.Size(409, 32);
            this.txtG_Mail.TabIndex = 23;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 128);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 23);
            this.label27.TabIndex = 22;
            this.label27.Text = "G.Mail :";
            // 
            // btnSil
            // 
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSil.FlatAppearance.BorderSize = 2;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(553, 27);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(107, 36);
            this.btnSil.TabIndex = 19;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(11, 86);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(63, 23);
            this.label44.TabIndex = 18;
            this.label44.Text = "Mail :";
            // 
            // txtMail
            // 
            this.txtMail.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMail.Location = new System.Drawing.Point(113, 80);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(409, 32);
            this.txtMail.TabIndex = 4;
            this.txtMail.Text = "Mail Ekle";
            this.txtMail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMail_MouseClick);
            // 
            // btnEkle
            // 
            this.btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEkle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEkle.FlatAppearance.BorderSize = 2;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(553, 80);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(107, 36);
            this.btnEkle.TabIndex = 17;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cmbMail
            // 
            this.cmbMail.FormattingEnabled = true;
            this.cmbMail.Location = new System.Drawing.Point(113, 35);
            this.cmbMail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbMail.Name = "cmbMail";
            this.cmbMail.Size = new System.Drawing.Size(409, 31);
            this.cmbMail.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 40);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 23);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mailler :";
            // 
            // btnEkAyar
            // 
            this.btnEkAyar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEkAyar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEkAyar.FlatAppearance.BorderSize = 2;
            this.btnEkAyar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkAyar.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkAyar.ForeColor = System.Drawing.Color.White;
            this.btnEkAyar.Location = new System.Drawing.Point(973, 236);
            this.btnEkAyar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnEkAyar.Name = "btnEkAyar";
            this.btnEkAyar.Size = new System.Drawing.Size(366, 61);
            this.btnEkAyar.TabIndex = 20;
            this.btnEkAyar.Text = "Diğer Ayarlar";
            this.btnEkAyar.UseVisualStyleBackColor = true;
            this.btnEkAyar.Click += new System.EventHandler(this.btnEkAyar_Click);
            // 
            // btnbolumAyar
            // 
            this.btnbolumAyar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbolumAyar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnbolumAyar.FlatAppearance.BorderSize = 2;
            this.btnbolumAyar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbolumAyar.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbolumAyar.ForeColor = System.Drawing.Color.White;
            this.btnbolumAyar.Location = new System.Drawing.Point(973, 315);
            this.btnbolumAyar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnbolumAyar.Name = "btnbolumAyar";
            this.btnbolumAyar.Size = new System.Drawing.Size(366, 61);
            this.btnbolumAyar.TabIndex = 21;
            this.btnbolumAyar.Text = "Bölüm Ayarları";
            this.btnbolumAyar.UseVisualStyleBackColor = true;
            this.btnbolumAyar.Click += new System.EventHandler(this.btnbolumAyar_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.label45);
            this.groupBox8.Controls.Add(this.mifarecom3);
            this.groupBox8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox8.Location = new System.Drawing.Point(572, 466);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox8.Size = new System.Drawing.Size(247, 78);
            this.groupBox8.TabIndex = 22;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Çıkış Mifare 3 :";
            this.groupBox8.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 30);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(100, 23);
            this.label45.TabIndex = 5;
            this.label45.Text = "ComPort:";
            // 
            // mifarecom3
            // 
            this.mifarecom3.FormattingEnabled = true;
            this.mifarecom3.Location = new System.Drawing.Point(116, 27);
            this.mifarecom3.Margin = new System.Windows.Forms.Padding(4);
            this.mifarecom3.Name = "mifarecom3";
            this.mifarecom3.Size = new System.Drawing.Size(124, 31);
            this.mifarecom3.TabIndex = 4;
            // 
            // AyarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1419, 834);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnbolumAyar);
            this.Controls.Add(this.btnEkAyar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.checkBileklik);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkAyak);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "AyarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.AyarForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnEkAyar_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.EkAyarFrm.ShowDialog();

        }
        private void listUpdate()
        {

            if (flagConnetionAyar)
            {
                flagConnetionAyar = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                cmbMail.Items.Clear();
                this.cmbMail.Text = "-- Mail Adresleri --";
                this.sqlConnectionMeyer = new SqlConnection(connA);
                this.sqlConnectionMeyer.Open();
                this.sqlCommand = new SqlCommand("Select mail from mail_tb", sqlConnectionMeyer);
                this.sqlDataReader = sqlCommand.ExecuteReader();

                while (this.sqlDataReader.Read())
                {
                    this.cmbMail.Items.Add(sqlDataReader[0]);
                }
                this.sqlCommand.Dispose();
                this.sqlDataReader.Dispose();
                this.sqlConnectionMeyer.Close();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           this.sqlConnectionMeyer = new SqlConnection(connA);
            this.sqlConnectionMeyer.Open();
            this.sqlCommand = new SqlCommand("delete from mail_tb where mail='" + cmbMail.SelectedItem + "'", sqlConnectionMeyer);
            this.sqlDataReader = sqlCommand.ExecuteReader();
            listUpdate();
            this.sqlCommand.Dispose();
            this.sqlDataReader.Dispose();
            this.sqlConnectionMeyer.Close();
            MessageBox.Show("Silindi");
        }

        private void btnbolumAyar_Click(object sender, EventArgs e)
        {
            BolumForm bolumForm = new BolumForm();
            bolumForm.ShowDialog();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            sqlConnectionMeyer = new SqlConnection(connA);
            sqlConnectionMeyer.Open();
            if (sqlConnectionMeyer.State == ConnectionState.Open)
            {
                sqlCommand = new SqlCommand("INSERT INTO mail_tb (mail) VALUES ('" + txtMail.Text + "');", sqlConnectionMeyer);
                sqlDataReader = sqlCommand.ExecuteReader();
                MessageBox.Show("Mail adresi eklendi.");
                sqlDataReader.Dispose();
                sqlCommand.Dispose();
                listUpdate();
                txtMail.Text = "@alpplas.com";
            }
            else
            {
                MessageBox.Show("Veri tabanı ile bağlantı oluşturulamadı !");
            }
            sqlConnectionMeyer.Close();
        }
    }
}
