using _02.MarketDesktopApp.Constants;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace _02.MarketDesktopApp;

public partial class MainForm : Form
{

    decimal total = 0;
    decimal remaining = 0;



    List<ReceiptDetail> receiptDetails = new List<ReceiptDetail>();
    List<ReceiptPayment> receiptPayments = new List<ReceiptPayment>();

    //path'ı olusturgumuz classtan cagırdık
    SqlConnection connection = new(Connection.ConnectionString); //connection class'ını cagırp connectionstringi aldık


    public MainForm()
    {
        InitializeComponent();
    }

    private void dgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
    {
        try
        {


            if (e.KeyChar == 13)
            {


                connection.Open();


                int id = 0;
                if (!int.TryParse(txtBarcode.Text, out id))
                {
                    MessageBox.Show("Just enter numeric values !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return;

                }

                string query = "Select TOP 1 * FROM Products where Id=" + id;
                SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["Name"].ToString();
                    var price = (decimal)reader["Price"];
                    AddShoppingCard(id, name, price);
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Product Not found! Check product control", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }



            }


        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        finally
        {
            connection.Close();
        }

    }

    private void AddShoppingCard(int id, string name, decimal price)
    {
        dgList.Rows.Add();

        int count = dgList.Rows.Count - 1;



        dgList.Rows[count].Cells["Count"].Value = count + 1; //#
        dgList.Rows[count].Cells["PId"].Value = id; //#
        dgList.Rows[count].Cells["PName"].Value = name; //Name
        dgList.Rows[count].Cells["Quantity"].Value = 1; //Quantity
        dgList.Rows[count].Cells["Price"].Value = price; //Price
        dgList.Rows[count].Cells["TotalPrice"].Value = (price * 1).ToString("#,##0.00") + "₺"; //Total Price

        txtBarcode.Text = "";

        total = 0;

        for (int i = 0; i < dgList.Rows.Count; i++)
        {
            total = total + Convert.ToDecimal(dgList.Rows[i].Cells["Quantity"].Value) * Convert.ToDecimal(dgList.Rows[i].Cells["Price"].Value);
        }


        txtTotal.Text = total.ToString();
        txtPayment.Text = total.ToString();
        lbRemaing.Text = remaining.ToString("#,##0.00") + "₺";



        ReceiptDetail receiptDetail = new()
        {
            Price = price,
            Total = price * 1,
            ProductId = id,
            ReceiptId = 1,
            Quantity = 1
        };
        receiptDetails.Add(receiptDetail);
    }



    private void btnKK_Click(object sender, EventArgs e)
    {
        try
        {

            connection.Open();

            Dictionary<int, int> dictList = new Dictionary<int, int>();

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                int value = Convert.ToInt32(dgList.Rows[i].Cells["PId"].Value);
                if (dictList.ContainsKey(value))
                {
                    dictList[value] = Convert.ToInt32(dictList[value] + 1);
                }
                else
                {
                    dictList.Add(value, 1);
                }
            }

            bool allStepsCompleted = true;


            foreach (var dicts in dictList)
            {
                int stockAmount = 0;
                string stockControlQuery = "SELECT StockAmount FROM ProductStocks WHERE ProductId=@ProductId";

                using (SqlCommand stockControlCmd = new SqlCommand(stockControlQuery, connection))
                {
                    stockControlCmd.Parameters.AddWithValue("@ProductId", dicts.Key);

                    using (SqlDataReader stockControlReader = stockControlCmd.ExecuteReader())
                    {
                        if (stockControlReader.Read())
                        {
                            stockAmount = Convert.ToInt32(stockControlReader["StockAmount"]);
                        }
                    }
                }

                if (stockAmount == 0)
                {
                    MessageBox.Show($"Bardoce No: {dicts.Key}.  Stock Not Found !");
                    allStepsCompleted = false;


                }
                else if (stockAmount < dicts.Value)
                {
                    MessageBox.Show($"Barcode No: {dicts.Key} . You Can Only Add {stockAmount} Products !");
                    allStepsCompleted = false;


                }

            }

            if (!allStepsCompleted)
            {
                return;
            }
            else
            {

                decimal totalAmount;
                if (!decimal.TryParse(txtTotal.Text, out totalAmount))
                {
                    MessageBox.Show("Total amount is not in a correct format.");
                    return;
                }

                decimal payment;
                if (!decimal.TryParse(txtPayment.Text, out payment))
                {
                    MessageBox.Show("Payment amount is not in a correct format.");
                    return;
                }


                ReceiptPayment receiptPayment = new ReceiptPayment
                {
                    ReceiptId = 1,
                    Amount = payment,
                    Type = "Credit Card"
                };

                receiptPayments.Add(receiptPayment);
                dgPayment.Rows.Add("Credit Card", payment);

                decimal totalPayment = 0;
                for (int i = 0; i < dgPayment.Rows.Count; i++)
                {
                    totalPayment += Convert.ToDecimal(dgPayment.Rows[i].Cells["PTotal"].Value);
                }

                decimal remaining = Convert.ToDecimal(txtTotal.Text) - totalPayment;

                if (remaining <= 0)
                {
                    lbRemaing.Text = "Remaining Amount: " + remaining.ToString("#,##0.00") + " ₺";
                    txtPayment.Text = remaining.ToString("#,##0.00");

                    gbPayment.Enabled = false;
                    txtBarcode.Enabled = false;
                    dgList.Enabled = false;

                    lbRemaing.Text = "Money Change: " + remaining.ToString("#,##0.00") + " ₺";
                    return;
                }
                else
                {
                    lbRemaing.Text = "Remaining Amount: " + remaining.ToString("#,##0.00");
                    txtPayment.Text = remaining.ToString("#,##0.00");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            connection.Close();
        }


    }


    private void btcCash_Click(object sender, EventArgs e)
    {

        try
        {

            connection.Open();

            Dictionary<int, int> dictList = new Dictionary<int, int>();

            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                int value = Convert.ToInt32(dgList.Rows[i].Cells["PId"].Value);
                if (dictList.ContainsKey(value))
                {
                    dictList[value] = Convert.ToInt32(dictList[value] + 1);
                }
                else
                {
                    dictList.Add(value, 1);
                }
            }

            bool allStepsCompleted = true;

            foreach (var dicts in dictList)
            {
                int stockAmount = 0;
                string stockControlQuery = "SELECT StockAmount FROM ProductStocks WHERE ProductId=@ProductId";

                using (SqlCommand stockControlCmd = new SqlCommand(stockControlQuery, connection))
                {
                    stockControlCmd.Parameters.AddWithValue("@ProductId", dicts.Key);

                    using (SqlDataReader stockControlReader = stockControlCmd.ExecuteReader())
                    {
                        if (stockControlReader.Read())
                        {
                            stockAmount = Convert.ToInt32(stockControlReader["StockAmount"]);
                        }
                    }
                }

                if (stockAmount == 0)
                {
                    MessageBox.Show($"Bardoce No: {dicts.Key}.  Stock Not Found !");
                    allStepsCompleted = false;


                }
                else if (stockAmount < dicts.Value)
                {
                    MessageBox.Show($"Barcode No: {dicts.Key} . You Can Only Add {stockAmount} Products!");
                    allStepsCompleted = false;


                }
            }

            if (!allStepsCompleted)
            {
                return;
            }
            else
            {



                decimal totalAmount;
                if (!decimal.TryParse(txtTotal.Text, out totalAmount))
                {
                    MessageBox.Show("Total amount is not in a correct format.");
                    return;
                }

                decimal payment;
                if (!decimal.TryParse(txtPayment.Text, out payment))
                {
                    MessageBox.Show("Payment amount is not in a correct format.");
                    return;
                }


                ReceiptPayment receiptPayment = new ReceiptPayment
                {
                    ReceiptId = 1,
                    Amount = payment,
                    Type = "Cash"
                };

                receiptPayments.Add(receiptPayment);
                dgPayment.Rows.Add("Cash", payment);

                decimal totalPayment = 0;
                for (int i = 0; i < dgPayment.Rows.Count; i++)
                {
                    totalPayment += Convert.ToDecimal(dgPayment.Rows[i].Cells["PTotal"].Value);
                }

                decimal remaining = Convert.ToDecimal(txtTotal.Text) - totalPayment;

                if (remaining <= 0)
                {
                    lbRemaing.Text = "Remaining Amount: " + remaining.ToString("#,##0.00") + " ₺";
                    txtPayment.Text = remaining.ToString("#,##0.00");

                    gbPayment.Enabled = false;
                    txtBarcode.Enabled = false;
                    dgList.Enabled = false;

                    lbRemaing.Text = "Money Change: " + remaining.ToString("#,##0.00") + " ₺";
                    return;
                }
                else
                {
                    lbRemaing.Text = "Remaining Amount: " + remaining.ToString("#,##0.00");
                    txtPayment.Text = remaining.ToString("#,##0.00");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            connection.Close();
        }

    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        dgList.Rows.Clear();
        dgPayment.Rows.Clear();
        lbRemaing.Text = "0,00 ₺";
        txtTotal.Text = "0,00 ₺";
        txtPayment.Text = "0";
        total = 0;
        remaining = 0;
        gbPayment.Enabled = true;
        txtBarcode.Enabled = true;
        txtBarcode.Focus();
        receiptDetails = new();
        receiptPayments = new();
        receiptId = 0;

        gbPayment.Enabled = true;
        txtBarcode.Enabled = true;
        dgList.Enabled = true;

    }

    int receiptId = 0;

    string connectionString = Connection.ConnectionString;

    private void btnComplete_Click(object sender, EventArgs e)
    {

        connection.Open();

        Dictionary<int, int> dictList = new Dictionary<int, int>();

        for (int i = 0; i < dgList.Rows.Count; i++)
        {
            int value = Convert.ToInt32(dgList.Rows[i].Cells["PId"].Value);
            if (dictList.ContainsKey(value))
            {
                dictList[value] = Convert.ToInt32(dictList[value] + 1);
            }
            else
            {
                dictList.Add(value, 1);
            }
        }

        foreach (var dicts in dictList)
        {
            int stockAmount = 0;
            string stockControlQuery = "SELECT StockAmount FROM ProductStocks WHERE ProductId=@ProductId";

            using (SqlCommand stockControlCmd = new SqlCommand(stockControlQuery, connection))
            {
                stockControlCmd.Parameters.AddWithValue("@ProductId", dicts.Key);

                using (SqlDataReader stockControlReader = stockControlCmd.ExecuteReader())
                {
                    if (stockControlReader.Read())
                    {
                        stockAmount = Convert.ToInt32(stockControlReader["StockAmount"]);
                    }
                }
            }

            string updateStockQuery = "UPDATE ProductStocks SET StockAmount -= @Amount WHERE ProductId = @ProductId";

            using (SqlCommand updateStockCmd = new SqlCommand(updateStockQuery, connection))
            {
                updateStockCmd.Parameters.AddWithValue("@ProductId", dicts.Key);
                updateStockCmd.Parameters.AddWithValue("@Amount", dicts.Value);
                updateStockCmd.ExecuteNonQuery();
            }

        }



        decimal totalPayment = 0;

        for (int i = 0; i < dgPayment.Rows.Count; i++)
        {
            totalPayment += Convert.ToDecimal(dgPayment.Rows[i].Cells[1].Value);
        }

        if (remaining > 0)
        {
            MessageBox.Show("Not All Payment", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        else if (totalPayment == 0)
        {


            MessageBox.Show(" '0' value isn't Add on Payment !\n After adding the product to the Shoppingcard, select the payment type!");
            return;

        }
        else
        {

        }



        //transaction

        SqlTransaction transaction = connection.BeginTransaction();



        try
        {


            Guid receiptNumber = Guid.NewGuid();

            string query = "Insert into Receipts (Date, Total, Payment, Remaining, ReceiptNumber) Values (@Date, @Total, @Payment, @Remaining, @ReceiptNumber)";



            SqlCommand command = new(query, connection, transaction);

            command.Parameters.AddWithValue("@Date", DateTime.Now);
            command.Parameters.AddWithValue("@Total", Convert.ToDecimal(txtTotal.Text));
            command.Parameters.AddWithValue("@Payment", totalPayment);
            command.Parameters.AddWithValue("@Remaining", Convert.ToDecimal(txtTotal.Text) - totalPayment);
            command.Parameters.AddWithValue("@ReceiptNumber", receiptNumber);

            command.ExecuteNonQuery();



            SqlCommand getIdCommand = new($"Select TOP 1 Id From Receipts Where ReceiptNumber = @ReceiptNumber", connection, transaction);
            getIdCommand.Parameters.AddWithValue("@ReceiptNumber", receiptNumber);

            SqlDataReader reader = getIdCommand.ExecuteReader();


            if (!reader.Read())
            {
                reader.Close();

                return;
            }

            receiptId = (int)reader["Id"];
            reader.Close();


            foreach (var detail in receiptDetails)
            {
                string detailQuery = $"insert into ReceiptDetails Values(@ReceiptId,@ProductId,@Quantity,@Price,@Total,@State)";
                SqlCommand detailCommand = new(detailQuery, connection, transaction);

                detailCommand.Parameters.AddWithValue("@ReceiptId", receiptId);
                detailCommand.Parameters.AddWithValue("@ProductId", detail.ProductId);
                detailCommand.Parameters.AddWithValue("@Quantity", detail.Quantity);
                detailCommand.Parameters.AddWithValue("@Price", detail.Price);
                detailCommand.Parameters.AddWithValue("@Total", detail.Total);
                detailCommand.Parameters.AddWithValue("@State", "");



                detailCommand.ExecuteNonQuery();
            }

            foreach (var payment in receiptPayments)
            {
                string paymentQuery = $"insert into ReceiptPayments Values(@ReceiptId,@Type,@Amount)";
                SqlCommand paymentCommand = new(paymentQuery, connection, transaction);
                paymentCommand.Parameters.AddWithValue("@ReceiptId", receiptId);
                paymentCommand.Parameters.AddWithValue("@Type", payment.Type);
                paymentCommand.Parameters.AddWithValue("@Amount", payment.Amount);

                paymentCommand.ExecuteNonQuery();
            }

            transaction.Commit();

            Clear();

            MessageBox.Show("shopping completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        catch (Exception ex)
        {
            transaction.Rollback(); //rollback metodu ile transaction içerisindeki tüm işlemleri geriye alır 
            MessageBox.Show($"We encountered an error during registration \n {ex.Message} ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {

        }


        connection.Close();
        Clear();

        // alışveriş sonrası stok güncelleme 2. yöntem 
        //connection.Open();
        //for (int i = 0; i < dgList.Rows.Count; i++)
        //{
        //    int value = Convert.ToInt32(dgList.Rows[i].Cells[5].Value);



        //    SqlCommand cmd = new("select * from Products as p left join ProductStocks as ps on p.Id=@ProductId", connection);

        //    cmd.Parameters.AddWithValue("@ProductId", value);
        //    SqlDataReader quatityReader = cmd.ExecuteReader();
        //    quatityReader.Read();




        //    quatityReader.Close();


        //    SqlCommand cmd1 = new("update ProductStocks set StockAmount-=1 where ProductId=@ProductId ", connection);
        //    cmd1.Parameters.AddWithValue("@ProductId", value);
        //    cmd1.ExecuteNonQuery();



    }

    private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void receiptsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FrmPaymentForm paymentForm = new FrmPaymentForm();
        paymentForm.Show();
    }

    private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void productsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Application.OpenForms["FrmProductOperations"] == null) //kullanıcının formu 1'den fazla acamaması için
        {
            FrmProductOperations productOperations = new FrmProductOperations();
            productOperations.Show();
        }

    }

    private void addProductToolStripMenuItem1_Click(object sender, EventArgs e)
    {

    }

    private void txtBarcode_TextChanged(object sender, EventArgs e)
    {

    }

    private void dgList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        try
        {


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dgList.Columns[e.ColumnIndex].Name == "PRemove")
                {
                    dgList.Cursor = Cursors.Hand; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak
                    dgPayment.Rows.Clear();
                }
            }

        }
        catch
        {

        }
    }

    private void dgList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
    {

        {
            try
            {

                DataGridViewCell cell = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex]; //tıklanan hücreyi cell degiskenine aldık
                if (dgList.Columns[e.ColumnIndex].Name == "PRemove")
                {
                    dgList.Cursor = Cursors.Default; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak
                }
            }
            catch
            {

            }
        }
    }

    private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgList.Columns[e.ColumnIndex].Name == "PRemove")
        {

            if (MessageBox.Show($"Do you want remove '{dgList.CurrentRow.Cells["PName"].Value}' record ? ", "Remove Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgList.CurrentRow.Cells["PId"].Value);

                dgList.Rows.Remove(dgList.CurrentRow);

                int sumTotal = 0;
                for (int i = 0; i < dgList.Rows.Count; i++)
                {
                    sumTotal += Convert.ToInt32(dgList.Rows[i].Cells["Price"].Value);
                    txtTotal.Text = sumTotal.ToString();

                }

                ReceiptDetail itemToRemove = receiptDetails.FirstOrDefault(detail => detail.ProductId == id);


                if (itemToRemove != null)
                {
                    receiptDetails.Remove(itemToRemove);
                }

                txtPayment.Text = sumTotal.ToString();
                int convPayment = Convert.ToInt32(txtPayment.Text);
                lbRemaing.Text = convPayment.ToString();

            }

        }
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void returnMerchandiseAuthorizationRMAToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Application.OpenForms["FrmRMA"] == null) //kullanıcının formu 1'den fazla acamaması için
        {
            FrmRMA frmRMA = new FrmRMA();
            frmRMA.Show();
        }
    }

    private void productGrafiksToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //Select p.Name, count(*) As SalesQuantity  from Products as p left join ReceiptDetails as rd on p.Id = rd.ProductId group by p.Name
        if (Application.OpenForms["Graphics"] == null) //kullanıcının formu 1'den fazla acamaması için
        {
            Graphics graphics = new Graphics();
            graphics.Show();
        }
    }

    private void sellsReportsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Application.OpenForms["FrmPaymentForm"] == null) //kullanıcının formu 1'den fazla acamaması için
        {
            FrmPaymentForm frmPaymentForm = new FrmPaymentForm();
            frmPaymentForm.Show();
        }
    }
}


public class ReceiptDetail
{
    public int ReceiptId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }


}

public class ReceiptPayment
{
    public int ReceiptId { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }

}