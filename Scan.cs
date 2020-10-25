using System;
using System.Collections.Generic;

namespace PiGRogue
{
    class Scan
    {
        public static Tuple<int[], int> ChoiseWall(int direct, Rect room)
        {
            int x1 = room.GetCoords()[0];
            int y1 = room.GetCoords()[1];
            int x2 = room.GetCoords()[2];
            int y2 = room.GetCoords()[3];

            Tuple<int[], int> wall;

            switch (direct)
            {
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

            return wall;
        }
    }
}
