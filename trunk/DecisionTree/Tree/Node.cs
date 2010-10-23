using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree
{
    public class Node
    {
        private Node parent;
        private List<Node> childs;

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
            parent = null;
            childs = null;
            // TODO: Implement code in here
        }

        public void AddChildNode(Node _node)
        {
            _node.Parent = this;
            childs.Add(_node);
        }
    }
}
