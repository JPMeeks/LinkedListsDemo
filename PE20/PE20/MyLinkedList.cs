using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE20
{
    // implement a singly linked list
    class MyLinkedList
    {
        // attributes
        private Node head = null; // initially nothing in the list
        private int count = 0;

        // add an item to the list
        public void Add(string str)
        {
            // create the new node
            Node newNode = new Node(str);

            // special case - nothing in the list
            if (head == null)
            {
                head = newNode;
                count++;
                return;
            }

            // if we get here there's something in the list
            Node current = head;
            while (current.Next != null)
            {
                // move to next node in the list
                current = current.Next;
            }

            // now at end of the list
            current.Next = newNode; // add the new node at the end of the list
            count++;
        }

        // insert a value into the list
        public void Insert(string str, int pos)
        {
            // special cases
            if (head == null) // no list yet
            {
                Add(str); // make it the initial item in the list
                return;
            }

            if (pos < 0) // invalid location
            {
                Console.WriteLine("Minimum allowed position value is zero");
                return;
            }

            // replace the head
            if (pos == 0)
            {
                Node newNode = new Node(str); // make the node
                newNode.Next = head; // make it point to the head
                head = newNode;
                count++;
                return;
            }

            // if pos is greater than or equal to count we are adding to end of the list
            if (pos >= count)
            {
                Add(str); // just do an add
                return;
            }

            // regular case - locate the position and insert the node
            Node prev = head;
            Node curr = head;
            int loc = 0;
            while (loc < count)
            {
                // is this a position match
                if (loc == pos)
                {
                    Node newNode = new Node(str);

                    // insert the new node
                    newNode.Next = curr;
                    prev.Next = newNode;
                    count++;
                    return;
                }

                // not a match yet
                loc++; // next node position
                prev = curr; // save current node as previous
                curr = curr.Next; // move to the next node
            }
        }

        // find the location of a specific value
        public int Find(string str)
        {
            // no list?
            if (head == null)
            {
                Console.WriteLine("No list to search");
                return -1;
            }

            Node curr = head;
            for (int i = 0; i < count; i++) // loop through the list
            {
                // data value match
                if (str == curr.Data)
                {
                    return i;
                }

                // not a match, move to next node
                curr = curr.Next;
            }

            // no match found
            return -1;
        }

        // delete based on location
        public void Delete(int pos)
        {
            // special cases
            if (head == null)
            {
                Console.WriteLine("No list, so nothing to delete");
                return;
            }

            // delete the head
            if (pos == 0)
            {
                head = head.Next;
                count--;
                return;
            }

            // invalid location
            if (pos < 0 || pos >= count)
            {
                Console.WriteLine("Position does not exist in the list");
                return;
            }

            // regular case
            Node prev = head;
            Node curr = head;
            for (int i = 0; i < count; i++)
            {
                if (i == pos) // at node to delete
                {
                    prev.Next = curr.Next;
                    count--;
                    return;
                }

                // not at the right spot, move forward a node
                prev = curr;
                curr = curr.Next;
            }
        }

        // overload of Delete - uses the value
        public void Delete(string str)
        {
            int pos = Find(str);  // get the location

            if (pos == -1) // no match found
            {
                Console.WriteLine("Value does not exist");
                return;
            }

            // delete based on location
            Delete(pos);
        }

        // traverse the list, printing all data
        public void Traverse()
        {
            // special case - no list
            if (head == null)
            {
                Console.WriteLine("No data in the list");
                return;
            }

            // loop through all of the items in the list
            Node current = head;
            while (current.Next != null)
            {
                // list the current node
                Console.WriteLine(current);

                // move to next node
                current = current.Next;
            }

            // still need to list the last node in the list
            Console.WriteLine(current);
        }

        //  
        public void InsertSorted(string str)
        {
            // create new node
            string compareNew = str.ToUpper();  // string of the new node to compare to the old string
            string compareOld;                  // string of the old node to compare to the new string
            int loc = 0;
            Node current;

            // special case - no list
            if (head == null)
            {
                head = new Node(str); ;
                return;
            }

            // alphabetic value is less than the head
            if (compareNew[0] < (head.Data.ToUpper())[0] )
            {
                Insert(str, 0);
                return;
            }

            // alphabetic value is located in the list
            current = head;
            while(loc < count)
            {
                if(compareNew[0] == (current.Data.ToUpper())[0])
                {
                    if(compareNew[1] < (current.Data.ToUpper())[1])
                    {
                        Insert(str, loc);
                        return;
                    }
                    else if(compareNew[1] > (current.Data.ToUpper())[1])
                    {
                        Insert(str, loc + 1);
                        return;
                    }
                    else if (compareNew == (current.Data.ToUpper())) // sets string to be right after the same string
                    {
                        Insert(str, loc + 1);
                        return;
                    }
                }
                else if(compareNew[0] > (current.Data.ToUpper())[0] && compareNew[0] < (current.Next.Data.ToUpper())[0] && current.Next != null)
                {
                    Insert(str, loc + 1);
                    return;
                }
                else if (compareNew[0] < (current.Data.ToUpper())[0])
                {
                    Insert(str, loc - 1);
                    return;
                }

                current = current.Next;
                loc++;
            }

            // alphabetic value is greater than the trail
            Add(str);
        }
    }
}
