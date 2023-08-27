namespace _02.MarketDesktopApp
{
    partial class Graphics
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
            zedGraphControl1 = new ZedGraph.ZedGraphControl();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            zedGraphControl2 = new ZedGraph.ZedGraphControl();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // zedGraphControl1
            // 
            zedGraphControl1.ImeMode = ImeMode.Hiragana;
            zedGraphControl1.IsAntiAlias = true;
            zedGraphControl1.IsAutoScrollRange = true;
            zedGraphControl1.IsEnableHEdit = true;
            zedGraphControl1.IsEnableHPan = false;
            zedGraphControl1.IsEnableHZoom = false;
            zedGraphControl1.IsEnableSelection = true;
            zedGraphControl1.IsEnableVEdit = true;
            zedGraphControl1.IsEnableVPan = false;
            zedGraphControl1.IsEnableVZoom = false;
            zedGraphControl1.IsEnableWheelZoom = false;
            zedGraphControl1.IsPrintFillPage = false;
            zedGraphControl1.IsPrintKeepAspectRatio = false;
            zedGraphControl1.IsPrintScaleAll = false;
            zedGraphControl1.IsScrollY2 = true;
            zedGraphControl1.IsShowContextMenu = false;
            zedGraphControl1.IsShowCopyMessage = false;
            zedGraphControl1.IsShowCursorValues = true;
            zedGraphControl1.IsShowHScrollBar = true;
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.IsShowVScrollBar = true;
            zedGraphControl1.IsSynchronizeXAxes = true;
            zedGraphControl1.IsSynchronizeYAxes = true;
            zedGraphControl1.IsZoomOnMouseCenter = true;
            zedGraphControl1.LinkButtons = MouseButtons.Right;
            zedGraphControl1.LinkModifierKeys = Keys.None;
            zedGraphControl1.Location = new Point(40, 55);
            zedGraphControl1.Margin = new Padding(5, 6, 5, 6);
            zedGraphControl1.Name = "zedGraphControl1";
            zedGraphControl1.ScrollGrace = 0D;
            zedGraphControl1.ScrollMaxX = 0D;
            zedGraphControl1.ScrollMaxY = 0D;
            zedGraphControl1.ScrollMaxY2 = 0D;
            zedGraphControl1.ScrollMinX = 0D;
            zedGraphControl1.ScrollMinY = 0D;
            zedGraphControl1.ScrollMinY2 = 0D;
            zedGraphControl1.Size = new Size(1003, 466);
            zedGraphControl1.TabIndex = 0;
            zedGraphControl1.UseExtendedPrintDialog = true;
            zedGraphControl1.Load += zedGraphControl1_Load;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1098, 606);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(zedGraphControl1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1090, 568);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Product Sells Graphics";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(zedGraphControl2);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1090, 568);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Product Revenues Graphics";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // zedGraphControl2
            // 
            zedGraphControl2.ImeMode = ImeMode.Alpha;
            zedGraphControl2.IsAntiAlias = true;
            zedGraphControl2.IsAutoScrollRange = true;
            zedGraphControl2.IsEnableHEdit = true;
            zedGraphControl2.IsEnableHPan = false;
            zedGraphControl2.IsEnableHZoom = false;
            zedGraphControl2.IsEnableSelection = true;
            zedGraphControl2.IsEnableVEdit = true;
            zedGraphControl2.IsEnableVPan = false;
            zedGraphControl2.IsEnableVZoom = false;
            zedGraphControl2.IsEnableWheelZoom = false;
            zedGraphControl2.IsPrintFillPage = false;
            zedGraphControl2.IsPrintKeepAspectRatio = false;
            zedGraphControl2.IsPrintScaleAll = false;
            zedGraphControl2.IsScrollY2 = true;
            zedGraphControl2.IsShowContextMenu = false;
            zedGraphControl2.IsShowCopyMessage = false;
            zedGraphControl2.IsShowCursorValues = true;
            zedGraphControl2.IsShowHScrollBar = true;
            zedGraphControl2.IsShowPointValues = true;
            zedGraphControl2.IsShowVScrollBar = true;
            zedGraphControl2.IsSynchronizeXAxes = true;
            zedGraphControl2.IsSynchronizeYAxes = true;
            zedGraphControl2.IsZoomOnMouseCenter = true;
            zedGraphControl2.LinkButtons = MouseButtons.Right;
            zedGraphControl2.Location = new Point(40, 55);
            zedGraphControl2.Margin = new Padding(5, 6, 5, 6);
            zedGraphControl2.Name = "zedGraphControl2";
            zedGraphControl2.ScrollGrace = 0D;
            zedGraphControl2.ScrollMaxX = 0D;
            zedGraphControl2.ScrollMaxY = 0D;
            zedGraphControl2.ScrollMaxY2 = 0D;
            zedGraphControl2.ScrollMinX = 0D;
            zedGraphControl2.ScrollMinY = 0D;
            zedGraphControl2.ScrollMinY2 = 0D;
            zedGraphControl2.Size = new Size(1003, 466);
            zedGraphControl2.TabIndex = 0;
            zedGraphControl2.UseExtendedPrintDialog = true;
            // 
            // Graphics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 606);
            Controls.Add(tabControl1);
            Name = "Graphics";
            Text = "Graphics";
            Load += Graphics_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.CodeDom.CodeTypeReference chart1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
    }
}