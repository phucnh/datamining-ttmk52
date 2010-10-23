using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    public class Tree
    {
        private Node root;
        private List<Node> _childNodes;
        private List<Branch> _branches;
        private int nodeCount;


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

        public int NodeCount
        {
            get { return nodeCount; }
            set { nodeCount = value; }
        }

        public Tree(Node root)
        {
            Root = root;
            ChildNodes = new List<Node>();
            NodeCount = 1;
        }

        public void AddNode(Node _node)
        {
            ChildNodes.Add(_node);
            if (_node.Childs != null)
                NodeCount += _node.Childs.Count + 1;
            else
                NodeCount++;
        }

        public Node RemoveNode(Node _node)
        {
            if (ChildNodes.Find(
                delegate(Node node)
                {
                    return node == _node;
                }) != null)
                ChildNodes.Remove(_node);
            NodeCount--;

            return _node;
        }
    }
}