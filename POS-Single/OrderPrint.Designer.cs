namespace POS_Single
{
    partial class OrderPrint
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
            this.dgr_butcher = new System.Windows.Forms.DataGridView();
            this.dgr_bakery = new System.Windows.Forms.DataGridView();
            this.dgr_generalStore = new System.Windows.Forms.DataGridView();
            this.lbl_butcher = new System.Windows.Forms.Label();
            this.lbl_bakery = new System.Windows.Forms.Label();
            this.lbl_generalStore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_butcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_bakery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_generalStore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgr_butcher
            // 
            this.dgr_butcher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgr_butcher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_butcher.Location = new System.Drawing.Point(12, 130);
            this.dgr_butcher.Name = "dgr_butcher";
            this.dgr_butcher.Size = new System.Drawing.Size(226, 413);
            this.dgr_butcher.TabIndex = 8;
            this.dgr_butcher.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgr_butcher_CellFormatting);
            // 
            // dgr_bakery
            // 
            this.dgr_bakery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgr_bakery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_bakery.Location = new System.Drawing.Point(283, 130);
            this.dgr_bakery.Name = "dgr_bakery";
            this.dgr_bakery.Size = new System.Drawing.Size(226, 415);
            this.dgr_bakery.TabIndex = 9;
            this.dgr_bakery.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgr_bakery_CellFormatting);
            // 
            // dgr_generalStore
            // 
            this.dgr_generalStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgr_generalStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_generalStore.Location = new System.Drawing.Point(553, 130);
            this.dgr_generalStore.Name = "dgr_generalStore";
            this.dgr_generalStore.Size = new System.Drawing.Size(226, 415);
            this.dgr_generalStore.TabIndex = 10;
            this.dgr_generalStore.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgr_generalStore_CellFormatting);
            // 
            // lbl_butcher
            // 
            this.lbl_butcher.AutoSize = true;
            this.lbl_butcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_butcher.Location = new System.Drawing.Point(12, 84);
            this.lbl_butcher.Name = "lbl_butcher";
            this.lbl_butcher.Size = new System.Drawing.Size(228, 31);
            this.lbl_butcher.TabIndex = 13;
            this.lbl_butcher.Text = "Butchery Supplier";
            // 
            // lbl_bakery
            // 
            this.lbl_bakery.AutoSize = true;
            this.lbl_bakery.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bakery.Location = new System.Drawing.Point(296, 84);
            this.lbl_bakery.Name = "lbl_bakery";
            this.lbl_bakery.Size = new System.Drawing.Size(205, 31);
            this.lbl_bakery.TabIndex = 14;
            this.lbl_bakery.Text = "Bakery Supplier";
            // 
            // lbl_generalStore
            // 
            this.lbl_generalStore.AutoSize = true;
            this.lbl_generalStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_generalStore.Location = new System.Drawing.Point(573, 84);
            this.lbl_generalStore.Name = "lbl_generalStore";
            this.lbl_generalStore.Size = new System.Drawing.Size(182, 31);
            this.lbl_generalStore.TabIndex = 15;
            this.lbl_generalStore.Text = "General Store";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ingredients Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "*Ingredients in red must be purchased soon";
            // 
            // OrderPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_generalStore);
            this.Controls.Add(this.lbl_bakery);
            this.Controls.Add(this.lbl_butcher);
            this.Controls.Add(this.dgr_generalStore);
            this.Controls.Add(this.dgr_bakery);
            this.Controls.Add(this.dgr_butcher);
            this.Name = "OrderPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderPrint";
            ((System.ComponentModel.ISupportInitialize)(this.dgr_butcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_bakery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_generalStore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgr_butcher;
        private System.Windows.Forms.DataGridView dgr_bakery;
        private System.Windows.Forms.DataGridView dgr_generalStore;
        private System.Windows.Forms.Label lbl_butcher;
        private System.Windows.Forms.Label lbl_bakery;
        private System.Windows.Forms.Label lbl_generalStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}