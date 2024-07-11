using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _169_Pamittan_PaulaHewlett_Inv
{
    public partial class frmRecordMgmt : Form
    {

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\169_Pamittan_PaulaHewlett_SC\\169_Pamittan_AppDB2\\dbSchoolSupplies.accdb");

        public frmRecordMgmt()
        {
            InitializeComponent();
        }

        private void frmRecordMgmt_Load(object sender, EventArgs e)
        {
            search("SELECT Product.* FROM Product");
        }

        void search(string _query)
        {
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            grdProducts2.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Product(productID, productName, quantity, price) VALUES('"+ txtProdID.Text+"', '"+txtProdName.Text+"', "+txtQuantity.Text+", "+txtPrice.Text+")";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT Product.* FROM Product");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE Product SET productName = '" + txtProdName.Text + "', quantity = '" + txtQuantity.Text + "', price = '" + txtPrice.Text + "' WHERE productID = '" + txtProdID.Text + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT Product.* FROM Product");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Product WHERE productName = '" + txtProdName.Text + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT Product.* FROM Product");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("SELECT Product.* FROM Product WHERE(((Product.productName) = '" + txtProdName.Text + "'));");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPrice.Clear();
            txtProdID.Clear();
            txtProdName.Clear();
            txtQuantity.Clear();

            search("SELECT Product.* FROM Product");
        }
    }
}
