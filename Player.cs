using BearLib;

namespace PiGRogue
{
    class Player
    {
        private int x;
        private int y;
        private int status = -1;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetPosition(int x, int y)
        {
            if (x >= 0) { this.x = x; }
            if (y >= 0) { this.y = y; }
        }

        public int[] GetPosition()
        {
            int[] ret = { x, y };

            return ret;
        }
        public void Move(int dx, int dy, Chunk area)
        {
            x += dx;
            y += dy;

            if (BlockMove(area))
            {
                x -= dx;
                y -= dy;
            }
        }

        public void Dropper(Chunk area)
        {
            if (!area.area[x, y + 1].block) { y++; }
            else if (!area.area[x, y - 1].block) { y--; }
            else if (!area.area[x + 1, y].block) { x++; }
            else if (!area.area[x - 1, y].block) { x--; }
        }

        private bool BlockMove(Chunk area)
        {
            try { return area.area[x, y].block; }
            catch { return false; }
        }

        public void Draw(int x, int y)
        {
            Terminal.Layer(10);
            Terminal.Color("red");

            Terminal.Put(this.x - x, this.y - y, '@');

            Terminal.Color("white");
            Terminal.Layer(0);
        }

        public void Clear()
        {
            Terminal.Layer(10);
            Terminal.Put(x, y, ' ');
            Terminal.Layer(0);
        }
    }
}
