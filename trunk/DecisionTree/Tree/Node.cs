using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIDT.Tree
{
    public class Node
    {
        private string nodeName;
        private string nodeValue;
        private int[] resultValue; //Phuc add 20101108 -- De de dang kiem tra va tich hop du lieu
        
        private Node parent;
        private List<Node> childs;

        public string NodeName
        {
            get { return nodeName; }
            set { nodeName = value; }
        }

        public string NodeValue
        {
            get { return nodeValue; }
            set { nodeValue = value; }
        }

        //Phuc add 20101108 -- De de dang kiem tra va tich hop du lieu
        public int[] ResultValue
        {
            get { return resultValue; }
            set { resultValue = value; }
        }
        //End phuc add 20101108

        public List<Node> Childs
        {
            get { return childs; }
            set { childs = value; }
        }

        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Node()
        {
            nodeName = string.Empty;
            nodeValue = string.Empty;
            parent = null;
            childs = null;
            // TODO: Implement code in here
        }

        public Node(string _nodeName, string _nodeValue, int[] _resultValue, Node _parent, List<Node> _childs)
        {
            nodeName = _nodeName;
            nodeValue = _nodeValue;
            resultValue = _resultValue;
            parent = _parent;
            childs = _childs;
        }

        public void AddChildNode(Node _node)
        {
            _node.Parent = this;
            if (Childs == null)
            {
                Childs = new List<Node>();
            }
            Childs.Add(_node);
        }

        public int CountingChilds()
        {
            if (childs == null)
            {
                return 0;
            }
            return childs.Count();
        }
    }
}
