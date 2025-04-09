using System.Text.Json;

namespace GuessTheNumber;

class Program
{
    static void Main(string[] args)
    {
        SaveLoadManager saveLoadManager = new SaveLoadManager();
        string saveFileName = saveLoadManager.SaveList();
        string gameSaveName = saveFileName;

        if (string.IsNullOrEmpty(saveFileName))
        {
            Console.WriteLine("Enter a name for your account file: ");
            gameSaveName = Console.ReadLine();

            if (string.IsNullOrEmpty(gameSaveName))
            {
                gameSaveName = $"new_game+";
            }
        }

        Play play = new Play();
        play.PlayGame(gameSaveName);

    }
}
