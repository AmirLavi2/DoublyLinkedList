using System;

namespace Linked_list_001
{
    class Program
    {
        static void IntList()
        {
            LinkList<int> list = new LinkList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);

            list.PrintFromHeadForward();
            list.PrintFromTailReverse();

            list.RemoveOne(1);
            list.PrintFromHeadForward();
            list.PrintFromTailReverse();

            int currectNodeData = 1;
            int newNodeData = 100;
            list.AddAfterNode(currectNodeData, newNodeData);
            list.PrintFromHeadForward();
            list.PrintFromTailReverse();

            // list.ToArray();

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

            string prevNodeData = "CCCCC";
            string newNodeData = "XYXYXYXY";
            list.AddAfterNode(prevNodeData, newNodeData);

            list.RemoveOne("GGGGG");   
            list.ToArray();

            list.PrintFromHeadForward();
            list.PrintFromTailReverse();

            list.Clear();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("== Wellcome to Link List Program ! ==");
            IntList();
            //StrList();
            Console.ReadLine();
        }
    }
}
