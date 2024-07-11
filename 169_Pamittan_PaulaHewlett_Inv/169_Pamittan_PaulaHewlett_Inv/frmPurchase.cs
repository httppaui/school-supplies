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
    public partial class frmPurchase : Form
    {

        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Z:\\169_Pamittan_PaulaHewlett_SC\\169_Pamittan_AppDB2\\dbSchoolSupplies.accdb");

        string idx;
        string quan;
        string price;
        


        public frmPurchase(string _idx, string _price, string _quan)
        {
            InitializeComponent();
            idx = _idx;
            quan = _quan;
            price = _price;
         
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            lblProdName.Text = "Product Name: " + idx;
            lblPrice.Text = "Product Price: " + price;
            lblQuantity.Text = "Quantity: " + quan;
            lblTotal.Text = "Total Price: " + (Int32.Parse(quan) * Int32.Parse(price));

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Customer(customerID, firstname, lastname) VALUES('"+txtID.Text+"','" + txtFName.Text + "', '" + txtLName.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Purchase Complete!");
        }

        //void update(string _query)
    }
}
