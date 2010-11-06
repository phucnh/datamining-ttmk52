using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using AIDT.ID3;
using AIDT.Tree;

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

        public Tree MakeTreeWithID3(DataTable dataTable)
        {
            if (dataTable.Columns.Count == 0) return null;

            Tree _tree;
            _tree = CreateTree(dataTable);

            if (_tree == null) return null;

            for (int i = 0; i < _tree.Root.Childs.Count; i++)
            {
                if (string.Compare(_tree.Root.Childs[i].NodeName, ResultName) != 0)
                {
                    dataTable.Columns.Remove(_tree.Root.Childs[i].NodeName);
                    //TODO : add function remove dataTable row in here
                    Tree _treeTemp = MakeTreeWithID3(dataTable);
                    _tree.Root.Childs[i] = _treeTemp.Root;
                }
            }

            return _tree;
        }

        public Tree CreateTree(DataTable dataTable)
        {
            if (dataTable.Columns.Count == 0) return null;

            Tree _tree = new Tree();
            Node _root = CalculateRoot(dataTable);

            if (_root == null) return null;

            _tree = AddChildNodeToTree(_tree);

            return _tree;
        }

        protected Tree AddChildNodeToTree(Tree _tree)
        {

            //TODO: Implement ID3 Tree AddChildNode in here
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

                int[,] _propertyDataset = ConvertToArray(_propertyTable);
                _gainDictionary.Add(_column.ColumnName, ID3Algorithm.CalculateGainFunction(_propertyDataset));
            }

            double max = 0;
            String _nameMax = string.Empty;
            foreach (string _key in _gainDictionary.Keys)
            {
                double _value = 0;
                if (_gainDictionary.TryGetValue(_key, out _value))
                {
                    if (_value > max)
                    {
                        max = _value;
                        _nameMax = _key;
                    }
                }
            }
            _root.NodeName = _nameMax;

            return _root;
        }

        public int[,] ConvertToArray(Dictionary<string, int[]> _propertyTable)
        {
            int[,] _result = new int[1, 1];
            int i = 0;

            foreach (int[] _properties in _propertyTable.Values)
            {
                int j = 0;

                foreach (int _property in _properties)
                {
                    _result = new int[i + 1, j + 1];
                    _result[i, j] = _property;

                    j++;
                }

                i++;
            }

            return _result;
        }

    }
}
