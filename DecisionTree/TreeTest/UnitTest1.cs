using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ChildOfNodeIsNullAfterConstructor()
        {
            AIDT.Tree.Node root = new AIDT.Tree.Node();
            AIDT.Tree.Tree tree = new AIDT.Tree.Tree(root);

            Assert.IsNull(root.Childs,"node's child is not null after constructor");
            //
            // TODO: Add test logic	here
            //
        }
        
        public void CreateTreeTest()
        {
            AIDT.Tree.Tree tree = new AIDT.Tree.Tree();
            AIDT.Tree.Node root = new AIDT.Tree.Node();
            tree.AddNode(root);

            //Assert.AreEqual(1, tree.ChildNodes.Count);
        }

        [TestMethod]
        public void AddNewNode()
        {
            AIDT.Tree.Node node1 = new AIDT.Tree.Node();
            node1.NodeName = "node1";
            AIDT.Tree.Node node2 = new AIDT.Tree.Node();
            node2.NodeName = "node2";
            AIDT.Tree.Node node3 = new AIDT.Tree.Node();
            node3.NodeName = "node3";
            AIDT.Tree.Tree testTree = new AIDT.Tree.Tree();
            testTree.AddNode(node1);
            testTree.AddNode(node2);
            testTree.AddNode(node3);

            testTree.RemoveNode(node2);

            Assert.AreEqual(2, testTree.ChildNodes.Count);
        }

        [TestMethod]
        public void AddNewBranch()
        {
            AIDT.Tree.Branch branch1 = new AIDT.Tree.Branch();
            AIDT.Tree.Branch branch2 = new AIDT.Tree.Branch();
            AIDT.Tree.Branch branch3 = new AIDT.Tree.Branch();
            AIDT.Tree.Tree testTree = new AIDT.Tree.Tree();
            testTree.AddBranch(branch1);
            testTree.AddBranch(branch2);
            testTree.AddBranch(branch3);

            testTree.RemoveBranch(branch3);

            Assert.AreEqual(2, testTree.Branches.Count);
        }

        //[TestMethod]
        //public void CalculateInfo()
        //{
        //    int i = 0;
        //    int[,] Array2D = { {2,2}, {3,0}, {0,1}};
        //    int totalPi = 0;
        //    int totalNi = 0;
        //    for (i = 0; i < Array2D.GetLength(0); i++)
        //    {
        //        totalPi = totalPi + Array2D[i, 0];
        //        totalNi = totalNi + Array2D[i, 1];
        //    }
        //    double expectedResult = (-((double)5 / 8) * Math.Log((double)5 / 8,2) - ((double)3 / 8) * Math.Log((double)3 / 8,2));

        //    AIDT.ID3.ID3Algorithm testID3 = new AIDT.ID3.ID3Algorithm();
        //    double test = testID3.CalculateInformationFunction(totalPi, totalNi);

        //    Assert.AreEqual(expectedResult, testID3.CalculateInformationFunction(totalPi, totalNi));
        //}

        //[TestMethod]
        //public void CalculateEntropy()
        //{
        //    int[,] Array2D = { { 2, 2 }, { 3, 0 }, { 0, 1 } };
        //    AIDT.ID3.ID3Algorithm testID3 = new AIDT.ID3.ID3Algorithm();
        //    double test = testID3.CalculateEntropyFunction(Array2D);

        //    Assert.AreEqual(0.5, testID3.CalculateEntropyFunction(Array2D));
        //}

        //[TestMethod]
        //public void CalculateGain()
        //{
        //    int[,] Array2D = { { 2, 2 }, { 3, 0 }, { 0, 1 } };
        //    AIDT.ID3.ID3Algorithm testID3 = new AIDT.ID3.ID3Algorithm();
        //    double test = testID3.CalculateGainFunction(Array2D);

        //    Assert.AreEqual(0.454, testID3.CalculateGainFunction(Array2D));
        //}
    }
}
