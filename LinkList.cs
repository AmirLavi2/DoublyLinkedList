using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_list_001
{
    class LinkList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        private int length = 0;
        public int Length
        {
            get { return length; }
        }

        public LinkList()
        {
            head = null;
            tail = null;
        }

        public void Add(T data)
        {
            Console.WriteLine("LinkList -> Add");
            Node<T> newNode = new Node<T>(data);

            if (head == null) // create new List
            {
                head = newNode;
                tail = newNode;
            }
            else // add new Node to the end of the list
            {
                tail.Next = newNode; // updating the tail pointer to the new last Node 
                newNode.Previous = tail;
            }
            tail = newNode;
            length++;
        }

        public void AddAfterNode(T currNodeData, T newNodeData)
        {
            Console.WriteLine("LinkList -> AddAfterNode");
            Node<T> currNode = FindNodeByData(currNodeData);

            if (currNode == null)
            {
                Console.WriteLine("Error: there is no " + currNodeData + " Node");
                return;
            }
            Node<T> newNode = new Node<T>(newNodeData);
            Node<T> NextNode = currNode.Next;

            newNode.Previous = currNode;
            currNode.Next = newNode;
            newNode.Next = NextNode;

            if (NextNode != null) NextNode.Previous = newNode; 
            else tail = newNode; // the added Node is the new last Node

            length++;
            Console.WriteLine("Added Node " + newNodeData  + " after " + currNodeData);
        }

        public Node<T> FindNodeByData(T data)
        {
            Console.WriteLine("LinkList -> FindNodeByData");
            Node<T> current = head;
            while (current != null && !(current.Data).Equals(data))
            {
                current = current.Next;
            }
            return current;
        }

        public T[] ToArray()
        {
            Console.WriteLine("LinkList -> ToArray");
            Node<T> current = head;
            T[] arr = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                arr[i] = current.Data;
                current = current.Next;
            }
            return arr;
        }

        public void PrintFromHeadForward()
        {
            Console.WriteLine("LinkList -> PrintFromHeadForward");
            Node<T> temp = head;
            while(temp != null)
            {
                Console.Write("(" + temp.Data + ")->");
                temp = temp.Next;
            }
            Console.WriteLine("  <= Data From Head Forward");
        }

        public void PrintFromTailReverse()
        {
            Console.WriteLine("LinkList -> PrintFromTailReverse");
            Node<T> temp = tail;
            while (temp != null)
            {
                Console.Write("(" + temp.Data + ")->");
                temp = temp.Previous;
            }
            Console.WriteLine("  <= Data From Tail Reverse");
        }

        public void PrintLength()
        {
            Console.WriteLine("LinkList -> PrintLength");
            Console.WriteLine("Number of Nodes: " + length);
        }
        
        /*public void RemoveOne(T data)
        {
            Node<T> node = FindNodeByData(data);

            if (node == null)
            {
                Console.WriteLine("Error: there is no node data " + data);
                return;
            }

            Node<T> current = head;
            Node<T> prevNode = head;

            while (!(current.Data).Equals(data))
            {
                prevNode = current;  // האיבר הקודם
                current = current.Next;
            }

            prevNode.Next = current.Next; // קפיצה במצביע מעל האיבר שנבחר
            Console.WriteLine("Node " + data + " was removed");
            length--;
        }*/
        
        public void RemoveOne(T data)
        {
            Console.WriteLine("LinkList -> RemoveOne");

            Node<T> currNode = FindNodeByData(data);
            if (currNode == null)
            {
                Console.WriteLine("Error: cannot remove - there is no " + data + " Node");
                return;
            }

            Node<T> prevNode = currNode.Previous;
            Node<T> nextNode = currNode.Next;

            if(prevNode != null) prevNode.Next = nextNode; 
            else head = currNode.Next; // the removed Node was the first Node

            if (nextNode != null) nextNode.Previous = prevNode; 
            else tail = currNode.Previous; // the removed Node was the last Node

            Console.WriteLine("Node " + data + " was removed\n");
            length--;
        }
        
        public void Clear()
        {
            Console.WriteLine("LinkList -> Clear");
            Node<T> temp = head;

            while (temp.Next != null)
            {
                head = temp.Next;
                temp = temp.Next;
            }
            head = null;
        }
    }
}
