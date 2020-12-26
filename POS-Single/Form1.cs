using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using POS_Single.Properties;
using System.Data.SqlClient;
using System.Data;

namespace POS_Single
{
    public partial class Form1 : Form
    {
        Dictionary<int, Item> allItems = new Dictionary<int, Item>();
        List<Item> newOrderItems = new List<Item>();
        List<Item> orderedItems = new List<Item>();
        List<int> transactionIds = new List<int>();
        DataTable sales = new DataTable();
        DataTable inventory = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_startCustomer_Click(object sender, EventArgs e)
        {
            //Switch panel to customerHome panel
            pnl_login.Visible = false;
            pnl_customerHome.Visible = true;
        }

        private void Btn_startEmployee_Click(object sender, EventArgs e)
        {
            //Check database and update allItems List
            updateItems();

            //Switch panel to employeeHome panel
            pnl_login.Visible = false;
            pnl_employeeHome.Visible = true;
        }

        private void Btn_customerNewOrder_Click(object sender, EventArgs e)
        {
            //Check database and update allItems list
            updateItems();

            //Only add items to their respective tab if their available attribute is set to true
            //  (the for-each)
            updateTabs();

            //Switch panel to newOrder panel
            pnl_customerHome.Visible = false;
            pnl_newOrder.Visible = true;
        }

        private void checkDescription(String description)
        {
            System.Windows.Forms.MessageBox.Show(description);
        }

        private void addItemToOrder(Item item)
        {           
            newOrderItems.Add(item);
            updateOrder();
        }

        private void removeItemFromOrder(Item item)
        {
            int index = newOrderItems.IndexOf(item);
            newOrderItems.RemoveAt(index);

            updateOrder();
        }

        private void updateOrder()
        {
            pnl_order.Controls.Clear();

            foreach (Item item in newOrderItems)
            {
                int groupBoxWidth = 500;
                int groupBoxHeight = 160;

                GroupBox groupBox = new GroupBox();
                groupBox.Size = new Size(groupBoxWidth, groupBoxHeight);
                int count = pnl_order.Controls.Count;

                groupBox.Location = new Point(20, count * (groupBoxHeight + 20)); //dynamic location + padding 

                PictureBox thumbnail = new PictureBox();
                thumbnail.Image = item.getThumbnail();
                int imageSize = (int)(groupBoxHeight * .7);
                thumbnail.Size = new Size(imageSize, imageSize);
                thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;

                thumbnail.Location = new Point(10, (groupBoxHeight / 2) - (imageSize / 2));
                groupBox.Controls.Add(thumbnail);

                float labelSizeName = 12;
                Label name = new Label();
                name.Font = new Font(FontFamily.GenericSansSerif, labelSizeName);
                name.Text = item.getName();

                name.Location = new Point((groupBoxWidth / 2)-100, (groupBoxHeight / 2) - (int)(labelSizeName / 2));
                groupBox.Controls.Add(name);

                float labelSizePrice = 10;
                Label price = new Label();
                price.Font = new Font(FontFamily.GenericSansSerif, labelSizePrice);
                price.Text = "$" + item.getPrice().ToString() + ".00";

                price.Location = new Point(groupBoxWidth / 2, (groupBoxHeight / 2) - (int)(labelSizePrice / 2));
                groupBox.Controls.Add(price);

                int buttonSizeY = 100;
                Button btn_cancel = new Button();
                btn_cancel.Size = new Size(130, buttonSizeY);
                btn_cancel.Click += (sender2, e2) => removeItemFromOrder(item);
                btn_cancel.Text = "Cancel";

                btn_cancel.Location = new Point((int)(groupBoxWidth * .7), (groupBoxHeight / 2) - (buttonSizeY / 2));
                groupBox.Controls.Add(btn_cancel);

                pnl_order.Controls.Add(groupBox);
            }
        }

        void updateTabs()
        {
            tab_drinks.Controls.Clear();
            tab_Food.Controls.Clear();
            tab_dessert.Controls.Clear();
            foreach (Item item in allItems.Values)
            {
                int groupSize = 175;

                if (!item.getAvailable() || !item.getToggled())
                {
                    continue;
                }
                GroupBox groupBox = new GroupBox();
                groupBox.Size = new Size(groupSize, groupSize);

                PictureBox thumbnail = new PictureBox();
                thumbnail.Image = item.getThumbnail();
                int imageSize = (int)(groupSize * .7);
                thumbnail.Size = new Size(imageSize, imageSize);
                thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;

                int buttonWidth = (int)(groupSize * .5) - 10;
                int buttonHeight = (int)(groupSize * .3) - 15;
                Button btn_getDescription = new Button();
                btn_getDescription.Size = new Size(buttonWidth, buttonHeight);
                btn_getDescription.Click += (sender2, e2) => checkDescription(item.getDescription());
                btn_getDescription.Text = "Description";

                Button btn_order = new Button();
                btn_order.Size = new Size(buttonWidth, buttonHeight);
                btn_order.Click += (sender2, e2) => addItemToOrder(item);
                btn_order.Text = "Order";

                thumbnail.Location = new Point((int)(groupSize * .5) - ((int)(imageSize * .5)), 10);
                groupBox.Controls.Add(thumbnail);
                btn_getDescription.Location = new Point(5, groupSize - buttonHeight - 5);
                btn_order.Location = new Point(5 + buttonWidth + 5, groupSize - buttonHeight - 5);
                groupBox.Controls.Add(btn_getDescription);
                groupBox.Controls.Add(btn_order);

                switch (item.getCategory())
                {
                    case 1:
                        //3x3
                        int itemNo = tab_drinks.Controls.Count;
                        int y = 0;
                        while (itemNo > 2)
                        {
                            itemNo -= 3;
                            y++;
                        };
                        groupBox.Location = new Point((itemNo * (groupSize + 25)), y * (groupSize + 25));
                        tab_drinks.Controls.Add(groupBox);
                        break;
                    case 2:
                        int itemNo2 = tab_Food.Controls.Count;
                        int yy = 0;
                        while (itemNo2 > 2)
                        {
                            itemNo2 -= 3;
                            yy++;
                        };
                        groupBox.Location = new Point((itemNo2 * (groupSize + 25)), yy * (groupSize + 25));
                        tab_Food.Controls.Add(groupBox);
                        break;
                    case 3:
                        int itemNo3 = tab_dessert.Controls.Count;
                        int yyy = 0;
                        while (itemNo3 > 2)
                        {
                            itemNo3 -= 3;
                            yyy++;
                        };
                        groupBox.Location = new Point((itemNo3 * (groupSize + 25)), yyy * (groupSize + 25));
                        tab_dessert.Controls.Add(groupBox);
                        break;
                    default:
                        Console.WriteLine("fu");
                        break;
                }
            }
        }

        private void Btn_customerPay_Click(object sender, EventArgs e)
        {
            //Create a modal asking if cash or card, no functionality.
            //Give total by reading the db with the transactionIds in the list
            // and += the cost of each            
            Form payment = new Form();
            int paymentSize = 300;
            payment.MaximizeBox = true;
            payment.Size = new Size(paymentSize, paymentSize);

           
            Label text = new Label();
            int labelSizeWidth = (int)(paymentSize * .5);
            int labelSizeHeight = (int)(paymentSize * .5);
            text.Font = new Font(FontFamily.GenericSansSerif, 10);
            text.AutoSize = true;
            text.Text = "Will you pay in cash or card?";
            text.Location = new Point((labelSizeWidth-100), labelSizeHeight-60);

            int buttonSize = (int)(paymentSize*.5);
            Button cash = new Button();
            cash.Location = new Point(buttonSize-110, buttonSize+20);
            cash.Text = "Cash";

            int buttonSizeCard = (int)(paymentSize * .5);
            Button card = new Button();
            card.Location = new Point(buttonSizeCard +20, buttonSizeCard + 20);
            card.Text = "Card";
            payment.Controls.Add(text);
            payment.Controls.Add(cash);
            payment.Controls.Add(card);

            payment.StartPosition = FormStartPosition.CenterParent;
            payment.ShowDialog();

            //Close session -> remove all items from orderedItems List
            // reset the transactionIds list
            transactionIds.Clear();

        }

        private void Btn_customerStartOrder_Click(object sender, EventArgs e) 
        {
            bool flag = false;
            
            updateItems();
            //Check that all items in the order are still available in the database
            foreach (Item x in newOrderItems) { 
                allItems.TryGetValue(x.getId(), out Item currentItemInAll);
                if(!currentItemInAll.getAvailable())
                {
                    //  If false, remove unavaiable items from newOrderItems List, send message saying "sorry, items unavailable, check order and try again"
                    //      and update avilableItems List
                    System.Windows.Forms.MessageBox.Show("Item " + x.getName() + " just went unavailable");
                    newOrderItems.Remove(x);
                    updateOrder();
                    updateItems();
                    updateTabs();
                    flag = true;                
                    break;                   
                }
            }
            if (!flag)
            {
                //Create a transcation in the db returning the transactionId
                //  status = 1, date should be "now"
                //SELECT * FROM transaction;
                //INSERT INTO transaction(date, transaction_id, total, status) VALUES(NOW() :: DATE, DEFAULT, 10, 1) RETURNING transaction_id; <- this on the list
                // add the transactionId to the transactionIds list
                float totalOrder = 0;
                int transaction_id = 0;
                foreach (Item x in newOrderItems)
                {
                    totalOrder += (float)x.getPrice();
                }
                string str = Properties.Settings.Default.pos_dbConnection;
                SqlConnection cnn = new SqlConnection(str);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();               
                SqlTransaction transaction;
                transaction = cnn.BeginTransaction("Check for Negative Quantity");
                cmd.Connection = cnn;
                cmd.Transaction = transaction;

                cmd.CommandText = "INSERT INTO transactions VALUES(" + totalOrder + ", 1, GETDATE())";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT MAX(transaction_id) FROM transactions";
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    transaction_id = (int)rdr.GetValue(0);
                    transactionIds.Add(transaction_id);
                }
                rdr.Close();
                //Add every item in newOrderItems to ordered_items table in db using itemId and transactionId obtained prev
                //Add y to ordered_items table INSERT INTO ordered_items(item_id, transaction_id) VALUES (y.getId(), transactionId)

                foreach (Item y in newOrderItems)
                {                  
                    orderedItems.Add(y);
                    cmd.CommandText = "INSERT INTO ordered_items(item_id,transaction_id) VALUES(" + y.getId() + "," + transaction_id + ")";
                    cmd.ExecuteNonQuery();                   
                }
                //check for negatives
                cmd.CommandText = "SELECT I.item_name, INP.quantity from items I " +
                    "INNER JOIN recipe R on R.item_id = I.item_id " +
                    "INNER JOIN recipe_ingredients_bridge RIN on RIN.recipe_id = R.recipe_id " +
                    "INNER JOIN ingredients_packs INP on INP.ingredient_id = RIN.ingredients_id " +
                    "WHERE quantity < 0";
                SqlDataReader rdr2 = cmd.ExecuteReader();
                if(rdr2.HasRows)
                {
                    string message = "The following item(s) are unavailable: \n";
                    while (rdr2.Read())
                    {
                        message += rdr2.GetValue(0).ToString() + ", please reduce item by " +rdr2.GetValue(1).ToString().Replace("-","") + "\n";
                    }
                    MessageBox.Show(message);
                    rdr2.Close();
                    transaction.Rollback();               
                }
                else
                {
                    rdr2.Close();                   
                    transaction.Commit();
                    System.Windows.Forms.MessageBox.Show("Order Acepted");
                }
                cnn.Close();

                newOrderItems.Clear();
                pnl_order.Controls.Clear();             
                //Switch panel to customerHome panel
                pnl_newOrder.Visible = false;
                pnl_customerHome.Visible = true;
            }
        }

        private void Btn_customerCancelOrder_Click(object sender, EventArgs e)
        {
            //Reset newOrderItems List
            tab_drinks.Controls.Clear();
            tab_Food.Controls.Clear();
            tab_dessert.Controls.Clear();
            newOrderItems.Clear();
            updateOrder();

            //Switch panel to customerHome panel
            pnl_newOrder.Visible = false;
            pnl_customerHome.Visible = true;
        }

        private void Btn_employeeOrders_Click(object sender, EventArgs e)
        {
            //Show all active orders in wide panels with description (showing all items in order) and a button to close the order.
            // get transactions from transactions table where status 1
            // show them as a box with transactionId with a clock showing how long the order has been active.
            //  they should have a button of "description" to know which items were ordered under this transactionId.
            //      show a modal with a list of items ordered.
            //  they should have a button to set the order as delivered/done
            //      this button should set the status of the transaction as 2 on db
            getTransactions();
            //check if we're already in this tab
            //  if true, don't do anything
            //  if false, change visibility and reset other tabs
            //      following code is for false case
            pnl_employeeOrders.AutoScroll = true;
            pnl_employeeOrders.Visible = true;
            pnl_employeeProducts.Visible = false;
            pnl_employeeStats.Visible = false;
            pnl_employeeSales.Visible = false;
            pnl_employeeInventory.Visible = false;
        }

        private void getTransactions()
        {
            pnl_employeeOrders.Controls.Clear();
            Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM transactions WHERE status = 1", cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Transaction t = new Transaction();
                t.setTransactionId((int)rdr.GetValue(0));
                t.setCreatedAt((DateTime)rdr.GetValue(3));
                transactions.Add(t.getTransactionId(), t);
            }
            rdr.Close();
            cnn.Close();

            cnn.Open();
            cmd = new SqlCommand("SELECT ordered_items.transaction_id, items.item_name FROM ordered_items LEFT JOIN items " +
                    "ON ordered_items.item_id = items.item_id " +
                    "LEFT JOIN transactions ON transactions.transaction_id = ordered_items.transaction_id " +
                    "WHERE transactions.status = 1;", cnn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int transactionId = (int)rdr.GetValue(0);
                String item = rdr.GetValue(1).ToString();
                transactions[transactionId].addItem(item);
            }
            rdr.Close();
            cnn.Close();

            displayTransactions(transactions);
        }

        private void displayTransactions(Dictionary<int, Transaction> transactions)
        {
            foreach(var item in transactions)
            {
                Transaction transaction = item.Value;
                int groupBoxWidth = 950;
                int groupBoxHeight = 160;

                GroupBox groupBox = new GroupBox();
                groupBox.Size = new Size(groupBoxWidth, groupBoxHeight);
                int count = pnl_employeeOrders.Controls.Count;
                groupBox.Location = new Point(20, count * (groupBoxHeight + 20));

                int buttonSizeY = 100;
                Button btn_complete = new Button();
                btn_complete.Size = new Size(130, buttonSizeY);
                btn_complete.Click += (sender2, e2) => orderCompleted(item.Key);
                btn_complete.Text = "Complete";
                btn_complete.Location = new Point((int)(groupBoxWidth * .7) + 130, (groupBoxHeight / 2) - (buttonSizeY / 2));

                groupBox.Controls.Add(btn_complete);


                //select all itemIds from ordered_items table where transactionId == this transactionId
                // Select name from items table for each itemId in orderedItems for this transactionId
                // Take all these elements into a list to display in your descriptionModal
                String ordered = "\n";
                foreach(String itemName in transaction.getItemList())
                {
                    ordered += itemName + "\n";
                }
                Button btn_description = new Button();
                btn_description.Size = new Size(130, buttonSizeY);
                btn_description.Click += (sender2, e2) => descriptionModal(sender2, e2, ordered);
                btn_description.Text = "Description";
                btn_description.Location = new Point((int)(groupBoxWidth * .7 - 20), (groupBoxHeight / 2) - (buttonSizeY / 2));

                groupBox.Controls.Add(btn_description);

                int labelFontSize = 12;
                Label lbl_orderID = new Label();
                lbl_orderID.Font = new Font(FontFamily.GenericSansSerif, labelFontSize);
                lbl_orderID.Text = "Order ID: " + item.Key;
                lbl_orderID.Location = new Point((int)(groupBoxWidth * .1 - 50), (groupBoxHeight / 2) - 5);

                groupBox.Controls.Add(lbl_orderID);

                Label lbl_time = new Label();
                lbl_time.Font = new Font(FontFamily.GenericSansSerif, labelFontSize);
                lbl_time.Text = "";
                lbl_time.Location = new Point((int)(groupBoxWidth * .5 - 80), (groupBoxHeight / 2) - 5);


                DateTime start = transaction.getCreatedAt();
                Timer t = new Timer();
                t.Interval = 1000;
                t.Tick += (s, e1) => tTick(s, e1, lbl_time, start);
                t.Start();

                groupBox.Controls.Add(lbl_time);

                pnl_employeeOrders.Controls.Add(groupBox);
            }
        }

        private void tTick(object sender, EventArgs e, Label label, DateTime start)
        {
            label.Text = (DateTime.Now - start).ToString("hh\\:mm\\:ss");
        }

        private void descriptionModal(object sender, EventArgs e, String orderedItems)
        {
            Form description = new Form();
            description.AutoScroll = true;
            description.StartPosition = FormStartPosition.CenterParent;
            Label items = new Label();
            items.Font = new Font(FontFamily.GenericSansSerif, 12);
            items.Size = description.Size;
            items.Text = orderedItems;
            items.TextAlign = ContentAlignment.TopCenter;
            description.Controls.Add(items);
            description.ShowDialog();
        }

        private void orderCompleted(int orderID)
        {
            //update database
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE transactions SET status = 2 WHERE transaction_id = " + orderID, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

            }
            rdr.Close();
            cnn.Close();

            //clear transactions from panel
            getTransactions();
            //updateEmployeeOrders();
        }

        private void Btn_employeeStats_Click(object sender, EventArgs e)
        {
            //Draw a graph with stats based on orders
            //SELECT items.item_name, COUNT(*) AS "Number of Orders"
            //FROM ordered_items LEFT JOIN items ON items.item_id = ordered_items.item_id
            //GROUP BY items.item_id
            Dictionary<String, int> countItems = new Dictionary<String, int>();
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM stats", cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                countItems.Add(rdr.GetValue(0).ToString(), Convert.ToInt32(rdr.GetValue(1)));
            }
            rdr.Close();
            cnn.Close();

            Chart cht_OrderedItems = new Chart();
            ChartArea chA = new ChartArea();
            cht_OrderedItems.ChartAreas.Add(chA);
            cht_OrderedItems.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            cht_OrderedItems.Dock = DockStyle.Fill;

            cht_OrderedItems.Visible = true;
            cht_OrderedItems.Location = new System.Drawing.Point(50, 50);
            cht_OrderedItems.Height = 100;
            cht_OrderedItems.Width = 100;
            cht_OrderedItems.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            cht_OrderedItems.BackColor = SystemColors.Control;
            cht_OrderedItems.Series.Add("Items");
            cht_OrderedItems.Series["Items"].BorderWidth = 3;
            cht_OrderedItems.Series["Items"].SetDefault(true);
            cht_OrderedItems.Series["Items"].Enabled = true;
            cht_OrderedItems.Series["Items"].ChartType = SeriesChartType.Bar;
            cht_OrderedItems.Series["Items"].IsValueShownAsLabel = true;

            foreach (KeyValuePair<String, int> item in countItems)
            {
                cht_OrderedItems.Series["Items"].Points.AddXY(item.Key, item.Value);
            }

            pnl_employeeStats.Controls.Add(cht_OrderedItems);
            //check if we're already in this tab
            //  if true, don't do anything
            //  if false, change visibility and reset other tabs
            //      following code is for false case
            pnl_employeeStats.Visible = true;
            pnl_employeeOrders.Visible = false;
            pnl_employeeProducts.Visible = false;
            pnl_employeeSales.Visible = false;
            pnl_employeeInventory.Visible = false;
        }

        private void Btn_employeeProducts_Click(object sender, EventArgs e)
        {
            updateItems();
            pnl_employeeProducts.AutoScroll = true;
            pnl_employeeProducts.Controls.Clear();
            //Show all items, unavailable items need a sign.
            if(pnl_employeeProducts.Controls.Count == 0)
            {
                foreach (Item item in allItems.Values)
                {
                    int groupSize = 175;

                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(groupSize, groupSize);

                    CheckBox thumbnailBox = new CheckBox();
                    thumbnailBox.Appearance = Appearance.Button;
                    thumbnailBox.BackgroundImage = item.getThumbnail();
                    thumbnailBox.BackgroundImageLayout = ImageLayout.Stretch;
                    if (item.getAvailable() == false || item.getToggled() == false)
                    {
                        thumbnailBox.BackColor = Color.Red;
                    }
                    else
                    {
                        thumbnailBox.BackColor = SystemColors.Control;
                    }
                    int imageSize = (int)(groupSize * .8);
                    thumbnailBox.Size = new Size(imageSize, imageSize);
                    thumbnailBox.Click += (sender3, e3) => toggledItem(sender3, e3, item);


                    thumbnailBox.Location = new Point((int)(groupSize * .5) - ((int)(imageSize * .5)), 20);
                    groupBox.Controls.Add(thumbnailBox);

                    int itemNo = pnl_employeeProducts.Controls.Count;
                    int y = 0;
                    while (itemNo > 4)
                    {
                        itemNo -= 5;
                        y++;
                    }
                    groupBox.Location = new Point((itemNo * (groupSize + 25)), y * (groupSize + 25));
                    pnl_employeeProducts.Controls.Add(groupBox);
                }         
            }

            //check if we're already in this tab
            //  if true, don't do anything
            //  if false, change visibility and reset other tabs
            //      following code is for false case
            pnl_employeeProducts.Visible = true;
            pnl_employeeOrders.Visible = false;
            pnl_employeeStats.Visible = false;
            pnl_employeeSales.Visible = false;
            pnl_employeeInventory.Visible = false;
        }

        private void toggledItem(object sender, EventArgs e, Item itemToggled)
        {
            string str = Properties.Settings.Default.pos_dbConnection;
            bool turnON = false;
            SqlConnection cnn = new SqlConnection(str);
            if (((CheckBox)sender).BackColor == Color.Red)
            {            
                //check if qty
                cnn.Open();
                /////////////////////////////////////////////////////////////FUNCTION HERE///////////////////////////////////////////////////////////////
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.toggled_and_available(@ITEM_ID)", cnn);
                cmd.Parameters.AddWithValue("@ITEM_ID", itemToggled.getId());
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if(Convert.ToInt32(rdr.GetValue(0)) == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Item is missing an ingredient, check inventory.");
                    }
                    else
                    {
                        turnON = true;
                    }
                }    
                rdr.Close();               
                if (turnON)
                {
                    ((CheckBox)sender).BackColor = SystemColors.Control;
                    cmd = new SqlCommand("UPDATE items SET toggled = 1 WHERE item_id =" + itemToggled.getId(), cnn);
                    cmd.ExecuteNonQuery();
                }
                cnn.Close();
            }
            else
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE items SET toggled = 0 WHERE item_id =" + itemToggled.getId(), cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();

                ((CheckBox)sender).BackColor = Color.Red;
            }
        }
       
        void updateItems()
        {
            allItems.Clear();
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM items ORDER BY item_id", cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                object[] values = new object[7];
                rdr.GetValues(values);
                int category = (int)rdr.GetValue(0);
                int itemId = (int)rdr.GetValue(1);
                String filename = (String)rdr.GetValue(3);
                ResourceManager rm = Resources.ResourceManager;
                Image thumbnail = (Image)rm.GetObject(filename);
                String name = (String)rdr.GetValue(2);
                String description = (String)rdr.GetValue(5);
                int price = (int)rdr.GetValue(4);
                Boolean available = (Boolean)rdr.GetValue(6);
                Boolean toggled = (Boolean)rdr.GetValue(7);

                Item newItem = new Item(category, itemId, thumbnail, name, description, price, available, toggled);
                allItems.Add(itemId, newItem);
            }
            rdr.Close();
            cnn.Close();
        }       

        private void btn_sales_Click(object sender, EventArgs e)
        {
            btn_printSales.Enabled = false;
            //reset data table 
            lbl_salesTotal.Text = "Sales Total: ";
            lbl_countSales.Text = "Orders:";
            sales.Rows.Clear();
            sales.Columns.Clear();
            sales.Columns.Add("Transaction date").ReadOnly = true;
            sales.Columns.Add("Transaction ID").ReadOnly = true;
            sales.Columns.Add("Total").ReadOnly = true;
            dgr_sales.DataSource = sales;
            pnl_employeeSales.Visible = true;
            pnl_employeeProducts.Visible = false;
            pnl_employeeOrders.Visible = false;
            pnl_employeeStats.Visible = false;
            pnl_employeeInventory.Visible = false;
        }
         
        private void btn_send_Click(object sender, EventArgs e)
        {
            btn_printSales.Enabled = true;
            //reset labels and totals
            lbl_salesTotal.Text = "Sales Total: ";
            lbl_countSales.Text = "Orders: ";
            int totalSales = 0;
            int totalCount = 0;
            //pull dates and format
            DateTime dateFROM = dte_from.Value;
            string stringDateFromdateFROM = dateFROM.ToString("yyyy/MM/dd");
            DateTime dateTO = dte_to.Value;
            string stringDateFromdateTO = dateTO.ToString("yyyy/MM/dd");
            /////////////////////////////////////////////////////////////STORED PROCEDURE HERE///////////////////////////////////////////////////////////////
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(
                "salesTotal", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(
            new SqlParameter("@DATEFROM", stringDateFromdateFROM));
            cmd.Parameters.Add(
            new SqlParameter("@DATETO", stringDateFromdateTO));
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DataRow row = sales.NewRow();
                row["Transaction date"] = rdr.GetValue(0).ToString();
                row["Transaction ID"] = rdr.GetValue(1).ToString();
                row["Total"] = "$ "+rdr.GetValue(2).ToString();                
                totalCount = (int)rdr.GetValue(3);
                totalSales = (int)rdr.GetValue(4);
                sales.Rows.Add(row);
            }
            rdr.Close();           
            cnn.Close();
            lbl_salesTotal.Text += "$" +totalSales.ToString();
            lbl_countSales.Text += " " + totalCount.ToString();
        }

        private void btn_printSales_Click(object sender, EventArgs e)
        {
            DateTime dateFROM = dte_from.Value;
            string stringDateFromdateFROM = dateFROM.ToString("yyyy/MM/dd");
            DateTime dateTO = dte_to.Value;
            string stringDateFromdateTO = dateTO.ToString("yyyy/MM/dd");
            SalesPrint salesPrint = new SalesPrint(stringDateFromdateFROM, stringDateFromdateTO);
            salesPrint.Show();           
        }

        private void btn_inventory_Click(object sender, EventArgs e)
        {
            btn_add.Enabled = false;

            createInventory();

            pnl_employeeInventory.Visible = true;
            pnl_employeeProducts.Visible = false;
            pnl_employeeOrders.Visible = false;
            pnl_employeeStats.Visible = false;
            pnl_employeeSales.Visible = false;
        }

        public void createInventory()
        {
            //reset data table 
            inventory.Rows.Clear();
            inventory.Columns.Clear();
            inventory.Columns.Add("Ingredient").ReadOnly = true;
            inventory.Columns.Add("Quantity").ReadOnly = true;

            //feed dgr
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ingredient_name_and_quantity()", cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DataRow row = inventory.NewRow();
                row["Ingredient"] = rdr.GetValue(0).ToString();
                cbx_ingredient.Items.Add(rdr.GetValue(0).ToString());
                row["Quantity"] = rdr.GetValue(1).ToString();
                inventory.Rows.Add(row);
            }
            dgr_inventory.DataSource = inventory;
            rdr.Close();
            cnn.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(num_quantity.Value > 0)
            {
                string str = Properties.Settings.Default.pos_dbConnection;
                SqlConnection cnn = new SqlConnection(str);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(
                "addIngredients", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                new SqlParameter("@QTY", num_quantity.Value));
                cmd.Parameters.Add(
                new SqlParameter("@NAME", cbx_ingredient.SelectedItem.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                cnn.Close();
                System.Windows.Forms.MessageBox.Show("Ingredients Succesfully Added");
                createInventory();
            }
        }

        private void Btn_employeeExit_Click(object sender, EventArgs e)
        {
            // Exit employee mode -> switch panel to login panel
            pnl_employeeHome.Visible = false;
            pnl_login.Visible = true;
        }

        private void cbx_ingredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_add.Enabled = true;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            OrderPrint orderPrint = new OrderPrint();
            orderPrint.Show();
        }
    }
}
