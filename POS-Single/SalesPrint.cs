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
    public partial class SalesPrint : Form
    {
        public SalesPrint(string from, string to)
        {
            InitializeComponent();
            lbl_dateFrom.Text = from;
            lbl_dateTo.Text = to;           
            fillData(from, to);
        }

        DataTable sales = new DataTable();

        public void fillData(string from, string to)
        {
            sales.Columns.Add("Transaction date").ReadOnly = true;
            sales.Columns.Add("Transaction ID").ReadOnly = true;
            sales.Columns.Add("Total").ReadOnly = true;
            dgr_sales.DataSource = sales;
            lbl_salesTotal.Text = "Sales Total: ";
            lbl_countSales.Text = "Orders: ";
            int totalSales = 0;
            int totalCount = 0;
            /////////////////////////////////////////////////////////////STORED PROCEDURE HERE///////////////////////////////////////////////////////////////
            string str = Properties.Settings.Default.pos_dbConnection;
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(
                "salesTotal", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(
            new SqlParameter("@DATEFROM", from));
            cmd.Parameters.Add(
            new SqlParameter("@DATETO", to));
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DataRow row = sales.NewRow();
                row["Transaction date"] = rdr.GetValue(0).ToString();
                row["Transaction ID"] = rdr.GetValue(1).ToString();
                row["Total"] = "$ " + rdr.GetValue(2).ToString();
                totalCount = (int)rdr.GetValue(3);
                totalSales = (int)rdr.GetValue(4);
                sales.Rows.Add(row);
            }
            rdr.Close();
            cnn.Close();
            lbl_salesTotal.Text += "$" + totalSales.ToString();
            lbl_countSales.Text += " " + totalCount.ToString();
        }
    }
}
