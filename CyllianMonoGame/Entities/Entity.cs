using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyllianMonoGame.Entities
{
    /// <summary>
    /// Base class for all entities in the game
    /// </summary>
    public abstract class Entity
    {
        public Vector2 Position { get; set; }
        public Texture2D Sprite { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Entity(Vector2 position, Texture2D sprite)
        {
            this.Position = position;
            this.Sprite = sprite;

            //Using 48*48 sprites so... just default them bosses can be set
            this.Width = sprite.Width;
            this.Height = sprite.Height;
        }

        public abstract void Initialize();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
