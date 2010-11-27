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
    public partial class MainForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        private DataTable _fullDataset;
        public static DecisionTree.ID3DecisionTree decisionTree;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _fullDataset = AIDatabase.Services.AIDataset.MakeFullDataSet();
            if (_fullDataset != null)
                dgrvDataset.DataSource = _fullDataset;
        }

        private void rbtnMakeTree_Click(object sender, EventArgs e)
        {
            decisionTree = new DecisionTree.ID3DecisionTree();
            decisionTree.ResultName = "IsStudentLearned";
            decisionTree.ResultToString = "True";
            decisionTree.GetTreeWithID3(_fullDataset);

            frmDecisionTree _frm = new frmDecisionTree();

            _frm.ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Demo frm = new Demo();

            frm.ShowDialog();
        }
    }
}
