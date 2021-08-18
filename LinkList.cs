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

        public void AddAfterNode(T prevNodeData, T newNodeData)
        {
            Node<T> node = FindNodeByData(prevNodeData);

            if (node == null)
            {
                Console.WriteLine("Error: there is no node equal to: " + prevNodeData);
                return;
            }

            Node<T> prevNode = node; // נחזיר את ערך האיבר הקודם
            Node<T> nextNode = node.Next; // נחזיר את ערך האיבר הבא
            Node<T> newNodeBetween = new Node<T>(newNodeData); // ניצור איבר חדש

            // האיבר החדש יכנס ביניהם
            newNodeBetween.Next = nextNode; // האיבר החדש יצביע על האיבר הקודם
            length++;
            prevNode.Next = newNodeBetween; // האיבר הקודם יצביע על האיבר החדש
            newNodeBetween.Previous = prevNode; // האיבר החדש יצביע אחורה על האיבר הקודם

            if (newNodeBetween.Next == null) tail = newNodeBetween; // אם האיבר החדש הוא האחרון - נעדכן את הזנב

            Console.WriteLine("Added new Node after: " + prevNodeData);
        }

        public Node<T> FindNodeByData(T data)
        {
            Node<T> current = head;
            while (current != null && !(current.Data).Equals(data))
            {
                current = current.Next;
            }
            return current;
        }

        /*public void PrintAll()
        {
            if (head == null)
            {
                Console.WriteLine("Error: there is no nodes on this Link List");
                return;
            }
            Node<T> temp = head;

            while (temp.Next != null)
            {
                Console.Write("(" + temp.Data + ")->");
                temp = temp.Next;
            }
            Console.Write("(" + temp.Data + ")"); // הדפסת האיבר האחרון
            Console.WriteLine("  <= Link List");
        }*/

        /*public void PrintAllReverse()
        {
            if (head == null)
            {
                Console.WriteLine("Error: there is no nodes on this Link List");
                return;
            }
            Node<T> temp = tail;

            while (temp.Previous != null)
            {
                Console.Write("(" + temp.Data + ")->");
                temp = temp.Previous;
            }
            Console.Write("(" + temp.Data + ")"); // הדפסת האיבר האחרון
            Console.WriteLine("  <= Link List Previous");
        }*/


        public T[] ToArray()
        {
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
            Node<T> currNode = FindNodeByData(data);
            if (currNode == null)
            {
                Console.WriteLine("Error: cannot remove - there is no " + data + " Node");
                return;
            }
            Node<T> prevNode = currNode.Previous;
            prevNode.Next = currNode.Next; // קפיצה במצביע מעל האיבר שנבחר
            Console.WriteLine("Node " + data + " was removed\n");
            length--;
        }
        
        public void Clear()
        {
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
