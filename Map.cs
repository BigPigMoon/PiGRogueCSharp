using System;

namespace PiGRogue
{
    class Map
    {
        public const int numChunk = 5;

        private Chunk[,] world = new Chunk[numChunk, numChunk];

        private Random rnd = new Random();

        public Map()
        {
            CreateWorld();
        }


        public Chunk GetChunk(int x, int y)
        {
            return world[x, y];
        }

        private void CreateWorld()
        {
            int size = Chunk.size;
            for (int i = 0; i < numChunk; i++)
            {
                for (int j = 0; j < numChunk; j++)
                {
                    world[i, j] = new Chunk();
                    for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            world[i, j].area[x, y] = new Tile("Grass", "white", false);
                        }
                    }
                }
            }

            for (int i = 0; i < numChunk; i++)
            {
                for (int j = 0; j < numChunk; j++)
                {
                    for (int a = 0; a < (int)(size * 0.46875); a++)
                    {
                        CreateArea(new Tile("Tree", "green", false), 3, i, j);
                    }
                    
                    for (int a = 0; a < (int)(size * 0.0234375); a++)
                    {
                        CreateArea(new Tile("Lake", "blue", true), 5, i, j);
                    }
                }
            }
        }

        private void CreateArea(Tile tile, int radius, int chunk_x, int chunk_y)
        {
            int size = Chunk.size;

            int i = rnd.Next(size + 1);
            int j = rnd.Next(size + 1);

            if (radius == 1) { radius = 2; }

            for (int a = 0; a < 100; a++)
            {
                Chunk chunk = world[chunk_x, chunk_y];

                int n = rnd.Next(1, radius);
                int w = rnd.Next(1, radius);
                int e = rnd.Next(1, radius);
                int s = rnd.Next(1, radius);

                if (n == 1)
                {
                    i--;
                    var tupl = CheckIJ(i, j, chunk_x, chunk_y);
                    i = tupl.Item1;
                    j = tupl.Item2;
                    chunk = tupl.Item3;
                    chunk.area[i, j] = tile;
                }
                if (s == 1)
                {
                    i++;
                    var tupl = CheckIJ(i, j, chunk_x, chunk_y);
                    i = tupl.Item1;
                    j = tupl.Item2;
                    chunk = tupl.Item3;
                    chunk.area[i, j] = tile;
                }

                if (w == 1)
                {
                    j--;
                    var tupl = CheckIJ(i, j, chunk_x, chunk_y);
                    i = tupl.Item1;
                    j = tupl.Item2;
                    chunk = tupl.Item3;
                    chunk.area[i, j] = tile;
                }
                
                if (e == 1)
                {
                    j++;
                    var tupl = CheckIJ(i, j, chunk_x, chunk_y);
                    i = tupl.Item1;
                    j = tupl.Item2;
                    chunk = tupl.Item3;
                    chunk.area[i, j] = tile;
                }
            }
        }

        private Tuple<int, int, Chunk> CheckIJ(int i, int j, int chunk_x, int chunk_y)
        {
            Chunk chunk = world[chunk_x, chunk_y];
            int size = Chunk.size;

            if (i >= size)
            {
                chunk_x++;
                if (chunk_x + 1 > numChunk) { chunk_x = 0; }
                chunk = world[chunk_x, chunk_y];
                i = 0;
            }

            if (j >= size)
            {
                chunk_y++;
                if (chunk_y + 1 > numChunk) { chunk_y = 0; }
                chunk = world[chunk_x, chunk_y];
                j = 0;
            }

            if (i < 0)
            {
                chunk_x--;
                if (chunk_x < 0) { chunk_x = numChunk - 1; }
                chunk = world[chunk_x, chunk_y];
                i = size - 1;
            }
            if (j < 0)
            {
                chunk_y--;
                if (chunk_y < 0) { chunk_y = numChunk - 1; }
                chunk = world[chunk_x, chunk_y];
                j = size - 1;
            }

            return Tuple.Create(i, j, chunk);
        }
    }
}
