using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WorldCreator
{
    public partial class frm_creator : Form
    {
        List<Image> imageList = new List<Image>();
        Bitmap cloneBitmap;
        Bitmap bitmap;

        Graphics formGraphics;
        Image image = Properties.Resources.SpriteSheet;

        int[,] array = new int[200, 50];

        bool mouseDown;

        int selectedIndex = 1;

        public frm_creator()
        {
            InitializeComponent();
            formGraphics = panel1.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hScrollBar1.Maximum = panel1.Width + hScrollBar1.LargeChange - this.Width - 1;

            cb_lifes.SelectedIndex = 2;
            cb_bullets.SelectedIndex = 3;


            // Create a Bitmap object from a file.
            Bitmap myBitmap = new Bitmap(Properties.Resources.SpriteSheet);

            // Clone a portion of the Bitmap object.
            cloneBitmap = myBitmap.Clone(new Rectangle(0, 0, 32, 32), myBitmap.PixelFormat);

            //Split up for-loop -> Memory Issue
            for (int x = 0; x < 6; x++) 
            {
                imageList.Add(myBitmap.Clone(new Rectangle(x * 32, 0, 32, 32), myBitmap.PixelFormat)); //First Row SpriteSheet

                if(x == 3)
                {
                    bitmap = new Bitmap(imageList[3]);
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    imageList.Add(bitmap);

                    bitmap = new Bitmap(imageList[2]);
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    imageList.Add(bitmap);
                }
                if(x == 4)
                {
                    bitmap = new Bitmap(imageList[6]);
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    imageList.Add(bitmap);
                }
            }

            imageList.Add(myBitmap.Clone(new Rectangle(0, 32, 32, 32), myBitmap.PixelFormat)); //LAVA
            imageList.Add(myBitmap.Clone(new Rectangle(96, 64, 32, 32), myBitmap.PixelFormat)); //Coin
            imageList.Add(myBitmap.Clone(new Rectangle(0, 246, 32, 42), myBitmap.PixelFormat)); //Zombie
            imageList.Add(myBitmap.Clone(new Rectangle(0, 96, 32, 64), myBitmap.PixelFormat)); //PLAYER
            imageList.Add(myBitmap.Clone(new Rectangle(6*32, 6*32, 64, 96), myBitmap.PixelFormat)); //Portal
            imageList.Add(myBitmap.Clone(new Rectangle(2*32, 32, 32, 32), myBitmap.PixelFormat)); //Eraser

            //LIST
            pb_01.BackgroundImage = imageList[0];
            pb_02.BackgroundImage = imageList[1];
            pb_03.BackgroundImage = imageList[2];
            pb_04.BackgroundImage = imageList[3];
            pb_05.BackgroundImage = imageList[4];
            pb_06.BackgroundImage = imageList[5];
            pb_07.BackgroundImage = imageList[6];
            pb_08.BackgroundImage = imageList[7];
            pb_09.BackgroundImage = imageList[8]; //SPIKE
            pb_10.BackgroundImage = imageList[9]; //LAVA
            pb_11.BackgroundImage = imageList[10]; //COIN
            pb_12.BackgroundImage = imageList[11]; //Zombie
            pb_13.BackgroundImage = imageList[12];  //Player
            pb_14.BackgroundImage = imageList[13]; //Portal
            pb_14.BackgroundImageLayout = ImageLayout.Stretch;
            pb_15.BackgroundImage = imageList[14];
        }
        
        private void DrawBlock(int index, int x, int y)
        {
            switch (index)
            {
                case 0:
                    //AIR
                    break;
                case 1:
                    formGraphics.DrawImage(imageList[0], x * 32, y * 32);
                    break;
                case 2:
                    formGraphics.DrawImage(imageList[1], x * 32, y * 32);
                    break;
                case 3:
                    formGraphics.DrawImage(imageList[2], x * 32, y * 32);
                    break;
                case 4:
                    formGraphics.DrawImage(imageList[3], x * 32, y * 32);
                    break;
                case 5:
                    formGraphics.DrawImage(imageList[4], x * 32, y * 32);
                    break;
                case 6:
                    formGraphics.DrawImage(imageList[5], x * 32, y * 32);
                    break;
                case 7:
                    formGraphics.DrawImage(imageList[6], x * 32, y * 32);
                    break;
                case 8:
                    formGraphics.DrawImage(imageList[7], x * 32, y * 32);
                    break;
                case 9:
                    formGraphics.DrawImage(imageList[8], x * 32, y * 32);
                    break;
                case 10:
                    formGraphics.DrawImage(imageList[9], x * 32, y * 32);
                    break;
                case 11:
                    formGraphics.DrawImage(imageList[10], x * 32, y * 32);
                    break;
                case 12: //ZOMBIE
                    formGraphics.DrawImage(imageList[11], x * 32, y * 32 - 10);
                    break;
                case 13: //PLAYER
                    formGraphics.DrawImage(imageList[12], x * 32, (y - 1)  * 32);
                    break;
                case 14:
                    formGraphics.DrawImage(imageList[13], x * 32, y * 32);
                    break;
                case 15:
                    //Eraser
                    formGraphics.FillRectangle(new SolidBrush(Color.White), x*32, y*32, 32, 32);
                    break;
            }
        }
        
        private void DrawWorld()
        {
            //Calculate Blocks to Render
            int minBlockToRender = Convert.ToInt32(Math.Floor(hScrollBar1.Value / 32.0));
            int maxBlockToRender = minBlockToRender + 32;

            //Draw Array 
            for (int x = minBlockToRender; x < maxBlockToRender; x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    DrawBlock(array[x, y], x, y);
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //User Clicks
            mouseDown = true;

            FillArray(e);
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //User stops clicking
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //if user moves mouse
            FillArray(e);
        }

        private void FillArray(MouseEventArgs e)
        {
            //Check if user clicks
            if (!mouseDown)
            {
                return;
            }

            //Check where Mouse clicked
            if (e.X < 0 || e.Y < 0) 
            {
                return;
            }

            int worldX = Convert.ToInt32(Math.Floor(e.X / 32.0));
            int worldY = Convert.ToInt32(Math.Floor(e.Y / 32.0));

            if(worldX >= array.GetLength(0) || worldY >= array.GetLength(1))
            {
                return;
            }

            if(PlayerHasBeenPlaced() && selectedIndex == 13)
            {
                return; //Allow only one Player
            }
            if (PortalHasBeenPlaced() && selectedIndex == 14)
            {
                return; //Allow only one Portal
            }
            
            if(selectedIndex == 15)
            {
                array[worldX, worldY] = 0;
            }
            else
            {
                array[worldX, worldY] = selectedIndex;
            }

            //DRAW it
            DrawBlock(selectedIndex, worldX, worldY);
        }

        private bool PlayerHasBeenPlaced()
        {
            bool placedPlayer = false;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if (array[x, y] == 13)
                    {
                        placedPlayer = true;
                    }
                }
            }
            return placedPlayer;
        }
        private bool PortalHasBeenPlaced()
        {
            bool placedPortal = false;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if (array[x, y] == 14)
                    {
                        placedPortal = true;
                    }
                }
            }
            return placedPortal;
        }

        private void pb_1_Click(object sender, EventArgs e)
        {
            //user selects which block he wants to draw
            selectedIndex = Convert.ToInt32(((PictureBox)sender).Name.Substring(3,2));
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //Move Panel
            panel1.Left = -hScrollBar1.Value;

            DrawWorld();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(!PlayerHasBeenPlaced() || !PortalHasBeenPlaced())
            {
                MessageBox.Show("Player or Portal has NOT been placed!");
                return;
            }
            
            World c = new World(Convert.ToInt32(cb_lifes.SelectedItem), Convert.ToInt32(cb_bullets.SelectedItem), TransposeArray());

            // Specify the file path relative to the executable directory
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "world6.json");

            // Check if the file already exists
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.Create(filePath).Close();
            }

            // Serialize the World object to JSON and write it to the file
            string worldJson = JsonConvert.SerializeObject(c);
            File.WriteAllText(filePath, worldJson);

            MessageBox.Show("World saved!");
        }

        private int[,] TransposeArray()
        {
            int[,] transposedArray = new int[50, 200]; ; 
            for(int x = 0; x < array.GetLength(0); x++)
            {
                for(int y = 0; y < array.GetLength(1); y++)
                {
                    transposedArray[y, x] = array[x, y];
                }
            }
            return transposedArray;
        }
    }
}
