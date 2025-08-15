using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // game loop
            while (true)
            {
                int max = 0;  // reset for each turn
                int indexOfMax = 0; // store the index of the tallest mountain

                for (int i = 0; i < 8; i++)
                {
                    int mountainH = int.Parse(Console.ReadLine()); // height of mountain i

                    if (mountainH > max)
                    {
                        max = mountainH;
                        indexOfMax = i; // store the position
                    }
                }

                // Fire at the tallest mountain
                Console.WriteLine(indexOfMax);
            }
        }
    }
}
