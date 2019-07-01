namespace POS_Single
{
    partial class Form1
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
            this.pnl_login = new System.Windows.Forms.Panel();
            this.btn_startEmployee = new System.Windows.Forms.Button();
            this.btn_startCustomer = new System.Windows.Forms.Button();
            this.pnl_employeeHome = new System.Windows.Forms.Panel();
            this.pnl_employeeProducts = new System.Windows.Forms.Panel();
            this.pnl_employeeOrders = new System.Windows.Forms.Panel();
            this.pnl_employeeStats = new System.Windows.Forms.Panel();
            this.btn_employeeExit = new System.Windows.Forms.Button();
            this.btn_employeeProducts = new System.Windows.Forms.Button();
            this.btn_employeeStats = new System.Windows.Forms.Button();
            this.btn_employeeOrders = new System.Windows.Forms.Button();
            this.pnl_customerHome = new System.Windows.Forms.Panel();
            this.btn_customerPay = new System.Windows.Forms.Button();
            this.btn_customerNewOrder = new System.Windows.Forms.Button();
            this.lbl_customerWelcome = new System.Windows.Forms.Label();
            this.pnl_newOrder = new System.Windows.Forms.Panel();
            this.btn_customerCancelOrder = new System.Windows.Forms.Button();
            this.btn_customerStartOrder = new System.Windows.Forms.Button();
            this.pnl_order = new System.Windows.Forms.Panel();
            this.tbg_itemList = new System.Windows.Forms.TabControl();
            this.tab_drinks = new System.Windows.Forms.TabPage();
            this.tab_Food = new System.Windows.Forms.TabPage();
            this.tab_dessert = new System.Windows.Forms.TabPage();
            this.pnl_login.SuspendLayout();
            this.pnl_employeeHome.SuspendLayout();
            this.pnl_employeeOrders.SuspendLayout();
            this.pnl_customerHome.SuspendLayout();
            this.pnl_newOrder.SuspendLayout();
            this.tbg_itemList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_login
            // 
            this.pnl_login.AutoSize = true;
            this.pnl_login.Controls.Add(this.btn_startEmployee);
            this.pnl_login.Controls.Add(this.btn_startCustomer);
            this.pnl_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_login.Location = new System.Drawing.Point(0, 0);
            this.pnl_login.Name = "pnl_login";
            this.pnl_login.Size = new System.Drawing.Size(1250, 701);
            this.pnl_login.TabIndex = 0;
            // 
            // btn_startEmployee
            // 
            this.btn_startEmployee.Location = new System.Drawing.Point(614, 423);
            this.btn_startEmployee.Name = "btn_startEmployee";
            this.btn_startEmployee.Size = new System.Drawing.Size(344, 89);
            this.btn_startEmployee.TabIndex = 1;
            this.btn_startEmployee.Text = "Start Employee";
            this.btn_startEmployee.UseVisualStyleBackColor = true;
            this.btn_startEmployee.Click += new System.EventHandler(this.Btn_startEmployee_Click);
            // 
            // btn_startCustomer
            // 
            this.btn_startCustomer.Location = new System.Drawing.Point(164, 423);
            this.btn_startCustomer.Name = "btn_startCustomer";
            this.btn_startCustomer.Size = new System.Drawing.Size(344, 89);
            this.btn_startCustomer.TabIndex = 0;
            this.btn_startCustomer.Text = "Start Customer";
            this.btn_startCustomer.UseVisualStyleBackColor = true;
            this.btn_startCustomer.Click += new System.EventHandler(this.Btn_startCustomer_Click);
            // 
            // pnl_employeeHome
            // 
            this.pnl_employeeHome.Controls.Add(this.pnl_employeeProducts);
            this.pnl_employeeHome.Controls.Add(this.pnl_employeeOrders);
            this.pnl_employeeHome.Controls.Add(this.btn_employeeExit);
            this.pnl_employeeHome.Controls.Add(this.btn_employeeProducts);
            this.pnl_employeeHome.Controls.Add(this.btn_employeeStats);
            this.pnl_employeeHome.Controls.Add(this.btn_employeeOrders);
            this.pnl_employeeHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_employeeHome.Location = new System.Drawing.Point(0, 0);
            this.pnl_employeeHome.Name = "pnl_employeeHome";
            this.pnl_employeeHome.Size = new System.Drawing.Size(1250, 701);
            this.pnl_employeeHome.TabIndex = 1;
            this.pnl_employeeHome.Visible = false;
            // 
            // pnl_employeeProducts
            // 
            this.pnl_employeeProducts.Location = new System.Drawing.Point(221, 12);
            this.pnl_employeeProducts.Name = "pnl_employeeProducts";
            this.pnl_employeeProducts.Size = new System.Drawing.Size(1017, 677);
            this.pnl_employeeProducts.TabIndex = 6;
            this.pnl_employeeProducts.Visible = false;
            // 
            // pnl_employeeOrders
            // 
            this.pnl_employeeOrders.Controls.Add(this.pnl_employeeStats);
            this.pnl_employeeOrders.Location = new System.Drawing.Point(221, 12);
            this.pnl_employeeOrders.Name = "pnl_employeeOrders";
            this.pnl_employeeOrders.Size = new System.Drawing.Size(1017, 677);
            this.pnl_employeeOrders.TabIndex = 4;
            // 
            // pnl_employeeStats
            // 
            this.pnl_employeeStats.Location = new System.Drawing.Point(0, 0);
            this.pnl_employeeStats.Name = "pnl_employeeStats";
            this.pnl_employeeStats.Size = new System.Drawing.Size(1017, 677);
            this.pnl_employeeStats.TabIndex = 5;
            this.pnl_employeeStats.Visible = false;
            // 
            // btn_employeeExit
            // 
            this.btn_employeeExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employeeExit.Location = new System.Drawing.Point(12, 544);
            this.btn_employeeExit.Name = "btn_employeeExit";
            this.btn_employeeExit.Size = new System.Drawing.Size(203, 106);
            this.btn_employeeExit.TabIndex = 3;
            this.btn_employeeExit.Text = "EXIT";
            this.btn_employeeExit.UseVisualStyleBackColor = true;
            this.btn_employeeExit.Click += new System.EventHandler(this.Btn_employeeExit_Click);
            // 
            // btn_employeeProducts
            // 
            this.btn_employeeProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employeeProducts.Location = new System.Drawing.Point(12, 384);
            this.btn_employeeProducts.Name = "btn_employeeProducts";
            this.btn_employeeProducts.Size = new System.Drawing.Size(203, 106);
            this.btn_employeeProducts.TabIndex = 2;
            this.btn_employeeProducts.Text = "PRODUCTS";
            this.btn_employeeProducts.UseVisualStyleBackColor = true;
            this.btn_employeeProducts.Click += new System.EventHandler(this.Btn_employeeProducts_Click);
            // 
            // btn_employeeStats
            // 
            this.btn_employeeStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employeeStats.Location = new System.Drawing.Point(12, 226);
            this.btn_employeeStats.Name = "btn_employeeStats";
            this.btn_employeeStats.Size = new System.Drawing.Size(203, 106);
            this.btn_employeeStats.TabIndex = 1;
            this.btn_employeeStats.Text = "STATS";
            this.btn_employeeStats.UseVisualStyleBackColor = true;
            this.btn_employeeStats.Click += new System.EventHandler(this.Btn_employeeStats_Click);
            // 
            // btn_employeeOrders
            // 
            this.btn_employeeOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employeeOrders.Location = new System.Drawing.Point(12, 57);
            this.btn_employeeOrders.Name = "btn_employeeOrders";
            this.btn_employeeOrders.Size = new System.Drawing.Size(203, 106);
            this.btn_employeeOrders.TabIndex = 0;
            this.btn_employeeOrders.Text = "ORDERS";
            this.btn_employeeOrders.UseVisualStyleBackColor = true;
            this.btn_employeeOrders.Click += new System.EventHandler(this.Btn_employeeOrders_Click);
            // 
            // pnl_customerHome
            // 
            this.pnl_customerHome.Controls.Add(this.btn_customerPay);
            this.pnl_customerHome.Controls.Add(this.btn_customerNewOrder);
            this.pnl_customerHome.Controls.Add(this.lbl_customerWelcome);
            this.pnl_customerHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_customerHome.Location = new System.Drawing.Point(0, 0);
            this.pnl_customerHome.Name = "pnl_customerHome";
            this.pnl_customerHome.Size = new System.Drawing.Size(1250, 701);
            this.pnl_customerHome.TabIndex = 7;
            this.pnl_customerHome.Visible = false;
            // 
            // btn_customerPay
            // 
            this.btn_customerPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customerPay.Location = new System.Drawing.Point(740, 467);
            this.btn_customerPay.Name = "btn_customerPay";
            this.btn_customerPay.Size = new System.Drawing.Size(405, 183);
            this.btn_customerPay.TabIndex = 2;
            this.btn_customerPay.Text = "PAY";
            this.btn_customerPay.UseVisualStyleBackColor = true;
            this.btn_customerPay.Click += new System.EventHandler(this.Btn_customerPay_Click);
            // 
            // btn_customerNewOrder
            // 
            this.btn_customerNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customerNewOrder.Location = new System.Drawing.Point(103, 467);
            this.btn_customerNewOrder.Name = "btn_customerNewOrder";
            this.btn_customerNewOrder.Size = new System.Drawing.Size(405, 183);
            this.btn_customerNewOrder.TabIndex = 1;
            this.btn_customerNewOrder.Text = "ORDER";
            this.btn_customerNewOrder.UseVisualStyleBackColor = true;
            this.btn_customerNewOrder.Click += new System.EventHandler(this.Btn_customerNewOrder_Click);
            // 
            // lbl_customerWelcome
            // 
            this.lbl_customerWelcome.AutoSize = true;
            this.lbl_customerWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customerWelcome.Location = new System.Drawing.Point(178, 80);
            this.lbl_customerWelcome.Name = "lbl_customerWelcome";
            this.lbl_customerWelcome.Size = new System.Drawing.Size(904, 181);
            this.lbl_customerWelcome.TabIndex = 0;
            this.lbl_customerWelcome.Text = "WELCOME";
            // 
            // pnl_newOrder
            // 
            this.pnl_newOrder.Controls.Add(this.btn_customerCancelOrder);
            this.pnl_newOrder.Controls.Add(this.btn_customerStartOrder);
            this.pnl_newOrder.Controls.Add(this.pnl_order);
            this.pnl_newOrder.Controls.Add(this.tbg_itemList);
            this.pnl_newOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_newOrder.Location = new System.Drawing.Point(0, 0);
            this.pnl_newOrder.Name = "pnl_newOrder";
            this.pnl_newOrder.Size = new System.Drawing.Size(1250, 701);
            this.pnl_newOrder.TabIndex = 3;
            this.pnl_newOrder.Visible = false;
            // 
            // btn_customerCancelOrder
            // 
            this.btn_customerCancelOrder.Location = new System.Drawing.Point(450, 623);
            this.btn_customerCancelOrder.Name = "btn_customerCancelOrder";
            this.btn_customerCancelOrder.Size = new System.Drawing.Size(153, 63);
            this.btn_customerCancelOrder.TabIndex = 9;
            this.btn_customerCancelOrder.Text = "CANCEL";
            this.btn_customerCancelOrder.UseVisualStyleBackColor = true;
            this.btn_customerCancelOrder.Click += new System.EventHandler(this.Btn_customerCancelOrder_Click);
            // 
            // btn_customerStartOrder
            // 
            this.btn_customerStartOrder.Location = new System.Drawing.Point(12, 626);
            this.btn_customerStartOrder.Name = "btn_customerStartOrder";
            this.btn_customerStartOrder.Size = new System.Drawing.Size(153, 63);
            this.btn_customerStartOrder.TabIndex = 8;
            this.btn_customerStartOrder.Text = "ORDER";
            this.btn_customerStartOrder.UseVisualStyleBackColor = true;
            this.btn_customerStartOrder.Click += new System.EventHandler(this.Btn_customerStartOrder_Click);
            // 
            // pnl_order
            // 
            this.pnl_order.Location = new System.Drawing.Point(12, 15);
            this.pnl_order.Name = "pnl_order";
            this.pnl_order.Size = new System.Drawing.Size(591, 605);
            this.pnl_order.TabIndex = 7;
            // 
            // tbg_itemList
            // 
            this.tbg_itemList.Controls.Add(this.tab_drinks);
            this.tbg_itemList.Controls.Add(this.tab_Food);
            this.tbg_itemList.Controls.Add(this.tab_dessert);
            this.tbg_itemList.Location = new System.Drawing.Point(614, 15);
            this.tbg_itemList.Name = "tbg_itemList";
            this.tbg_itemList.SelectedIndex = 0;
            this.tbg_itemList.Size = new System.Drawing.Size(621, 671);
            this.tbg_itemList.TabIndex = 6;
            // 
            // tab_drinks
            // 
            this.tab_drinks.Location = new System.Drawing.Point(4, 22);
            this.tab_drinks.Name = "tab_drinks";
            this.tab_drinks.Padding = new System.Windows.Forms.Padding(3);
            this.tab_drinks.Size = new System.Drawing.Size(613, 645);
            this.tab_drinks.TabIndex = 0;
            this.tab_drinks.Text = "Drinks";
            this.tab_drinks.UseVisualStyleBackColor = true;
            // 
            // tab_Food
            // 
            this.tab_Food.Location = new System.Drawing.Point(4, 22);
            this.tab_Food.Name = "tab_Food";
            this.tab_Food.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Food.Size = new System.Drawing.Size(613, 645);
            this.tab_Food.TabIndex = 1;
            this.tab_Food.Text = "Food";
            this.tab_Food.UseVisualStyleBackColor = true;
            // 
            // tab_dessert
            // 
            this.tab_dessert.Location = new System.Drawing.Point(4, 22);
            this.tab_dessert.Name = "tab_dessert";
            this.tab_dessert.Padding = new System.Windows.Forms.Padding(3);
            this.tab_dessert.Size = new System.Drawing.Size(613, 645);
            this.tab_dessert.TabIndex = 2;
            this.tab_dessert.Text = "Dessert";
            this.tab_dessert.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 701);
            this.Controls.Add(this.pnl_login);
            this.Controls.Add(this.pnl_employeeHome);
            this.Controls.Add(this.pnl_customerHome);
            this.Controls.Add(this.pnl_newOrder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnl_login.ResumeLayout(false);
            this.pnl_employeeHome.ResumeLayout(false);
            this.pnl_employeeHome.PerformLayout();
            this.pnl_employeeOrders.ResumeLayout(false);
            this.pnl_customerHome.ResumeLayout(false);
            this.pnl_customerHome.PerformLayout();
            this.pnl_newOrder.ResumeLayout(false);
            this.tbg_itemList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_login;
        private System.Windows.Forms.Button btn_startEmployee;
        private System.Windows.Forms.Button btn_startCustomer;
        private System.Windows.Forms.Panel pnl_employeeHome;
        private System.Windows.Forms.Panel pnl_employeeOrders;
        private System.Windows.Forms.Button btn_employeeExit;
        private System.Windows.Forms.Button btn_employeeProducts;
        private System.Windows.Forms.Button btn_employeeStats;
        private System.Windows.Forms.Button btn_employeeOrders;
        private System.Windows.Forms.Panel pnl_employeeProducts;
        private System.Windows.Forms.Panel pnl_employeeStats;
        private System.Windows.Forms.Panel pnl_customerHome;
        private System.Windows.Forms.Panel pnl_newOrder;
        private System.Windows.Forms.Button btn_customerCancelOrder;
        private System.Windows.Forms.Button btn_customerStartOrder;
        private System.Windows.Forms.Panel pnl_order;
        private System.Windows.Forms.TabControl tbg_itemList;
        private System.Windows.Forms.TabPage tab_drinks;
        private System.Windows.Forms.TabPage tab_Food;
        private System.Windows.Forms.TabPage tab_dessert;
        private System.Windows.Forms.Button btn_customerPay;
        private System.Windows.Forms.Button btn_customerNewOrder;
        private System.Windows.Forms.Label lbl_customerWelcome;
    }
}

