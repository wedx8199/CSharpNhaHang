namespace QuanLyNhaHang
{
    partial class fPrintDT
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
            this.GetDoanhThuByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nhahangDataSet6 = new QuanLyNhaHang.nhahangDataSet6();
            this.buttonExit = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GetDoanhThuByDateTableAdapter = new QuanLyNhaHang.nhahangDataSet6TableAdapters.GetDoanhThuByDateTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GetDoanhThuByDateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // GetDoanhThuByDateBindingSource
            // 
            this.GetDoanhThuByDateBindingSource.DataMember = "GetDoanhThuByDate";
            this.GetDoanhThuByDateBindingSource.DataSource = this.nhahangDataSet6;
            // 
            // nhahangDataSet6
            // 
            this.nhahangDataSet6.DataSetName = "nhahangDataSet6";
            this.nhahangDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.Red;
            this.buttonExit.Location = new System.Drawing.Point(663, 618);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(125, 60);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "THOÁT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GetDoanhThuByDateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhaHang.ReportDT.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 600);
            this.reportViewer1.TabIndex = 3;
            // 
            // GetDoanhThuByDateTableAdapter
            // 
            this.GetDoanhThuByDateTableAdapter.ClearBeforeFill = true;
            // 
            // fPrintDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 690);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonExit);
            this.Name = "fPrintDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất Doanh Thu";
            this.Load += new System.EventHandler(this.FPrintDT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetDoanhThuByDateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetDoanhThuByDateBindingSource;
        private nhahangDataSet6 nhahangDataSet6;
        private nhahangDataSet6TableAdapters.GetDoanhThuByDateTableAdapter GetDoanhThuByDateTableAdapter;
    }
}