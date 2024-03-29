﻿using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> journals = new List<string>();
        string userInput;
        bool startstop = false;

        Console.WriteLine("Enter 'start' to start writing into your journal, 'stop' to end writing.");

        while (true)
        {
            userInput = Console.ReadLine();

            if (userInput == "start")
            {
                startstop = true;
                Console.WriteLine("You just begin to write your journal Mr. Picard. Enter 'stop' to end writing.");

                // Add the prompts to the beginning of the journal
                journals.Add("Captain's log");
                journals.Add($"Stardate {DateTime.Now:yyyy-MM-dd}"); // I learned that from the internet that I can use DateTime.Now command to take the current day
                journals.Add("");
            }
            else if (userInput == "stop")
            {
                startstop = false;
                Console.WriteLine("You stopped writing into the journal.");

                // Create a text file with the current date and write the journal into it
                string fileName = $"Captains_journal_{DateTime.Now:yyyy-MM-dd}.txt";
                File.WriteAllLines(fileName, journals);
                Console.WriteLine($"The journal has been saved into {fileName}.");

                // Adds "Jean-Luc Picard" text to the end of the file
                File.AppendAllText(fileName, "\nJean-Luc Picard");

                // Clear the journal entries for the next try
                journals.Clear();
            }
            else if (startstop)
            {
                journals.Add(userInput);
            }
        }
    }
}