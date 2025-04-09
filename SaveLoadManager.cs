using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class SaveLoadManager
    {
       
        public const string SaveDirectory = "Saves";
        public static readonly string SaveFilePath = Path.Combine(SaveDirectory, $"save.json");

       

        public string SaveList()
        {
            Console.WriteLine("Avaliable saves: ");
            List<string> saveFile = SaveLoadManager.GetSaveFiles();
            int saveCount = saveFile.Count;

            if (saveFile.Count > 0 && saveFile != null)
            {
                for (int i = 0; i < saveFile.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {saveFile[i]}");
                }
            }
            Console.WriteLine($"{saveFile.Count + 1}. New game");

            Console.WriteLine($"Choose save for loaded");
            string choose = Console.ReadLine();
            int selectedIndex;

            PlayerProgress playerProgress = null;

            if (int.TryParse(choose, out selectedIndex))
            {
                if (selectedIndex >= 1 && selectedIndex <= saveFile.Count)
                {
                    string selectedFile = Path.Combine(SaveDirectory, $"{saveFile[selectedIndex - 1]}.json");
                    string selectedFileName = saveFile[selectedIndex - 1];
                    playerProgress = LoadProgress(selectedFile);
                    if (playerProgress != null)
                    {
                        Console.WriteLine("Game have been loaded");
                        return selectedFileName;
                    }
                    else
                    {
                        Console.WriteLine($"Error of loading save file");
                        return null;
                    }
                }
                else if (selectedIndex == saveFile.Count + 1)
                {
                    Console.WriteLine("New game begining");
                    return string.Empty;
                }
                else
                {
                    Console.WriteLine("Wrong input");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
                return null;
            }
        }

        public void InitializeSaveSistem()
        {
            try
            {
                if (!Directory.Exists(SaveDirectory))
                {
                    Directory.CreateDirectory(SaveDirectory);
                    Console.WriteLine("The directory of save files has beed created");
                }
                if (!File.Exists(SaveFilePath))
                {
                    PlayerProgress initialProgress = new PlayerProgress();
                    string jsonString = JsonSerializer.Serialize(initialProgress);
                    File.WriteAllText(SaveFilePath, jsonString);
                    Console.WriteLine($"The saving file with start progress has been created {SaveFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error of initialize saving system");
            }
        }

        public void SaveProgress(PlayerProgress progress, string saveFileName)
        {
            if (!Directory.Exists(SaveDirectory)) { Directory.CreateDirectory(SaveDirectory); }
            string filePath = Path.Combine(SaveDirectory, $"{saveFileName}");
            try
            {
                string jsonString = JsonSerializer.Serialize(progress);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Progress has been saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error of saving progress in {filePath}:{ex.Message} ");
            }
        }
        public PlayerProgress LoadProgress(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<PlayerProgress>(jsonString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error of loading progress  of  {filePath}:{ex.Message}");
                    return null;
                }
            }
            return null;
        }

        private static List<string> GetSaveFiles()
        {
            if (!Directory.Exists(SaveFilePath))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
            return Directory.GetFiles(SaveDirectory, "*.json").Select(Path.GetFileNameWithoutExtension).ToList();
        }
    }
}
