namespace AIDT.DecisionTreeApp
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrvDataset = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.rbtnMakeTree = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.grpDataset = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvDataset)).BeginInit();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.grpDataset.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrvDataset
            // 
            this.dgrvDataset.AllowUserToAddRows = false;
            this.dgrvDataset.AllowUserToDeleteRows = false;
            this.dgrvDataset.AllowUserToOrderColumns = true;
            this.dgrvDataset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvDataset.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrvDataset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrvDataset.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgrvDataset.Location = new System.Drawing.Point(0, 0);
            this.dgrvDataset.Name = "dgrvDataset";
            this.dgrvDataset.ReadOnly = true;
            this.dgrvDataset.Size = new System.Drawing.Size(992, 496);
            this.dgrvDataset.TabIndex = 0;
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.Class = "";
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.qatCustomizeItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(998, 154);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 1;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(998, 99);
            // 
            // 
            // 
            this.ribbonPanel1.Style.Class = "";
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.Class = "";
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.Class = "";
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.Class = "";
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbtnMakeTree,
            this.buttonItem2});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(100, 96);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Thao tác";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.Class = "";
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.Class = "";
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbtnMakeTree
            // 
            this.rbtnMakeTree.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.rbtnMakeTree.Name = "rbtnMakeTree";
            this.rbtnMakeTree.SubItemsExpandWidth = 14;
            this.rbtnMakeTree.Text = "Tạo cây";
            this.rbtnMakeTree.Click += new System.EventHandler(this.rbtnMakeTree_Click);
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "Thao tác";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            // 
            // grpDataset
            // 
            this.grpDataset.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpDataset.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpDataset.Controls.Add(this.dgrvDataset);
            this.grpDataset.Location = new System.Drawing.Point(5, 156);
            this.grpDataset.Name = "grpDataset";
            this.grpDataset.Size = new System.Drawing.Size(998, 502);
            // 
            // 
            // 
            this.grpDataset.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpDataset.Style.BackColorGradientAngle = 90;
            this.grpDataset.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpDataset.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpDataset.Style.BorderBottomWidth = 1;
            this.grpDataset.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpDataset.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpDataset.Style.BorderLeftWidth = 1;
            this.grpDataset.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpDataset.Style.BorderRightWidth = 1;
            this.grpDataset.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpDataset.Style.BorderTopWidth = 1;
            this.grpDataset.Style.Class = "";
            this.grpDataset.Style.CornerDiameter = 4;
            this.grpDataset.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpDataset.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpDataset.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpDataset.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpDataset.StyleMouseDown.Class = "";
            this.grpDataset.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpDataset.StyleMouseOver.Class = "";
            this.grpDataset.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpDataset.TabIndex = 2;
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "Demo";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.grpDataset);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvDataset)).EndInit();
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.grpDataset.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgrvDataset;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.GroupPanel grpDataset;
        private DevComponents.DotNetBar.ButtonItem rbtnMakeTree;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
    }
}