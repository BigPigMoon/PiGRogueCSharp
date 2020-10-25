using System;

namespace PiGRogue
{
    class Rect
    {
        private int x1, x2, y1, y2;
        private Random rnd = new Random();

        public Rect(int x, int y, int w, int h)
        {
            x1 = x;
            y1 = y;
            x2 = w + x;
            y2 = h + y;
        }

        public int[] GetCoords()
        {
            int[] ret = { x1, x2, y1, y2 };

            return ret;
        }

        public void Dig(Tile[,] area)
        {
            for (int x = Min(x1, x2); x < Max(x1, x2); x++)
            {
                for (int y = Min(y1, y2); y < Min(y1, y2); y++)
                {
                    area[x, y].block = false;
                    area[x, y].color = "black";
                    area[x, y].type = "void ";
                }
            }
        }

        public bool Intersect(Rect other)
        {
            if (x1 <= other.x2 && x2 >= other.x1 && y1 <= other.y2 && y2 >= other.y1) { return true; }
            return false;
        }

        public int[] GetCenter()
        {
            int centerX = (x1 + x2) / 2;
            int centerY = (y1 + y2) / 2;

            int[] ret = { centerX, centerY };
            return ret;
        }

        public int[] GetRandom()
        {
            int randomX = rnd.Next(x1 + 1, x2 - 1);
            int randomY = rnd.Next(y1 + 1, y2 - 1);

            int[] ret = { randomX, randomY };
            return ret;
        }

        private int Max(int a, int b)
        {
            if (a > b) { return a; }
            else { return b; }
        }

        private int Min(int a, int b)
        {
            if (a < b) { return a; }
            else { return b; }
        }
    }
}
