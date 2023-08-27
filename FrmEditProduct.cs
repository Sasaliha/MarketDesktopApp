using _02.MarketDesktopApp.Constants;
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

namespace _02.MarketDesktopApp
{
    public partial class FrmEditProduct : Form
    {
        int _id;
        FrmProductOperations _frmProductOperations;
        string connectinString = Connection.ConnectionString;
        SqlConnection connection;
        public FrmEditProduct(FrmProductOperations frmProductOperations, int id)
        {
            InitializeComponent();
            _id = id;
            _frmProductOperations = frmProductOperations;  //formu set ettim

            connection = new(connectinString); //connectonstringi constractor içinde atayabiliyorum

        }

        private void GetProductById()
        {
            connection.Open();

            string query = "Select Top 1 * from Products as p left join ProductStocks as ps on p.Id=ps.ProductId where p.Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", _id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtProduct.Text = reader["Name"].ToString();
                txtPrice.Text = reader["Price"].ToString();
                txtProductStock.Text = reader["StockAmount"].ToString();

            }
            connection.Close();

        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {
            GetProductById();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string value = txtPrice.Text;


            if (!string.IsNullOrEmpty(txtProduct.Text) && !string.IsNullOrEmpty(txtPrice.Text) && decimal.TryParse(txtPrice.Text, out decimal result) && !string.IsNullOrEmpty(txtProductStock.Text))
            {
                UpdateProductAndStock();

            }
            else
            {
                MessageBox.Show("Update Error! Please control your data");
            }


        }

        public void UpdateProductAndStock()
        {
            connection.Open();

            string query = "update Products Set Name=@Name, Price=@Price where Id=@Id ";
            string query1 = "update ProductStocks set ProductId=@ProductId, StockAmount=@StockAmount where ProductId=@ProductId";

            SqlCommand cmd = new(query, connection);
            SqlCommand cmd1 = new(query1, connection);

            cmd.Parameters.AddWithValue("@Id", _id);
            cmd.Parameters.AddWithValue("@Name", txtProduct.Text);
            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
            cmd1.Parameters.AddWithValue("@ProductId", _id);
            cmd1.Parameters.AddWithValue("@StockAmount", Convert.ToInt32(txtProductStock.Text));

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Update is succesfull", "Update Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);


            _frmProductOperations.GetAllProdut();
            this.Close();
        }
    }
}

