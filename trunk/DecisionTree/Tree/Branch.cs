using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    public class Branch
    {
        private Node parentNode;
        public Node ParentNode
        {
            get { return parentNode; }
            set { parentNode = value; }
        }

        private Node childNode;
        public Node ChildNode
        {
            get { return childNode; }
            set { childNode = value; }
        }

        private string branchValue;
        public string BranchValue
        {
            get { return branchValue; }
            set { branchValue = value; }
        }

        private string _operator;
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public Branch()
        {
            parentNode = null;
            childNode = null;
            branchValue = string.Empty;
        }

        public Branch(Node parentNode, Node childNode, string _branchValue)
        {
            this.parentNode = parentNode;
            this.childNode = childNode;
            this.branchValue = _branchValue;
        }
    }
}
