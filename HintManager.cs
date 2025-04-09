using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class HintManager
    {
        public bool HintCheck(int userGuess, int[] unknownNumber, bool check)
        {
            bool exitCondition = false;
            do
            {
                Console.WriteLine($"If you want to get hint press H otherwise press C");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                if (consoleKeyInfo.Key == ConsoleKey.H)
                {
                    if (userGuess > unknownNumber[1])
                    {
                        Console.WriteLine($"Guessed number is less than your assume");
                    }
                    else if (userGuess < unknownNumber[1])
                    {
                        Console.WriteLine($"Guessed number is greater than your assume");
                    }
                    exitCondition = true;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.C)
                {
                    check = true;
                    exitCondition = true;
                    Console.WriteLine("You continue without hint. Please enter your number: ");
                }
            } while (!exitCondition);
            return check;
        }
    }
}
