using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Single
{
    public partial class OrderPrint : Form
    {
        DataTable butcher = new DataTable();
        DataTable bakery = new DataTable();
        DataTable generalStore = new DataTable();

        public OrderPrint()
        {
            InitializeComponent();
            fillDataGrids();
        }

        public void fillDataGrids()
        {
            //create columns
            butcher.Columns.Add("Ingredient").ReadOnly = true;
            butcher.Columns.Add("Quantity").ReadOnly = true;

            bakery.Columns.Add("Ingredient").ReadOnly = true;
            bakery.Columns.Add("Quantity").ReadOnly = true;

            generalStore.Columns.Add("Ingredient").ReadOnly = true;
            generalStore.Columns.Add("Quantity").ReadOnly = true;

            //fill rows
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT supplier_id, ingredient_name, quantity FROM ingredients_packs", cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {                     
                if ((int)rdr.GetValue(0) == 1)
                {
                    DataRow rowBakery = bakery.NewRow();
                    rowBakery["Ingredient"] = rdr.GetValue(1).ToString();
                    rowBakery["Quantity"] = rdr.GetValue(2).ToString();
                    bakery.Rows.Add(rowBakery);
                }
                else if((int)rdr.GetValue(0) == 2)
                {
                    DataRow rowButcher = butcher.NewRow();
                    rowButcher["Ingredient"] = rdr.GetValue(1).ToString();
                    rowButcher["Quantity"] = rdr.GetValue(2).ToString();
                    butcher.Rows.Add(rowButcher);
                }
                else
                {
                    DataRow rowGeneralStore = generalStore.NewRow();
                    rowGeneralStore["Ingredient"] = rdr.GetValue(1).ToString();
                    rowGeneralStore["Quantity"] = rdr.GetValue(2).ToString();
                    generalStore.Rows.Add(rowGeneralStore);
                }
            }
            rdr.Close();
            cnn.Close();

            dgr_butcher.DataSource = butcher;
            dgr_bakery.DataSource = bakery;
            dgr_generalStore.DataSource = generalStore;
        }

        private void dgr_butcher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dr in dgr_butcher.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    var temp = dr.Cells[1].Value;
                    int cellValue = Int32.Parse(temp.ToString());
                    if (cellValue <= 5)
                    {
                        dr.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void dgr_bakery_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dr in dgr_bakery.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    var temp = dr.Cells[1].Value;
                    int cellValue = Int32.Parse(temp.ToString());
                    if (cellValue <= 5)
                    {
                        dr.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void dgr_generalStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dr in dgr_generalStore.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    var temp = dr.Cells[1].Value;
                    int cellValue = Int32.Parse(temp.ToString());
                    if (cellValue <= 5)
                    {
                        dr.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
