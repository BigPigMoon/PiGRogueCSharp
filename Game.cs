using BearLib;

namespace PiGRogue
{
    class Game
    {
        private static bool gameFlag = true;
        private static int turnCounter = -1;

        private static Player player = new Player(45, 55);
        private static View view = new View(player);

        private static Map map = new Map();

        private static int chunkX = 2;
        private static int chunkY = 2;
        private static Chunk loadChunk = map.GetChunk(chunkX, chunkY);


        static void Main(string[] argv)
        {
            Terminal.Open();
            Terminal.Set("GameSettings.ini");
            
            while (gameFlag)
            {
                GameInput();

                view.Update();
                view.Draw(loadChunk);

                Terminal.Print(52, 1, $"player: x={player.GetPosition()[0]}, y={player.GetPosition()[1]}");
                Terminal.Print(52, 3, $"view: x={view.GetPosition()[0]}, y={player.GetPosition()[1]}");

                Terminal.Refresh();
                Terminal.Clear();
            }

            Terminal.Close();
        }

        static private void JumpChunk(int chunkX, int chunkY)
        {
            if (chunkX == 0)
            {
                Game.chunkY += chunkY;

                if (chunkY > 0) { view.SetPosition(-1, 0); }
                else { view.SetPosition(-1, Chunk.size - view.GetSize()[1]); }
            }

            else if (chunkY == 0)
            {
                Game.chunkX += chunkX;
                
                if (chunkX > 0) { view.SetPosition(0, -1); }
                else { view.SetPosition(Chunk.size - view.GetSize()[0], -1); }
            }

            if (Game.chunkX < 0) { Game.chunkX = Map.numChunk - 1; }
            if (Game.chunkY < 0) { Game.chunkY = Map.numChunk - 1; }
            if (Game.chunkX > Map.numChunk - 1) { Game.chunkX = 0; }
            if (Game.chunkY > Map.numChunk - 1) { Game.chunkY = 0; }

            loadChunk = map.GetChunk(Game.chunkX, Game.chunkY);
        }

        static private bool GameInput()
        {
            if (turnCounter == -1)
            {
                turnCounter++;
                return false;
            }

            if (Terminal.HasInput())
            {
                int key = Terminal.Read();

                if (key == Terminal.TK_ESCAPE || key == Terminal.TK_CLOSE)
                {
                    gameFlag = false;
                }

                if (key == Terminal.TK_LEFT || key == Terminal.TK_H)
                {
                    player.Move(-1, 0, loadChunk);

                    // jump
                    if (player.GetPosition()[0] < 0)
                    {
                        JumpChunk(-1, 0);
                        player.SetPosition(Chunk.size - 1, -1);
                    }

                    turnCounter += 1;
                    return true;
                }

                if (key == Terminal.TK_RIGHT || key == Terminal.TK_L)
                {
                    player.Move(1, 0, loadChunk);

                    // jump
                    if (player.GetPosition()[0] > Chunk.size - 1)
                    {
                        JumpChunk(1, 0);
                        player.SetPosition(0, -1);
                    }

                    turnCounter += 1;
                    return true;
                }

                if (key == Terminal.TK_UP || key == Terminal.TK_K)
                {
                    player.Move(0, -1, loadChunk);

                    // jump
                    if (player.GetPosition()[1] < 0)
                    {
                        JumpChunk(0, -1);
                        player.SetPosition(-1, Chunk.size - 1);
                    }

                    turnCounter += 1;
                    return true;
                }

                if (key == Terminal.TK_DOWN || key == Terminal.TK_J)
                {
                    player.Move(0, 1, loadChunk);

                    // jump
                    if (player.GetPosition()[1] > Chunk.size - 1)
                    {
                        JumpChunk(0, 1);
                        player.SetPosition(-1, 0);
                    }

                    turnCounter += 1;
                    return true;
                }
            }

            return false;
        }
    }
}
