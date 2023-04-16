using System.Data;

namespace ConsoleApp1
{
    internal class Program
    {
        public delegate void MyDelegate(string msg);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyDelegate del = new MyDelegate(Print);
            MyDelegate del1 = Print1;
            MyDelegate del2 = Print2;
            MyDelegate del3 = (string m) => Console.WriteLine(m);
            
            MyDelegate mul = del + del1 + del3 + del2;

            mul += del;
            mul -= del;
            del.Invoke("First?");
            del1("Second?");
            del3("Third?");

            mul("Our message");
        }

        static void Print(string message)
        { 
            Console.WriteLine(message);
        }
        static void Print1(string message)
        {
            Console.WriteLine("Test " + message);
        }
        static void Print2(string message)
        {
            Console.WriteLine("Hello " + message);
        }
    }

    public class Test
    {

    }
}