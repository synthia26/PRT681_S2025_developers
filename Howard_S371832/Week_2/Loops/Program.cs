using System;

namespace Loops
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int[] intsToCompress = [10, 15, 20, 25, 30, 12, 34];

      DateTime startTime = DateTime.Now;
      int totalValue = 0;

      // for (int i = 0; i < intsToCompress.Length; i++)
      // {
      //   totalValue += intsToCompress[i];
      // }

      // foreach (int intForCompression in intsToCompress)
      // {
      //   totalValue += intForCompression;
      // }

      // int index = 0;
      // while (index < intsToCompress.Length)
      // {
      //   totalValue += intsToCompress[index];
      //   index++;
      // }

      // int index = 0;
      // do
      // {
      //   totalValue += intsToCompress[index];
      //   index++;
      // } while (index < intsToCompress.Length);

      totalValue = intsToCompress.Sum();

      Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
      Console.WriteLine(totalValue);
    }
  }
}