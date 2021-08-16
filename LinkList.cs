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

        // תהליך לא יעיל
        /*public void AddToEnd(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null) // אם אין רשימה - נאתחל אותה כאן
            {
                head = newNode;
                length++;
            }
            else //  נתקדם בחוליות עד החוליה האחרונה שלא מצביעה על כלום
            {              
                Node<T> current = head;
                while (current.Next != null) // תהליך לא יעיל
                {
                    current = current.Next;
                }
                current.Next = newNode; // פה נמצאים על החוליה האחרונה. מפה ניצור חוליה חדשה
                current.Previous = current.Next.Next;
                length++;
            }
        }*/

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null) // אם אין רשימה - נאתחל אותה כאן
            {
                head = newNode;
                tail = newNode;
            }
            else // אם יש רשימה
            {
                tail.Next = newNode; // מזיזים את המצביע לאיבר החדש האחרון
                newNode.Previous = tail;
            }
            tail = newNode;
            length++; // מעדכנים את אורך הרשימה
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

            if(newNodeBetween.Next == null) tail = newNodeBetween; // אם האיבר החדש הוא האחרון - נעדכן את הזנב

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

        public void PrintAll()
        {
            if (head == null)
            {
                Console.WriteLine("Error: there is no nodes on this Link List");
                return;
            }

            Node<T> current = head;

            Console.Write("Link List: ");
            
            while (current.Next != null)
            {
                Console.Write("(" + current.Data + ")->");
                current = current.Next;
            }
            Console.WriteLine("(" + current.Data + ")"); // הדפסת האיבר האחרון
            Console.WriteLine("Number of Nodes: " + length);
        }

        public void PrintAllPrev()
        {
            if (head == null)
            {
                Console.WriteLine("Error: there is no nodes on this Link List");
                return;
            }

            Node<T> current = tail;

            Console.Write("Link List Previous: ");

            while (current.Previous != null)
            {
                Console.Write("(" + current.Data + ")->");
                current = current.Previous;
            }
            Console.WriteLine("(" + current.Data + ")"); // הדפסת האיבר האחרון
            Console.WriteLine("Number of Nodes: " + length);
        }

        public void Clear()
        {
            Node<T> current = head;

            while (current.Next != null)
            {
                head = current.Next;
                current = current.Next;
            }
            head = null;
        }

        public T[] ToArray()
        {
            Node<T> current = head;
            T[] arr = new T[Length];

            for(int i=0;i<Length;i++)
            {
                arr[i] = current.Data;
                current = current.Next;
            }
            return arr;
        }
        public void RemoveOne(T data)
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
        }

    }
}
