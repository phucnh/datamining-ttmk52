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
    public partial class frmDecisionTree : DevComponents.DotNetBar.Office2007Form
    {
        public frmDecisionTree()
        {
            InitializeComponent();
        }

        public List<AIDT.Tree.Node> result = new List<AIDT.Tree.Node>();

        private void Form1_Load(object sender, EventArgs e)
        {
            if ((MainForm.decisionTree != null) &&
                (MainForm.decisionTree.DTree != null) &&
                (MainForm.decisionTree.DTree.Root != null))
            {
                DevComponents.Tree.Node treeGXNode = GetListNode(MainForm.decisionTree.DTree.Root);
                this.node2.Nodes.Add(treeGXNode);
            }
        }

        void TestMethod()
        {
            System.Data.DataTable _testDataSet = new System.Data.DataTable();
            _testDataSet.Columns.Add("HairColor");
            _testDataSet.Columns.Add("Height");
            _testDataSet.Columns.Add("Weight");
            _testDataSet.Columns.Add("Use");
            _testDataSet.Columns.Add("Result");

            string[] tempString = { "Den", "Tam thuoc", "Nhe", "Khong", "true" };
            _testDataSet.Rows.Add(tempString);
            tempString = new string[5] { "Den", "Cao", "Vua phai", "Co", "false" };
            _testDataSet.Rows.Add(tempString);
            tempString = new string[5] { "Ram", "Thap", "Vua phai", "Co", "false" };
            _testDataSet.Rows.Add(tempString);
            tempString = new string[5] { "Den", "Thap", "Vua phai", "Khong", "true" };
            _testDataSet.Rows.Add(tempString);
            tempString = new string[5] { "Bac", "Tam thuoc", "Nang", "Khong", "true" };
            _testDataSet.Rows.Add(tempString);
            tempString = new string[5] { "Ram", "Cao", "Nang", "Khong", "false" };
            _testDataSet.Rows.Add(tempString);
            tempString = new string[5] { "Ram", "Tam thuoc", "Nang", "Khong", "false" };
            _testDataSet.Rows.Add(tempString);
            tempString = new string[5] { "Den", "Thap", "Nhe", "Co", "false" };
            _testDataSet.Rows.Add(tempString);

            AIDT.Tree.Node node = new AIDT.Tree.Node();
            DecisionTree.ID3DecisionTree testDTree = new DecisionTree.ID3DecisionTree();
            testDTree.ResultName = "Result";
            testDTree.ResultToString = "true";
            //node = testDTree.CalculateRoot(_testDataSet);
            testDTree.GetTreeWithID3(_testDataSet);

            //AIDT.Tree.Node rootNode = test.Root;
            //TreeNode node = GetListNode(rootNode);
            DevComponents.Tree.Node treeGXNode = GetListNode(testDTree.DTree.Root);
            this.node2.Nodes.Add(treeGXNode);
            //this.node2.Visible = false;
            //this.node2.Text = treeGXNode.Text;
            //this.node2 = treeGXNode;
            //foreach (DevComponents.Tree.Node childNode in treeGXNode.Nodes)
            //for (int i = 0; i < treeGXNode.Nodes.Count; i++)
            //    this.node2.Nodes.Add(treeGXNode.Nodes[i]);


        }

        //public Tree TestTree()
        //{
        //    //Tree testTree = new Tree();

        //    AIDT.Tree.Node node3 = new AIDT.Tree.Node();
        //    node3.NodeName = "node3";

        //    AIDT.Tree.Node node4 = new AIDT.Tree.Node();
        //    node4.NodeName = "node4";

        //    AIDT.Tree.Node node5 = new AIDT.Tree.Node();
        //    node5.NodeName = "node5";

        //    AIDT.Tree.Node node1 = new AIDT.Tree.Node("node1", null, null, null, null);
        //    node1.AddChildNode(node3);
        //    node1.AddChildNode(node4);

        //    AIDT.Tree.Node node2 = new AIDT.Tree.Node("node2", null, null, null, null);
        //    node2.AddChildNode(node5);

        //    List<AIDT.Tree.Node> listChildNode = new List<AIDT.Tree.Node>();
        //    listChildNode.Add(node1);
        //    listChildNode.Add(node2);
        //    listChildNode.Add(node3);
        //    listChildNode.Add(node4);
        //    listChildNode.Add(node5);

        //    AIDT.Tree.Node rootNode = new AIDT.Tree.Node();
        //    rootNode.NodeName = "Root";
        //    rootNode.AddChildNode(node1);
        //    rootNode.AddChildNode(node2);

        //    testTree.Root = rootNode;
        //    testTree.ChildNodes = listChildNode;

        //    return testTree;
        //}

        List<DevComponents.Tree.Node> atempListNode = new List<DevComponents.Tree.Node>();

        public DevComponents.Tree.Node GetListNode(AIDT.Tree.Node root)
        {
            if (root != null)
            {
                result.Add(root);
                DevComponents.Tree.Node currentParentNode = new DevComponents.Tree.Node();
                currentParentNode.Name = root.NodeName;
                StringBuilder _format = new StringBuilder(String.Empty);
                //_format.AppendFormat("( {0} ) {1} ", root.NodeValue, root.NodeName);
                if (root.ResultValue == null)
                    _format.AppendFormat("( Parent value: {0} ) {1} ",root.NodeValue, root.NodeName);
                else
                    _format.AppendFormat("( Parent value: {0} ) {1}. Sinh viên: {2}. Đi làm: {3} ",
                        root.NodeValue,
                        root.NodeName,
                        root.ResultValue[0].ToString(),
                        root.ResultValue[1].ToString());

                currentParentNode.Text = _format.ToString();
                currentParentNode.Expanded = true;

                if ((root.Childs != null) && (root.Childs.Count != 0))
                {
                    foreach (AIDT.Tree.Node childNode in root.Childs)
                    {
                        DevComponents.Tree.Node tempNode = GetListNode(childNode);
                        if (!result.Contains(childNode))
                        {
                            result.Add(childNode);
                            //tempNode.Name = childNode.NodeName;
                            //tempNode.Text = childNode.NodeName;
                            //currentParentNode.Nodes.Add(tempNode);
                        }
                        if (tempNode == null) continue;
                        //tempNode.Name = childNode.NodeName;
                        //tempNode.Text = childNode.NodeName;
                        tempNode.Expanded = true;
                        currentParentNode.Nodes.Add(tempNode);
                    }
                }
                //if (!this.node1.Nodes.Contains(currentParentNode))
                //{
                //    this.node1.Nodes.Add(currentParentNode);
                //}
                return currentParentNode;
            }
            return null;
        }

        //public void GetListNode(AIDT.Tree.Node root)
        //{
        //    if (root != null)
        //    {
        //        result.Add(root);
        //        if ((root.Childs != null) && (root.Childs.Count != 0))
        //        {
        //            foreach (AIDT.Tree.Node childNode in root.Childs)
        //            {
        //                GetListNode(childNode);
        //                if (!result.Contains(childNode))
        //                    result.Add(childNode);
        //            }
        //        }
        //    }
        //}

        public void DrawTree()
        {
            List<AIDT.Tree.Node> tempListNode = new List<AIDT.Tree.Node>();
            DevComponents.Tree.Node parentNodeGX = new DevComponents.Tree.Node();
            DevComponents.Tree.Node nodeChildGX = new DevComponents.Tree.Node();

            if ((result != null) && (result.Count != 0))
            {
                this.node1.Text = result[0].NodeName;
                tempListNode.Add(result[0]);
                foreach (AIDT.Tree.Node nodeTree in result)
                {
                    if (!tempListNode.Contains(nodeTree))
                    {
                        parentNodeGX.Name = nodeTree.NodeName;
                        parentNodeGX.Text = nodeTree.NodeName;

                        if ((nodeTree.Childs != null) && (nodeTree.Childs.Count != 0))
                        {
                            foreach (AIDT.Tree.Node nodeChild in nodeTree.Childs)
                            {
                                nodeChildGX.Name = nodeChild.NodeName;
                                nodeChildGX.Text = nodeChild.NodeName;
                                parentNodeGX.Nodes.Add(nodeChildGX);
                                tempListNode.Add(nodeChild);
                            }
                        }
                        tempListNode.Add(nodeTree);
                        this.node1.Nodes.Add(parentNodeGX);
                    }
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Tree test = TestTree();
            //AIDT.Tree.Node rootNode = test.Root;
            //TestMethod();
            //TreeNode node = GetListNode(rootNode);
            //DevComponents.Tree.Node node = GetListNode(rootNode);
            //this.node2.Nodes.Add(node);
            //this.treeView1.Nodes.Add(node);
            //this.node1.Nodes.Add(node);
            //this.treeGX1.Nodes.Remove(this.node1);
            //this.treeGX1.NodesConnector = this.nodeConnector2;
            //this.treeGX1.NodeStyle = this.elementStyle1;
            //this.treeGX1.PathSeparator = ";";
            //this.treeGX1.RootConnector = this.nodeConnector1;
            //this.treeGX1.Size = new System.Drawing.Size(1055, 449);
            //this.treeGX1.Styles.Add(this.elementStyle1);
            //this.treeGX1.SuspendPaint = false;
            //this.treeGX1.TabIndex = 2;
            //this.treeGX1.Text = "treeGX1";

            //DrawTree();

            //this.node1.Expanded = true;
            //this.node1.Name = "node1";

            //DevComponents.Tree.Node node2 = new DevComponents.Tree.Node();
            //node2.Name = "node2";
            //node2.Text = "node2";
            //node2.Expanded = true;

            //node1.Nodes.Add(node2);

            //this.treeGX1.Nodes.Add(node2);
        }

        private void zoomBar_ValueChanged(object sender, EventArgs e)
        {
            decisionTree.Zoom = (float)zoomBar.Value / 100;
            labelZoom.Text = zoomBar.Value.ToString() + "%";
        }

    }
}
