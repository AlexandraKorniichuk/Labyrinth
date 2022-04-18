using System;

namespace Labyrinth
{
    public class Game
    {
        private (int, int) FieldSize = (15, 15);
        private const int WallChance = 25;

        private const int MaxMovesAmount = 40;
        private int MovesAmountLeft = MaxMovesAmount;

        private (int, int) PlayerPosition;
        private (int, int) KeyPosition;
        private (int, int)[] ExitPositions = new (int, int)[3];

        private bool HaveGotKey = false;

        public static bool IsWin;

        private Random rand = new Random();
        public void StartNewGame()
        {
            IsWin = false;

            char[,] GameField = CreateField(); 
            CreateSpecialObjects();

        }

        private char[,] CreateField()
        {
            char[,] Field = new char[FieldSize.Item1, FieldSize.Item2];
            for (int i = 0; i < FieldSize.Item1; i++)
            {
                for (int j = 0; j < FieldSize.Item2; j++)
                {
                    int randNumber = rand.Next(0, 100);
                    char cell;
                    if (WallChance > randNumber)
                    {
                        cell = CellSymbol.WallSymbol;
                    }
                    else
                    {
                        cell = CellSymbol.EmptySymbol;
                    }
                    Field[i, j] = cell;
                }
            }
            return Field;
        }

        private void CreateSpecialObjects()
        {

        }
    }
}