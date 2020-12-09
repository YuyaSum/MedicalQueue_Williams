using System;
using System.Threading;

namespace MedicalQueue_Williams
{
    class Program
    {
        static void Main(string[] args)
        {
            ERQueue queue = new ERQueue();
            char choice = 'x';

            while (choice != 'Q')
            {
                Console.WriteLine("(A)dd Patient  (P)rocess Current Patient  (L)ist All in Queue  (Q)uit\n");
                choice = Console.ReadKey(true).KeyChar;
                Console.Clear();

                switch (char.ToUpper(choice))
                {
                    case 'A':
                        {
                            int numList;
                            string name;
                            int prioNum = -1;
                            Console.WriteLine("Who are we adding today?");
                            name = Console.ReadLine();

                            Console.WriteLine("Priority number? (1 being the highest and 5 being the lowset)");
                            string priority = Console.ReadLine();

                            while (!Int32.TryParse(priority, out prioNum) || (prioNum < 0 || prioNum > 5))
                            {
                                Console.WriteLine("Make sure the priority matches the requirements.");
                                priority = Console.ReadLine();
                            }

                            Patient person = new Patient(name, prioNum);
                            numList = queue.Enqueue(person);

                            if (numList == -1)
                            {
                                Console.WriteLine("Queue is full, cannot enqueue.");
                            }else
                            {
                                Console.WriteLine("There are " + numList + " in the queue." );
                            }

                            break;
                        }
                    case 'P':
                        {
                            string removed = queue.Dequeue();
                            if (removed == "x")
                            {
                                Console.WriteLine("There is nobody to dequeue.\n");
                            }
                            else { 
                                Console.WriteLine(removed + " was processed.\n");
                            }
                            break;
                        }
                    case 'L':
                        {
                            if (queue.listSize() <= 0)
                            {
                                Console.WriteLine("There is nobody in the queue.\n");
                            }
                            else { 
                                Console.WriteLine("Order from Top to Bottom.\n");
                                Console.WriteLine(queue.ToString());
                            }
                            break;
                        }
                    case 'Q':
                        {
                            Console.Clear();
                            Console.WriteLine("Have a good day.");
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("That isn't a valid key.");
                            break;
                        }
                }

            }


        }
    }
}
