using _02.MarketDesktopApp.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace _02.MarketDesktopApp
{
    public partial class FrmRMA : Form
    {

        string connectionString = Connection.ConnectionString;
        SqlConnection connection;

        public FrmRMA()
        {
            InitializeComponent();
            connection = new(connectionString);
        }

        private void FrmRMA_Load(object sender, EventArgs e)
        {



        }

        private void txtReceiptNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {


                connection.Open();
                dgReceipts.Rows.Clear();
                SqlCommand cmd = new SqlCommand($"Select * from Receipts where ReceiptNumber like '%{txtReceiptNumber.Text}%'", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgReceipts.Rows.Add();

                    int rowCount = dgReceipts.Rows.Count - 1;
                    dgReceipts.Rows[rowCount].Cells["Count"].Value = rowCount + 1;
                    dgReceipts.Rows[rowCount].Cells["RId"].Value = reader["Id"];
                    dgReceipts.Rows[rowCount].Cells["ReceiptNumber"].Value = reader["ReceiptNumber"];
                    dgReceipts.Rows[rowCount].Cells["Date"].Value = reader["Date"];
                    dgReceipts.Rows[rowCount].Cells["Total"].Value = reader["Total"];
                    dgReceipts.Rows[rowCount].Cells["Payment"].Value = reader["Payment"];
                    dgReceipts.Rows[rowCount].Cells["Remaining"].Value = reader["Remaining"];

                }
                connection.Close();
            }
            catch
            {

            }
        }


        private void dgReceipts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgReceipts_Click(object sender, EventArgs e)
        {
            try
            {



                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                dgReceiptDetails.Rows.Clear(); //Sürekli üzerine ekleme yapmaması için datagridmizi sıfırlıyoruz
                DataGridViewRow row = dgReceipts.CurrentRow; //secili row u elde etmem saglar


                if (row != null && !row.IsNewRow) //row boş degilse ve row yeni bir row degilse
                {
                    object value = row.Cells["ReceiptNumber"].Value;   //elde ettiğimiz receiptnumber degerini object olan bir value'ya atadık
                    String receiptNumber = value?.ToString(); //value null degilse stringe cevir diyoruz


                    SqlCommand receiptCmd = new("Select *from Receipts where ReceiptNumber=@ReceiptNumber", connection);
                    receiptCmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber);
                    SqlDataReader receiptReader = receiptCmd.ExecuteReader();    //okuma işlemini gerçekleştiriyorum



                    if (receiptReader.Read())
                    {
                        int receiptId = (int)receiptReader["Id"];
                        receiptReader.Close();
                        //receipt tablom tıkladıgında receipdetail tablomda ilgili verilerimin gelmesi için kodlarımı yazıyorum
                        SqlCommand receiptDetailsCmd = new("select p.Name as Name, rd.Quantity as Quantity, rd.Price as Price, rd.Total as Total, rd.ProductId, rd.State from ReceiptDetails as rd Left Join Products as p on rd.ProductId = p.Id where ReceiptId =@ReceiptId", connection);
                        receiptDetailsCmd.Parameters.AddWithValue("@ReceiptId", receiptId);

                        SqlDataReader receiptDetailReader = receiptDetailsCmd.ExecuteReader();

                        while (receiptDetailReader.Read())
                        {
                            dgReceiptDetails.Rows.Add();
                            int dgRDCount = dgReceiptDetails.Rows.Count - 1;

                            dgReceiptDetails.Rows[dgRDCount].Cells["RDCount"].Value = dgRDCount + 1;
                            dgReceiptDetails.Rows[dgRDCount].Cells["RDProductName"].Value = receiptDetailReader["Name"];
                            dgReceiptDetails.Rows[dgRDCount].Cells["RDQuantity"].Value = receiptDetailReader["Quantity"];
                            dgReceiptDetails.Rows[dgRDCount].Cells["RDPrice"].Value = receiptDetailReader["Price"];
                            dgReceiptDetails.Rows[dgRDCount].Cells["RDTotal"].Value = receiptDetailReader["Total"];
                            dgReceiptDetails.Rows[dgRDCount].Cells["ProductId"].Value = receiptDetailReader["ProductId"];
                            dgReceiptDetails.Rows[dgRDCount].Cells["State"].Value = receiptDetailReader["State"];

                        }
                        receiptDetailReader.Close();
                        dgReceiptDetails.ClearSelection();


                        connection.Close();
                    }



                }

            }
            catch
            {

            }


        }

        private void dgReceiptDetails_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgReceiptDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dgReceiptDetails.Columns[e.ColumnIndex].Name == "BtnReturn")
                {
                    dgReceiptDetails.Cursor = Cursors.Hand; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak

                }
            }
        }

        private void dgReceiptDetails_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)  //e.RowIndex ve e.ColumnIndex değerlerini kullanarak bir hücreye tıklanıp tıklanmadıgını kontorl eder
            {
                DataGridViewCell cell = dgReceiptDetails.Rows[e.RowIndex].Cells[e.ColumnIndex]; //tıklanan hücreyi cell degiskenine aldık
                if (dgReceiptDetails.Columns[e.ColumnIndex].Name == "BtnReturn")
                {
                    dgReceiptDetails.Cursor = Cursors.Default; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak
                }
            }
        }

        private void dgReceiptDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgReceiptDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgReceiptDetails.CurrentRow != null && dgReceiptDetails.Columns[e.ColumnIndex].Name == "BtnReturn")
            {
                string stateValue = dgReceiptDetails.Rows[e.RowIndex].Cells["State"].Value?.ToString();

                if (stateValue != "Returned")
                {
                    if (MessageBox.Show($"'{dgReceiptDetails.CurrentRow.Cells["RDProductName"].Value}' will be returned! \nDo you approve the product return process?", "Product Return", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgReceiptDetails.CurrentRow.Cells["ProductId"].Value);

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string updateStockQuery = "UPDATE ProductStocks SET StockAmount += 1 WHERE ProductId = @ProductId";
                            MessageBox.Show("Return is Succesfull");
                            using (SqlCommand cmd = new SqlCommand(updateStockQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@ProductId", id);
                                cmd.ExecuteNonQuery();
                            }

                            int receiptId = Convert.ToInt32(dgReceipts.CurrentRow.Cells["RId"].Value);
                            dgReceiptDetails.CurrentRow.Cells["State"].Value = "Returned";
                            string updateStateQuery = "UPDATE ReceiptDetails SET State=@State WHERE ReceiptId = @ReceiptId AND ProductId=@ProductId";
                            using (SqlCommand cmd1 = new SqlCommand(updateStateQuery, connection))
                            {
                                cmd1.Parameters.AddWithValue("@ReceiptId", receiptId);
                                cmd1.Parameters.AddWithValue("@ProductId", id);
                                cmd1.Parameters.AddWithValue("@State", "Returned");
                                cmd1.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This product already returned!");
                }
            }

        }

        private void dgReceiptDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgReceiptDetails.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];

                // Sütunun adını kontrol edin (örneğin "State" sütunu)
                if (dgReceiptDetails.Columns[e.ColumnIndex].Name == "State")
                {
                    // Hücredeki değeri alın
                    string cellValue = cell.Value?.ToString();

                    // Eğer hücrede "iade edildi" yazıyorsa
                    if (cellValue == "Returned")
                    {

                        // Satırın kilidini açın
                        row.ReadOnly = true;

                        row.DefaultCellStyle.BackColor = Color.LightGray; // Opsiyonel: Kilitli satırları farklı renkte göster
                    }
                    else
                    {
                        // Satırın kilidini kapatın


                        row.DefaultCellStyle.BackColor = Color.White; // Opsiyonel: Kilidi açık satırları varsayılan renkte göster
                    }
                }
            }
        }
    }
}

