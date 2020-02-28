using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Npgsql;
using System.Windows.Forms.DataVisualization.Charting;
using POS_Single.Properties;


namespace POS_Single
{
    public partial class Form1 : Form
    {
        Dictionary<int, Item> allItems = new Dictionary<int, Item>();
        List<Item> newOrderItems = new List<Item>();
        List<Item> orderedItems = new List<Item>();
        List<int> transactionIds = new List<int>();
        String connString = "Host=" + Properties.Settings.Default.POSTGRES_HOST +
            ";Username=" + Properties.Settings.Default.POSTGRES_USER +
            ";Password=" + Properties.Settings.Default.POSTGRES_PASSWORD +
            ";Database=" + Properties.Settings.Default.POSTGRES_DB_NAME;

        
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

                if (!item.getAvailable())
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
            //Check that all items in the order are still available in the database
            updateItems();
            foreach (Item x in newOrderItems) { 
                allItems.TryGetValue(x.getId(), out Item currentItemInAll);
                if(currentItemInAll.getAvailable() == false)
                {
                    //  If false, remove unavaiable items from newOrderItems List, send message saying "sorry, items unavailable, check order and try again"
                    //      and update avilableItems List
                    System.Windows.Forms.MessageBox.Show("Item " + x.getName() + " just went unavailable");
                    Console.WriteLine("lmao");
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
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("INSERT INTO transactions(date, transaction_id, total, status, created_at) VALUES(NOW() :: DATE, DEFAULT, " + totalOrder + ", 1, NOW() :: TIMESTAMP) " +
                        "RETURNING transaction_id;", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        transaction_id = (int)reader.GetValue(0);
                        transactionIds.Add(transaction_id);
                    }
                    reader.Close();
                    conn.Close();
                }

                //Add every item in newOrderItems to ordered_items table in db using itemId and transactionId obtained prev
                //Add y to ordered_items table INSERT INTO ordered_items(item_id, transaction_id) VALUES (y.getId(), transactionId)
                using (var conn2 = new NpgsqlConnection(connString))
                {
                    foreach (Item y in newOrderItems)
                    {
                        conn2.Open();
                        orderedItems.Add(y);
                        var cmd2 = new NpgsqlCommand("INSERT INTO ordered_items(item_id,transaction_id) VALUES(" + y.getId() + "," + transaction_id + ");", conn2);
                        var reader2 = cmd2.ExecuteReader();
                        reader2.Close();
                        conn2.Close();
                    }
                }
                newOrderItems.Clear();
                pnl_order.Controls.Clear();
                //Send a message "Order accepted"
                System.Windows.Forms.MessageBox.Show("Order Acepted");
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
        }

        private void getTransactions()
        {
            pnl_employeeOrders.Controls.Clear();
            Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM transactions WHERE status = 1", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Transaction t = new Transaction();
                    t.setTransactionId((int)reader.GetValue(1));
                    t.setCreatedAt((DateTime)reader.GetValue(4));
                    transactions.Add(t.getTransactionId(), t);
                }
                reader.Close();
                conn.Close();
            }

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT ordered_items.transaction_id, items.item_name FROM ordered_items LEFT JOIN items " +
                    "ON ordered_items.item_id = items.item_id " +
                    "LEFT JOIN transactions ON transactions.transaction_id = ordered_items.transaction_id " +
                    "WHERE transactions.status = 1;", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int transactionId = (int)reader.GetValue(0);
                    String item = reader.GetValue(1).ToString();
                    transactions[transactionId].addItem(item);
                }
            }
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
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("UPDATE transactions SET status = 2 WHERE transaction_id = " + orderID, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
                reader.Close();
                conn.Close();
            }
            //clear transactions from panel
            getTransactions();
            //updateEmployeeOrders();
        }

        private void updateEmployeeOrders()
        {

        }

        private void Btn_employeeStats_Click(object sender, EventArgs e)
        {
            //Draw a graph with stats based on orders
            //  TODO: RESEARCH HOW TO DO GRAPHS IN C#
            //SELECT items.item_name, COUNT(*) AS "Number of Orders"
            //FROM ordered_items LEFT JOIN items ON items.item_id = ordered_items.item_id
            //GROUP BY items.item_id
            Dictionary<String, int> countItems = new Dictionary<String, int>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT items.item_name, COUNT(*) " +
                    "FROM ordered_items " +
                    "LEFT JOIN items ON items.item_id = ordered_items.item_id " +
                    "GROUP BY items.item_id", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countItems.Add(reader.GetValue(0).ToString(), Convert.ToInt32(reader.GetValue(1)));
                }
                reader.Close();
                conn.Close();
            }
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
        }

        private void Btn_employeeProducts_Click(object sender, EventArgs e)
        {
            pnl_employeeProducts.AutoScroll = true;
            //Show all items, unavailable items need a sign.
            foreach (Item item in allItems.Values)
            {
                int groupSize = 175;

                GroupBox groupBox = new GroupBox();
                groupBox.Size = new Size(groupSize, groupSize);

                CheckBox thumbnailBox = new CheckBox();
                thumbnailBox.Appearance = Appearance.Button;
                thumbnailBox.BackgroundImage = item.getThumbnail();
                thumbnailBox.BackgroundImageLayout = ImageLayout.Stretch;
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

            //check if we're already in this tab
            //  if true, don't do anything
            //  if false, change visibility and reset other tabs
            //      following code is for false case
            pnl_employeeProducts.Visible = true;
            pnl_employeeOrders.Visible = false;
            pnl_employeeStats.Visible = false;
        }

        private void toggledItem(object sender, EventArgs e, Item itemToggled)
        {

            if (((CheckBox)sender).Checked)
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("UPDATE items SET available = false WHERE item_id =" + itemToggled.getId(), conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    conn.Close();
                    reader.Close();
                }
                ((CheckBox)sender).BackColor = Color.Red;
            }
            else
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("UPDATE items SET available = true WHERE item_id =" + itemToggled.getId(), conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    conn.Close();
                    reader.Close();
                }
                ((CheckBox)sender).BackColor = SystemColors.Control;
            }
        }


        private void Btn_employeeExit_Click(object sender, EventArgs e)
        {
            // Exit employee mode -> switch panel to login panel
            pnl_employeeHome.Visible = false;
            pnl_login.Visible = true;
        }
        void updateItems()
        {
            allItems.Clear();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM items ORDER BY item_id", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    object[] values = new object[7];
                    reader.GetValues(values);
                    int category = (int)reader.GetValue(0);
                    int itemId = (int)reader.GetValue(1);
                    String filename = (String)reader.GetValue(3);
                    ResourceManager rm = Resources.ResourceManager;
                    Image thumbnail = (Image)rm.GetObject(filename);
                    String name = (String)reader.GetValue(2);
                    String description = (String)reader.GetValue(5);
                    int price = (int)reader.GetValue(4);
                    Boolean available = (Boolean)reader.GetValue(6);

                    Item newItem = new Item(category, itemId, thumbnail, name, description, price, available);
                    allItems.Add(itemId, newItem);
                }
                conn.Close();
                reader.Close();
            }
        }

        private void Pnl_login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Pnl_employeeHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pnl_customerHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pnl_newOrder_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
