using System;

namespace Linked_list_001
{
    class Program
    {
        static void IntList()
        {
            LinkList<int> list = new LinkList<int>();

            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(100000);

            list.PrintAll();
            list.PrintAllPrev();

            int prevNodeData = 100000;
            int newNodeData = 100;
            list.AddAfterNode(prevNodeData, newNodeData);
            list.PrintAll();
            list.PrintAllPrev();

            list.RemoveOne(2);
            list.PrintAll();
            list.PrintAllPrev();

            list.ToArray();


            list.Clear();
        }


        static void StrList()
        {
            LinkList<string> list = new LinkList<string>();

            list.Add("3");
            list.Add("45vfd");
            list.Add("asdas");
            list.Add("435346");
            list.Add("3453fg");
            list.Add("xcvyixf");
            list.Add("srttgdsf");
            list.Add("x");

            list.PrintAll();

            string prevNodeData = "asdas";
            string newNodeData = "z";
            list.AddAfterNode(prevNodeData, newNodeData);
            list.PrintAll();

            list.RemoveOne("x");
            list.PrintAll();

            list.PrintAll();

            list.ToArray();

            list.Clear();
        }

        static void Main(string[] args)
        {
            IntList();
            StrList();
            Console.ReadLine();
        }
    }
}
