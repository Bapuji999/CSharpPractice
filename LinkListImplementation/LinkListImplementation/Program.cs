using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinkListImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddToEnd(1);
            linkedList.AddToEnd(2);
            linkedList.AddToEnd(1);
            var a = isPalindrom(linkedList);
            linkedList.PrintList();
            linkedList.Reverse();
            linkedList.PrintList();
            var middle = linkedList.FindMiddle();
            Console.WriteLine("\nMiddle Element is:" + middle);
        }
        static bool isPalindrom<T>(LinkedList<T> list)
        {
            LinkedList<T> copyList = new LinkedList<T>();
            copyList.head = CopyList(list.head);
            copyList.Reverse();
            while (list.head.Next != null)
            {
                if(!copyList.head.Data.Equals(list.head.Data))
                {
                    return false;
                }
                copyList.head = copyList.head.Next;
                list.head = list.head.Next;
            }
            return true;
        }
        static Node<T> CopyList<T>(Node<T> head)
        {
            if (head == null)
            {
                return null;
            }

            Node<T> newHead = new Node<T>(head.Data);
            Node<T> current = newHead;
            Node<T> original = head.Next;

            while (original != null)
            {
                current.Next = new Node<T>(original.Data);
                current = current.Next;
                original = original.Next;
            }

            return newHead;
        }
    }
public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    public class LinkedList<T>
    {
        public Node<T> head;

        public LinkedList()
        {
            head = null;
        }
        public void AddToEnd(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.Data} -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
        public T FindMiddle()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }

            Node<T> slowPointer = head;
            Node<T> fastPointer = head;

            while (fastPointer != null && fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;
            }
            return slowPointer.Data;
        }
        public void Reverse()
        {
            if (head == null || head.Next == null)
            {
                return;
            }
            Node<T> previous = null;
            Node<T> current = head;
            Node<T> next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            Console.WriteLine("Reversed....");
            head = previous;
        }
    }
}
