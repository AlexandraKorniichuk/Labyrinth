using System;

namespace Labyrinth
{
    public class Game
    {
        private (int, int) FieldSize = (10, 15);
        private const int WallChance = 25;

        private const int MaxMovesAmount = 40;
        private int MovesAmountLeft = MaxMovesAmount;

        private (int, int) PlayerPosition;
        private (int, int) KeyPosition;
        private (int, int)[] ExitPositions;
        private const int ExitsAmount = 3;

        private bool HaveGotKey = false;

        public static bool IsWin;

        private Random rand = new Random();
        public void StartNewGame()
        {
            IsWin = false;

            CreateSpecialObjectsPositions();
            char[,] GameField = CreateField();

            //while (!IsEndGame())
            //{
            DrawField(GameField);
            //}
        }

        private void CreateSpecialObjectsPositions()
        {
            PlayerPosition = GetRandomPosition();
            KeyPosition = GetRandomPosition();
            ExitPositions = new (int, int)[ExitsAmount] {
                GetRandomPosition(),
                GetRandomPosition(),
                GetRandomPosition(),
            };
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
                    if (CheckSpecialObjectsPostion((i, j)))
                    {
                        cell = CellSymbol.EmptySymbol;
                    }
                    else if (WallChance > randNumber)
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

        private bool CheckSpecialObjectsPostion((int, int) currentCell)
        {
            return PlayerPosition == currentCell || KeyPosition == currentCell || CheckExitPositions(currentCell);
        }

        private bool CheckExitPositions((int, int) currentCell)
        {
            for (int i = 0; i < ExitsAmount; i++)
            {
                if (currentCell == ExitPositions[i])
                    return true;
            }
            return false;
        }

        private (int, int) GetRandomPosition()
        {
            return (rand.Next(0, FieldSize.Item1), rand.Next(0, FieldSize.Item2));
        }

        private void DrawField(char[,] Field)
        {
            for (int i = 0; i < FieldSize.Item1; i++)
            {
                for (int j = 0; j < FieldSize.Item2; j++)
                {
                    char cell;
                    if (PlayerPosition == (i, j))
                    {
                        cell = CellSymbol.PlayerSymbol;
                    }
                    else if (KeyPosition == (i, j))
                    {
                        cell = CellSymbol.KeySymbol;
                    }
                    else if (CheckExitPositions((i, j)))
                    {
                        cell = CellSymbol.ExitSymbol;
                    }
                    else
                    {
                        cell = Field[i, j];
                    }
                    Console.Write(cell);
                }
                Console.WriteLine();
            }
        }

        private bool IsEndGame()
        {
            return false;
        }
    }
}