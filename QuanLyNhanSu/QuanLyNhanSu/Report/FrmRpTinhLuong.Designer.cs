namespace QuanLyNhanSu.Report
{
    partial class FrmRpTinhLuong
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
            this.TINHLUONGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RpDataSet = new QuanLyNhanSu.Report.RpDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TINHLUONGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TINHLUONGBindingSource
            // 
            this.TINHLUONGBindingSource.DataMember = "TINHLUONG";
            this.TINHLUONGBindingSource.DataSource = this.RpDataSet;
            // 
            // RpDataSet
            // 
            this.RpDataSet.DataSetName = "RpDataSet";
            this.RpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TINHLUONGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhanSu.Report.rpTinhLuong.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1049, 676);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmRpTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 676);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRpTinhLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tính lương";
            this.Load += new System.EventHandler(this.FrmRpTinhLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TINHLUONGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TINHLUONGBindingSource;
        private RpDataSet RpDataSet;
    }
}