using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AIDT.Tree;
using DevComponents.Tree;

namespace AIDT.DecisionTreeApp
{
    public partial class Demo : DevComponents.DotNetBar.Office2007Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void Demo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aIProjectDataSet.ClassDetails' table. You can move, or remove it, as needed.
            this.classDetailsTableAdapter.Fill(this.aIProjectDataSet.ClassDetails);
            // TODO: This line of code loads data into the 'aIProjectDataSet.ClassDetails' table. You can move, or remove it, as needed.
            this.classDetailsTableAdapter.Fill(this.aIProjectDataSet.ClassDetails);

        }

        private void classDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.classDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.aIProjectDataSet);

        }

        private void classDetailsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.classDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.aIProjectDataSet);

        }
    }
}
