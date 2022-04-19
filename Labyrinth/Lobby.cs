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
            Console.WriteLine($"Your character is '{CellSymbol.PlayerSymbol}', key is '{CellSymbol.KeySymbol}', exits are '{CellSymbol.ExitSymbol}'");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press 'Enter' to start");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void CheckEnterKey()
        {
            InputController.InputKey(ConsoleKey.Enter);
        }

        public bool IsEndGame()
        {
            return true;
        }
    }
}