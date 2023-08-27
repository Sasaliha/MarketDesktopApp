namespace _02.MarketDesktopApp
{
    partial class FrmProductOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductOperations));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgProducts = new DataGridView();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            btnSave = new Button();
            txtStockAmount = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtPrice = new TextBox();
            txtName = new TextBox();
            Count = new DataGridViewTextBoxColumn();
            PId = new DataGridViewTextBoxColumn();
            PName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            BtnEdit = new DataGridViewImageColumn();
            BtnRemove = new DataGridViewImageColumn();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgProducts).BeginInit();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1083, 613);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgProducts);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1075, 575);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Products";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // dgProducts
            // 
            dgProducts.AllowUserToAddRows = false;
            dgProducts.BackgroundColor = SystemColors.ActiveCaption;
            dgProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProducts.Columns.AddRange(new DataGridViewColumn[] { Count, PId, PName, Price, Stock, BtnEdit, BtnRemove });
            dgProducts.Dock = DockStyle.Fill;
            dgProducts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgProducts.Location = new Point(3, 3);
            dgProducts.Name = "dgProducts";
            dgProducts.RowHeadersVisible = false;
            dgProducts.RowHeadersWidth = 62;
            dgProducts.RowTemplate.Height = 33;
            dgProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgProducts.Size = new Size(1069, 569);
            dgProducts.TabIndex = 0;
            dgProducts.CellClick += dgProducts_CellClick;
            dgProducts.CellContentClick += dgProducts_CellContentClick;
            dgProducts.CellMouseEnter += dgProducts_CellMouseEnter;
            dgProducts.CellMouseLeave += dgProducts_CellMouseLeave;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSkyBlue;
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1075, 575);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "ProductAdd";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtStockAmount);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtName);
            groupBox1.Location = new Point(210, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 440);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Product Add";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(129, 314);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(138, 78);
            btnSave.TabIndex = 5;
            btnSave.Text = "PRODUCT SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtStockAmount
            // 
            txtStockAmount.Location = new Point(71, 241);
            txtStockAmount.Name = "txtStockAmount";
            txtStockAmount.Size = new Size(275, 31);
            txtStockAmount.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 46);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 0;
            label1.Text = "Product Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 213);
            label4.Name = "label4";
            label4.Size = new Size(125, 25);
            label4.TabIndex = 7;
            label4.Text = "Stock Amount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 134);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 1;
            label2.Text = "Product Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(71, 162);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(275, 31);
            txtPrice.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(71, 74);
            txtName.Name = "txtName";
            txtName.Size = new Size(275, 31);
            txtName.TabIndex = 3;
            // 
            // Count
            // 
            Count.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Count.HeaderText = "Barcode No";
            Count.MinimumWidth = 8;
            Count.Name = "Count";
            // 
            // PId
            // 
            PId.HeaderText = "Id";
            PId.MinimumWidth = 8;
            PId.Name = "PId";
            PId.Visible = false;
            PId.Width = 150;
            // 
            // PName
            // 
            PName.HeaderText = "Name";
            PName.MinimumWidth = 8;
            PName.Name = "PName";
            PName.Width = 200;
            // 
            // Price
            // 
            dataGridViewCellStyle1.Format = "c2";
            Price.DefaultCellStyle = dataGridViewCellStyle1;
            Price.HeaderText = "Price";
            Price.MinimumWidth = 8;
            Price.Name = "Price";
            Price.Width = 150;
            // 
            // Stock
            // 
            Stock.HeaderText = "Stock";
            Stock.MinimumWidth = 8;
            Stock.Name = "Stock";
            Stock.Width = 150;
            // 
            // BtnEdit
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.LightBlue;
            dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
            BtnEdit.DefaultCellStyle = dataGridViewCellStyle2;
            BtnEdit.HeaderText = "Edit Product";
            BtnEdit.Image = (Image)resources.GetObject("BtnEdit.Image");
            BtnEdit.MinimumWidth = 8;
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Resizable = DataGridViewTriState.True;
            BtnEdit.Width = 150;
            // 
            // BtnRemove
            // 
            BtnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 192, 192);
            dataGridViewCellStyle3.NullValue = resources.GetObject("dataGridViewCellStyle3.NullValue");
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(255, 128, 128);
            BtnRemove.DefaultCellStyle = dataGridViewCellStyle3;
            BtnRemove.HeaderText = "Remove Product";
            BtnRemove.Image = (Image)resources.GetObject("BtnRemove.Image");
            BtnRemove.MinimumWidth = 8;
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Resizable = DataGridViewTriState.True;
            BtnRemove.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // FrmProductOperations
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 613);
            Controls.Add(tabControl1);
            Name = "FrmProductOperations";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Operations";
            Load += FrmProductOperations_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgProducts).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgProducts;
        private TabPage tabPage2;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSave;
        private TextBox txtPrice;
        private TextBox txtStockAmount;
        private Label label4;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn Count;
        private DataGridViewTextBoxColumn PId;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewImageColumn BtnEdit;
        private DataGridViewImageColumn BtnRemove;
    }
}