using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> journals = new List<string>();
        string userInput;
        bool startstop = false;

        Console.WriteLine("Enter 'start' to begin writing into the journal, 'stop' to end writing.");

        while (true)
        {
            userInput = Console.ReadLine();

            if (userInput == "start")
            {
                startstop = true;
                Console.WriteLine("You have started writing into the journal. Enter 'stop' to end writing.");

                // Add the prompts to the beginning of the journal
                journals.Add("Captain's log");
                journals.Add($"Stardate {DateTime.Now:yyyy-MM-dd}"); // I learned that from the internet that I can use DateTime.Now command to take the current day
                journals.Add("");
            }
            else if (userInput == "stop")
            {
                startstop = false;
                Console.WriteLine("You have stopped writing into the journal.");

                // Create a text file with the current date and write the journal into it
                string fileName = $"Captains_journal_{DateTime.Now:yyyy-MM-dd}.txt";
                File.WriteAllLines(fileName, journals);
                Console.WriteLine($"The journal has been saved into {fileName}.");

                // Adds "Jean-Luc Picard" to the end of the file
                File.AppendAllText(fileName, "\nJean-Luc Picard");

                // Clear the journal entries list for the next session
                journals.Clear();
            }
            else if (startstop)
            {
                journals.Add(userInput);
            }
        }
    }
}