using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyllianMonoGame.Other.Camera
{
    /// <summary>
    /// Camera which allows the player to 'move' further then the borders of the map
    /// </summary>
    public class Camera
    {
        public Vector2 Position { get; set; } //Position should be player's position
        public Rectangle BoundingBox { get; set; } //In this rectangle the player can move freely without moving the camera

        /// <summary>
        /// Directly config camera
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="BoundingBox"></param>
        public Camera(Vector2 Position, Rectangle BoundingBox)
        {
            this.Position = Position;
            this.BoundingBox = BoundingBox;
        }

        /// <summary>
        /// Or just use defaults
        /// </summary>
        public Camera()
        {
            this.Position = new Vector2(200, 200);
            this.BoundingBox = new Rectangle(200, 200, 600, 400);
        }

        public void SetPosition(Vector2 position)
        {
            this.Position = position;
            this.BoundingBox = new Rectangle((int)position.X, (int)position.Y, 600, 400);
        }
    }
}
