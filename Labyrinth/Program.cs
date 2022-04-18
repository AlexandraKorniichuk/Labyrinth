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
            game.StartGame();


            Console.ReadKey();
        }
    }
}
