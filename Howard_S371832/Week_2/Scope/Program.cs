using System;

namespace Scope
{
  internal class Program
  {
    static readonly int accessibleInt = 7;

    static void Main(string[] args)
    {
      // int accessibleInt = 5 ;
      Console.WriteLine(accessibleInt);

      
    }

    // void TestMethod()
    // {
    //   Console.WriteLine(accessibleInt);
    // }


  }
}