namespace _02.MarketDesktopApp
{
    partial class FrmRMA
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRMA));
            txtReceiptNumber = new TextBox();
            label1 = new Label();
            dgReceipts = new DataGridView();
            Count = new DataGridViewTextBoxColumn();
            RId = new DataGridViewTextBoxColumn();
            ReceiptNumber = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Payment = new DataGridViewTextBoxColumn();
            Remaining = new DataGridViewTextBoxColumn();
            dgReceiptDetails = new DataGridView();
            RDCount = new DataGridViewTextBoxColumn();
            RDProductName = new DataGridViewTextBoxColumn();
            RDQuantity = new DataGridViewTextBoxColumn();
            RDPrice = new DataGridViewTextBoxColumn();
            RDTotal = new DataGridViewTextBoxColumn();
            BtnReturn = new DataGridViewImageColumn();
            ProductId = new DataGridViewTextBoxColumn();
            State = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgReceipts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgReceiptDetails).BeginInit();
            SuspendLayout();
            // 
            // txtReceiptNumber
            // 
            txtReceiptNumber.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            txtReceiptNumber.Location = new Point(54, 37);
            txtReceiptNumber.Name = "txtReceiptNumber";
            txtReceiptNumber.Size = new Size(523, 50);
            txtReceiptNumber.TabIndex = 0;
            txtReceiptNumber.TextChanged += txtReceiptNumber_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 9);
            label1.Name = "label1";
            label1.Size = new Size(139, 25);
            label1.TabIndex = 1;
            label1.Text = "Receipt Number";
            // 
            // dgReceipts
            // 
            dgReceipts.AllowUserToAddRows = false;
            dgReceipts.AllowUserToResizeRows = false;
            dgReceipts.BackgroundColor = SystemColors.Control;
            dgReceipts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReceipts.Columns.AddRange(new DataGridViewColumn[] { Count, RId, ReceiptNumber, Date, Total, Payment, Remaining });
            dgReceipts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgReceipts.Location = new Point(54, 93);
            dgReceipts.Name = "dgReceipts";
            dgReceipts.RowHeadersVisible = false;
            dgReceipts.RowHeadersWidth = 62;
            dgReceipts.RowTemplate.Height = 33;
            dgReceipts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgReceipts.Size = new Size(954, 183);
            dgReceipts.TabIndex = 4;
            dgReceipts.Tag = "";
            dgReceipts.CellContentClick += dgReceipts_CellContentClick;
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
            ReceiptNumber.Width = 200;
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
            // dgReceiptDetails
            // 
            dgReceiptDetails.AllowUserToAddRows = false;
            dgReceiptDetails.BackgroundColor = SystemColors.Control;
            dgReceiptDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReceiptDetails.Columns.AddRange(new DataGridViewColumn[] { RDCount, RDProductName, RDQuantity, RDPrice, RDTotal, BtnReturn, ProductId, State });
            dgReceiptDetails.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgReceiptDetails.Location = new Point(54, 309);
            dgReceiptDetails.Name = "dgReceiptDetails";
            dgReceiptDetails.RowHeadersVisible = false;
            dgReceiptDetails.RowHeadersWidth = 62;
            dgReceiptDetails.RowTemplate.Height = 33;
            dgReceiptDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgReceiptDetails.Size = new Size(966, 254);
            dgReceiptDetails.TabIndex = 5;
            dgReceiptDetails.CellClick += dgReceiptDetails_CellClick;
            dgReceiptDetails.CellContentClick += dgReceiptDetails_CellContentClick;
            dgReceiptDetails.CellFormatting += dgReceiptDetails_CellFormatting;
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
            RDProductName.FillWeight = 115.384613F;
            RDProductName.HeaderText = "ProductName";
            RDProductName.MinimumWidth = 8;
            RDProductName.Name = "RDProductName";
            RDProductName.Width = 150;
            // 
            // RDQuantity
            // 
            RDQuantity.FillWeight = 92.30769F;
            RDQuantity.HeaderText = "Quantity";
            RDQuantity.MinimumWidth = 8;
            RDQuantity.Name = "RDQuantity";
            RDQuantity.Width = 150;
            // 
            // RDPrice
            // 
            dataGridViewCellStyle5.Format = "c2";
            RDPrice.DefaultCellStyle = dataGridViewCellStyle5;
            RDPrice.FillWeight = 92.30769F;
            RDPrice.HeaderText = "Price";
            RDPrice.MinimumWidth = 8;
            RDPrice.Name = "RDPrice";
            RDPrice.Width = 150;
            // 
            // RDTotal
            // 
            dataGridViewCellStyle6.Format = "c2";
            RDTotal.DefaultCellStyle = dataGridViewCellStyle6;
            RDTotal.HeaderText = "Total";
            RDTotal.MinimumWidth = 8;
            RDTotal.Name = "RDTotal";
            RDTotal.Width = 150;
            // 
            // BtnReturn
            // 
            BtnReturn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BtnReturn.HeaderText = "Return";
            BtnReturn.Image = (Image)resources.GetObject("BtnReturn.Image");
            BtnReturn.MinimumWidth = 8;
            BtnReturn.Name = "BtnReturn";
            // 
            // ProductId
            // 
            ProductId.HeaderText = "Product Id";
            ProductId.MinimumWidth = 8;
            ProductId.Name = "ProductId";
            ProductId.Visible = false;
            ProductId.Width = 150;
            // 
            // State
            // 
            State.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            State.HeaderText = "State";
            State.MinimumWidth = 8;
            State.Name = "State";
            // 
            // FrmRMA
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 585);
            Controls.Add(dgReceiptDetails);
            Controls.Add(dgReceipts);
            Controls.Add(label1);
            Controls.Add(txtReceiptNumber);
            Name = "FrmRMA";
            Text = "RMA";
            Load += FrmRMA_Load;
            ((System.ComponentModel.ISupportInitialize)dgReceipts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgReceiptDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtReceiptNumber;
        private Label label1;
        private DataGridView dgReceipts;
        private DataGridViewTextBoxColumn Count;
        private DataGridViewTextBoxColumn RId;
        private DataGridViewTextBoxColumn ReceiptNumber;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Payment;
        private DataGridViewTextBoxColumn Remaining;
        private DataGridView dgReceiptDetails;
        private DataGridViewTextBoxColumn RDCount;
        private DataGridViewTextBoxColumn RDProductName;
        private DataGridViewTextBoxColumn RDQuantity;
        private DataGridViewTextBoxColumn RDPrice;
        private DataGridViewTextBoxColumn RDTotal;
        private DataGridViewImageColumn BtnReturn;
        private DataGridViewTextBoxColumn ProductId;
        private DataGridViewTextBoxColumn State;
    }
}