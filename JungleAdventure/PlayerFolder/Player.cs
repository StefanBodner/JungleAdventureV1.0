using JungleAdventure.Blocks;
using Microsoft.Xna.Framework;

namespace JungleAdventure.PlayerFolder
{
    internal class Player
    {
        BaseTile baseTile = new BaseTile();

        public Rectangle r = new Rectangle();

        public int x;
        public int y;

        //base variables
        public int speed = 3;
        public int height = 55;
        public int width = 32;
        public int jumpTicks = 0;
        public int minJumpTicks = 5;
        public int force = -17;
        public int gravity = 0;
        
        //different states
        public bool isInvincible = false;
        public bool inAir = true;
        public bool headroom = true;
        public bool readyToFire = true;

        // Collision Detectors
        public Rectangle colBottom;
        public Rectangle colTop;
        public Rectangle colLeft;
        public Rectangle colRight;
        public Rectangle colBottomCenter;
        public Rectangle colBelowBottomCenter;
        public Rectangle colRightTop;
        public Rectangle colLeftTop;

        //stats
        public int bulletAmount = 3;
        public int score = 0;
        public int life = 3;

        public Player() { }

        public Player(int spawnX, int spawnY)
        {
            this.x = spawnX;
            this.y = spawnY;
        }

        public void SetCollision()
        {
            colBottom = new Rectangle(x, y + height, width, speed); //Bottom Collision
            colTop = new Rectangle(x, y + gravity, width, speed); //Top Collision
            colLeft = new Rectangle(x - speed, y, speed, height); // Left Collision
            colLeftTop = new Rectangle(x - speed, y, speed, baseTile.tileHeight / 2); // Left Bottom Collision
            colRight = new Rectangle(x + width, y, speed, height); // Right Collision
            colRightTop = new Rectangle(x + width, y, speed, baseTile.tileHeight / 2); // Right Bottom Collision
            colBottomCenter = new Rectangle(x + width / 2, y + height - 2, 1, 1); //Bottom Center Collision
            colBelowBottomCenter = new Rectangle(x + width / 2, y + height + baseTile.tileHeight / 2, 1, 1); //Bottom Center Collision
        }
    }
}
