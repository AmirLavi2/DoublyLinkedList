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

            list.Add("AAAAA");
            list.Add("BBBBB");
            list.Add("CCCCC");
            list.Add("DDDDD");
            list.Add("EEEEE");
            list.Add("FFFFF");
            list.Add("GGGGG");
            list.Add("ZZZZZ");

            list.PrintAll();

            string prevNodeData = "CCCCC";
            string newNodeData = "XYXYXYXY";
            list.AddAfterNode(prevNodeData, newNodeData);
            list.PrintAll();

            list.RemoveOne("GGGGG");
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
