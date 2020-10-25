using BearLib;

namespace PiGRogue
{ 
    class View
    {
        private const int width = 50;
        private const int height = 50;
        private int x = 0;
        private int y = 0;

        private Player player;

        public View(Player player)
        {
            this.player = player;

            Update();
        }

        public void SetPosition(int x, int y)
        {
            if (x >= 0){ this.x = x; }
            if (y >= 0) { this.y = y; }                
        }

        public int[] GetSize()
        {
            int[] ret = { width, height };
            return ret;
        }

        public int[] GetPosition()
        {
            int[] ret = { x, y };
            return ret;
        }

        public void Update()
        {
            int[] playerPos = player.GetPosition();

            x = playerPos[0] - width / 2 + 1;
            y = playerPos[1] - height / 2 + 1;

            if (x < 0) { x = 0; }
            if (y < 0) { y = 0; }
        }

        public void Draw(Chunk chunk)
        {
            Terminal.Layer(1);

            if (x > Chunk.size - width) { x = Chunk.size - width; }
            if (y > Chunk.size - width) { y = Chunk.size - width; }

            int vx = 0;
            int vy = 0;

            for (int j = y; j < height + y; j++)
            {
                for (int i = x; i < width + x; i++)
                {
                    Tile cell = chunk.area[i, j];
                    Terminal.Color(cell.color);
                    Terminal.Put(vx, vy, cell.c);
                    vx++;
                }
                vx = 0;
                vy++;
            }

            Terminal.Layer(0);
            Terminal.Color("white");

            player.Draw(x, y);
        }
    }
}
