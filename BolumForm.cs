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
    public partial class BolumForm : Form
    {
 
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader dr;
        string bolumler;
        int id;
        public BolumForm()
        {
            InitializeComponent();
        }

        private void BolumForm_Load(object sender, EventArgs e)
        {
            sqlConnectionSet();
            getData();
            checkedListUpdate();
        }
        public void sqlConnectionSet()
        {
            this.sqlConnection = new SqlConnection(AyarForm.conn);
            try {
                this.sqlConnection.Open();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Hata : " + ex);
            }
           
        }

        private void getData() {
            if (sqlConnection.State == ConnectionState.Open)
            {
                this.sqlCommand = new SqlCommand("select * from cbo_Bolum order by Ad ", sqlConnection);
                this.dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    this.bolumler = dr.GetString(1);//GetString(i) i : sütun index;
                    this.listDepartmant.Items.Add(bolumler);
                    this.checkedListBox2.Items.Add(bolumler);
                }
                this.sqlCommand.Dispose();
                this.dr.Close();
            }
            this.sqlConnection.Close();
        }
        private void checkedListUpdate() 
        {
            foreach (var item in Ayarlar.Default.departmentList)
            {
                listDepartmant.SetItemCheckState(item, CheckState.Checked);
            }

            foreach (var item in Ayarlar.Default.mailDepartmentList)
            {
                checkedListBox2.SetItemCheckState(item, CheckState.Checked);
            }
        }


        private void checkedListSave()
        {
            this.sqlConnection.Open();
            foreach (string item in listDepartmant.CheckedItems)
            {
                this.sqlCommand = new SqlCommand("select * from cbo_Bolum where Ad='" + item + "' order by Ad ", sqlConnection);
                this.dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    this.id = Int16.Parse(dr["ID"].ToString());
                    Ayarlar.Default.departmentListIndex.Add(id);
                    this.dr.Close();
                }

            }
            foreach (int item in listDepartmant.CheckedIndices)
            {
                Ayarlar.Default.departmentList.Add(item);
            }
            Ayarlar.Default.departmentListIndex.Add(0);


            this.sqlCommand.Dispose();
            this.sqlConnection.Close();
            Ayarlar.Default.Save();

        }
        private void checkedMailListSave()
        {
            this.sqlConnection.Open();
            foreach (string item in checkedListBox2.CheckedItems)
            {
                this.sqlCommand = new SqlCommand("select * from cbo_Bolum where Ad='" + item + "' order by Ad ", sqlConnection);
                this.dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    this.id = Int16.Parse(dr["ID"].ToString());
                    Ayarlar.Default.mailDepartmentListIndex.Add(id);
                    this.dr.Close();
                }

            }
            foreach (int item in checkedListBox2.CheckedIndices)
            {
                Ayarlar.Default.mailDepartmentList.Add(item);
            }
            Ayarlar.Default.mailDepartmentListIndex.Add(0);


            this.sqlCommand.Dispose();
            this.sqlConnection.Close();
            Ayarlar.Default.Save();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ayarlar.Default.departmentList.Clear();
            Ayarlar.Default.departmentListIndex.Clear();
            Ayarlar.Default.mailDepartmentList.Clear();
            Ayarlar.Default.mailDepartmentListIndex.Clear();
            checkedListSave();
            checkedMailListSave();
            MessageBox.Show("Kaydedildi !");
            this.Close();
        }

        private void clearChecked()
        {
            for (int i = 0; i < listDepartmant.Items.Count; i++)
            {
                listDepartmant.SetItemChecked(i, true);
            }
           
        }
        private void clearCheckedFalse()
        {
            for (int i = 0; i < listDepartmant.Items.Count; i++)
            {
                listDepartmant.SetItemChecked(i, false);
            }
            
        }

        private void checkBoxDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDepartment.Checked == true)
            {
                clearChecked();
            }
            else
            {
                clearCheckedFalse(); 
            }

        }

        private void checkBoxMailDepartment_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxMailDepartment.Checked == true)
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }
        }
    }
}
