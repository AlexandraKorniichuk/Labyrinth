using System;

namespace Labyrinth
{
    public class Converting
    {
        public static (int, int) GetDirection(string directionString)
        {
            int i = 0, j = 0;
            if (directionString == "UpArrow")
                i = -1;
            else if (directionString == "DownArrow")
                i = 1;
            else if (directionString == "RightArrow")
                j = 1;
            else if (directionString == "LeftArrow")
                j = -1;
            return (i, j);
        }
        public static (int, int) GetNewPostion((int, int) OldPosition, (int, int) direction) =>
            (OldPosition.Item1 + direction.Item1, OldPosition.Item2 + direction.Item2);
    }
}