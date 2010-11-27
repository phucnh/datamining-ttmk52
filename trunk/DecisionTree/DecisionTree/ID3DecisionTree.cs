using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using AIDT.ID3;
using AIDT.Tree;
using System.Runtime.InteropServices;

namespace DecisionTree
{
    public class ID3DecisionTree
    {
        private Tree dTree;
        public AIDT.Tree.Tree DTree
        {
            get { return dTree; }
            set { dTree = value; }
        }

        private string resultName;
        public string ResultName
        {
            get { return resultName; }
            set { resultName = value; }
        }

        private string resultToString;
        public string ResultToString
        {
            get { return resultToString; }
            set { resultToString = value; }
        }
        private DataTable dataTraining;
        public System.Data.DataTable DataTraining
        {
            get { return dataTraining; }
            set { dataTraining = value; }
        }

        public ID3DecisionTree()
        {
            this.DataTraining = new DataTable();
        }

        public void GetTreeWithID3(DataTable dataTable)
        {
            dTree = MakeTreeWithID3(dataTable);
        }

        public Tree MakeTreeWithID3(DataTable dataTable)
        {
            if (dataTable.Columns.Count <= 1) return null;

            Tree _tree;
            _tree = CreateTree(dataTable);

            if (_tree == null) return null;

            for (int i = 0; i < _tree.Root.Childs.Count; i++)
            {
                DataTable _tempData = dataTable.Copy();
                if (!CheckNodeValueIsOneResult(_tree.Root.Childs[i]))
                {
                    Tree _treeTemp = MakeTreeWithID3(ResizeDataTable(_tempData, _tree.Root.NodeName, _tree.Root.Childs[i].NodeValue)); //remove row and column (Root Name) in here
                    if (_treeTemp != null)
                    {
                        _tree.Root.Childs[i].NodeName = _treeTemp.Root.NodeName;
                        _tree.Root.Childs[i].Childs = _treeTemp.Root.Childs;
                    }
                }
            }

            return _tree;
        }

        private bool CheckNodeValueIsOneResult(Node node)
        {
            for (int i = 0; i < node.ResultValue.GetLength(0); i++)
            {
                if (node.ResultValue[i] == 0) return true;
            }
            return false;
        }

        private DataTable ResizeDataTable(DataTable _dataTable, string _columnName, string _value)
        {
            //if (_dataTable.Columns.Count <= 1) return _dataTable;

            DataTable _dataTableTemp = _dataTable;

            int _columnCount = _dataTableTemp.Columns[_columnName].Ordinal;
            int[] _markRowDelete = new int[1];
            int i = 0;

            foreach (DataRow _row in _dataTableTemp.Rows)
            {
                if (string.CompareOrdinal(_row[_columnCount].ToString(), _value) != 0)
                {
                    Array.Resize(ref _markRowDelete, i + 1);
                    _markRowDelete[i] = _dataTableTemp.Rows.IndexOf(_row);
                    i++;
                }

            }
            //_dataTableTemp.AcceptChanges();
            if (i != 0)
            {
                for (int j = (_markRowDelete.GetLength(0) - 1); j >= 0; j--)
                    _dataTableTemp.Rows.RemoveAt(_markRowDelete[j]);
            }

            _dataTableTemp.Columns.Remove(_columnName);

            return _dataTableTemp;
        }

        public Tree CreateTree(DataTable dataTable)
        {
            if (dataTable.Columns.Count == 0) return null;

            Tree _tree = new Tree();
            Node _root = CalculateRoot(dataTable);

            if (_root == null) return null;
            if (string.IsNullOrEmpty(_root.NodeName)) return null;

            _tree.Root = _root;
            _tree = AddChildNodeToTree(_tree, dataTable);

            return _tree;
        }

        protected Tree AddChildNodeToTree(Tree _tree, DataTable _dataTable)
        {

            Dictionary<string, int[]> _propertyTable = new Dictionary<string, int[]>();

            foreach (DataRow row in _dataTable.Rows)
            {
                int _resultCount = 0;
                int _negativeResultCount = 0;

                if (string.CompareOrdinal(row[ResultName].ToString(), resultToString) == 0)
                    _resultCount++;
                else
                    _negativeResultCount++;

                int[] _propertyTemp = { _resultCount, _negativeResultCount };
                //int[] _propertyTemp;

                if (_propertyTable.ContainsKey(row[_tree.Root.NodeName].ToString()))
                {
                    if (_propertyTable.TryGetValue(row[_tree.Root.NodeName].ToString(), out _propertyTemp))
                    {
                        _propertyTemp[0] += _resultCount;
                        _propertyTemp[1] += _negativeResultCount;
                    }
                    _propertyTable.Remove(row[_tree.Root.NodeName].ToString());
                    _propertyTable.Add(row[_tree.Root.NodeName].ToString(), _propertyTemp);
                }
                else
                {
                    _propertyTable.Add(row[_tree.Root.NodeName].ToString(), _propertyTemp);
                }
            }

            foreach (string _key in _propertyTable.Keys)
            {
                int[] _resultValue;

                if (_propertyTable.TryGetValue(_key, out _resultValue))
                {
                    Node _childNode = new Node("", _key, _resultValue, _tree.Root, new List<Node>());
                    //Branch _branch = new Branch(_tree.Root, _childNode, _key);
                    _tree.AddNodeToRoot(_childNode);
                    //_tree.Branches.Add(_branch);
                }
            }

            return _tree;
        }

        public Node CalculateRoot(DataTable _dataTable)
        {
            Node _root = new Node();
            Dictionary<string, double> _gainDictionary = new Dictionary<string, double>();

            foreach (DataColumn _column in _dataTable.Columns)
            {
                Dictionary<string, int[]> _propertyTable = new Dictionary<string, int[]>();
                int _resultCount = 0;
                int _negativeResultCount = 0;
                int _columnNumber = _column.Ordinal;

                if (_column.ColumnName == ResultName)
                    continue;

                foreach (DataRow row in _dataTable.Rows)
                {
                    if (string.CompareOrdinal(row[ResultName].ToString(), resultToString) == 0)
                        _resultCount++;
                    else
                        _negativeResultCount++;

                    int[] _propertyTemp = { _resultCount, _negativeResultCount };
                    //int[] _propertyTemp;

                    if (_propertyTable.ContainsKey(row[_column].ToString()))
                    {
                        if (_propertyTable.TryGetValue(row[_column].ToString(), out _propertyTemp))
                        {
                            _propertyTemp[0] += _resultCount;
                            _propertyTemp[1] += _negativeResultCount;
                        }
                        _propertyTable.Remove(row[_column].ToString());
                        _propertyTable.Add(row[_column].ToString(), _propertyTemp);
                    }
                    else
                    {
                        _propertyTable.Add(row[_column].ToString(), _propertyTemp);
                    }

                    _resultCount = 0;
                    _negativeResultCount = 0;
                }

                //int[,] _propertyDataset = ConvertToArray(_propertyTable);
                int[][] _propertyDatasetTemp = _propertyTable.Values.ToArray();
                int[,] _propertyDataset = ConvertToArray(_propertyDatasetTemp);
                _gainDictionary.Add(_column.ColumnName, ID3Algorithm.CalculateGainFunction(_propertyDataset));
            }

            double max = 0;
            String _nameMax = string.Empty;
            foreach (string _key in _gainDictionary.Keys)
            {
                double _value = 0;
                if (_gainDictionary.TryGetValue(_key, out _value))
                {
                    if (_value >= max)
                    {
                        max = _value;
                        _nameMax = _key;
                    }
                }
            }
            _root.NodeName = _nameMax;

            return _root;
        }

        private int[,] ConvertToArray(int[][] _propertyDatasetTemp)
        {
            int[,] _result = new int[_propertyDatasetTemp.GetLength(0), 2];

            for (int i = 0; i < _propertyDatasetTemp.GetLength(0); i++)
                for (int j = 0; j < 2; j++)
                {
                    _result[i, j] = _propertyDatasetTemp[i][j];
                }

            return _result;
        }

    }
}
