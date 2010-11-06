using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIDT.Tree
{
    public class Tree
    {
        private Node root;
        private List<Node> _childNodes;
        private List<Branch> _branches;

        public Tree()
        {
            root = null;
            _childNodes = null;
            _branches = null;
        }

        public int ChildNumbers
        {
            get
            {
                if (_childNodes == null)
                {
                    return 0;
                }
                return _childNodes.Count();
            }
        }

        public List<Node> ChildNodes
        {
            get { return _childNodes; }
            set { _childNodes = value; }
        }

        public Node Root
        {
            get { return root; }
            set { root = value; }
        }

        public Tree(Node root)
        {
            Root = root;
            ChildNodes = new List<Node>();
        }

        public List<Branch> Branches
        {
            get { return _branches; }
            set { _branches = value; }
        }

        public void AddNode(Node _node)
        {
            if (ChildNodes == null)
            {
                ChildNodes = new List<Node>();
                ChildNodes.Add(_node);
            }
            else
            {
                ChildNodes.Add(_node);
            }
        }

        public Node RemoveNode(Node _node)
        {
            if (ChildNodes.Find(
                delegate(Node node)
                {
                    return node == _node;
                }) != null)
                ChildNodes.Remove(_node);
            return _node;
        }

        public void AddBranch(Branch _branch)
        {
            if (Branches == null)
            {
                Branches = new List<Branch>();
                Branches.Add(_branch);
            }
            else
            {
                Branches.Add(_branch);
            }
        }

        public Branch RemoveBranch(Branch _branch)
        {
            if (Branches.Find(
                delegate(Branch branch)
                {
                    return branch == _branch;
                }) != null)
                Branches.Remove(_branch);
            return _branch;
        }
    }
}