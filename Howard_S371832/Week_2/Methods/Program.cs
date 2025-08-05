using System;

namespace Methods
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int[] intsToCompress = [10, 15, 20, 25, 30, 12, 34];
      int totalValue = GetSum(intsToCompress);
      Console.WriteLine(totalValue);
    }

    static private int GetSum(int[] intsToCompress)
    {
      
      int totalValue = 0;
      foreach (int intForCompression in intsToCompress)
      {
        totalValue += intForCompression;
      }
      return totalValue;
    }
  }
}