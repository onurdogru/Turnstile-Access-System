
namespace EsdTurnikesi
{
    partial class BolumForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listDepartmant = new System.Windows.Forms.CheckedListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBoxDepartment = new System.Windows.Forms.CheckBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxMailDepartment = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listDepartmant
            // 
            this.listDepartmant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.listDepartmant.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listDepartmant.ForeColor = System.Drawing.Color.White;
            this.listDepartmant.FormattingEnabled = true;
            this.listDepartmant.Location = new System.Drawing.Point(42, 72);
            this.listDepartmant.Name = "listDepartmant";
            this.listDepartmant.Size = new System.Drawing.Size(455, 510);
            this.listDepartmant.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(534, 505);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(158, 61);
            this.button5.TabIndex = 6;
            this.button5.Text = "Kaydet";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // checkBoxDepartment
            // 
            this.checkBoxDepartment.AutoSize = true;
            this.checkBoxDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxDepartment.ForeColor = System.Drawing.Color.White;
            this.checkBoxDepartment.Location = new System.Drawing.Point(518, 95);
            this.checkBoxDepartment.Name = "checkBoxDepartment";
            this.checkBoxDepartment.Size = new System.Drawing.Size(186, 29);
            this.checkBoxDepartment.TabIndex = 7;
            this.checkBoxDepartment.Text = "Bütün Bölümler ";
            this.checkBoxDepartment.UseVisualStyleBackColor = true;
            this.checkBoxDepartment.CheckedChanged += new System.EventHandler(this.checkBoxDepartment_CheckedChanged);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.checkedListBox2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkedListBox2.ForeColor = System.Drawing.Color.White;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(727, 71);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(448, 510);
            this.checkedListBox2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "ESD TURNİKESİNE TANIMLI BÖLÜMLER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(722, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "MAİL SİSTEMİ TANIMLI BÖLÜMLER";
            // 
            // checkBoxMailDepartment
            // 
            this.checkBoxMailDepartment.AutoSize = true;
            this.checkBoxMailDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxMailDepartment.ForeColor = System.Drawing.Color.White;
            this.checkBoxMailDepartment.Location = new System.Drawing.Point(518, 146);
            this.checkBoxMailDepartment.Name = "checkBoxMailDepartment";
            this.checkBoxMailDepartment.Size = new System.Drawing.Size(176, 29);
            this.checkBoxMailDepartment.TabIndex = 11;
            this.checkBoxMailDepartment.Text = "Mail  Bölümler ";
            this.checkBoxMailDepartment.UseVisualStyleBackColor = true;
            this.checkBoxMailDepartment.CheckedChanged += new System.EventHandler(this.checkBoxMailDepartment_CheckedChanged);
            // 
            // BolumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1187, 593);
            this.Controls.Add(this.checkBoxMailDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkBoxDepartment);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listDepartmant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BolumForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BolumForm";
            this.Load += new System.EventHandler(this.BolumForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listDepartmant;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBoxDepartment;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxMailDepartment;
    }
}