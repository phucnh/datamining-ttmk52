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
using DecisionTree;

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
            DataTable _customerDetailsCollection = GetCustomerWithDecisionTree();

            grvCustomer.SelectAll();
            grvCustomer.ClearSelection();

            if (_customerDetailsCollection != null)
            {
                CustomerDetailsService service = new CustomerDetailsService();

                grvCustomer.DataSource = _customerDetailsCollection;
            }
        }

        private DataTable GetCustomerWithDecisionTree()
        {
            DataTable _customerDetailsCollection = new DataTable();

            if (MainForm.decisionTree == null) return null;

            DataTable _table = BindRecordToList();

            if ((_table != null) && (_table.Rows[0] != null))
            {
                DataRow _dataRecord = BindRecordToList().Rows[0];

                AIDT.Tree.Node node = MainForm.decisionTree.DTree.Root;

                while ((node != null) &&
                    (node.Childs != null) &&
                    (node.Childs.Count != 0) &&
                    (node.NodeName != MainForm.decisionTree.ResultName))
                {
                    //var test = (from t in node.Childs where t.NodeValue == _dataRecord[node.NodeName] select t).Single();
                    node = node.Childs.Find(delegate(AIDT.Tree.Node _node)
                    {
                        return _node.NodeValue == _dataRecord[node.NodeName].ToString();
                    });

                    if (node == null) continue;
                }

                if (node == null) return _customerDetailsCollection;

                //My policy
                if (node.ResultValue[0] + node.ResultValue[1] < 5)
                    return _customerDetailsCollection;
                //end my policy

                if ((node.ResultValue[0] > 0) || (node.ResultValue[1] == 0))
                {
                    CustomerDetailsService service = new CustomerDetailsService();
                    _customerDetailsCollection = service.GetByOccupationType("Sinh viên");
                }
                else if ((node.ResultValue[0] == 0) || (node.ResultValue[1] > 0))
                {
                    CustomerDetailsService service = new CustomerDetailsService();
                    _customerDetailsCollection = service.GetByNotOccupationType("Sinh viên");
                }
                else
                {
                    CustomerDetailsService service = new CustomerDetailsService();
                    _customerDetailsCollection = service.GetByOccupationType("Sinh viên");
                    _customerDetailsCollection.Rows.Add(service.GetByNotOccupationType("SinhViên").Rows);
                }
            }

            return _customerDetailsCollection;
        }

        private DataTable BindRecordToList()
        {
            ClassDetail classDetails = new ClassDetail();
            classDetails.ClassName = classNameTextEdit.Text;
            classDetails.ClassTime = Convert.ToInt32(classTimeComboBox.SelectedValue);
            classDetails.CourseId = Convert.ToInt32(courseIdComboBox.SelectedValue);
            classDetails.TeacherId = Convert.ToInt32(teacherIdComboBox.SelectedValue);

            DataTable _dataTable = AIDataset.MakeRecord(classDetails);
            lstExampleRecord.DataSource = _dataTable.Rows[0].ItemArray;

            return _dataTable;
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
