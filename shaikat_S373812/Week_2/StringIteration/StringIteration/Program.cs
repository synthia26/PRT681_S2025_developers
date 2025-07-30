using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StringIteration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello, World!";
            //Console.WriteLine(message[0]);
            for (int i = 0;i < message.Length; i++)
            {
                Console.Write(message[i]);
               // Thread.Sleep(500); // Simulate some delay   
            }
            Console.WriteLine();
            Console.WriteLine(message.Contains("h"));
            bool  contains = false; 
            for  (int i = 0; i < message.Length; i++)
            {
                if (message[i] == 'W')
                {
                    contains = true;
                    break;
                }
            }
            Console.WriteLine(contains);
            string name="Alpha";
            Console.WriteLine(string.IsNullOrEmpty(name));
            Console.Write("Write your message:");
            string y_Message = Console.ReadLine();
            for(int i = y_Message.Length-1;i>= 0; i--)
            {
                Console.Write(y_Message[i]);
                //Thread.Sleep(500); // Simulate some delay   
            }   
        }
    }
}
