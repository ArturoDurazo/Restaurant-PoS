using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Single
{
    public partial class Form1 : Form
    {
        Dictionary<int, Item> allItems = new Dictionary<int, Item>();
        Dictionary<int, Item> newOrderItems = new Dictionary<int, Item>();
        Dictionary<int, Item> orderedItems = new Dictionary<int, Item>();
        
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
            while(dr.Read())
            {
                int category = Integer.parse(dr[0]);
                Item newItem = new Item(category, etc);

                allItems.Add(newItem.getId(), newItem);
            }


            //Switch panel to employeeHome panel
            pnl_login.Visible = false;
            pnl_employeeHome.Visible = true;
        }

        private void Btn_customerNewOrder_Click(object sender, EventArgs e)
        {
            //Check database and update allItems list
            allItems.Clear();


            //Only add items to their respective tab if their available attribute is set to true
            //  (the for-each)
            foreach(Item item in allItems.Values)
            {
                GroupBox group = new GroupBox();

                Button btn_checkDesc = new Button();
                btn_checkDesc.Text = item.getId().ToString() + " " + item.getName();
                btn_checkDesc.Size = new Size(50, 50);
                btn_checkDesc.Click += new EventHandler(this.checkDescription);

                Button btn_orderItem = new Button();
                btn_orderItem.Text = item.getId().ToString() + " " + item.getName();
                btn_orderItem.Size = new Size(50, 50);
                btn_orderItem.Click += new EventHandler(this.addItemToOrder);

                switch (item.getCategory())
                {
                    case 1:
                        //food
                        tab_Food.Controls.Add(newButton);
                        break;
                    case 2:
                        //drinks
                        tab_drinks.Controls.Add(newButton);
                        break;
                    case 3:
                        //dessert
                        tab_dessert.Controls.Add(newButton);
                        break;
                    default:
                        Console.WriteLine("ERROR: Unexpected item category for item: " + item.getName());
                        break;
                }
            }


            //Switch panel to newOrder panel
            pnl_customerHome.Visible = false;
            pnl_newOrder.Visible = true;
        }


        private void checkDescription(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String id = btn.Text.Split(' ')[0];

            Item item = allItems[Int32.Parse(id)];

            System.Windows.Forms.MessageBox.Show(item.getDescription());
        }

        private void addItemToOrder(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String id = btn.Text.Split(' ')[0];

            Item item = allItems[Int32.Parse(id)];

            newOrderItems.Add(item.getId(), item);

        }

        private void Btn_customerPay_Click(object sender, EventArgs e)
        {
            //Create a modal asking if cash or card, no functionality.


            //Close session -> remove all items from orderedItems List





            // IGNORE THIS, IF YOU ASK ME ABOUT IT LATER ON I'LL FUCKING KILL YOU.
            /*pnl_customerHome.Visible = false;
            pnl_login.Visible = true;*/
            // IGNORE THIS, IF YOU ASK ME ABOUT IT LATER ON I'LL FUCKING KILL YOU.
        }

        private void Btn_customerStartOrder_Click(object sender, EventArgs e)
        {
            //Check that all items in the order are still available in the database
            //  If true, add all ordered items to orderedItems List
            //      and reset newOrderItems List
            //  If false, remove unavaiable items from newOrderItems List, send message saying "sorry, items unavailable, check order and try again"
            //      and update avilableItems List


            //Send a message "Order accepted"


            //Switch panel to customerHome panel
            pnl_newOrder.Visible = false;
            pnl_customerHome.Visible = true;
        }

        private void Btn_customerCancelOrder_Click(object sender, EventArgs e)
        {
            //Reset newOrderItems List


            //Switch panel to customerHome panel
            pnl_newOrder.Visible = false;
            pnl_customerHome.Visible = true;
        }

        private void Btn_employeeOrders_Click(object sender, EventArgs e)
        {
            //Show all active orders in wide panels with description (showing all items in order) and a button to close the order.


            //check if we're already in this tab
            //  if true, don't do anything
            //  if false, change visibility and reset other tabs
            //      following code is for false case
            pnl_employeeOrders.Visible = true;
            pnl_employeeProducts.Visible = false;
            pnl_employeeStats.Visible = false;
        }

        private void Btn_employeeStats_Click(object sender, EventArgs e)
        {
            //Draw a graph with stats based on orders
            //  TODO: RESEARCH HOW TO DO GRAPHS IN C#


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
            //Show all items, unavailable items need a sign.


            //check if we're already in this tab
            //  if true, don't do anything
            //  if false, change visibility and reset other tabs
            //      following code is for false case
            pnl_employeeProducts.Visible = true;
            pnl_employeeOrders.Visible = false;
            pnl_employeeStats.Visible = false;
        }

        private void Btn_employeeExit_Click(object sender, EventArgs e)
        {
            // Exit employee mode -> switch panel to login panel
            pnl_employeeHome.Visible = false;
            pnl_login.Visible = true;
        }
    }
}
