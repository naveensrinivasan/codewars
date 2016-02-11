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
        /// http://www.codewars.com/kata/56af1a20509ce5b9b000001e/train/csharp
        ///
        public static string Travel(string r, string zipcode) 
        {
            var key = zipcode;
            var street = string.Empty;
			var door  = string.Empty;
            
            var address = r.Split (new [] { ',' })
                .Select (f => f.Split(new [] {" "},StringSplitOptions.None))
				.Select (x => new {Door = x.First(), 
					Street = x.Skip(1).Take(x.Count() - 3).Aggregate((i, j) => i + " " + j), 
					StateZip = x.Skip(x.Count() -2).Take(2).Aggregate((i, j) => i + " " + j)})
                    .Where (x => x.StateZip == key);
			
      
			foreach	(var item in address)
			{
				street += item.Street + ",";
				door += item.Door + ",";
			}
            
			return string.Format ("{0}:{1}/{2}", key, street.Trim (new [] { ',' }), door.Trim (new [] { ',' }));
        }


    }
}
