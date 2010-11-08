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

namespace DecisionTreeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<AIDT.Tree.Node> result = new List<AIDT.Tree.Node>();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Tree test = TestTree();
            //AIDT.Tree.Node rootNode = test.Root;
            //GetListNode(rootNode);
            //DrawTree();
        }

        public Tree TestTree()
        {
            Tree testTree = new Tree();

            AIDT.Tree.Node node3 = new AIDT.Tree.Node();
            node3.NodeName = "node3";

            AIDT.Tree.Node node4 = new AIDT.Tree.Node();
            node4.NodeName = "node4";

            AIDT.Tree.Node node5 = new AIDT.Tree.Node();
            node5.NodeName = "node5";

            AIDT.Tree.Node node1 = new AIDT.Tree.Node("node1", null, null, null);
            node1.AddChildNode(node3);
            node1.AddChildNode(node4);

            AIDT.Tree.Node node2 = new AIDT.Tree.Node("node2", null, null, null);
            node2.AddChildNode(node5);

            List<AIDT.Tree.Node> listChildNode = new List<AIDT.Tree.Node>();
            listChildNode.Add(node1);
            listChildNode.Add(node2);
            listChildNode.Add(node3);
            listChildNode.Add(node4);
            listChildNode.Add(node5);

            AIDT.Tree.Node rootNode = new AIDT.Tree.Node();
            rootNode.NodeName = "Root";
            rootNode.AddChildNode(node1);
            rootNode.AddChildNode(node2);

            testTree.Root = rootNode;
            testTree.ChildNodes = listChildNode;

            return testTree;
        }

        List<DevComponents.Tree.Node> atempListNode = new List<DevComponents.Tree.Node>();

        public TreeNode GetListNode(AIDT.Tree.Node root)
        {
            TreeNode tempNode = new TreeNode();
            if (root != null)
            {
                result.Add(root);
                TreeNode currentParentNode = new TreeNode();
                currentParentNode.Name = root.NodeName;
                currentParentNode.Text = root.NodeName;
                //currentParentNode.Expanded = true;
                
                if ((root.Childs != null) && (root.Childs.Count != 0))
                {
                    foreach (AIDT.Tree.Node childNode in root.Childs)
                    {
                        GetListNode(childNode);
                        if (!result.Contains(childNode))
                        {
                            result.Add(childNode);
                            //tempNode.Name = childNode.NodeName;
                            //tempNode.Text = childNode.NodeName;
                            //currentParentNode.Nodes.Add(tempNode);
                        }
                        tempNode.Name = childNode.NodeName;
                        tempNode.Text = childNode.NodeName;
                        //tempNode.Expanded = true;
                        currentParentNode.Nodes.Add(tempNode);
                    }
                }
                //if (!this.node1.Nodes.Contains(currentParentNode))
                //{
                //    this.node1.Nodes.Add(currentParentNode);
                //}
                return currentParentNode;
            }
            return null ;
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
            Tree test = TestTree();
            AIDT.Tree.Node rootNode = test.Root;
            TreeNode node = GetListNode(rootNode);
            this.treeView1.Nodes.Add(node);
            //this.node1.Nodes.Add(node);
            //this.treeGX1.Nodes.Remove(this.node1);
            //this.treeGX1.AllowDrop = true;
            //this.treeGX1.CommandBackColorGradientAngle = 90;
            //this.treeGX1.CommandMouseOverBackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2;
            //this.treeGX1.CommandMouseOverBackColorGradientAngle = 90;
            //this.treeGX1.ExpandLineColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            //this.treeGX1.Location = new System.Drawing.Point(70, 83);
            //this.treeGX1.Name = "treeGX1";
            //this.treeGX1.Nodes.AddRange(new DevComponents.Tree.Node[] {
            //node});
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

    }
}
