using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryKV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> names = new Dictionary<int, string>();
            names.Add(1, "Alice");
            names.Add(2, "Bob");    
            names.Add(3, "Charlie");

            for(int i = 0;i < names.Count; i++)
            {
                KeyValuePair<int, string> kvp = names.ElementAt(i);
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Console.Write("\n");
            foreach (KeyValuePair<int, string> kvp in names)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Dictionary<string, string> teachers = new Dictionary<string, string>
            {
                { "Math", "Mr. Smith" },
                { "Science", "Ms. Johnson" },
                { "History", "Mrs. Brown" }

            };
            Console.WriteLine("\n");
            Console.WriteLine(teachers["Math"]);
            if(teachers.TryGetValue("science", out string scienceTeacher))
            {
                Console.WriteLine(scienceTeacher);
            }
            else
            {
                Console.WriteLine("Key not found.");
            }   
        }
    }
}
