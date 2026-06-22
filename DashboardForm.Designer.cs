namespace UserActivity
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalLocked = new System.Windows.Forms.Label();
            this.lblTotalPassive = new System.Windows.Forms.Label();
            this.lblTotalActive = new System.Windows.Forms.Label();
            this.lblTotalWork = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lblTotalLocked);
            this.panel1.Controls.Add(this.lblTotalPassive);
            this.panel1.Controls.Add(this.lblTotalActive);
            this.panel1.Controls.Add(this.lblTotalWork);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGetReport);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.cmbUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 126);
            this.panel1.TabIndex = 0;
            // 
            // lblTotalLocked
            // 
            this.lblTotalLocked.AutoSize = true;
            this.lblTotalLocked.Location = new System.Drawing.Point(581, 101);
            this.lblTotalLocked.Name = "lblTotalLocked";
            this.lblTotalLocked.Size = new System.Drawing.Size(122, 16);
            this.lblTotalLocked.TabIndex = 8;
            this.lblTotalLocked.Text = "Kilitli Süre: 0 Saniye";
            // 
            // lblTotalPassive
            // 
            this.lblTotalPassive.AutoSize = true;
            this.lblTotalPassive.Location = new System.Drawing.Point(581, 70);
            this.lblTotalPassive.Name = "lblTotalPassive";
            this.lblTotalPassive.Size = new System.Drawing.Size(126, 16);
            this.lblTotalPassive.TabIndex = 7;
            this.lblTotalPassive.Text = "Pasif Süre: 0 Saniye";
            // 
            // lblTotalActive
            // 
            this.lblTotalActive.AutoSize = true;
            this.lblTotalActive.Location = new System.Drawing.Point(581, 39);
            this.lblTotalActive.Name = "lblTotalActive";
            this.lblTotalActive.Size = new System.Drawing.Size(121, 16);
            this.lblTotalActive.TabIndex = 6;
            this.lblTotalActive.Text = "Aktif Süre: 0 Saniye";
            // 
            // lblTotalWork
            // 
            this.lblTotalWork.AutoSize = true;
            this.lblTotalWork.Location = new System.Drawing.Point(581, 12);
            this.lblTotalWork.Name = "lblTotalWork";
            this.lblTotalWork.Size = new System.Drawing.Size(164, 16);
            this.lblTotalWork.TabIndex = 5;
            this.lblTotalWork.Text = "Toplam Çalışma: 0 Saniye";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tarih :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı :";
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(397, 39);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(136, 32);
            this.btnGetReport.TabIndex = 2;
            this.btnGetReport.Text = "Raporu Getir";
            this.btnGetReport.UseVisualStyleBackColor = true;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(142, 70);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(220, 22);
            this.dtpDate.TabIndex = 1;
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(142, 20);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(220, 24);
            this.cmbUsers.TabIndex = 1;
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(0, 126);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.RowTemplate.Height = 24;
            this.dgvLogs.Size = new System.Drawing.Size(891, 345);
            this.dgvLogs.TabIndex = 1;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 471);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardForm";
            this.Text = "Yönetici Paneli";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Label lblTotalLocked;
        private System.Windows.Forms.Label lblTotalPassive;
        private System.Windows.Forms.Label lblTotalActive;
        private System.Windows.Forms.Label lblTotalWork;
    }
}