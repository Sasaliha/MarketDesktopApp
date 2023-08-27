namespace _02.MarketDesktopApp
{
    partial class FrmPaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentForm));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            dgReceipts = new DataGridView();
            Count = new DataGridViewTextBoxColumn();
            RId = new DataGridViewTextBoxColumn();
            ReceiptNumber = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Payment = new DataGridViewTextBoxColumn();
            Remaining = new DataGridViewTextBoxColumn();
            BtnPrint = new DataGridViewImageColumn();
            dgReceiptPayments = new DataGridView();
            RPCount = new DataGridViewTextBoxColumn();
            RPType = new DataGridViewTextBoxColumn();
            RPAmount = new DataGridViewTextBoxColumn();
            toolTip1 = new ToolTip(components);
            groupBox1 = new GroupBox();
            dgReceiptDetails = new DataGridView();
            RDCount = new DataGridViewTextBoxColumn();
            RDProductName = new DataGridViewTextBoxColumn();
            RDQuantity = new DataGridViewTextBoxColumn();
            RDPrice = new DataGridViewTextBoxColumn();
            RDTotal = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
            label1 = new Label();
            cbType = new ComboBox();
            monthCalendar1 = new MonthCalendar();
            cbMonth = new ComboBox();
            label2 = new Label();
            cbYear = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgReceipts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgReceiptPayments).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgReceiptDetails).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dgReceipts
            // 
            dgReceipts.AllowUserToAddRows = false;
            dgReceipts.AllowUserToResizeRows = false;
            dgReceipts.BackgroundColor = SystemColors.ActiveCaption;
            dgReceipts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReceipts.Columns.AddRange(new DataGridViewColumn[] { Count, RId, ReceiptNumber, Date, Total, Payment, Remaining, BtnPrint });
            dgReceipts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgReceipts.Location = new Point(11, 27);
            dgReceipts.Name = "dgReceipts";
            dgReceipts.RowHeadersVisible = false;
            dgReceipts.RowHeadersWidth = 62;
            dgReceipts.RowTemplate.Height = 33;
            dgReceipts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgReceipts.Size = new Size(1154, 274);
            dgReceipts.TabIndex = 0;
            dgReceipts.Tag = "";
            dgReceipts.CellContentClick += dgReceipts_CellContentClick;
            dgReceipts.CellMouseEnter += dgReceipts_CellMouseEnter;
            dgReceipts.CellMouseLeave += dgReceipts_CellMouseLeave;
            dgReceipts.Click += dgReceipts_Click;
            // 
            // Count
            // 
            Count.HeaderText = "#";
            Count.MinimumWidth = 8;
            Count.Name = "Count";
            Count.Width = 50;
            // 
            // RId
            // 
            RId.HeaderText = "Id";
            RId.MinimumWidth = 8;
            RId.Name = "RId";
            RId.Visible = false;
            RId.Width = 150;
            // 
            // ReceiptNumber
            // 
            ReceiptNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ReceiptNumber.HeaderText = "ReceiptNumber";
            ReceiptNumber.MinimumWidth = 8;
            ReceiptNumber.Name = "ReceiptNumber";
            ReceiptNumber.Width = 350;
            // 
            // Date
            // 
            Date.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "F";
            dataGridViewCellStyle1.NullValue = null;
            Date.DefaultCellStyle = dataGridViewCellStyle1;
            Date.HeaderText = "Date";
            Date.MinimumWidth = 8;
            Date.Name = "Date";
            // 
            // Total
            // 
            Total.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "c2";
            Total.DefaultCellStyle = dataGridViewCellStyle2;
            Total.HeaderText = "Total";
            Total.MinimumWidth = 8;
            Total.Name = "Total";
            // 
            // Payment
            // 
            dataGridViewCellStyle3.Format = "c2";
            Payment.DefaultCellStyle = dataGridViewCellStyle3;
            Payment.HeaderText = "Payment";
            Payment.MinimumWidth = 8;
            Payment.Name = "Payment";
            Payment.Width = 150;
            // 
            // Remaining
            // 
            Remaining.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Format = "c2";
            Remaining.DefaultCellStyle = dataGridViewCellStyle4;
            Remaining.HeaderText = "Money Change";
            Remaining.MinimumWidth = 8;
            Remaining.Name = "Remaining";
            // 
            // BtnPrint
            // 
            BtnPrint.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BtnPrint.HeaderText = "Print";
            BtnPrint.Image = (Image)resources.GetObject("BtnPrint.Image");
            BtnPrint.MinimumWidth = 8;
            BtnPrint.Name = "BtnPrint";
            BtnPrint.Resizable = DataGridViewTriState.True;
            BtnPrint.SortMode = DataGridViewColumnSortMode.Automatic;
            BtnPrint.ToolTipText = "Print";
            // 
            // dgReceiptPayments
            // 
            dgReceiptPayments.AllowUserToAddRows = false;
            dgReceiptPayments.BackgroundColor = SystemColors.ActiveCaption;
            dgReceiptPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReceiptPayments.Columns.AddRange(new DataGridViewColumn[] { RPCount, RPType, RPAmount });
            dgReceiptPayments.Location = new Point(6, 31);
            dgReceiptPayments.Name = "dgReceiptPayments";
            dgReceiptPayments.RowHeadersVisible = false;
            dgReceiptPayments.RowHeadersWidth = 62;
            dgReceiptPayments.RowTemplate.Height = 33;
            dgReceiptPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgReceiptPayments.Size = new Size(550, 308);
            dgReceiptPayments.TabIndex = 2;
            dgReceiptPayments.CellContentClick += dgReceiptPayments_CellContentClick;
            // 
            // RPCount
            // 
            RPCount.HeaderText = "#";
            RPCount.MinimumWidth = 8;
            RPCount.Name = "RPCount";
            RPCount.Width = 50;
            // 
            // RPType
            // 
            RPType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RPType.HeaderText = "Type";
            RPType.MinimumWidth = 8;
            RPType.Name = "RPType";
            // 
            // RPAmount
            // 
            RPAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Format = "c2";
            RPAmount.DefaultCellStyle = dataGridViewCellStyle5;
            RPAmount.HeaderText = "Amount";
            RPAmount.MinimumWidth = 8;
            RPAmount.Name = "RPAmount";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgReceipts);
            groupBox1.Location = new Point(35, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1185, 307);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Receipt Informations";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dgReceiptDetails
            // 
            dgReceiptDetails.AllowUserToAddRows = false;
            dgReceiptDetails.BackgroundColor = SystemColors.ActiveCaption;
            dgReceiptDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReceiptDetails.Columns.AddRange(new DataGridViewColumn[] { RDCount, RDProductName, RDQuantity, RDPrice, RDTotal });
            dgReceiptDetails.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgReceiptDetails.Location = new Point(6, 30);
            dgReceiptDetails.Name = "dgReceiptDetails";
            dgReceiptDetails.RowHeadersVisible = false;
            dgReceiptDetails.RowHeadersWidth = 62;
            dgReceiptDetails.RowTemplate.Height = 33;
            dgReceiptDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgReceiptDetails.Size = new Size(580, 309);
            dgReceiptDetails.TabIndex = 1;
            dgReceiptDetails.CellContentClick += dgReceiptDetails_CellContentClick;
            dgReceiptDetails.CellMouseEnter += dgReceiptDetails_CellMouseEnter;
            dgReceiptDetails.CellMouseLeave += dgReceiptDetails_CellMouseLeave;
            // 
            // RDCount
            // 
            RDCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            RDCount.HeaderText = "#";
            RDCount.MinimumWidth = 8;
            RDCount.Name = "RDCount";
            RDCount.Width = 50;
            // 
            // RDProductName
            // 
            RDProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            RDProductName.FillWeight = 115.384613F;
            RDProductName.HeaderText = "ProductName";
            RDProductName.MinimumWidth = 8;
            RDProductName.Name = "RDProductName";
            RDProductName.Width = 150;
            // 
            // RDQuantity
            // 
            RDQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            RDQuantity.FillWeight = 92.30769F;
            RDQuantity.HeaderText = "Quantity";
            RDQuantity.MinimumWidth = 8;
            RDQuantity.Name = "RDQuantity";
            RDQuantity.Width = 150;
            // 
            // RDPrice
            // 
            RDPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Format = "c2";
            RDPrice.DefaultCellStyle = dataGridViewCellStyle6;
            RDPrice.FillWeight = 92.30769F;
            RDPrice.HeaderText = "Price";
            RDPrice.MinimumWidth = 8;
            RDPrice.Name = "RDPrice";
            // 
            // RDTotal
            // 
            RDTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Format = "c2";
            RDTotal.DefaultCellStyle = dataGridViewCellStyle7;
            RDTotal.HeaderText = "Total";
            RDTotal.MinimumWidth = 8;
            RDTotal.Name = "RDTotal";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgReceiptDetails);
            groupBox2.Location = new Point(35, 325);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(592, 345);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Receipt Product Details";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgReceiptPayments);
            groupBox3.Location = new Point(633, 325);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(587, 345);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Receipt Payment Details";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1263, 581);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 9;
            textBox1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1283, 169);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 8;
            label1.Text = "Select A Day";
            label1.Visible = false;
            // 
            // cbType
            // 
            cbType.BackColor = SystemColors.ScrollBar;
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Items.AddRange(new object[] { "All Times", "Day Sells", "Month Sells", "Year Sells" });
            cbType.Location = new Point(1257, 70);
            cbType.Name = "cbType";
            cbType.Size = new Size(348, 33);
            cbType.TabIndex = 7;
            cbType.SelectedValueChanged += comboBox1_SelectedValueChanged;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(1283, 203);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 6;
            monthCalendar1.Visible = false;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // cbMonth
            // 
            cbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonth.FormattingEnabled = true;
            cbMonth.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            cbMonth.Location = new Point(1331, 301);
            cbMonth.Name = "cbMonth";
            cbMonth.Size = new Size(182, 33);
            cbMonth.TabIndex = 10;
            cbMonth.Visible = false;
            cbMonth.SelectedValueChanged += cbMonth_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1331, 273);
            label2.Name = "label2";
            label2.Size = new Size(133, 25);
            label2.TabIndex = 11;
            label2.Text = "Select A Month";
            label2.Visible = false;
            // 
            // cbYear
            // 
            cbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbYear.FormattingEnabled = true;
            cbYear.Location = new Point(1331, 237);
            cbYear.Name = "cbYear";
            cbYear.Size = new Size(182, 33);
            cbYear.TabIndex = 12;
            cbYear.Visible = false;
            cbYear.SelectedValueChanged += cbYear_SelectedValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1331, 209);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 13;
            label3.Text = "Select A Year";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1338, 42);
            label4.Name = "label4";
            label4.Size = new Size(175, 25);
            label4.TabIndex = 14;
            label4.Text = "Select A Report Type";
            // 
            // FrmPaymentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1627, 698);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbYear);
            Controls.Add(label2);
            Controls.Add(cbMonth);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(cbType);
            Controls.Add(monthCalendar1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmPaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipts Reports";
            Load += PaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgReceipts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgReceiptPayments).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgReceiptDetails).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgReceipts;
        private DataGridView dgReceiptPayments;
        private DataGridViewTextBoxColumn RPCount;
        private DataGridViewTextBoxColumn RPType;
        private DataGridViewTextBoxColumn RPAmount;
        private ToolTip toolTip1;
        private GroupBox groupBox1;
        private DataGridView dgReceiptDetails;
        private DataGridViewTextBoxColumn RDCount;
        private DataGridViewTextBoxColumn RDProductName;
        private DataGridViewTextBoxColumn RDQuantity;
        private DataGridViewTextBoxColumn RDPrice;
        private DataGridViewTextBoxColumn RDTotal;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridViewTextBoxColumn Count;
        private DataGridViewTextBoxColumn RId;
        private DataGridViewTextBoxColumn ReceiptNumber;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Payment;
        private DataGridViewTextBoxColumn Remaining;
        private DataGridViewImageColumn BtnPrint;
        private TextBox textBox1;
        private Label label1;
        private ComboBox cbType;
        private MonthCalendar monthCalendar1;
        private ComboBox cbMonth;
        private Label label2;
        private ComboBox cbYear;
        private Label label3;
        private Label label4;
    }
}