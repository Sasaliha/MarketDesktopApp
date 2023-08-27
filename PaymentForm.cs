using _02.MarketDesktopApp.Constants;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace _02.MarketDesktopApp
{
    public partial class FrmPaymentForm : Form
    {
        string connectionString = Connection.ConnectionString;
        SqlConnection connection;

        public FrmPaymentForm()
        {
            //constructor yapıcı metotlar. uygulamanın basında class newlendiği esnada yani instance'ı türetildiği esnada calısır.
            InitializeComponent();
            connection = new(connectionString);  //connectionstringi new leyerek objesini olustur ve parametre olarak gönder
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

            GetReceipts();



            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 10; i <= currentYear; i++)
            {
                cbYear.Items.Add(i.ToString());
            }



        }

        private void GetReceipts()
        {
            connection.Open();
            SqlCommand cmd = new("SELECT * FROM Receipts Order By Date Desc", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dgReceipts.Rows.Add();
                int rowCount = dgReceipts.Rows.Count - 1;

                //sagdaki isimler database deki isimler, soldaki isimler ise datagriddeki alan isimlerimiz
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
                        GetReceiptDetails(receiptId);
                        GetReceiptPayments(receiptId);

                        connection.Close();
                    }



                }

            }
            catch
            {

            }




        }

        private void GetReceiptPayments(int receiptId)
        {
            //receipt tablom tıkladıgında paymentdetail tablomda ilgili verilerimin gelmesi için kodlarımı yazıyorum

            SqlCommand receiptPaymentCmd = new("Select * From ReceiptPayments where ReceiptId=@ReceiptId", connection);
            receiptPaymentCmd.Parameters.AddWithValue("@ReceiptId", receiptId);
            SqlDataReader receiptPaymentReader = receiptPaymentCmd.ExecuteReader();
            dgReceiptPayments.Rows.Clear();


            while (receiptPaymentReader.Read())
            {
                dgReceiptPayments.Rows.Add();
                int dgReceiptPaymentsCount = dgReceiptPayments.Rows.Count - 1;

                dgReceiptPayments.Rows[dgReceiptPaymentsCount].Cells["RPCount"].Value = dgReceiptPaymentsCount + 1;
                dgReceiptPayments.Rows[dgReceiptPaymentsCount].Cells["RPType"].Value = receiptPaymentReader["Type"];
                dgReceiptPayments.Rows[dgReceiptPaymentsCount].Cells["RPAmount"].Value = receiptPaymentReader["Amount"];

            }
            dgReceiptPayments.ClearSelection();
            receiptPaymentReader.Close();
        }

        private void GetReceiptDetails(int receiptId)
        {

            //receipt tablom tıkladıgında receipdetail tablomda ilgili verilerimin gelmesi için kodlarımı yazıyorum
            SqlCommand receiptDetailsCmd = new("select p.Name as Name, rd.Quantity as Quantity, rd.Price as Price, rd.Total as Total from ReceiptDetails as rd Left Join Products as p on rd.ProductId = p.Id where ReceiptId =@ReceiptId", connection);
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
            }
            receiptDetailReader.Close();
            dgReceiptDetails.ClearSelection();
        }

        private void dgReceipts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgReceipts.Columns[e.ColumnIndex].Name == "BtnPrint")
                {


                    int id = Convert.ToInt32(dgReceipts.CurrentRow.Cells["RId"].Value);
                    connection.Open();

                    string query = "select r.ReceiptNumber as ReceiptNumber, p.Name as Name, rd.Quantity as Quantity, rd.Price as Price, r.Total as Total, r.Payment, r.Remaining from ReceiptDetails as rd left join Products as p on rd.ProductId = p.Id left join Receipts as r on r.Id=rd.ReceiptId where ReceiptId=@ReceiptId";

                    SqlCommand cmd = new(query, connection);
                    cmd.Parameters.AddWithValue("@ReceiptId", id);
                    SqlDataReader reader = cmd.ExecuteReader();


                    Excel.Application app = new();
                    Excel.Workbook book;

                    Excel.Worksheet sheet;

                    object misValue = System.Reflection.Missing.Value;
                    book = app.Workbooks.Add(misValue);
                    sheet = (Excel.Worksheet)book.Worksheets["Sayfa1"];

                    sheet.Range["A1:C200"].Font.Name = "Console";
                    sheet.Range["A1:C200"].Font.Size = 8;
                    sheet.Range["A1:A2"].Font.Color = Color.Red;
                    sheet.Range["A1:C4"].Font.Bold = true;
                    sheet.Range["A1:C1"].EntireColumn.ColumnWidth = 16.29;
                    sheet.Range["A1", "C1"].Merge(true);
                    sheet.Cells[1, "A"] = "SASA MARKET RECEIPT";

                    //yazıyı sayfada ortaladık
                    Excel.Range range = sheet.get_Range("A1");
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    sheet.Range["A2", "C2"].Merge(true);
                    sheet.Cells[2, "A"] = DateTime.Now;

                    sheet.Cells[3, "A"] = "ReceiptNumber";

                    sheet.Range["B3", "C3"].Merge(true);


                    sheet.Cells[4, "A"] = "Name";
                    sheet.Cells[4, "B"] = "Quantity";
                    sheet.Cells[4, "C"] = " Price";


                    int rowCount = 6;

                    while (reader.Read())
                    {
                        sheet.Cells[rowCount, 1] = reader["Name"];
                        sheet.Cells[rowCount, 2] = reader["Quantity"];
                        sheet.Cells[rowCount, 3] = reader["Price"];
                        sheet.Cells[3, "B"] = reader["ReceiptNumber"];




                        rowCount++;

                        sheet.Range["C" + (rowCount)].Value = reader["Total"];

                        sheet.Range["C" + (rowCount + 1)].Value = reader["Payment"];
                        sheet.Range["C" + (rowCount + 2)].Value = reader["Remaining"];




                        sheet.Range["A2"].NumberFormat = "dd.MM.yyyy HH:mm:ss";
                        sheet.Range["C:C"].NumberFormat = "₺#,##0.00";


                    }

                    sheet.Range["A" + 5 + ":C" + (rowCount + 2)].Borders.LineStyle = 1;


                    sheet.Range["B" + (rowCount)].Font.Bold = true;
                    sheet.Range["B" + (rowCount + 1)].Font.Bold = true;
                    sheet.Range["B" + (rowCount + 2)].Font.Bold = true;
                    sheet.Range["C" + (rowCount)].Font.Bold = true;
                    sheet.Range["C" + (rowCount + 2)].Font.Bold = true;

                    sheet.Range["B" + 5 + ":C" + (rowCount + 2)].Borders.LineStyle = 1;
                    sheet.Range["C" + rowCount + 2].Borders.LineStyle = 1;
                    sheet.Range["C" + rowCount + 3].Borders.LineStyle = 1;
                    sheet.Range["C" + rowCount + 4].Borders.LineStyle = 1;
                    sheet.Range["A5:C5"].Borders.LineStyle = 1;



                    sheet.Range["B" + (rowCount)].Value = "TOTAL";
                    sheet.Range["B" + (rowCount + 1)].Value = "PAYMENT";
                    sheet.Range["B" + (rowCount + 2)].Value = "REMAINING";


                    app.Visible = true;

                    book.SaveAs("C:\\Users\\LENOVO\\Desktop\\YMYP\\MarketApp\\Receipt.xlsx");
                    book.Close(true, misValue, misValue);
                    app.Quit();
                    sheet.PrintOutEx(1);

                }
            }
            catch
            {
            }

            connection.Close();
        }

        private void dgReceiptPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgReceipts_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgReceipts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dgReceipts.Columns[e.ColumnIndex].Name == "BtnPrint")
                {
                    dgReceipts.Cursor = Cursors.Hand; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak

                }
            }

        }

        private void dgReceipts_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)  //e.RowIndex ve e.ColumnIndex değerlerini kullanarak bir hücreye tıklanıp tıklanmadıgını kontorl eder
            {
                DataGridViewCell cell = dgReceipts.Rows[e.RowIndex].Cells[e.ColumnIndex]; //tıklanan hücreyi cell degiskenine aldık
                if (dgReceipts.Columns[e.ColumnIndex].Name == "BtnPrint")
                {
                    dgReceipts.Cursor = Cursors.Default; // Hücrenin üzerine gelindiğinde fare işareti el işareti olacak
                }
            }
        }

        private void dgReceiptDetails_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgReceiptDetails_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgReceiptDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {


                dgReceipts.Rows.Clear();
                textBox1.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");

                connection.Open();
                if (cbType.Text == "Day Sells")
                {

                    SqlCommand cmd = new("SELECT * FROM Receipts where CONVERT(DATE, Date)=@Date", connection);
                    cmd.Parameters.AddWithValue("@Date", textBox1.Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgReceipts.Rows.Add();
                        int rowCount = dgReceipts.Rows.Count - 1;

                        //sagdaki isimler database deki isimler, soldaki isimler ise datagriddeki alan isimlerimiz
                        dgReceipts.Rows[rowCount].Cells["Count"].Value = rowCount + 1;
                        dgReceipts.Rows[rowCount].Cells["RId"].Value = reader["Id"];
                        dgReceipts.Rows[rowCount].Cells["ReceiptNumber"].Value = reader["ReceiptNumber"];
                        dgReceipts.Rows[rowCount].Cells["Date"].Value = reader["Date"];
                        dgReceipts.Rows[rowCount].Cells["Total"].Value = reader["Total"];
                        dgReceipts.Rows[rowCount].Cells["Payment"].Value = reader["Payment"];
                        dgReceipts.Rows[rowCount].Cells["Remaining"].Value = reader["Remaining"];
                    }

                    connection.Close();
                    return;
                }

            }
            catch (Exception ex)
            {
                
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {


                if (cbType.SelectedItem == "Day Sells")
                {
                    dgReceiptPayments.Rows.Clear();
                    dgReceiptDetails.Rows.Clear();
                    dgReceipts.Rows.Clear();
                    monthCalendar1.Visible = true;
                    label1.Visible = true;
                    cbMonth.Visible = false;
                    label2.Visible = false;
                    cbYear.Visible = false;
                    label3.Visible = false;
                    return;
                }
                else if (cbType.SelectedItem == "All Times")
                {
                    dgReceiptPayments.Rows.Clear();
                    dgReceiptDetails.Rows.Clear();
                    dgReceipts.Rows.Clear();
                    GetReceipts();
                    monthCalendar1.Visible = false;
                    label1.Visible = false;
                    cbMonth.Visible = false;
                    label2.Visible = false;
                    cbYear.Visible = false;
                    label3.Visible = false;
                    return;
                }
                else if (cbType.SelectedItem == "Month Sells")
                {
                    dgReceiptPayments.Rows.Clear();
                    dgReceiptDetails.Rows.Clear();
                    dgReceipts.Rows.Clear();
                    cbMonth.Visible = true;
                    label2.Visible = true;
                    cbYear.Visible = true;
                    label3.Visible = true;
                    monthCalendar1.Visible = false;
                    label1.Visible = false;
                    return;

                }

                else if (cbType.SelectedItem == "Year Sells")
                {
                    dgReceiptPayments.Rows.Clear();
                    dgReceiptDetails.Rows.Clear();
                    dgReceipts.Rows.Clear();
                    cbMonth.Visible = false;
                    label2.Visible = false;
                    cbYear.Visible = true;
                    label3.Visible = true;
                    monthCalendar1.Visible = false;
                    label1.Visible = false;
                    return;

                }
            }
            catch
            {

            }
        }

        private void cbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            dgReceiptPayments.Rows.Clear();
            dgReceiptDetails.Rows.Clear();
            dgReceipts.Rows.Clear();


            try
            {



                textBox1.Text = $"{cbYear.SelectedItem}-{cbMonth.SelectedItem}";

                connection.Open();
                if (cbType.Text == "Month Sells")
                {

                    SqlCommand cmd = new("SELECT * FROM Receipts WHERE MONTH(Date) = @DateMonth AND YEAR(Date) = @DateYear", connection);
                    cmd.Parameters.AddWithValue("@Date", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DateMonth", cbMonth.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DateYear", cbYear.SelectedItem.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgReceipts.Rows.Add();
                        int rowCount = dgReceipts.Rows.Count - 1;

                        //sagdaki isimler database deki isimler, soldaki isimler ise datagriddeki alan isimlerimiz
                        dgReceipts.Rows[rowCount].Cells["Count"].Value = rowCount + 1;
                        dgReceipts.Rows[rowCount].Cells["RId"].Value = reader["Id"];
                        dgReceipts.Rows[rowCount].Cells["ReceiptNumber"].Value = reader["ReceiptNumber"];
                        dgReceipts.Rows[rowCount].Cells["Date"].Value = reader["Date"];
                        dgReceipts.Rows[rowCount].Cells["Total"].Value = reader["Total"];
                        dgReceipts.Rows[rowCount].Cells["Payment"].Value = reader["Payment"];
                        dgReceipts.Rows[rowCount].Cells["Remaining"].Value = reader["Remaining"];
                    }



                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }



        }

        private void cbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            dgReceiptPayments.Rows.Clear();
            dgReceiptDetails.Rows.Clear();
            dgReceipts.Rows.Clear();

            try
            {



                textBox1.Text = $"{cbYear.SelectedItem}";

                connection.Open();
                if (cbType.Text == "Year Sells")
                {

                    SqlCommand cmd = new("SELECT * FROM Receipts WHERE YEAR(Date) = @DateYear", connection);


                    cmd.Parameters.AddWithValue("@DateYear", cbYear.SelectedItem.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgReceipts.Rows.Add();
                        int rowCount = dgReceipts.Rows.Count - 1;

                        //sagdaki isimler database deki isimler, soldaki isimler ise datagriddeki alan isimlerimiz
                        dgReceipts.Rows[rowCount].Cells["Count"].Value = rowCount + 1;
                        dgReceipts.Rows[rowCount].Cells["RId"].Value = reader["Id"];
                        dgReceipts.Rows[rowCount].Cells["ReceiptNumber"].Value = reader["ReceiptNumber"];
                        dgReceipts.Rows[rowCount].Cells["Date"].Value = reader["Date"];
                        dgReceipts.Rows[rowCount].Cells["Total"].Value = reader["Total"];
                        dgReceipts.Rows[rowCount].Cells["Payment"].Value = reader["Payment"];
                        dgReceipts.Rows[rowCount].Cells["Remaining"].Value = reader["Remaining"];
                    }



                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }


        }
    }
}


