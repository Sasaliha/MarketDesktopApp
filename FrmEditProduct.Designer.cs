namespace _02.MarketDesktopApp
{
    partial class FrmEditProduct
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
            label1 = new Label();
            label2 = new Label();
            txtPrice = new TextBox();
            btnUpdate = new Button();
            txtProduct = new TextBox();
            txtProductStock = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 48);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 0;
            label1.Text = "Product Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 145);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 1;
            label2.Text = "Product Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(66, 173);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(283, 31);
            txtPrice.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(134, 294);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(147, 66);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Send The Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(66, 76);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(283, 31);
            txtProduct.TabIndex = 5;
            // 
            // txtProductStock
            // 
            txtProductStock.Location = new Point(66, 248);
            txtProductStock.Name = "txtProductStock";
            txtProductStock.Size = new Size(283, 31);
            txtProductStock.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 220);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 6;
            label3.Text = "Product Stock";
            // 
            // FrmEditProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(411, 384);
            Controls.Add(txtProductStock);
            Controls.Add(label3);
            Controls.Add(txtProduct);
            Controls.Add(btnUpdate);
            Controls.Add(txtPrice);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmEditProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Product";
            Load += FrmEditProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox txtPrice;
        private Button btnUpdate;
        private TextBox txtProduct;
        private TextBox txtProductStock;
        private Label label3;
    }
}