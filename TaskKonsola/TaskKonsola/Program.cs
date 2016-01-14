using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskKonsola
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        static void menu()
        {
            Console.Title = "Parallel programming";
            int wybor = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: Pętla vs Parallel for");
                Console.WriteLine("2: Lista zadań");
                Console.WriteLine("3: Sztafeta");
                Console.WriteLine("4: Obserwator");
                Console.WriteLine("5: Opuszczenie programu");
                wybor = Convert.ToInt32(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        loopvsparallel();
                        break;
                    case 2:
                        listaZadan();
                        break;
                    case 3:
                        sztafeta();
                        break;
                    case 4:
                        obserwator();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            } while (wybor < 5);
        }

        static void listaZadan()
        {
            Action a = () =>
            {
                Console.WriteLine("Start zadania nr " + Task.CurrentId);
                Thread.SpinWait(new Random().Next(100000000));
                Console.WriteLine("koniec zadania nr " + Task.CurrentId);
            };

            List<Task> listaZadan = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                listaZadan.Add(new Task(a));
            }

            listaZadan.ForEach(t => t.Start());
            listaZadan.ForEach(t => t.Wait());
        }

        static void loopvsparallel()
        {
            Console.WriteLine("Using C# For Loop \n");

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("i = {0}, thread = {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }

            Console.WriteLine("\nUsing Parallel.For \n");

            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
        }

        static void sztafeta()
        {
            Random rdm = new Random();
            Task t1, t2, t3, t4;
            Action a = () =>
                {
                    int czas = rdm.Next(1000, 9500);

                    Console.WriteLine("Task nr {0} wystartował", Task.CurrentId);
                    Thread.Sleep(czas);
                    Console.WriteLine("Task nr {0} zakończył działanie w {1}", Task.CurrentId, czas.ToString());
                };

            Action<Task> b = (t) =>
                {
                    int czas = rdm.Next(1000, 2500);
                    Console.WriteLine("Task nr {0} wystartował po Tasku nr {1}", Task.CurrentId, t.Id);
                    Thread.Sleep(czas);
                    Console.WriteLine("Task nr {0} zakończył działanie w {1}", Task.CurrentId, czas.ToString());
                };

            t1 = new Task(a);
            t2 = new Task(a);
            t3 = t1.ContinueWith(b);
            t4 = t2.ContinueWith(b);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2, t3, t4);
            Console.WriteLine("Taski skończyły swoje działanie");
        }

        static void obserwator()
        {
            Task test = new Task(() =>
                {
                    Console.WriteLine("Task rozpoczęty");
                    Thread.Sleep(400);
                    Console.WriteLine("Task zakończony");
                });

            Task obserwator = Task.Factory.StartNew(() =>
                {
                    int i = 10;
                    while (i-- > 0)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine(test.Status.ToString());
                    }
                });

            Thread.Sleep(200);
            test.Start();

            Task.WaitAll(test, obserwator);
        }
    }
}
