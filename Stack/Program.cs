using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static Stack myStack = new Stack();

        static void Main(string[] args)
        {
            ShowMenu();

            while (true)
            {
                var keyPressed = Console.ReadKey();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.LeftArrow:
                        ShowStack();
                        break;
                    case ConsoleKey.UpArrow:
                        PushOnStack();
                        break;
                    case ConsoleKey.DownArrow:
                        PopFromStack();
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Enter:
                        GetMin();
                        break;
                    default:
                        Console.Clear();
                        ShowMenu();
                        break;
                }
            }
        }

        private static void GetMin()
        {
            Console.WriteLine("");
            if (myStack.Min() == -1)
                Console.WriteLine($"Min: Empty.");
            else
                Console.WriteLine($"Min: { myStack.Min()}");
        }

        private static void PushOnStack()
        {
            Console.WriteLine("");
            Console.WriteLine("Type an integer number:");
            int toPush;
            try
            {
                toPush = int.Parse(Console.ReadLine());
                myStack.Push(toPush);
                ShowStack();
            }
            catch (FormatException)
            {
                Console.WriteLine("You need to type an integer number. Operation canceled.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error while pushing: {e.Message}");
                Console.WriteLine("Operation canceled.");
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("");
            Console.WriteLine(" -------------------------------------------------- ");
            Console.WriteLine("| Press \"Up Arrow\" to Push.                        |");
            Console.WriteLine("| Press \"Down Arrow\" to pop.                       | ");
            Console.WriteLine("| Press \"Left Arrow\" to visualize the stack.       | ");
            Console.WriteLine("| Press \"Right Arrow\" to clear console.            |");
            Console.WriteLine("| Press \"Enter Key\" to get the minimum stack value.|");
            Console.WriteLine(" --------------------------------------------------");

        }

        private static void PopFromStack()
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine($"{myStack.Pop()} got popped.");
                ShowStack();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Stack is empty.");
            }
        }

        private static void ShowStack()
        {
            var stack = myStack.stack;
            Console.WriteLine("");
            if (stack.Count > 0)
            {
                Console.WriteLine("Stack:");
                stack.ToList();
                foreach (var item in stack.Reverse())
                {
                    Console.WriteLine($"|{item}|");
                }
            }
            else
                Console.WriteLine("Stack: Empty.");
        }
    }
}
