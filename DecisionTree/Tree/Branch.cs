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

        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private string _operator;
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        Branch(Node parentNode, Node childNode, string _value)
        {
            this.parentNode = parentNode;
            this.childNode = childNode;
            this._value = _value;
        }
    }
}
