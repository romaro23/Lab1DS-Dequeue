using System.Collections;
using System.Xml.Linq;
using static Lab1.Program;

namespace Lab1
{

    class Program
    {
        public class Node<T>(T value)
        {
            public T Value { get; set; } = value;
            public Node<T> Previous { get; set; }
            public Node<T> Next { get; set; }
        }
        public class Deque<T> : IEnumerable<T>
        {
            Node<T>? head;
            Node<T> tail;
            int count;
            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            public void AddLast(T value)
            {
                Node<T> node = new Node<T>(value);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    node.Previous = tail;
                }
                tail = node;
                count++;
            }
            public void AddFirst(T value)
            {
                Node<T> node = new Node<T>(value);
                Node<T> temp = head;
                node.Next = temp;
                head = node;
                if (IsEmpty)
                {
                    tail = head;
                }
                else
                {
                    temp.Previous = node;
                }
                count++;
            }
            public T RemoveFirst()
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Deque is empty");
                }
                T value = head.Value;
                if (count == 1)
                {
                    head = tail = null;
                }
                else
                {
                    head = head.Next;
                    head.Previous = null;
                }
                count--;
                return value;
            }
            public T RemoveLast()
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Deque is empty");
                }
                T value = tail.Value;
                if (count == 1)
                {
                    head = tail = null;
                }
                else
                {
                    tail = tail.Previous;
                    tail.Next = null;
                }
                count--;
                return value;
            }
            public T GetFirst
            {
                get
                {
                    if (IsEmpty)
                    {
                        throw new InvalidOperationException("Deque is empty");
                    }
                    return head.Value;
                }

            }
            public T GetLast
            {
                get
                {
                    if (IsEmpty)
                    {
                        throw new InvalidOperationException("Deque is empty");
                    }
                    return tail.Value;
                }
            }
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
            public bool Contains(T value)
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Deque is empty");
                }
                Node<T> node = head;
                while (node != null)
                {
                    if (node.Value.Equals(value))
                    {
                        return true;
                    }
                    node = node.Next;
                }
                return false;
            }
            public void Swap()
            {
                if (count < 2)
                {
                    throw new InvalidOperationException("Wrong operation. Deque size < 2");
                }
                if (count == 2)
                {
                    Node<T> temp = head;
                    tail.Previous = null;
                    head = tail;
                    tail.Next = temp;
                    tail = temp;
                    tail.Next = null;
                    tail.Previous = head;
                }
                else
                {
                    Node<T> temp = head;
                    head = tail;
                    tail = temp;
                    head.Next = temp.Next;
                    head.Next.Previous = head;
                    tail.Previous = head.Previous;
                    tail.Previous.Next = tail;
                    head.Previous = null;
                    temp.Next = null;
                }

            }
            public void Reverse()
            {
                if (count < 2)
                {
                    throw new InvalidOperationException("Wrong operation. Deque size < 2");
                }
                if (count == 2)
                {
                    Swap();
                }
                else
                {
                    Node<T> node = head;
                    Node<T> temp = null;
                    while (node != null)
                    {
                        temp = node.Previous;
                        node.Previous = node.Next;
                        node.Next = temp;
                        node = node.Previous;
                    }
                    temp = head;
                    head = tail;
                    tail = temp;
                }


            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> node = head;
                while (node != null)
                {
                    yield return node.Value;
                    node = node.Next;
                }
            }
            public void Print()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Deque: ");
                foreach (var value in this)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Deque<int> deque = new Deque<int>();
            deque.AddLast(5);
            deque.AddLast(2);
            deque.AddLast(3);
            deque.AddLast(1);
            deque.AddLast(4);
            while (true)
            {
                Console.WriteLine("1 - Add last\n2 - Add first\n3 - Remove last\n4 - Remove first\n5 - Get last\n6 - Get first\n7 - Clear\n8 - Contains\n9 - Swap\n10 - Revers\n11 - Print");
                var option = int.Parse(Console.ReadLine());
                int value;
                try
                {
                    switch (option)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Print value: ");
                            value = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.White;
                            deque.AddLast(value);
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Print value: ");                           
                            value = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.White;
                            deque.AddFirst(value);
                            break;
                        case 3:
                            deque.RemoveLast();
                            break;
                        case 4:
                            deque.RemoveFirst();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(deque.GetLast.ToString());
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(deque.GetFirst.ToString());
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 7:
                            deque.Clear();
                            break;
                        case 8:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Print value: ");
                            value = int.Parse(Console.ReadLine());
                            Console.WriteLine(deque.Contains(value).ToString());
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 9:
                            deque.Swap();
                            break;
                        case 10:
                            deque.Reverse();
                            break;
                        case 11:
                            deque.Print();
                            break;
                    }
                    deque.Print();
                }
                catch(Exception ex) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

        }
        }


    }
}
