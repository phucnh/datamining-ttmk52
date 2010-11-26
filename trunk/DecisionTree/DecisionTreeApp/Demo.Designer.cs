namespace AIDT.DecisionTreeApp
{
    partial class Demo
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
            this.grpClassDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.SuspendLayout();
            // 
            // grpClassDetails
            // 
            this.grpClassDetails.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpClassDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpClassDetails.Location = new System.Drawing.Point(12, 12);
            this.grpClassDetails.Name = "grpClassDetails";
            this.grpClassDetails.Size = new System.Drawing.Size(357, 477);
            // 
            // 
            // 
            this.grpClassDetails.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpClassDetails.Style.BackColorGradientAngle = 90;
            this.grpClassDetails.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpClassDetails.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpClassDetails.Style.BorderBottomWidth = 1;
            this.grpClassDetails.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpClassDetails.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpClassDetails.Style.BorderLeftWidth = 1;
            this.grpClassDetails.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpClassDetails.Style.BorderRightWidth = 1;
            this.grpClassDetails.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpClassDetails.Style.BorderTopWidth = 1;
            this.grpClassDetails.Style.Class = "";
            this.grpClassDetails.Style.CornerDiameter = 4;
            this.grpClassDetails.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpClassDetails.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpClassDetails.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpClassDetails.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpClassDetails.StyleMouseDown.Class = "";
            this.grpClassDetails.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpClassDetails.StyleMouseOver.Class = "";
            this.grpClassDetails.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpClassDetails.TabIndex = 0;
            this.grpClassDetails.Text = "ClassDetails";
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(808, 501);
            this.Controls.Add(this.grpClassDetails);
            this.DoubleBuffered = true;
            this.Name = "Demo";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.Demo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel grpClassDetails;
    }
}