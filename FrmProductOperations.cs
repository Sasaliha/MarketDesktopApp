using _02.MarketDesktopApp.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace _02.MarketDesktopApp
{
    public partial class FrmProductOperations : Form
    {
        string connectionString = Connection.ConnectionString;
        SqlConnection connection;
        public FrmProductOperations()
        {
            InitializeComponent();
            connection = new(connectionString);

        }

        private void FrmProductOperations_Load(object sender, EventArgs e)
        {

            GetAllProdut();

        }

        public void GetAllProdut()
        {
            try
            {


                dgProducts.Rows.Clear();
                connection.Open();
                string query = "Select * from Products as p left join ProductStocks as ps on p.Id=ps.ProductId Order By p.Id";
                SqlCommand cmd = new(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgProducts.Rows.Add();
                    int count = dgProducts.RowCount - 1;

                    dgProducts.Rows[count].Cells["Count"].Value = reader["Id"];
                    dgProducts.Rows[count].Cells["PId"].Value = reader["Id"];
                    dgProducts.Rows[count].Cells["PName"].Value = reader["Name"];
                    dgProducts.Rows[count].Cells["Price"].Value = reader["Price"];
                    dgProducts.Rows[count].Cells["Stock"].Value = reader["StockAmount"];


                }

                connection.Close();

            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {



                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPrice.Text) && !string.IsNullOrEmpty(txtStockAmount.Text))
                {
                    if (decimal.TryParse(txtPrice.Text, out decimal price) && int.TryParse(txtStockAmount.Text, out int stock))
                    {
                        string name = txtName.Text;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
                            string stockQuery = "INSERT INTO ProductStocks (ProductId, StockAmount) VALUES (@ProductId, @StockAmount)";

                            string maxIdQuery = "SELECT MAX(Id) FROM Products"; // maxIdQuery sorgusunu düzelttik

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            using (SqlCommand cmd1 = new SqlCommand(stockQuery, connection))
                            using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, connection)) // maxIdQuery için SqlCommand ekledik
                            {
                                cmd.Parameters.AddWithValue("@Name", name);
                                cmd.Parameters.AddWithValue("@Price", price);

                                int productId = (int)(maxIdCmd.ExecuteScalar() ?? 0) + 1; // en büyük Id değerini alarak +1 ekleyip yeni ProductId belirliyoruz

                                cmd1.Parameters.AddWithValue("@ProductId", productId);

                                cmd1.Parameters.AddWithValue("@StockAmount", stock);

                                cmd.ExecuteNonQuery();
                                cmd1.ExecuteNonQuery();
                                connection.Close();
                            }


                        }

                        MessageBox.Show("Product saved successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Text = "";
                        txtPrice.Text = "0";
                        txtStockAmount.Text = "0";
                        txtName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Price and Stock Amount must be numeric values!");
                    }
                }
                else
                {
                    MessageBox.Show("Value cannot be null!");
                }
            }
            catch
            {

            }
        }




        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgProducts.Rows.Clear();
            GetAllProdut();

        }

        private void dgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (dgProducts.Columns[e.ColumnIndex].Name == "BtnEdit")
                {
                    int id = Convert.ToInt32(dgProducts.CurrentRow.Cells["PId"].Value);

                    FrmEditProduct frmEditProduct = new(this, id); //intanse üretmeden formu cagıramam parametre olarak formu da gönderdim
                    frmEditProduct.Show();


                }
                if (dgProducts.Columns[e.ColumnIndex].Name == "BtnRemove")
                {

                    if (MessageBox.Show($"Do you want remove '{dgProducts.CurrentRow.Cells["PName"].Value}' record ? ", "Remove Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgProducts.CurrentRow.Cells["PId"].Value);
                        bool Soldresult = CheckProductHasBeenSold(id);
                        if (!Soldresult) return; //daha önce satıldıysa false dönecek -- eger false ise metodu durdur


                        RemoveProductById(id);
                        dgProducts.Rows.Clear();
                        GetAllProdut();

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckProductHasBeenSold(int id)
        {
            connection.Open();
            string query = "Select * from ReceiptDetails where ProductId=@ProductId";
            SqlCommand cmd = new(query, connection);
            cmd.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("This Product cannot be deleted because it has been sold!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return false;
            }
            else
            {

                connection.Close();

                return true;
            }
        }

        private void RemoveProductById(int id)
        {


            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {


                string deleteProductStockQuery = "DELETE FROM ProductStocks WHERE ProductId = @ProductId";
                SqlCommand deleteProductStockCmd = new SqlCommand(deleteProductStockQuery, connection, transaction);
                deleteProductStockCmd.Parameters.AddWithValue("@ProductId", id);
                deleteProductStockCmd.ExecuteNonQuery();


                string deleteProductQuery = "DELETE FROM Products WHERE Id = @ProductId";
                SqlCommand deleteProductCmd = new SqlCommand(deleteProductQuery, connection, transaction);
                deleteProductCmd.Parameters.AddWithValue("@ProductId", id);
                deleteProductCmd.ExecuteNonQuery();



                transaction.Commit(); // İşlemleri onayla

                MessageBox.Show("Product and related data deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                connection.Close();
                GetAllProdut();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback(); // İşlem başarısız olursa geri al
                connection.Close();
                GetAllProdut();
            }
            finally
            {

                connection.Close();


            }


        }


        private void dgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProducts_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dgProducts.Columns[e.ColumnIndex].Name == "BtnEdit")
                {
                    dgProducts.Cursor = Cursors.Hand; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak

                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dgProducts.Columns[e.ColumnIndex].Name == "BtnRemove")
                {
                    dgProducts.Cursor = Cursors.Hand; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak

                }
            }
        }

        private void dgProducts_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)  //e.RowIndex ve e.ColumnIndex değerlerini kullanarak bir hücreye tıklanıp tıklanmadıgını kontorl eder
            {
                DataGridViewCell cell = dgProducts.Rows[e.RowIndex].Cells[e.ColumnIndex]; //tıklanan hücreyi cell degiskenine aldık
                if (dgProducts.Columns[e.ColumnIndex].Name == "BtnEdit")
                {

                    dgProducts.Cursor = Cursors.Default; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak
                }


            }



            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)  //e.RowIndex ve e.ColumnIndex değerlerini kullanarak bir hücreye tıklanıp tıklanmadıgını kontorl eder
            {
                DataGridViewCell cell = dgProducts.Rows[e.RowIndex].Cells[e.ColumnIndex]; //tıklanan hücreyi cell degiskenine aldık
                if (dgProducts.Columns[e.ColumnIndex].Name == "BtnRemove")
                {
                    dgProducts.Cursor = Cursors.Default; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak
                }
            }
        }
    }
}
