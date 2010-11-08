using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeTest
{
    /// <summary>
    /// Summary description for DecisionTreeTest
    /// </summary>
    [TestClass]
    public class DecisionTreeTest
    {
        public DecisionTreeTest()
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
        public void TestMethod1()
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
            tempString = new string[5]  { "Den", "Thap", "Nhe", "Co", "false" };
            _testDataSet.Rows.Add(tempString);

            AIDT.Tree.Node node = new AIDT.Tree.Node();
            DecisionTree.ID3DecisionTree testDTree = new DecisionTree.ID3DecisionTree();
            testDTree.ResultName = "Result";
            testDTree.ResultToString = "true";
            //node = testDTree.CalculateRoot(_testDataSet);
            testDTree.GetTreeWithID3(_testDataSet);

            //Assert.AreEqual("HairColor", node.NodeName);
        }
    }
}
