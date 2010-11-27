namespace AIDT.DecisionTreeApp
{
    partial class frmDecisionTree
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
            this.node1 = new DevComponents.Tree.Node();
            this.decisionTree = new DevComponents.Tree.TreeGX();
            this.node2 = new DevComponents.Tree.Node();
            this.elementStyle5 = new DevComponents.Tree.ElementStyle();
            this.elementStyle7 = new DevComponents.Tree.ElementStyle();
            this.nodeConnector2 = new DevComponents.Tree.NodeConnector();
            this.nodeConnector1 = new DevComponents.Tree.NodeConnector();
            this.elementStyle1 = new DevComponents.Tree.ElementStyle();
            this.elementStyle2 = new DevComponents.Tree.ElementStyle();
            this.elementStyle3 = new DevComponents.Tree.ElementStyle();
            this.elementStyle4 = new DevComponents.Tree.ElementStyle();
            this.elementStyle6 = new DevComponents.Tree.ElementStyle();
            this.zoomBar = new DevComponents.DotNetBar.Controls.Slider();
            this.labelZoom = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.decisionTree)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // node1
            // 
            this.node1.Name = "node1";
            this.node1.Text = "node1";
            // 
            // decisionTree
            // 
            this.decisionTree.AllowDrop = true;
            this.decisionTree.CellLayout = DevComponents.Tree.eCellLayout.Horizontal;
            this.decisionTree.CommandBackColorGradientAngle = 90;
            this.decisionTree.CommandMouseOverBackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2;
            this.decisionTree.CommandMouseOverBackColorGradientAngle = 90;
            this.decisionTree.ExpandLineColorSchemePart = DevComponents.Tree.eColorSchemePart.BarPopupBackground;
            this.decisionTree.Location = new System.Drawing.Point(3, 3);
            this.decisionTree.Name = "decisionTree";
            this.decisionTree.Nodes.AddRange(new DevComponents.Tree.Node[] {
            this.node2});
            this.decisionTree.NodesConnector = this.nodeConnector2;
            this.decisionTree.NodeStyle = this.elementStyle5;
            this.decisionTree.NodeStyleExpanded = this.elementStyle5;
            this.decisionTree.NodeStyleMouseOver = this.elementStyle7;
            this.decisionTree.NodeStyleSelected = this.elementStyle7;
            this.decisionTree.NodeVerticalSpacing = 25;
            this.decisionTree.PathSeparator = ";";
            this.decisionTree.RenderMode = DevComponents.Tree.eNodeRenderMode.Professional;
            this.decisionTree.RootConnector = this.nodeConnector1;
            this.decisionTree.Size = new System.Drawing.Size(1148, 572);
            this.decisionTree.Styles.Add(this.elementStyle1);
            this.decisionTree.Styles.Add(this.elementStyle2);
            this.decisionTree.Styles.Add(this.elementStyle3);
            this.decisionTree.Styles.Add(this.elementStyle4);
            this.decisionTree.Styles.Add(this.elementStyle5);
            this.decisionTree.Styles.Add(this.elementStyle6);
            this.decisionTree.Styles.Add(this.elementStyle7);
            this.decisionTree.SuspendPaint = false;
            this.decisionTree.TabIndex = 2;
            this.decisionTree.Text = "treeGX1";
            // 
            // node2
            // 
            this.node2.CellLayout = DevComponents.Tree.eCellLayout.Horizontal;
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Style = this.elementStyle5;
            this.node2.StyleExpanded = this.elementStyle5;
            this.node2.StyleMouseOver = this.elementStyle7;
            this.node2.StyleSelected = this.elementStyle7;
            this.node2.Text = "DecisionTree";
            // 
            // elementStyle5
            // 
            this.elementStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            this.elementStyle5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(176)))), ((int)(((byte)(120)))));
            this.elementStyle5.BackColorGradientAngle = 90;
            this.elementStyle5.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle5.BorderBottomWidth = 1;
            this.elementStyle5.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle5.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle5.BorderLeftWidth = 1;
            this.elementStyle5.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle5.BorderRightWidth = 1;
            this.elementStyle5.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle5.BorderTopWidth = 1;
            this.elementStyle5.CornerDiameter = 4;
            this.elementStyle5.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle5.Description = "Orange";
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.PaddingBottom = 3;
            this.elementStyle5.PaddingLeft = 3;
            this.elementStyle5.PaddingRight = 3;
            this.elementStyle5.PaddingTop = 3;
            this.elementStyle5.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle7
            // 
            this.elementStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.elementStyle7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(151)))));
            this.elementStyle7.BackColorGradientAngle = 90;
            this.elementStyle7.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle7.BorderBottomWidth = 1;
            this.elementStyle7.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle7.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle7.BorderLeftWidth = 1;
            this.elementStyle7.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle7.BorderRightWidth = 1;
            this.elementStyle7.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle7.BorderTopWidth = 1;
            this.elementStyle7.CornerDiameter = 4;
            this.elementStyle7.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle7.Description = "Red";
            this.elementStyle7.Name = "elementStyle7";
            this.elementStyle7.PaddingBottom = 3;
            this.elementStyle7.PaddingLeft = 3;
            this.elementStyle7.PaddingRight = 3;
            this.elementStyle7.PaddingTop = 3;
            this.elementStyle7.TextColor = System.Drawing.Color.Black;
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.EndCap = DevComponents.Tree.eConnectorCap.Arrow;
            this.nodeConnector2.LineWidth = 5;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineWidth = 5;
            // 
            // elementStyle1
            // 
            this.elementStyle1.BackColor2SchemePart = DevComponents.Tree.eColorSchemePart.BarBackground2;
            this.elementStyle1.BackColorGradientAngle = 90;
            this.elementStyle1.BackColorSchemePart = DevComponents.Tree.eColorSchemePart.BarBackground;
            this.elementStyle1.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderBottomWidth = 1;
            this.elementStyle1.BorderColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            this.elementStyle1.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderLeftWidth = 1;
            this.elementStyle1.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderRightWidth = 1;
            this.elementStyle1.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderTopWidth = 1;
            this.elementStyle1.CornerDiameter = 4;
            this.elementStyle1.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.PaddingBottom = 3;
            this.elementStyle1.PaddingLeft = 3;
            this.elementStyle1.PaddingRight = 3;
            this.elementStyle1.PaddingTop = 3;
            this.elementStyle1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle2.Description = "Blue";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 3;
            this.elementStyle2.PaddingLeft = 3;
            this.elementStyle2.PaddingRight = 3;
            this.elementStyle2.PaddingTop = 3;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle3
            // 
            this.elementStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle3.BackColorGradientAngle = 90;
            this.elementStyle3.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle3.BorderBottomWidth = 1;
            this.elementStyle3.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle3.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle3.BorderLeftWidth = 1;
            this.elementStyle3.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle3.BorderRightWidth = 1;
            this.elementStyle3.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle3.BorderTopWidth = 1;
            this.elementStyle3.CornerDiameter = 4;
            this.elementStyle3.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle3.Description = "Blue";
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.PaddingBottom = 3;
            this.elementStyle3.PaddingLeft = 3;
            this.elementStyle3.PaddingRight = 3;
            this.elementStyle3.PaddingTop = 3;
            this.elementStyle3.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle4
            // 
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle4.BackColorGradientAngle = 90;
            this.elementStyle4.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle4.BorderBottomWidth = 1;
            this.elementStyle4.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle4.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle4.BorderLeftWidth = 1;
            this.elementStyle4.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle4.BorderRightWidth = 1;
            this.elementStyle4.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle4.BorderTopWidth = 1;
            this.elementStyle4.CornerDiameter = 4;
            this.elementStyle4.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle4.Description = "Blue";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 3;
            this.elementStyle4.PaddingLeft = 3;
            this.elementStyle4.PaddingRight = 3;
            this.elementStyle4.PaddingTop = 3;
            this.elementStyle4.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle6
            // 
            this.elementStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(227)))), ((int)(((byte)(234)))));
            this.elementStyle6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(156)))), ((int)(((byte)(183)))));
            this.elementStyle6.BackColorGradientAngle = 90;
            this.elementStyle6.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle6.BorderBottomWidth = 1;
            this.elementStyle6.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle6.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle6.BorderLeftWidth = 1;
            this.elementStyle6.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle6.BorderRightWidth = 1;
            this.elementStyle6.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle6.BorderTopWidth = 1;
            this.elementStyle6.CornerDiameter = 4;
            this.elementStyle6.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle6.Description = "PurpleMist";
            this.elementStyle6.Name = "elementStyle6";
            this.elementStyle6.PaddingBottom = 3;
            this.elementStyle6.PaddingLeft = 3;
            this.elementStyle6.PaddingRight = 3;
            this.elementStyle6.PaddingTop = 3;
            this.elementStyle6.TextColor = System.Drawing.Color.Black;
            // 
            // zoomBar
            // 
            // 
            // 
            // 
            this.zoomBar.BackgroundStyle.Class = "";
            this.zoomBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.zoomBar.Location = new System.Drawing.Point(679, 12);
            this.zoomBar.Maximum = 500;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(397, 23);
            this.zoomBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.zoomBar.TabIndex = 3;
            this.zoomBar.Text = "Zoom";
            this.zoomBar.Value = 100;
            this.zoomBar.ValueChanged += new System.EventHandler(this.zoomBar_ValueChanged);
            // 
            // labelZoom
            // 
            // 
            // 
            // 
            this.labelZoom.BackgroundStyle.Class = "";
            this.labelZoom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelZoom.Location = new System.Drawing.Point(1082, 12);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(75, 23);
            this.labelZoom.TabIndex = 4;
            this.labelZoom.Text = "labelX1";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.decisionTree);
            this.groupPanel1.Location = new System.Drawing.Point(3, 42);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1163, 602);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "DecisionTree";
            // 
            // frmDecisionTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1169, 647);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.zoomBar);
            this.DoubleBuffered = true;
            this.Name = "frmDecisionTree";
            this.Opacity = 0.9;
            this.Text = "Decision Tree";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.decisionTree)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Tree.Node node1;
        private DevComponents.Tree.TreeGX decisionTree;
        private DevComponents.Tree.Node node2;
        private DevComponents.Tree.NodeConnector nodeConnector2;
        private DevComponents.Tree.ElementStyle elementStyle1;
        private DevComponents.Tree.NodeConnector nodeConnector1;
        private DevComponents.Tree.ElementStyle elementStyle5;
        private DevComponents.Tree.ElementStyle elementStyle7;
        private DevComponents.Tree.ElementStyle elementStyle2;
        private DevComponents.Tree.ElementStyle elementStyle3;
        private DevComponents.Tree.ElementStyle elementStyle4;
        private DevComponents.Tree.ElementStyle elementStyle6;
        private DevComponents.DotNetBar.Controls.Slider zoomBar;
        private DevComponents.DotNetBar.LabelX labelZoom;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;

    }
}

