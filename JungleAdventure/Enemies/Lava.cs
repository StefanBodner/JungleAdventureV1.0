using JungleAdventure.Blocks;
using Microsoft.Xna.Framework;

namespace JungleAdventure.Enemies
{
    internal class Lava : BaseTile
    {
        public Lava(int x, int y, Microsoft.Xna.Framework.Graphics.Texture2D spriteSheet, Rectangle textureCoordinates) : base(x, y, spriteSheet, textureCoordinates)
        {
            this.textureCoordinates = textureCoordinates;
        }
    }
}
