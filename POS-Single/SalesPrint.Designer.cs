namespace POS_Single
{
    partial class SalesPrint
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
            this.dgr_sales = new System.Windows.Forms.DataGridView();
            this.lbl_dateFrom = new System.Windows.Forms.Label();
            this.lbl_dateTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_countSales = new System.Windows.Forms.Label();
            this.lbl_salesTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_sales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgr_sales
            // 
            this.dgr_sales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgr_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_sales.Location = new System.Drawing.Point(192, 168);
            this.dgr_sales.Name = "dgr_sales";
            this.dgr_sales.Size = new System.Drawing.Size(410, 491);
            this.dgr_sales.TabIndex = 6;
            // 
            // lbl_dateFrom
            // 
            this.lbl_dateFrom.AutoSize = true;
            this.lbl_dateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dateFrom.Location = new System.Drawing.Point(185, 56);
            this.lbl_dateFrom.Name = "lbl_dateFrom";
            this.lbl_dateFrom.Size = new System.Drawing.Size(191, 39);
            this.lbl_dateFrom.TabIndex = 8;
            this.lbl_dateFrom.Text = "2020-07-12";
            // 
            // lbl_dateTo
            // 
            this.lbl_dateTo.AutoSize = true;
            this.lbl_dateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dateTo.Location = new System.Drawing.Point(422, 56);
            this.lbl_dateTo.Name = "lbl_dateTo";
            this.lbl_dateTo.Size = new System.Drawing.Size(191, 39);
            this.lbl_dateTo.TabIndex = 9;
            this.lbl_dateTo.Text = "2020-07-12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(386, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 39);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sales Period";
            // 
            // lbl_countSales
            // 
            this.lbl_countSales.AutoSize = true;
            this.lbl_countSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_countSales.Location = new System.Drawing.Point(336, 134);
            this.lbl_countSales.Name = "lbl_countSales";
            this.lbl_countSales.Size = new System.Drawing.Size(105, 31);
            this.lbl_countSales.TabIndex = 13;
            this.lbl_countSales.Text = "Orders:";
            // 
            // lbl_salesTotal
            // 
            this.lbl_salesTotal.AutoSize = true;
            this.lbl_salesTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_salesTotal.Location = new System.Drawing.Point(313, 103);
            this.lbl_salesTotal.Name = "lbl_salesTotal";
            this.lbl_salesTotal.Size = new System.Drawing.Size(165, 31);
            this.lbl_salesTotal.TabIndex = 12;
            this.lbl_salesTotal.Text = "Sales Total: ";
            // 
            // SalesPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 675);
            this.Controls.Add(this.lbl_countSales);
            this.Controls.Add(this.lbl_salesTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_dateTo);
            this.Controls.Add(this.lbl_dateFrom);
            this.Controls.Add(this.dgr_sales);
            this.Name = "SalesPrint";
            this.Text = "SalesPrint";
            ((System.ComponentModel.ISupportInitialize)(this.dgr_sales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgr_sales;
        private System.Windows.Forms.Label lbl_dateFrom;
        private System.Windows.Forms.Label lbl_dateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_countSales;
        private System.Windows.Forms.Label lbl_salesTotal;
    }
}