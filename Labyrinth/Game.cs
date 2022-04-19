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
        public void StartNewRound()
        {
            IsWin = false;

            CreateSpecialObjectsPositions();
            char[,] GameField = CreateField();

            do
            {
                DrawField(GameField);
                WriteMessages();

                CheckHavingKey();

                ConsoleKey inputArrow = InputController.GetInputMovementKey();
                (int, int) direction = Converting.GetDirection(inputArrow.ToString());

                (int, int) NewPosition = Converting.GetNewPostion(PlayerPosition, direction);
                if (TryMove(GameField, NewPosition))
                    Move(NewPosition);

                MovesAmountLeft--;
                Console.Clear();
            } while (!IsEndGame());
        }

        private void CreateSpecialObjectsPositions()
        {
            PlayerPosition = GetRandomPosition();
            KeyPosition = GetRandomPosition();
            ExitPositions = new (int, int)[ExitsAmount] 
            {
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
                        cell = CellSymbol.EmptySymbol;
                    else if (WallChance > randNumber)
                        cell = CellSymbol.WallSymbol;
                    else
                        cell = CellSymbol.EmptySymbol;

                    Field[i, j] = cell;
                }
            }
            return Field;
        }

        private bool CheckSpecialObjectsPostion((int, int) currentCell) =>
            PlayerPosition == currentCell || KeyPosition == currentCell || CheckExitPositions(currentCell);

        private bool CheckExitPositions((int, int) currentCell)
        {
            for (int i = 0; i < ExitsAmount; i++)
            {
                if (currentCell == ExitPositions[i])
                    return true;
            }
            return false;
        }

        private (int, int) GetRandomPosition() =>
            (rand.Next(0, FieldSize.Item1), rand.Next(0, FieldSize.Item2));

        private void DrawField(char[,] Field)
        {
            for (int i = 0; i < FieldSize.Item1; i++)
            {
                for (int j = 0; j < FieldSize.Item2; j++)
                {
                    char cell;
                    if (PlayerPosition == (i, j))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        cell = CellSymbol.PlayerSymbol;
                    }
                    else if (KeyPosition == (i, j) && !HaveGotKey)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        cell = CellSymbol.KeySymbol;
                    }
                    else if (CheckExitPositions((i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        cell = CellSymbol.ExitSymbol;
                    }
                    else
                    {
                        cell = Field[i, j];
                    }
                    Console.Write(cell);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        private bool TryMove(char[,] Field, (int, int) NewPosition)
        {
            if (IsNewPositionOutOfField(NewPosition))
                return false;
            else if (IsNewPositionWall(Field, NewPosition))
                return false;

            return true;
        }

        private bool IsNewPositionWall(char[,] Field, (int, int) NewPosition) => 
            Field[NewPosition.Item1, NewPosition.Item2] == '#';

        private bool IsNewPositionOutOfField((int, int) NewPosition) =>
            NewPosition.Item1 < 0 || NewPosition.Item2 < 0 || NewPosition.Item1 >= FieldSize.Item1 || NewPosition.Item2 >= FieldSize.Item2;

        private void Move((int, int) NewPosition) =>
            PlayerPosition = NewPosition;

        private void WriteMessages()
        {
            WriteMovesMessage();
            WriteKeyMessage();
            WriteExitMessage();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WriteMovesMessage() =>
            Console.WriteLine($"Moves left: {MovesAmountLeft}");

        private void WriteKeyMessage() 
        {
            if (CheckKeyPosition())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You've got a key!");
            }
        }

        private void WriteExitMessage()
        {
            if (CheckExitPositions(PlayerPosition) || (PlayerPosition == ExitPositions[0] && !HaveGotKey))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Closed!");
            }
        }

        private void CheckHavingKey()
        {
            if (CheckKeyPosition())
                HaveGotKey = true;
        }

        private bool CheckKeyPosition() =>
            PlayerPosition == KeyPosition && !HaveGotKey;

        private bool IsEndGame()
        {
            if (HaveGotKey && PlayerPosition == ExitPositions[0])
            {
                IsWin = true;
                return true;
            }
            else if (MovesAmountLeft == 0)
            {
                IsWin = false;
                return true;
            }
            return false;
        }
    }
}