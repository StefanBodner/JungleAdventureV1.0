using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCreator
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
