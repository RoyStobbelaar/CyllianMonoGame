using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyllianMonoGame.Entities.Characters
{
    /// <summary>
    /// Base class for all moving entities
    /// Eg; Player, Enemies, NPCS. Everything walking on the map
    /// </summary>
    public abstract class MovingEntity : Entity
    {
        public Vector2 Velocity { get; set; }
        public int HorizontalFrames { get; set; }
        public int VerticalFrames { get; set; }
        public int HorizontalFramesOffset { get; set; }
        public int VerticalFramesOffset { get; set; }
        public int CurrentHorizontalFrame { get; set; }
        public int CurrentVerticalFrame { get; set; }

        public MovingEntity(Vector2 position, Texture2D sprite, Vector2? velocity)
            : base(position, sprite)
        {
            if (velocity.HasValue) {
                this.Velocity = velocity.Value;
            }
            else {
                this.Velocity = Vector2.Zero;
            }
        }

        public abstract void InitializeSprite(int horizontalFrames, int verticalFrames, int horizontalOffset, int verticalOffset);
    }
}
