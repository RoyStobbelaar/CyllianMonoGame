using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyllianMonoGame.Config;

namespace CyllianMonoGame.Level
{
    /// <summary>
    /// Holds alot of tiles
    /// </summary>
    public class Tilemap
    {
        public int Height { get; set; } //Height in tilespaces (*48)
        public int Width { get; set; } //Width in tilespaces (*48)
        public int[,] Tiles { get; set; } //2D array for all tiles tile map holds
        public Texture2D Tilesprite { get; set; }

        public Tilemap(Vector2 tilemapSize, Texture2D tilemap) 
        {
            this.Tilesprite = tilemap;
            this.Height = (int)tilemapSize.Y;
            this.Width = (int)tilemapSize.X;
            this.Tiles = new int[Height,Width];

            InitializeTiles();
        }

        public void InitializeTiles()
        {
            //this.Tiles = tilesArray;

            //Create some test tiles
            for(var x = 0; x < this.Width; x++)
            {
                for(var y = 0; y < this.Height; y++)
                {
                    Tiles[x, y] = 0; //Assign '1' to each tile on the tilemap. '1' is tile nr#1 on the sheet
                }
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //Draw each tile

            for (var x = 0; x < this.Width; x++)
            {
                for (var y = 0; y < this.Height; y++)
                {
                    var tileValue = Tiles[x, y];

                    var yValue = tileValue / (Tilesprite.Width / Global.Spritesize);
                    var xValue = tileValue % (Tilesprite.Height / Global.Spritesize);

                    spriteBatch.Draw(
                        Tilesprite,
                        new Vector2(x * Global.Spritesize - (int)Global.GlobalPosition.X, y * Global.Spritesize - (int)Global.GlobalPosition.Y),
                        new Rectangle(xValue * Global.Spritesize, yValue * Global.Spritesize, Global.Spritesize, Global.Spritesize),
                        Color.White,
                        0f,
                        Vector2.Zero,
                        1f,
                        SpriteEffects.None,
                        0f);
                }
            }
        }
    }
}
