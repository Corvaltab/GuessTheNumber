using GuessTheNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class Play
    {
        public void PlayGame(string saveFileName)
        {
            PlayerProgress playerProgress = new PlayerProgress();
            HintManager hintManager = new HintManager();
            SaveLoadManager saveLoadManager = new SaveLoadManager();

            int[] unknownNumber;
            int userGuess = 0;
            int attempts = 0;
            bool check = false;

            while (true)
            {
                Console.Clear();
                unknownNumber = GameMechaniks.ChooseDifficult(); // The choose of diffivult level. Перше значення - Рівень складності; Друге - загадане число.

                Console.Clear();
                Console.Write($"Your difficult level is: {unknownNumber[0]}" +
                    $"\nPlease enter your number: ");

                for (int i = 1; i <= 5; i++)
                {
                    userGuess = CommonOperation.UserInput(); // Input number that user assumed

                    if (userGuess == unknownNumber[1])
                    {
                        Console.WriteLine($"Your answer is correct. Your number is {userGuess} and unknow number was {unknownNumber[1]}");
                        playerProgress.Score += 5;
                        playerProgress.CorrectAnswers++;
                        saveLoadManager.SaveProgress(playerProgress, saveFileName);
                        Console.ReadKey();
                        break;
                    }
                    else if (userGuess != unknownNumber[1])
                    {
                        Console.WriteLine($"Your number is not correct. You have left {5 - i} attempts");
                    }
                    if (i >= 3 && !check)
                    {
                        hintManager.HintCheck(userGuess, unknownNumber, check);
                    }
                    attempts++;
                    if (attempts == 5)
                    {
                        Console.WriteLine($"Game over");
                        saveLoadManager.SaveProgress(playerProgress, saveFileName);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}


