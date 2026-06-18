using System;
using System.IO;
using System.Media;

public class AudioPlayer
{
    public static void PlayGreeting()
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Greeting.wav");

            if (File.Exists(filePath))
            {
                SoundPlayer player = new SoundPlayer(filePath);
                player.PlaySync();
            }
            else
            {
                Console.WriteLine("Greeting audio file not found.");
            }
        }
        catch
        {
            Console.WriteLine("Error playing audio.");
        }
    }
}
