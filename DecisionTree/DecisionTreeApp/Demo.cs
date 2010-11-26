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
using AIDT.AIDatabase;
using AIDT.AIDatabase.Services;

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
            // TODO: This line of code loads data into the 'aIProjectDataSet.TeacherDetails' table. You can move, or remove it, as needed.
            this.teacherDetailsTableAdapter.Fill(this.aIProjectDataSet.TeacherDetails);
            // TODO: This line of code loads data into the 'aIProjectDataSet.CourseDetails' table. You can move, or remove it, as needed.
            this.courseDetailsTableAdapter.Fill(this.aIProjectDataSet.CourseDetails);
            // TODO: This line of code loads data into the 'aIProjectDataSet.ClassTime' table. You can move, or remove it, as needed.
            this.classTimeTableAdapter.Fill(this.aIProjectDataSet.ClassTime);
            // TODO: This line of code loads data into the 'aIProjectDataSet.ClassDetails' table. You can move, or remove it, as needed.
            //this.classDetailsTableAdapter.Fill(this.aIProjectDataSet.ClassDetails);
            // TODO: This line of code loads data into the 'aIProjectDataSet.ClassDetails' table. You can move, or remove it, as needed.
            //this.classDetailsTableAdapter.Fill(this.aIProjectDataSet.ClassDetails);


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

        private void btnTest_Click(object sender, EventArgs e)
        {
            List<CustomerDetail> _customerDetailsCollection = GetCustomerWithDecisionTree();

            if (_customerDetailsCollection != null)
                grvCustomer.DataSource = _customerDetailsCollection;
        }

        private List<CustomerDetail> GetCustomerWithDecisionTree()
        {
            List<CustomerDetail> _customerDetailsCollection = new List<CustomerDetail>();

            if (MainForm.decisionTree == null) return null;

            return _customerDetailsCollection;
        }

        private string[] BindRecordToList()
        {
            ClassDetail classDetails = new ClassDetail();
            classDetails.ClassName = classNameTextEdit.Text;
            classDetails.ClassTime = Convert.ToInt32(classTimeComboBox.SelectedValue);
            classDetails.CourseId = Convert.ToInt32(courseIdComboBox.SelectedValue);
            classDetails.TeacherId = Convert.ToInt32(teacherIdComboBox.SelectedValue);

            string[] _record = AIDataset.MakeRecord(classDetails);
            lstExampleRecord.DataSource = _record;

            return _record;
        }

        private void classNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            BindRecordToList();
        }

        private void classTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRecordToList();
        }

        private void courseIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRecordToList();
        }

        private void teacherIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRecordToList();
        }
    }
}
