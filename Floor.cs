using System;
using System.Collections.Generic;

namespace PiGRogue
{
    class Floor
    {
        public const int size = 128;

        public Tile[,] area;
        private Rect start;
        private Rect end;
        public List<Rect> rooms;

        public Floor(Tile[,] floor, Rect start, Rect end, List<Rect> rooms)
        {
            area = floor;
            this.start = start;
            this.end = end;
            this.rooms = rooms;
        }
    }
}
