using JungleAdventure.Blocks;
using JungleAdventure.Enemies;
using JungleAdventure.PlayerFolder;
using JungleAdventure.WorldFolder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JungleAdventure
{
    public class Game1 : Game
    {
        #region Variables
        //Monogame visualization
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        //List to store blocks
        static List<Rectangle> liBlockID = new List<Rectangle>();

        //Lists of Elements
        static List<Block> liBlocks = new List<Block>();
        static List<Slope> liSlopes = new List<Slope>();
        static List<Spike> liSpikes = new List<Spike>();
        static List<Coin> liCoins = new List<Coin>();
        static List<Zombie> liZombie = new List<Zombie>();
        static List<Bullet> liBullets = new List<Bullet>();
        static List<Lava> liLava = new List<Lava>();
        
        //Create BaseTypes of Classes to access variables
        public Texture2D spriteSheet;
        Texture2D background;
        BaseTile baseTile = new BaseTile() { };
        Zombie baseZombie = new Zombie() { };
        Bullet bullet = new Bullet() { };
        Player p = new Player() { };
        Portal portal = new Portal() { };


        //Timer for Damage Animation
        float damageTimer = 0;
        float damageThreshold = 1500;
        int damageAnimationInvisFrame;

        //User input 
        public bool left;
        public bool right;
        public bool up;
        public bool shoot;

        //Timer for Shooting ability
        int shootingAnimationIndex;
        float shootTimer;
        float shootThreshold = 500;

        // Result of Collision Detection
        static bool canMoveToTheLeft;
        static bool canMoveToTheRight;

        // Set Bounds for "Camera" Movement
        static int borderRight;
        static int borderLeft;
        static bool touchesBorderRight;
        static bool touchesBorderLeft;

        // Graphics/Animation Timer
        float timer; // A timer that stores milliseconds.
        int threshold; // An int that is the threshold for the timer.
        Rectangle[] sourcePlayer;
        Rectangle[] shootingPlayer;
        Rectangle[] sourceCoins;
        Rectangle[] sourceZombie;
        int playerAnimationIndex;
        int zombieAnimationIndex;
        int coinAnimationIndex;
        bool lastInputRight = true; // false = lastInputLeft
        SpriteEffects spriteEffects = SpriteEffects.None;

        //World
        static int worldOffsetX;
        static int[,] world = new int[,] { };
        #endregion 

        #region Game Initialization
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //graphics.PreferredBackBufferWidth = 640;  // set this value to the desired width of your window
            //graphics.PreferredBackBufferHeight = 360;   // set this value to the desired height of your window
            borderLeft = graphics.PreferredBackBufferWidth / 100 * 40;
            borderRight = graphics.PreferredBackBufferWidth / 100 * 60;
            graphics.ApplyChanges();
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        #endregion 

        #region Game Structure
        private string FilePathWorld()
        {
            string programFolderPath = AppDomain.CurrentDomain.BaseDirectory;

            // Loop through parent directories up to 3 levels
            for (int i = 0; i < 5; i++)
            {
                programFolderPath = Directory.GetParent(programFolderPath)?.FullName;
            }
            
            return Path.Combine(programFolderPath, "WorldCreation", "WorldCreator", "bin", "Debug", "Data");
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("SpriteSheet");
            background = Content.Load<Texture2D>("background");
            font = Content.Load<SpriteFont>("defaultFont");


            //Fill first block slot
            Rectangle r = new Rectangle(baseTile.tileWidth, baseTile.tileHeight, baseTile.tileWidth, baseTile.tileHeight);
            liBlockID.Add(r);

            //Fill block list
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    r = new Rectangle(baseTile.tileWidth * x, baseTile.tileHeight * y, baseTile.tileWidth, baseTile.tileHeight);
                    liBlockID.Add(r);
                }
            }

            liBlockID.Add(new Rectangle(6 * 32, 6 * 32, portal.tileWidth, portal.tileHeight));

            // Read the contents of the file
            string temp = FilePathWorld() + "\\selectedLevel.txt";
            int selectedWorld = Convert.ToInt32(File.ReadAllText(temp));

            //world selector
            switch (selectedWorld)
            {
                case 1:
                    temp = FilePathWorld() + "\\world1.json";
                    break;
                case 2:
                    temp = FilePathWorld() + "\\world2.json";
                    break;
                case 3:
                    temp = FilePathWorld() + "\\world3.json";
                    break;
                case 4:
                    temp = FilePathWorld() + "\\world4.json";
                    break;
                case 5:
                    temp = FilePathWorld() + "\\world5.json";
                    break;
                case 6:
                    temp = FilePathWorld() + "\\world6.json";
                    break;
            }

            //set variables
            World customWorld = JsonConvert.DeserializeObject<World>(File.ReadAllText(temp));
            p.life = customWorld.life;
            p.bulletAmount = customWorld.bullets;
            world = customWorld.world;

            //Load Player
            for (int y = 0; y < world.GetLength(0); y++)
            {
                for (int x = 0; x < world.GetLength(1); x++)
                {
                    switch (world[y, x])
                    {
                        case 13:
                            p = new Player(x * baseTile.tileWidth, y * baseTile.tileHeight - baseTile.tileHeight);
                            break;
                    }
                }
            }

            //Load all Animations
            AnimationLoadContent();

            //Load All Zombies in List
            for (int y = 0; y < world.GetLength(0); y++)
            {
                for (int x = 0; x < world.GetLength(1); x++)
                {
                    switch (world[y, x])
                    {
                        case 12:
                            liZombie.Add(new Zombie(x * baseTile.tileWidth, y * baseTile.tileHeight - 10, spriteSheet, sourceZombie[zombieAnimationIndex]));
                            break;
                    }
                }
            }
        }
        protected override void Update(GameTime gameTime)
        {
            p.SetCollision();
            SetPlayerMovementBounds();
            PlayerInput();
            CheckCollisionPlayer(gameTime);
            CheckCollisionEnemy();
            CheckCollisionBullet();
            BasicMovement();

            AnimationUpdate(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //Draw Background
            spriteBatch.Draw(background, new Rectangle(worldOffsetX / 3 - background.Width, 0, background.Width, background.Height), new Rectangle(0, 0, background.Width, background.Height), Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            spriteBatch.Draw(background, new Rectangle(worldOffsetX / 3, 0, background.Width, background.Height), Color.White);
            spriteBatch.Draw(background, new Rectangle(worldOffsetX / 3 + background.Width, 0, background.Width, background.Height), new Rectangle(0, 0, background.Width, background.Height),Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            spriteBatch.Draw(background, new Rectangle(worldOffsetX / 3 + background.Width * 2, 0, background.Width, background.Height), Color.White);
            spriteBatch.Draw(background, new Rectangle(worldOffsetX / 3 + background.Width, 3, background.Width, background.Height), new Rectangle(0, 0, background.Width, background.Height), Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            spriteBatch.Draw(background, new Rectangle(worldOffsetX / 3 + background.Width * 4, 0, background.Width, background.Height), Color.White);

            DrawPlayer();
            DrawBullets();
            DrawWorld();
            DrawEnemies();

            DrawScoreAndLifes();
            Shoot(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        private void DrawEnemies()
        {
            foreach (Zombie z in liZombie)
            {
                z.textureCoordinates = sourceZombie[zombieAnimationIndex];
                z.DrawZombie(spriteBatch, worldOffsetX);
            }
        }
        private void DrawBullets()
        {
            foreach(Bullet b in liBullets)
            {
                b.DrawBullet(spriteBatch, worldOffsetX);         
            }

            for (int i = liBullets.Count - 1; i >= 0; i--)
            {
                if(liBullets[i].x < 0 - worldOffsetX || liBullets[i].x > 1000 - worldOffsetX)
                {
                    liBullets.RemoveAt(i);
                }
            }
        }
        #endregion

        #region Collision
        private void CheckCollisionPlayer(GameTime gameTime)
        {
            p.SetCollision();
            
            p.inAir = true;
            p.headroom = true;
            canMoveToTheLeft = true;
            canMoveToTheRight = true;
            bool onSlope = false;

            //Check Spikes
            foreach (Spike s in liSpikes)
            {
                if (p.r.Intersects(s.r))
                {
                    RemoveLife();
                }
            }

            //Check Slopes
            foreach (Slope s in liSlopes)
            {
                //Check if Player stands on Slope
                if (p.colBelowBottomCenter.Intersects(s.r) && p.gravity >= 0)
                {
                    p.inAir = false;
                    p.y = s.CalcPlayerBottomCenterY(new Point(p.colBelowBottomCenter.Left - worldOffsetX, p.colBelowBottomCenter.Top)) - p.height;
                    p.gravity = 0;
                    p.SetCollision();
                    onSlope = true;
                }
                //Check if Player touches Slope
                else if (p.colBottomCenter.Intersects(s.r) && p.gravity >= 0)
                {
                    p.inAir = false;
                    p.y = s.CalcPlayerBottomCenterY(new Point(p.colBottomCenter.Left - worldOffsetX, p.colBottomCenter.Top)) - p.height;
                    p.gravity = 0;
                    p.SetCollision();
                    onSlope = true;
                }
            }

            //Check Blocks
            foreach (Block b in liBlocks)
            {
                if (p.colBottom.Intersects(b.r) && !onSlope)
                {
                    p.inAir = false;
                    p.y = b.r.Top - p.height;
                    p.gravity = 0;
                    p.SetCollision();
                }
                if (p.colTop.Intersects(b.r) && p.gravity < 0)
                {
                    p.headroom = false;
                    p.gravity = 0;
                    p.y = b.r.Bottom;
                    p.SetCollision();
                }
                if ((p.colLeft.Intersects(b.r) && !onSlope) || (p.colLeftTop.Intersects(b.r) && onSlope))
                {
                    canMoveToTheLeft = false;
                    p.x = b.r.Right;
                    p.SetCollision();
                }
                if ((p.colRight.Intersects(b.r) && !onSlope) || (p.colRightTop.Intersects(b.r) && onSlope))
                {
                    canMoveToTheRight = false;
                    p.x = b.r.Left - p.width;
                    p.SetCollision();
                }
            }

            //Check Coins
            foreach (Coin c in liCoins)
            {
                if (p.r.Intersects(c.r))
                {
                    p.score++;
                    if(p.score >= 10)
                    {
                        p.life++;
                        p.score = 0;
                    }

                    int coinBlockY = Convert.ToInt32(Math.Floor(((float)c.tileX - (float)worldOffsetX) / (float)baseTile.tileWidth));
                    int coinBlockX = Convert.ToInt32(Math.Floor((float)c.tileY / (float)baseTile.tileWidth));

                    world[coinBlockX, coinBlockY] = 0;
                }
            }

            //Check Zombie
            foreach (Zombie z in liZombie)
            {
                if (p.r.Intersects(z.r))
                {
                    RemoveLife();
                }
            }
            
            foreach(Lava l in liLava)
            {
                if (p.r.Intersects(l.r))
                {
                    p.life = 0;
                    RemoveLife();
                }
            }

            if (p.isInvincible)
            {
                if (damageTimer < damageThreshold)
                {
                    //Animatie Damage
                    damageTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else
                {
                    p.isInvincible = false;
                    damageTimer = 0;
                }
            }

            if(p.y > 16 * 32)
            {
                RemoveLife();
            }

            if (p.r.Intersects(portal.r))
            {
                
                Exit();
            }
        }
        private void CheckCollisionEnemy()
        {
            foreach (Zombie z in liZombie)
            {
                //Create Ground Check for Zombies
                Rectangle groundCheck = new Rectangle(z.r.X + z.zombieWidth / 2, z.r.Y + z.zombieHeight, 1, 16);

                bool inAir = true;
                bool touchesWall = false;

                foreach (Block b in liBlocks)
                {
                    //Check if Zombie touches Ground
                    if (groundCheck.Intersects(b.r))
                    {
                        inAir = false;
                    }
                    if (z.r.Intersects(b.r))
                    {
                        touchesWall = true;
                    }
                }

                if (touchesWall || inAir)
                {
                    //Change walking direction
                    z.zombieSpeed = -z.zombieSpeed;
                }

                //Move Zombie
                z.awayFromBaseXCoordinate += z.zombieSpeed;
            }
        }
        private void CheckCollisionBullet()
        {
            if(liBullets.Count <= 0)
            {
                return;
            }

            foreach(Bullet b in liBullets)
            {
                //Check Zombie Collision
                foreach(Zombie z in liZombie)
                {
                    if (b.r.Intersects(z.r))
                    {
                        liBullets.Remove(b);
                        liZombie.Remove(z);
                        p.score += 2; //Get Scorepoints for killing Zombie
                        return;
                    }
                }

                //Check Block Collision
                foreach(Block bl in liBlocks)
                {
                    if (b.r.Intersects(bl.r))
                    {
                        liBullets.Remove(b);
                        return;
                    }
                }
            }
        }
        private void RemoveLife()
        {
            if (!p.isInvincible)
            {
                p.life--;
                p.isInvincible = true;
                if (p.life < 0)
                {
                    Exit();
                    return;
                }
            }
        }
        #endregion

        #region Player + World Creation
        private void PlayerInput()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                left = true;
                lastInputRight = false;
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else { left = false; }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                right = true;
                lastInputRight = true;
                spriteEffects = SpriteEffects.None;
            }
            else { right = false; }
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                up = true;
            }
            else { up = false; }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.Space) && !left && !right && !p.inAir)
            {
                shoot = true;
            }
            else 
            { 
                shoot = false;
                p.readyToFire = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                //TODO: OPEN NEW WINDOW
            }
        }
        public void BasicMovement()
        {
            //basic left & right movement
            if (left && canMoveToTheLeft && !touchesBorderLeft)
            {
                p.x -= p.speed;
            }
            else if (right && canMoveToTheRight && !touchesBorderRight)
            {
                p.x += p.speed;
            }

            //allow player to jump
            if (up && !p.inAir)
            {
                p.inAir = true;
                p.gravity = p.force;
            }

            //check if player touches the floor
            if (p.inAir)
            {
                p.gravity += 1;
            }
            else if (!p.inAir)
            {
                p.gravity = 0;
            }

            //track jumping duration
            if (p.gravity < 0)
            {
                p.jumpTicks++;
            }
            else if (p.gravity >= 0) //if player starts falling - reset jumpTick tracker
            {
                p.jumpTicks = 0;
            }

            //Prevent player from going higher
            if (!up && p.gravity < 0 && p.jumpTicks >= p.minJumpTicks)
            {
                //-3 because of smoother jumping curve - not an aprupt stop in velocity
                p.gravity = -3;
                p.jumpTicks = 0;
            }

            //move player according to p.gravity's value
            p.y += p.gravity;
        }
        public void Shoot(GameTime gameTime)
        {
            if (!shoot || !p.readyToFire) //Do nothing if player doesn't shoot or isnt ready to fire
            {
                shootTimer = 0;
                return; 
            } 

            if (p.bulletAmount <= 0) //Do nothing if player has no bullets left
            {
                return;
            }

            if (shootTimer > shootThreshold)
            {
                //Shoot bullet after loading the gun
                liBullets.Add(new Bullet(p.x + p.width / 2 - worldOffsetX - bullet.bulletWidth / 2, p.y + p.height / 2 - 6, spriteSheet, new Rectangle(352, 224, bullet.bulletWidth, bullet.bulletHeight), lastInputRight));
                p.bulletAmount--;
                p.readyToFire = false;
                return;
            }
            shootTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        }
        public void SetPlayerMovementBounds()
        {
            if (p.x + p.width > borderRight)
            {
                touchesBorderRight = true;
            }
            else
            {
                touchesBorderRight = false;
            }

            if (p.x < borderLeft)
            {
                touchesBorderLeft = true;
            }
            else
            {
                touchesBorderLeft = false;
            }
        }
        public void SetWorldOffset()
        {
            if (touchesBorderLeft && left)
            {
                worldOffsetX += p.speed;
            }
            else if (touchesBorderRight && right)
            {
                worldOffsetX -= p.speed;
            }
        }
        public void DrawWorld()
        {
            SetWorldOffset();
            liBlocks.Clear();
            liSlopes.Clear();
            liCoins.Clear();
            liSpikes.Clear();
            liLava.Clear();

            Block b;
            Slope s;
            Coin c;
            Spike spike;
            Lava l;

            for (int y = 0; y < world.GetLength(0); y++)
            {
                for (int x = 0; x < world.GetLength(1); x++)
                {
                    switch (world[y, x])
                    {
                        case 1: //dirt block
                            b = new Block(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, spriteSheet, liBlockID[1]);
                            b.DrawBlock(spriteBatch);
                            liBlocks.Add(b);
                            break;
                        case 2: //grass block
                            b = new Block(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, spriteSheet, liBlockID[2]);
                            b.DrawBlock(spriteBatch);
                            liBlocks.Add(b);
                            break;
                        case 3: //grass flat bottom slope | bottom right
                            s = new Slope(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, 0.5f, 0, spriteSheet, liBlockID[3]);
                            s.DrawBlock(spriteBatch);
                            liSlopes.Add(s);
                            break;
                        case 4: //grass flat top slope | bottom right
                            s = new Slope(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, 0.5f, baseTile.tileHeight / 2, spriteSheet, liBlockID[4]);
                            s.DrawBlock(spriteBatch);
                            liSlopes.Add(s);
                            break;
                        case 5: //grass flat top slope | bottom left
                            s = new Slope(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, -0.5f, baseTile.tileHeight, spriteSheet, liBlockID[4]);
                            s.DrawBlockRotate(spriteBatch);
                            liSlopes.Add(s);
                            break;
                        case 6: //grass flat bottom slope | bottom left
                            s = new Slope(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, -0.5f, baseTile.tileHeight / 2, spriteSheet, liBlockID[3]);
                            s.DrawBlockRotate(spriteBatch);
                            liSlopes.Add(s);
                            break;
                        case 7: //grass steep slope | bottom right
                            s = new Slope(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, 1f, 0, spriteSheet, liBlockID[5]);
                            s.DrawBlock(spriteBatch);
                            liSlopes.Add(s);
                            break;
                        case 8: //grass steep slope | bottom left
                            s = new Slope(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, -1f, baseTile.tileHeight, spriteSheet, liBlockID[5]);
                            s.DrawBlockRotate(spriteBatch);
                            liSlopes.Add(s);
                            break;
                        case 9: //Spike
                            spike = new Spike(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, spriteSheet, liBlockID[6]);
                            spike.DrawBlock(spriteBatch);
                            liSpikes.Add(spike);
                            break;
                        case 10: //LAVA - instakill
                            l = new Lava(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, spriteSheet, liBlockID[13]);
                            l.DrawBlock(spriteBatch);
                            liLava.Add(l);
                            break;
                        case 11: //Coin
                            c = new Coin(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, spriteSheet, sourceCoins[coinAnimationIndex]);
                            c.DrawBlock(spriteBatch);
                            liCoins.Add(c);
                            break;
                        case 12:
                            //Enemy - Already handled in LoadContent()
                            break;
                        case 13:
                            //Player - Already handled in LoadContent()
                            break;
                        case 14: //Portal
                            portal = new Portal(x * baseTile.tileWidth + worldOffsetX, y * baseTile.tileHeight, spriteSheet, liBlockID[37]);
                            portal.DrawBlock(spriteBatch);
                            break;
                    }
                }
            }
        }
        public void DrawPlayer()
        {
            p.r = new Rectangle(p.x, p.y, p.width, p.height);
            

            if (p.isInvincible) //Player took damage
            {
                if (damageAnimationInvisFrame <= 4) //Let user know that player was hit -> blinking
                {
                    damageAnimationInvisFrame ++;
                    spriteBatch.Draw(spriteSheet, p.r, sourcePlayer[playerAnimationIndex], Color.White, 0, new Vector2(0, 0), spriteEffects, 0);
                }
                else
                {
                    damageAnimationInvisFrame = 0;
                }
            }
            else if(shoot && p.readyToFire && p.bulletAmount != 0)
            {
                //Draw Player
                if(shootingAnimationIndex >= 21)
                {
                    spriteBatch.Draw(spriteSheet, p.r, shootingPlayer[3], Color.White, 0, new Vector2(0, 0), spriteEffects, 0);
                }
                else if (shootingAnimationIndex >= 14)
                {
                    spriteBatch.Draw(spriteSheet, p.r, shootingPlayer[2], Color.White, 0, new Vector2(0, 0), spriteEffects, 0);
                }
                else if (shootingAnimationIndex >= 7)
                {
                    spriteBatch.Draw(spriteSheet, p.r, shootingPlayer[1], Color.White, 0, new Vector2(0, 0), spriteEffects, 0);
                }
                else if (shootingAnimationIndex >= 0)
                {
                    spriteBatch.Draw(spriteSheet, p.r, shootingPlayer[0], Color.White, 0, new Vector2(0, 0), spriteEffects, 0);
                }

                //Next Animation Frame
                shootingAnimationIndex++;
            }
            else
            {
                //Draw Player - normal state
                spriteBatch.Draw(spriteSheet, p.r, sourcePlayer[playerAnimationIndex], Color.White, 0, new Vector2(0, 0), spriteEffects, 0);
                shootingAnimationIndex = 0;
            }

            
        }
        public void DrawScoreAndLifes()
        {
            spriteBatch.Draw(this.spriteSheet, new Rectangle(0, 0, 4 * 32, 3 * 32), new Rectangle(8 * 32, 6 * 32, 4 * 32, 3 * 32), Color.White);

            spriteBatch.DrawString(font, "Lifes: " + p.life, new Vector2(25, 20), Color.Black);
            spriteBatch.DrawString(font, "Score: " + p.score, new Vector2(25, 40), Color.Black);
            spriteBatch.DrawString(font, "Bullets: " + p.bulletAmount, new Vector2(25, 60), Color.Black);
        }
        #endregion

        #region Animation
        public void AnimationLoadContent()
        {
            // Set a default timer value.
            timer = 0;
            //speed of the animation (lower number = faster animation).
            threshold = 100;

            sourcePlayer = new Rectangle[7];
            sourcePlayer[0] = new Rectangle(0, 105, 32, p.height);
            sourcePlayer[1] = new Rectangle(32, 105, 32, p.height);
            sourcePlayer[2] = new Rectangle(64, 105, 32, p.height);
            sourcePlayer[3] = new Rectangle(96, 105, 32, p.height);
            sourcePlayer[4] = new Rectangle(128, 105, 32, p.height);
            sourcePlayer[5] = new Rectangle(160, 105, 32, p.height);
            sourcePlayer[6] = new Rectangle(192, 105, 32, p.height);

            shootingPlayer = new Rectangle[4];
            shootingPlayer[0] = new Rectangle(0, 169, 32, p.height);
            shootingPlayer[1] = new Rectangle(32, 169, 32, p.height);
            shootingPlayer[2] = new Rectangle(64, 169, 32, p.height);
            shootingPlayer[3] = new Rectangle(96, 169, 32, p.height);

            sourceCoins = new Rectangle[6];
            sourceCoins[0] = new Rectangle(0, 64, baseTile.tileWidth, baseTile.tileHeight);
            sourceCoins[1] = new Rectangle(32, 64, baseTile.tileWidth, baseTile.tileHeight);
            sourceCoins[2] = new Rectangle(64, 64, baseTile.tileWidth, baseTile.tileHeight);
            sourceCoins[3] = new Rectangle(96, 64, baseTile.tileWidth, baseTile.tileHeight);
            sourceCoins[4] = new Rectangle(128, 64, baseTile.tileWidth, baseTile.tileHeight);
            sourceCoins[5] = new Rectangle(160, 64, baseTile.tileWidth, baseTile.tileHeight);

            sourceZombie = new Rectangle[4];
            sourceZombie[0] = new Rectangle(0, 224 + 22, baseZombie.zombieWidth, baseZombie.zombieHeight);
            sourceZombie[1] = new Rectangle(32, 224 + 22, baseZombie.zombieWidth, baseZombie.zombieHeight);
            sourceZombie[2] = new Rectangle(64, 224 + 22, baseZombie.zombieWidth, baseZombie.zombieHeight);
            sourceZombie[3] = new Rectangle(96, 224 + 22, baseZombie.zombieWidth, baseZombie.zombieHeight);

            // This tells the animation to start on the left-side sprite.
            playerAnimationIndex = 1;
        }
        public void AnimationUpdate(GameTime gameTime)
        { 
            // Check if the timer has exceeded the threshold.
            if (timer > threshold) 
            {
                //Player Animation
                if (!right && !left)
                {
                    if (lastInputRight)
                    {
                        playerAnimationIndex = 0;
                    }
                    else
                    {
                        playerAnimationIndex = 0;
                    }
                }
                if (right || left)
                {
                    playerAnimationIndex++;
                    if (playerAnimationIndex == sourcePlayer.Length)
                    {
                        playerAnimationIndex = 1;
                    } 
                }

                //Coins Animation
                coinAnimationIndex++;
                if (coinAnimationIndex == 6)
                {
                    coinAnimationIndex = 0;
                }

                //Zombie Animation
                zombieAnimationIndex++;
                if(zombieAnimationIndex == 3)
                {
                    zombieAnimationIndex = 0;
                }

                // Reset the timer.
                timer = 0;
            }
            // If the timer has not reached the threshold, then add the milliseconds that have past since the last Update() to the timer.
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        #endregion
    }
} 