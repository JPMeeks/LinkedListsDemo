using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE20
{
    // test class
    class Program
    {
        static void Main(string[] args)
        {
            // create a linked list
            MyLinkedList list = new MyLinkedList();

            // populate the list

            list.InsertSorted("Lich");
            list.InsertSorted("wizard");
            list.InsertSorted("Apple");
            list.InsertSorted("Elemental");
            list.InsertSorted("beast");
            list.InsertSorted("human");

            // traverse the list
            list.Traverse();
            
        }
    }
}