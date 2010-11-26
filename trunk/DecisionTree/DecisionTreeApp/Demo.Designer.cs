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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Demo));
            System.Windows.Forms.Label classIdLabel;
            System.Windows.Forms.Label classNameLabel;
            System.Windows.Forms.Label classTimeLabel;
            System.Windows.Forms.Label courseIdLabel;
            System.Windows.Forms.Label teacherIdLabel;
            this.grpClassDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.aIProjectDataSet = new AIDT.DecisionTreeApp.AIProjectDataSet();
            this.classDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.classDetailsTableAdapter = new AIDT.DecisionTreeApp.AIProjectDataSetTableAdapters.ClassDetailsTableAdapter();
            this.tableAdapterManager = new AIDT.DecisionTreeApp.AIProjectDataSetTableAdapters.TableAdapterManager();
            this.classDetailsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.classDetailsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.classIdLabel1 = new System.Windows.Forms.Label();
            this.classNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.classTimeComboBox = new System.Windows.Forms.ComboBox();
            this.courseIdComboBox = new System.Windows.Forms.ComboBox();
            this.teacherIdComboBox = new System.Windows.Forms.ComboBox();
            classIdLabel = new System.Windows.Forms.Label();
            classNameLabel = new System.Windows.Forms.Label();
            classTimeLabel = new System.Windows.Forms.Label();
            courseIdLabel = new System.Windows.Forms.Label();
            teacherIdLabel = new System.Windows.Forms.Label();
            this.grpClassDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aIProjectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDetailsBindingNavigator)).BeginInit();
            this.classDetailsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classNameTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpClassDetails
            // 
            this.grpClassDetails.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpClassDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpClassDetails.Controls.Add(classIdLabel);
            this.grpClassDetails.Controls.Add(this.classIdLabel1);
            this.grpClassDetails.Controls.Add(this.teacherIdComboBox);
            this.grpClassDetails.Controls.Add(classNameLabel);
            this.grpClassDetails.Controls.Add(teacherIdLabel);
            this.grpClassDetails.Controls.Add(this.classNameTextEdit);
            this.grpClassDetails.Controls.Add(this.courseIdComboBox);
            this.grpClassDetails.Controls.Add(classTimeLabel);
            this.grpClassDetails.Controls.Add(courseIdLabel);
            this.grpClassDetails.Controls.Add(this.classTimeComboBox);
            this.grpClassDetails.Location = new System.Drawing.Point(12, 56);
            this.grpClassDetails.Name = "grpClassDetails";
            this.grpClassDetails.Size = new System.Drawing.Size(353, 347);
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
            // aIProjectDataSet
            // 
            this.aIProjectDataSet.DataSetName = "AIProjectDataSet";
            this.aIProjectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // classDetailsBindingSource
            // 
            this.classDetailsBindingSource.DataMember = "ClassDetails";
            this.classDetailsBindingSource.DataSource = this.aIProjectDataSet;
            // 
            // classDetailsTableAdapter
            // 
            this.classDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClassArrangementTableAdapter = null;
            this.tableAdapterManager.ClassDetailsTableAdapter = this.classDetailsTableAdapter;
            this.tableAdapterManager.ClassTimeTableAdapter = null;
            this.tableAdapterManager.CourseCertificateTableAdapter = null;
            this.tableAdapterManager.CourseDetailsTableAdapter = null;
            this.tableAdapterManager.CourseGroupTableAdapter = null;
            this.tableAdapterManager.CustomerDetailsTableAdapter = null;
            this.tableAdapterManager.OccupationTypeTableAdapter = null;
            this.tableAdapterManager.TeacherDetailsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AIDT.DecisionTreeApp.AIProjectDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // classDetailsBindingNavigator
            // 
            this.classDetailsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.classDetailsBindingNavigator.BindingSource = this.classDetailsBindingSource;
            this.classDetailsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.classDetailsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.classDetailsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.classDetailsBindingNavigatorSaveItem});
            this.classDetailsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.classDetailsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.classDetailsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.classDetailsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.classDetailsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.classDetailsBindingNavigator.Name = "classDetailsBindingNavigator";
            this.classDetailsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.classDetailsBindingNavigator.Size = new System.Drawing.Size(828, 25);
            this.classDetailsBindingNavigator.TabIndex = 1;
            this.classDetailsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // classDetailsBindingNavigatorSaveItem
            // 
            this.classDetailsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.classDetailsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("classDetailsBindingNavigatorSaveItem.Image")));
            this.classDetailsBindingNavigatorSaveItem.Name = "classDetailsBindingNavigatorSaveItem";
            this.classDetailsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.classDetailsBindingNavigatorSaveItem.Text = "Save Data";
            this.classDetailsBindingNavigatorSaveItem.Click += new System.EventHandler(this.classDetailsBindingNavigatorSaveItem_Click_1);
            // 
            // classIdLabel
            // 
            classIdLabel.AutoSize = true;
            classIdLabel.Location = new System.Drawing.Point(33, 44);
            classIdLabel.Name = "classIdLabel";
            classIdLabel.Size = new System.Drawing.Size(47, 13);
            classIdLabel.TabIndex = 2;
            classIdLabel.Text = "Class Id:";
            // 
            // classIdLabel1
            // 
            this.classIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classDetailsBindingSource, "ClassId", true));
            this.classIdLabel1.Location = new System.Drawing.Point(115, 44);
            this.classIdLabel1.Name = "classIdLabel1";
            this.classIdLabel1.Size = new System.Drawing.Size(121, 23);
            this.classIdLabel1.TabIndex = 3;
            this.classIdLabel1.Text = "label1";
            // 
            // classNameLabel
            // 
            classNameLabel.AutoSize = true;
            classNameLabel.Location = new System.Drawing.Point(33, 86);
            classNameLabel.Name = "classNameLabel";
            classNameLabel.Size = new System.Drawing.Size(66, 13);
            classNameLabel.TabIndex = 4;
            classNameLabel.Text = "Class Name:";
            // 
            // classNameTextEdit
            // 
            this.classNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.classDetailsBindingSource, "ClassName", true));
            this.classNameTextEdit.Location = new System.Drawing.Point(115, 83);
            this.classNameTextEdit.Name = "classNameTextEdit";
            this.classNameTextEdit.Size = new System.Drawing.Size(121, 20);
            this.classNameTextEdit.TabIndex = 5;
            // 
            // classTimeLabel
            // 
            classTimeLabel.AutoSize = true;
            classTimeLabel.Location = new System.Drawing.Point(33, 139);
            classTimeLabel.Name = "classTimeLabel";
            classTimeLabel.Size = new System.Drawing.Size(61, 13);
            classTimeLabel.TabIndex = 6;
            classTimeLabel.Text = "Class Time:";
            // 
            // classTimeComboBox
            // 
            this.classTimeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classDetailsBindingSource, "ClassTime", true));
            this.classTimeComboBox.FormattingEnabled = true;
            this.classTimeComboBox.Location = new System.Drawing.Point(115, 136);
            this.classTimeComboBox.Name = "classTimeComboBox";
            this.classTimeComboBox.Size = new System.Drawing.Size(121, 21);
            this.classTimeComboBox.TabIndex = 7;
            // 
            // courseIdLabel
            // 
            courseIdLabel.AutoSize = true;
            courseIdLabel.Location = new System.Drawing.Point(33, 190);
            courseIdLabel.Name = "courseIdLabel";
            courseIdLabel.Size = new System.Drawing.Size(55, 13);
            courseIdLabel.TabIndex = 8;
            courseIdLabel.Text = "Course Id:";
            // 
            // courseIdComboBox
            // 
            this.courseIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classDetailsBindingSource, "CourseId", true));
            this.courseIdComboBox.FormattingEnabled = true;
            this.courseIdComboBox.Location = new System.Drawing.Point(115, 187);
            this.courseIdComboBox.Name = "courseIdComboBox";
            this.courseIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.courseIdComboBox.TabIndex = 9;
            // 
            // teacherIdLabel
            // 
            teacherIdLabel.AutoSize = true;
            teacherIdLabel.Location = new System.Drawing.Point(33, 241);
            teacherIdLabel.Name = "teacherIdLabel";
            teacherIdLabel.Size = new System.Drawing.Size(62, 13);
            teacherIdLabel.TabIndex = 10;
            teacherIdLabel.Text = "Teacher Id:";
            // 
            // teacherIdComboBox
            // 
            this.teacherIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classDetailsBindingSource, "TeacherId", true));
            this.teacherIdComboBox.FormattingEnabled = true;
            this.teacherIdComboBox.Location = new System.Drawing.Point(115, 238);
            this.teacherIdComboBox.Name = "teacherIdComboBox";
            this.teacherIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.teacherIdComboBox.TabIndex = 11;
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(828, 418);
            this.Controls.Add(this.classDetailsBindingNavigator);
            this.Controls.Add(this.grpClassDetails);
            this.DoubleBuffered = true;
            this.Name = "Demo";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.Demo_Load);
            this.grpClassDetails.ResumeLayout(false);
            this.grpClassDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aIProjectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classDetailsBindingNavigator)).EndInit();
            this.classDetailsBindingNavigator.ResumeLayout(false);
            this.classDetailsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classNameTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel grpClassDetails;
        private AIProjectDataSet aIProjectDataSet;
        private System.Windows.Forms.BindingSource classDetailsBindingSource;
        private AIDT.DecisionTreeApp.AIProjectDataSetTableAdapters.ClassDetailsTableAdapter classDetailsTableAdapter;
        private AIDT.DecisionTreeApp.AIProjectDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator classDetailsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton classDetailsBindingNavigatorSaveItem;
        private System.Windows.Forms.Label classIdLabel1;
        private System.Windows.Forms.ComboBox teacherIdComboBox;
        private DevExpress.XtraEditors.TextEdit classNameTextEdit;
        private System.Windows.Forms.ComboBox courseIdComboBox;
        private System.Windows.Forms.ComboBox classTimeComboBox;
    }
}