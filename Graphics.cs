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
using ZedGraph;

namespace _02.MarketDesktopApp
{
    public partial class Graphics : Form
    {
        public Graphics()
        {
            InitializeComponent();
        }

        private void Graphics_Load(object sender, EventArgs e)
        {
            //page1
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Product Sell Quantities Graphics(All Times)";
            myPane.XAxis.Title.Text = "Products";
            myPane.YAxis.Title.Text = "Sell Quantities";


            using (SqlConnection connection = new(Connection.ConnectionString))
            {
                string query = "SELECT p.Name AS ProductName, SUM(Quantity) AS TotalQuantity FROM ReceiptDetails as rd left join Products as p on p.Id=rd.ProductId left join Receipts as r on r.Id=rd.ReceiptId  GROUP BY p.Name  order by TotalQuantity";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                string[] labels = new string[dataTable.Rows.Count];
                double[] values = new double[dataTable.Rows.Count];

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    labels[i] = dataTable.Rows[i]["ProductName"].ToString();
                    values[i] = Convert.ToDouble(dataTable.Rows[i]["TotalQuantity"]);
                }

                BarItem bar = myPane.AddBar("Sell Quantities", null, values, System.Drawing.Color.Blue);
                bar.Bar.Fill = new Fill(System.Drawing.Color.Blue);

                myPane.XAxis.Scale.TextLabels = labels;
                myPane.XAxis.Type = AxisType.Text;

                zedGraphControl1.AxisChange();

                //page2

                GraphPane myPane2 = zedGraphControl2.GraphPane;
                myPane2.Title.Text = "Product Sell Revenues Graphics (All Times)";
                myPane2.XAxis.Title.Text = "Products";
                myPane2.YAxis.Title.Text = "Sell Revenues";

                using (SqlConnection connection2 = new SqlConnection(Connection.ConnectionString))
                {
                    string query2 = "SELECT p.Name AS ProductName, SUM(rd.Price) AS TotalPrice FROM ReceiptDetails as rd left join Products as p on p.Id=rd.ProductId GROUP BY p.Name ORDER BY TotalPrice";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection2);
                    DataTable dataTable2 = new DataTable();
                    adapter2.Fill(dataTable2);

                    string[] labels2 = new string[dataTable2.Rows.Count];
                    double[] values2 = new double[dataTable2.Rows.Count];

                    for (int i = 0; i < dataTable2.Rows.Count; i++)
                    {
                        labels2[i] = dataTable2.Rows[i]["ProductName"].ToString();
                        values2[i] = Convert.ToDouble(dataTable2.Rows[i]["TotalPrice"]);
                    }

                    BarItem bar2 = myPane2.AddBar("Sell Revenues", null, values2, System.Drawing.Color.Blue);
                    bar2.Bar.Fill = new Fill(System.Drawing.Color.Blue);

                    myPane2.XAxis.Scale.TextLabels = labels2;
                    myPane2.XAxis.Type = AxisType.Text;

                    zedGraphControl2.AxisChange();
                }




            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
