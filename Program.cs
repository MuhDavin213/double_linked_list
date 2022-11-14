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
            for (current = previous = START;
                current != null && nim >= current.noMhs;
                previous = current, current = current.next)
            {
                if(nim == current.noMhs)
                {
                    Console.WriteLine("\nDublicate roll numbers not allowed");
                    return ;
                }
            }
            /*
             on the exucition of the above for loop,prev and 
            current will point to those nodes
            between wich the node is to be inserted
             
             
             */
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be issarted at the end of the list
            if(current == null)
            {
                newNode.next = null;
                newNode.next = newNode;
                return;

            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollNo, ref node previous, ref node current)
        {
            for (previous = current = START; current != null && rollNo != current.noMhs; previous = current, current = current.next) { }
            return(current != null);
        }
        public bool dellNode(int rollNo)
        {
            node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            //the beginning of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //node between two nodes in the list
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            /*
             if the to deleted is in between the list then the following lines of is executed 
            */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are: \n");
                node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + "" + currentNode.name + "\n");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + " roll number are: \n");
                node currendNode;
                for (currendNode = START; currendNode != null; currendNode = currendNode.next)
                { }

                while(currendNode != null)
                {
                    Console.Write(currendNode.noMhs + "" + currendNode.name + "\n");
                    currendNode = currendNode.prev;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while(true)
            {
                try
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. delete a record from the list");
                    Console.WriteLine("3. view all record in the ascending order of roll numbers");
                    Console.WriteLine("4. view all record in the descending order of roll numbers");
                    Console.WriteLine("5. search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" + "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted \n");
                            }
                            break ;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break ;
                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number");
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                            }
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }
    }
}
