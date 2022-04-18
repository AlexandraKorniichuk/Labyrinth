using System;

namespace Labyrinth
{
    public class Lobby
    {
        public void OpenLobby()
        {
            ShowGreating();
            CheckEnterKey();
            Console.Clear();
        }

        private void ShowGreating()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the labyrinth");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Rules are simple: ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Get out of Labyrynth before time runs out");
            Console.WriteLine("Take the key and find THE RIGHT exist");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Use arrows for movement");
            Console.WriteLine("Your character is '0', key is 'k', exits are '?'");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press 'Enter' to start");
        }

        private void CheckEnterKey()
        {
            ConsoleKey enterKey;
            do
            {
                enterKey = Console.ReadKey(true).Key;
            } while (enterKey != ConsoleKey.Enter);
        }
    }
}