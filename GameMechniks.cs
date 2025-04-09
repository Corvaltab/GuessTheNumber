using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public static class GameMechaniks
    {
        public static int[] ChooseDifficult()
        {
            Random random = new Random();
            int difficultRange = 0;
            int lvlDifficult = 0;
            int[] array_1;

            Console.WriteLine($"Choose difficult level from the list" +
                     $"\n1. 1 - 10 range. Press 1 on keyboard" +
                     $"\n2. 1 - 100 range. Press 2 on keyboard" +
                     $"\n3. 1 - 1000 range. Press 3 on keyboard " +
                     $"\n4. Random difficult. Press Enter on keyboard");

            do
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                if (consoleKeyInfo.Key == ConsoleKey.D1) { lvlDifficult = 1; }
                else if (consoleKeyInfo.Key == ConsoleKey.D2) { lvlDifficult = 2; }
                else if (consoleKeyInfo.Key == ConsoleKey.D3) { lvlDifficult = 3; }
                else if (consoleKeyInfo.Key == ConsoleKey.Enter) { lvlDifficult = 4; }

            } while (lvlDifficult != 1 && lvlDifficult != 2 && lvlDifficult != 3 && lvlDifficult != 4);

            switch (lvlDifficult)
            {
                case 1:
                    return array_1 = SwitchCase(lvlDifficult);
                case 2:
                    return array_1 = SwitchCase(lvlDifficult);
                case 3:
                    return array_1 = SwitchCase(lvlDifficult);
                default:
                    int randomPath = random.Next(1, 3);
                    return array_1 = SwitchCase(randomPath);
            }
        }
        static private int[] SwitchCase(int lvlDifficult)
        {
            int[] transfer = new int[2];
            int difficultRange = 0;
            Random random = new Random();

            transfer[0] = lvlDifficult;

            if (lvlDifficult == 1) { difficultRange = random.Next(1, 10); }
            else if (lvlDifficult == 2) { difficultRange = random.Next(1, 100); }
            else if (lvlDifficult == 3) { difficultRange = random.Next(1, 1000); }

            transfer[1] = difficultRange;
            return transfer;
        }
    }
}
