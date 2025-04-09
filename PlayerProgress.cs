using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    [Serializable]
    public class PlayerProgress
    {
        public int Score { get; set; }
        public int GamesPlayed { get; set; }
        public int CorrectAnswers { get; set; }
        public List<string> UnlockedItems { get; set; } = new List<string>(); // Наприклад, назви розблокованих речей

        //public void DisplayPlayerStats()
        //{
        //    Console.WriteLine("--- Player statictics ---");
        //    Console.WriteLine($"Score: {Score}");
        //    Console.WriteLine($"Right answer count: {CorrectAnswers}");
        //    Console.WriteLine($"Games played: {GamesPlayed}");
        //    Console.WriteLine("--------------------------");
        //}
    }                                      
}
