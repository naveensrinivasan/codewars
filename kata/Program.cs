using System;
using System.Collections.Generic;
using System.Linq;

namespace kata
{
    public class Program
    {
        public static bool AmicableNumbers(int num1, int num2)
        { 
           var numDivisorSums = new Func<int,int>(number =>  Enumerable.Range(1,number / 2)
                .Select(n => new {Number = n , Mod =number % n})
                .Where(n => n.Mod == 0)
                .Select(n => n.Number)
                .Sum());
           if (numDivisorSums(num1) != num2)
                return false;    
            if (numDivisorSums(num2) != num1)
                return false;
            return true;   
        }
    }
}
