namespace QLBH_DIEN_TU
{
    partial class indonhang
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.hOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpv_hoadon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bt_inhoadon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbmahd = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.hOADONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hOADONBindingSource
            // 
            this.hOADONBindingSource.DataMember = "HOA_DON";
            // 
            // qLBANHANGDTDataSet
            // 
            // 
            // rpv_hoadon
            // 
            reportDataSource1.Name = "indonhang";
            reportDataSource1.Value = this.hOADONBindingSource;
            this.rpv_hoadon.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv_hoadon.LocalReport.ReportEmbeddedResource = "QLBH_DIEN_TU.Report_indonhang.rdlc";
            this.rpv_hoadon.Location = new System.Drawing.Point(1, 105);
            this.rpv_hoadon.Name = "rpv_hoadon";
            this.rpv_hoadon.ServerReport.BearerToken = null;
            this.rpv_hoadon.Size = new System.Drawing.Size(1454, 346);
            this.rpv_hoadon.TabIndex = 0;
            // 
            // bt_inhoadon
            // 
            this.bt_inhoadon.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_inhoadon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_inhoadon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_inhoadon.Location = new System.Drawing.Point(896, 32);
            this.bt_inhoadon.Name = "bt_inhoadon";
            this.bt_inhoadon.Size = new System.Drawing.Size(75, 30);
            this.bt_inhoadon.TabIndex = 1;
            this.bt_inhoadon.Text = "IN";
            this.bt_inhoadon.UseVisualStyleBackColor = false;
            this.bt_inhoadon.Click += new System.EventHandler(this.bt_inhoadon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(413, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã hóa đơn";
            // 
            // cmbmahd
            // 
            this.cmbmahd.FormattingEnabled = true;
            this.cmbmahd.Location = new System.Drawing.Point(566, 37);
            this.cmbmahd.Name = "cmbmahd";
            this.cmbmahd.Size = new System.Drawing.Size(141, 24);
            this.cmbmahd.TabIndex = 3;
            // 
            // hOA_DONTableAdapter
            // 
            // 
            // indonhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 450);
            this.Controls.Add(this.cmbmahd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_inhoadon);
            this.Controls.Add(this.rpv_hoadon);
            this.Name = "indonhang";
            this.Text = "indonhang";
            this.Load += new System.EventHandler(this.indonhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hOADONBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv_hoadon;
        private System.Windows.Forms.Button bt_inhoadon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbmahd;
        private System.Windows.Forms.BindingSource hOADONBindingSource;
    }
}