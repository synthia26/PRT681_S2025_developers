using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = new List<string>
           {
               "Coffee","Milk"
           };

            //Console.WriteLine(shoppingList.IndexOf("Coffee")); 
            Console.WriteLine(shoppingList.IndexOf("Milk"));
            Console.WriteLine(FindInList("Milk",shoppingList,out int loc));
            Console.WriteLine(loc);
            /*
            int index = -1;
            for (int i = 0; i < shoppingList.Count; i++)
            {
                if (shoppingList[i].ToLower().Equals("milk"))
                {
                    index = i;
                }
            }

            Console.WriteLine(index);
            bool found = index > -1;
            Console.WriteLine(found ? "Found" : "Not Found");
            */
        }
        static bool FindInList(string s,List<string>list,out int index)
        {
            index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToLower().Equals(s.ToLower()))
                {
                    index = i;
                }
            }
            return index>-1;
        }

    }
}
