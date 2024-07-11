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
    public partial class frmMain : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\169_Pamittan_PaulaHewlett_SC\\169_Pamittan_AppDB2\\dbSchoolSupplies.accdb");

        

        Form RecForm = new frmRecordMgmt();

        public frmMain()
        {
            InitializeComponent();
        }

        void search(string _query)
        {
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            grdProducts1.DataSource = dt;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            search("SELECT Product.* FROM Product");
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            RecForm.ShowDialog();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                string name = grdProducts1.SelectedCells[1].Value.ToString();
                string price = grdProducts1.SelectedCells[3].Value.ToString();
                string quan = txtQuantity.Text;
                //string prodID = grdProducts1.SelectedCells[0].Value.ToString();


                Form PurForm = new frmPurchase(name, price, quan);
                PurForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Enter Quantity!");
            }
           
        }
    }
}
