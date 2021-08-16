using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list_001
{
    class Node<T>
    {
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        private Node<T> next;
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        private Node<T> previous;
        public Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Node(T data)
        {
            this.data = data;
            next = null;
            previous = null;
        }
    }
}
