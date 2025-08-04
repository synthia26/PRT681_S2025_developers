using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumabers = new List<int>();
            //listNumabers.Add(1);
            //listNumabers.Add(2);
            //listNumabers.Add(3);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter a Number: ");
                listNumabers.Add(Convert.ToInt32(Console.ReadLine()));
            }
            for (int i = 0;i < listNumabers.Count; i++)
            {
                Console.WriteLine("Number {0} is: {1}", i + 1, listNumabers[i]);
            }
        }
    }
}
