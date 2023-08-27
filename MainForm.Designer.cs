namespace _02.MarketDesktopApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            txtBarcode = new TextBox();
            groupBox2 = new GroupBox();
            dgList = new DataGridView();
            Count = new DataGridViewTextBoxColumn();
            PId = new DataGridViewTextBoxColumn();
            PName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            PRemove = new DataGridViewImageColumn();
            groupBox3 = new GroupBox();
            txtTotal = new TextBox();
            gbPayment = new GroupBox();
            btcCash = new Button();
            btnKK = new Button();
            txtPayment = new TextBox();
            groupBox5 = new GroupBox();
            btnComplete = new Button();
            lbRemaing = new Label();
            btnReset = new Button();
            groupBox6 = new GroupBox();
            dgPayment = new DataGridView();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            PTotal = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            receiptsToolStripMenuItem = new ToolStripMenuItem();
            productGrafiksToolStripMenuItem = new ToolStripMenuItem();
            addProductToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem = new ToolStripMenuItem();
            returnMerchandiseAuthorizationRMAToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            groupBox3.SuspendLayout();
            gbPayment.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPayment).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtBarcode);
            groupBox1.Location = new Point(25, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(817, 111);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = " Barcode Field";
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            txtBarcode.Location = new Point(8, 29);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(787, 66);
            txtBarcode.TabIndex = 0;
            txtBarcode.TextChanged += txtBarcode_TextChanged;
            txtBarcode.KeyPress += txtBarcode_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgList);
            groupBox2.Location = new Point(12, 137);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(836, 472);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = " ";
            // 
            // dgList
            // 
            dgList.AllowUserToAddRows = false;
            dgList.BackgroundColor = SystemColors.ButtonFace;
            dgList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgList.Columns.AddRange(new DataGridViewColumn[] { Count, PId, PName, Quantity, Price, TotalPrice, PRemove });
            dgList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgList.Location = new Point(6, 21);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.RowHeadersWidth = 62;
            dgList.RowTemplate.Height = 33;
            dgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgList.Size = new Size(823, 441);
            dgList.TabIndex = 0;
            dgList.CellClick += dgList_CellClick;
            dgList.CellContentClick += dgList_CellContentClick;
            dgList.CellMouseEnter += dgList_CellMouseEnter;
            dgList.CellMouseLeave += dgList_CellMouseLeave;
            // 
            // Count
            // 
            Count.HeaderText = "#";
            Count.MinimumWidth = 8;
            Count.Name = "Count";
            Count.Width = 50;
            // 
            // PId
            // 
            PId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PId.HeaderText = "Barcode";
            PId.MinimumWidth = 8;
            PId.Name = "PId";
            // 
            // PName
            // 
            PName.HeaderText = "Name";
            PName.MinimumWidth = 8;
            PName.Name = "PName";
            PName.Width = 150;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            Quantity.Width = 150;
            // 
            // Price
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            Price.DefaultCellStyle = dataGridViewCellStyle1;
            Price.HeaderText = "Price";
            Price.MinimumWidth = 8;
            Price.Name = "Price";
            Price.Width = 150;
            // 
            // TotalPrice
            // 
            TotalPrice.HeaderText = "Total Price";
            TotalPrice.MinimumWidth = 8;
            TotalPrice.Name = "TotalPrice";
            TotalPrice.Width = 150;
            // 
            // PRemove
            // 
            PRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PRemove.HeaderText = "Product Remove";
            PRemove.Image = (Image)resources.GetObject("PRemove.Image");
            PRemove.MinimumWidth = 8;
            PRemove.Name = "PRemove";
            PRemove.Resizable = DataGridViewTriState.True;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtTotal);
            groupBox3.Location = new Point(857, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(444, 97);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = " Total Price";
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            txtTotal.ForeColor = SystemColors.MenuHighlight;
            txtTotal.Location = new Point(7, 23);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(431, 66);
            txtTotal.TabIndex = 1;
            txtTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // gbPayment
            // 
            gbPayment.Controls.Add(btcCash);
            gbPayment.Controls.Add(btnKK);
            gbPayment.Controls.Add(txtPayment);
            gbPayment.Location = new Point(857, 105);
            gbPayment.Name = "gbPayment";
            gbPayment.Size = new Size(444, 198);
            gbPayment.TabIndex = 3;
            gbPayment.TabStop = false;
            gbPayment.Text = " Payment Entry";
            // 
            // btcCash
            // 
            btcCash.BackColor = SystemColors.ActiveCaption;
            btcCash.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btcCash.Image = (Image)resources.GetObject("btcCash.Image");
            btcCash.Location = new Point(221, 109);
            btcCash.Name = "btcCash";
            btcCash.Size = new Size(175, 83);
            btcCash.TabIndex = 3;
            btcCash.UseVisualStyleBackColor = false;
            btcCash.Click += btcCash_Click;
            // 
            // btnKK
            // 
            btnKK.BackColor = SystemColors.ActiveCaption;
            btnKK.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnKK.Image = (Image)resources.GetObject("btnKK.Image");
            btnKK.Location = new Point(47, 109);
            btnKK.Name = "btnKK";
            btnKK.Size = new Size(175, 83);
            btnKK.TabIndex = 0;
            btnKK.UseVisualStyleBackColor = false;
            btnKK.Click += btnKK_Click;
            // 
            // txtPayment
            // 
            txtPayment.Font = new Font("Segoe UI Black", 26F, FontStyle.Bold, GraphicsUnit.Point);
            txtPayment.ForeColor = SystemColors.MenuHighlight;
            txtPayment.Location = new Point(7, 30);
            txtPayment.Name = "txtPayment";
            txtPayment.Size = new Size(432, 78);
            txtPayment.TabIndex = 0;
            txtPayment.Text = "0";
            txtPayment.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnComplete);
            groupBox5.Controls.Add(lbRemaing);
            groupBox5.Controls.Add(btnReset);
            groupBox5.Location = new Point(854, 447);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(441, 162);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = " ";
            // 
            // btnComplete
            // 
            btnComplete.BackColor = SystemColors.ActiveCaption;
            btnComplete.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnComplete.ForeColor = SystemColors.ActiveCaption;
            btnComplete.Image = (Image)resources.GetObject("btnComplete.Image");
            btnComplete.Location = new Point(230, 88);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(169, 74);
            btnComplete.TabIndex = 1;
            btnComplete.UseVisualStyleBackColor = false;
            btnComplete.Click += btnComplete_Click;
            // 
            // lbRemaing
            // 
            lbRemaing.Font = new Font("Calibri", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbRemaing.ForeColor = Color.FromArgb(192, 0, 0);
            lbRemaing.Location = new Point(3, 27);
            lbRemaing.Name = "lbRemaing";
            lbRemaing.Size = new Size(432, 55);
            lbRemaing.TabIndex = 1;
            lbRemaing.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            btnReset.BackColor = SystemColors.ActiveCaption;
            btnReset.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.ForeColor = Color.Black;
            btnReset.Image = (Image)resources.GetObject("btnReset.Image");
            btnReset.Location = new Point(48, 87);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(185, 75);
            btnReset.TabIndex = 2;
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgPayment);
            groupBox6.Location = new Point(854, 298);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(441, 143);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "Payment Amounts";
            // 
            // dgPayment
            // 
            dgPayment.AllowUserToAddRows = false;
            dgPayment.BackgroundColor = SystemColors.ButtonFace;
            dgPayment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPayment.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn2, PTotal });
            dgPayment.Location = new Point(9, 30);
            dgPayment.Name = "dgPayment";
            dgPayment.RowHeadersVisible = false;
            dgPayment.RowHeadersWidth = 62;
            dgPayment.RowTemplate.Height = 33;
            dgPayment.Size = new Size(426, 109);
            dgPayment.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.HeaderText = "Type";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // PTotal
            // 
            PTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.NullValue = null;
            PTotal.DefaultCellStyle = dataGridViewCellStyle2;
            PTotal.HeaderText = "Total";
            PTotal.MinimumWidth = 8;
            PTotal.Name = "PTotal";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { reportsToolStripMenuItem, addProductToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1370, 33);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { receiptsToolStripMenuItem, productGrafiksToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(89, 29);
            reportsToolStripMenuItem.Text = "Reports";
            reportsToolStripMenuItem.Click += reportsToolStripMenuItem_Click;
            // 
            // receiptsToolStripMenuItem
            // 
            receiptsToolStripMenuItem.Name = "receiptsToolStripMenuItem";
            receiptsToolStripMenuItem.Size = new Size(270, 34);
            receiptsToolStripMenuItem.Text = "Receipts Reports";
            receiptsToolStripMenuItem.Click += receiptsToolStripMenuItem_Click;
            // 
            // productGrafiksToolStripMenuItem
            // 
            productGrafiksToolStripMenuItem.Name = "productGrafiksToolStripMenuItem";
            productGrafiksToolStripMenuItem.Size = new Size(270, 34);
            productGrafiksToolStripMenuItem.Text = "Product Graphics";
            productGrafiksToolStripMenuItem.Click += productGrafiksToolStripMenuItem_Click;
            // 
            // addProductToolStripMenuItem
            // 
            addProductToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productsToolStripMenuItem, returnMerchandiseAuthorizationRMAToolStripMenuItem });
            addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            addProductToolStripMenuItem.Size = new Size(183, 29);
            addProductToolStripMenuItem.Text = "Product Operations";
            addProductToolStripMenuItem.Click += addProductToolStripMenuItem_Click;
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(436, 34);
            productsToolStripMenuItem.Text = "Product Edit/Remove/Add Operations";
            productsToolStripMenuItem.Click += productsToolStripMenuItem_Click;
            // 
            // returnMerchandiseAuthorizationRMAToolStripMenuItem
            // 
            returnMerchandiseAuthorizationRMAToolStripMenuItem.Name = "returnMerchandiseAuthorizationRMAToolStripMenuItem";
            returnMerchandiseAuthorizationRMAToolStripMenuItem.Size = new Size(436, 34);
            returnMerchandiseAuthorizationRMAToolStripMenuItem.Text = "Return Merchandise Authorization (RMA)";
            returnMerchandiseAuthorizationRMAToolStripMenuItem.Click += returnMerchandiseAuthorizationRMAToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1370, 684);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(gbPayment);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Sasa Store Application";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbPayment.ResumeLayout(false);
            gbPayment.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgPayment).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox gbPayment;
        private TextBox txtBarcode;
        private DataGridView dgList;
        private GroupBox groupBox5;
        private Button btnKK;
        private TextBox txtPayment;
        private Button btnComplete;
        private Button btcCash;
        private Label lbRemaing;
        private Button btnReset;
        private GroupBox groupBox6;
        private DataGridView dgPayment;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem addProductToolStripMenuItem;
        private ToolStripMenuItem receiptsToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem returnMerchandiseAuthorizationRMAToolStripMenuItem;
        private TextBox txtTotal;
        private DataGridViewTextBoxColumn Count;
        private DataGridViewTextBoxColumn PId;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn TotalPrice;
        private DataGridViewImageColumn PRemove;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn PTotal;
        private ToolStripMenuItem productGrafiksToolStripMenuItem;
    }
}