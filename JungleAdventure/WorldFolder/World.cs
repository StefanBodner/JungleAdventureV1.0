namespace JungleAdventure.WorldFolder
{
    internal class World
    {
        public int life { get; set; }
        public int bullets { get; set; }
        public int[,] world { get; set; }

        public World(int life, int bullets, int[,] world)
        {
            this.life = life;
            this.bullets = bullets;
            this.world = world;
        }
    }
}
