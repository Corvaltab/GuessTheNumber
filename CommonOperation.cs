using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public static class CommonOperation
    {
        public static int UserInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int userNumb))
            {
                Console.WriteLine($"A value must be must be both an integer and greater than 0");
            }
            else if (userNumb < 0)
            {
                Console.WriteLine("Your number can`t be less than zero");
                return -1;
            }
            return userNumb;
        }
    }
}
