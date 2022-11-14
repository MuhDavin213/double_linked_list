using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_linked_list
{
    class node
    {
        /*
         - node class represents the node doubly linked list.
         - it consist of the information part and links to its succeding and precedding
         - in terms of the next and previous 
         */
        public int noMhs;
        public string name;
        //public  to the succeding node
        public node next;
        //poimt to the preccedding node
        public node prev;
    }
    class DoubleLinkedList
    {
        node START;

        //constructor 
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNote()
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            node newNode = new node();
            newNode.noMhs = nim;
            newNode.name = nm;

            //check if the list empty
            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = newNode;
                return;
            }
            /*
             if the node is to be inserted at between two node
            */
            node previous, current;
            for(current = previous)
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
