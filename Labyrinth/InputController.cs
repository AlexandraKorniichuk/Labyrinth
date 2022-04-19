using System;

namespace Labyrinth
{
    public class InputController
    {
        public static ConsoleKey GetInputArrow()
        {
            ConsoleKey inputArrow;
            do
            {
                inputArrow = Console.ReadKey(true).Key;
            } while (inputArrow != ConsoleKey.DownArrow && inputArrow != ConsoleKey.UpArrow && inputArrow != ConsoleKey.RightArrow && inputArrow != ConsoleKey.LeftArrow);
            return inputArrow;
        }

        public static void InputKey(ConsoleKey desiredKey)
        {
            ConsoleKey inputKey;
            do
            {
                inputKey = Console.ReadKey(true).Key;
            } while (inputKey != desiredKey);
        }

        public static ConsoleKey GetInputKey() =>
            Console.ReadKey(true).Key;
    }
}