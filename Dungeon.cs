using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiGRogue
{
    class Dungeon
    {
        Random rnd = new Random();
        private List<Floor> floors = new List<Floor>();
        private int maxNumFloor;

        public Dungeon()
        {
            maxNumFloor = rnd.Next(3, 8);

            for (int i = 0; i < maxNumFloor; i++)
            {
                // create_floor
            }
        }

        private void CreateFloor()
        {
            Tile[,] floor = new Tile[Floor.size, Floor.size];

            Rect start = CreateStart();
            start.Dig(floor);

            Rect firstRoom = CreateFirstRoom(start, floor);

            List<Rect> rooms = new List<Rect>();
            rooms.Add(firstRoom);
            List<Rect> tonnels = new List<Rect>();

            CreateMain(rooms, tonnels, floor);

            rooms.Remove(firstRoom);

            Rect end = CreateEnd(rooms, floor);
            rooms.Add(firstRoom);

            floor[end.GetCoords()[0], end.GetCoords()[1]] = new Tile("eXit", "blue", false);
            floor[start.GetCoords()[0], start.GetCoords()[1]] = new Tile("eXit", "blue", false);

            floors.Add(new Floor(floor, start, end, rooms));
        }

        private Rect CreateStart()
        {
            int x = rnd.Next(10, Floor.size - 10);
            int y = rnd.Next(10, Floor.size - 10);

            return new Rect(x, y, 1, 1);
        }

        private Rect CreateFirstRoom(Rect start, Tile[,] floor)
        {

        }

        private Rect CreateEnd(List<Rect> rooms, Tile[,] floor)
        {
            bool failed = false;
            
            while (!failed)
            {
                Rect end_room = rooms[rnd.Next(rooms.Count)];
                int direct = rnd.Next(1, 4);
            }
        }
    }
}
