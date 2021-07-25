namespace QuanLyNhaHang
{
    partial class fPrint
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PrintBillInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nhahangDataSet4 = new QuanLyNhaHang.nhahangDataSet4();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PrintBillInfoTableAdapter = new QuanLyNhaHang.nhahangDataSet4TableAdapters.PrintBillInfoTableAdapter();
            this.buttonExit = new System.Windows.Forms.Button();
            this.nhahangDataSet5 = new QuanLyNhaHang.nhahangDataSet5();
            this.nhahangDataSet5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrintBillInfoTotalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrintBillInfoTotalTableAdapter = new QuanLyNhaHang.nhahangDataSet5TableAdapters.PrintBillInfoTotalTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBillInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBillInfoTotalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintBillInfoBindingSource
            // 
            this.PrintBillInfoBindingSource.DataMember = "PrintBillInfo";
            this.PrintBillInfoBindingSource.DataSource = this.nhahangDataSet4;
            // 
            // nhahangDataSet4
            // 
            this.nhahangDataSet4.DataSetName = "nhahangDataSet4";
            this.nhahangDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PrintBillInfoBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.PrintBillInfoTotalBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhaHang.PrintBill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 600);
            this.reportViewer1.TabIndex = 0;
            // 
            // PrintBillInfoTableAdapter
            // 
            this.PrintBillInfoTableAdapter.ClearBeforeFill = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.Red;
            this.buttonExit.Location = new System.Drawing.Point(663, 618);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(125, 60);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "THOÁT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // nhahangDataSet5
            // 
            this.nhahangDataSet5.DataSetName = "nhahangDataSet5";
            this.nhahangDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nhahangDataSet5BindingSource
            // 
            this.nhahangDataSet5BindingSource.DataSource = this.nhahangDataSet5;
            this.nhahangDataSet5BindingSource.Position = 0;
            // 
            // PrintBillInfoTotalBindingSource
            // 
            this.PrintBillInfoTotalBindingSource.DataMember = "PrintBillInfoTotal";
            this.PrintBillInfoTotalBindingSource.DataSource = this.nhahangDataSet5;
            // 
            // PrintBillInfoTotalTableAdapter
            // 
            this.PrintBillInfoTotalTableAdapter.ClearBeforeFill = true;
            // 
            // fPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 690);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.reportViewer1);
            this.Name = "fPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn";
            this.Load += new System.EventHandler(this.FPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PrintBillInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhahangDataSet5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBillInfoTotalBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PrintBillInfoBindingSource;
        private nhahangDataSet4 nhahangDataSet4;
        private nhahangDataSet4TableAdapters.PrintBillInfoTableAdapter PrintBillInfoTableAdapter;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.BindingSource nhahangDataSet5BindingSource;
        private nhahangDataSet5 nhahangDataSet5;
        private System.Windows.Forms.BindingSource PrintBillInfoTotalBindingSource;
        private nhahangDataSet5TableAdapters.PrintBillInfoTotalTableAdapter PrintBillInfoTotalTableAdapter;
    }
}