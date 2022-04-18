using System;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            Lobby lobby = new Lobby();
            Game game = new Game(); 

            lobby.OpenLobby();

            do
            {
                game.StartNewGame();

            } while (!lobby.IsEndGame());

            Console.ReadKey();
        }
    }
}
