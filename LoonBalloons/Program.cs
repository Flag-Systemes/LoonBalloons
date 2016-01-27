using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoonBalloons.Utils;

namespace LoonBalloons
{
  class Program
  {
    static void Main(string[] args)
    {
      string test;

      test = "2,1 5 1 2 5";
      List<decimal> liste1 = test.Split<decimal>(' ');

      test = "2 1 5 1 2 5";
      List<int> liste2 = test.Split<int>(' ');

      Console.ReadLine();
    }
  }
}
