using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CyllianMonoGame.Config;

namespace CyllianMonoGame.Entities.Characters
{
    public class Player : MovingEntity
    {
        public Player(Vector2 position, Texture2D sprite, Vector2 velocity)
            : base(position, sprite, velocity)
        {
            InitializeSprite(2, 3, 0, 0);
            Initialize();
        }


        public override void Initialize()
        {
            //Set stats or something

            //Set camera
            Global.Camera.Position = this.Position;
        }

        public override void InitializeSprite(int horizontalFrames, int verticalFrames, int horizontalOffset, int verticalOffset)
        {
            this.HorizontalFrames = horizontalFrames;
            this.HorizontalFramesOffset = HorizontalFramesOffset;
            this.VerticalFrames = verticalFrames;
            this.VerticalFramesOffset = VerticalFramesOffset;

            this.CurrentHorizontalFrame = 0;
            this.CurrentVerticalFrame = 0;
        }

        public override void Update(GameTime gameTime)
        {
            //Input
            this.Velocity = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y - 2);
                this.CurrentVerticalFrame = 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                this.Velocity = new Vector2(this.Velocity.X - 2, this.Velocity.Y);
                this.CurrentVerticalFrame = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) {
                this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + 2);
                this.CurrentVerticalFrame = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                this.Velocity = new Vector2(this.Velocity.X + 2, this.Velocity.Y);
                this.CurrentVerticalFrame = 2;
            }

            //Update movement
            this.Position = this.Position + this.Velocity;
            //this.Position = this.Position - Global.GlobalPosition;

            //Update bounding box
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 0, 0);

            //Move camera if player no longer intersects
            if (!Global.Camera.BoundingBox.Intersects(new Rectangle((int)(this.Position.X - Global.GlobalPosition.X), (int)(this.Position.Y - Global.GlobalPosition.Y),0,0)))
            {
                //Update global position
                Global.GlobalPosition = Global.GlobalPosition + this.Velocity;
                //Global.Camera.SetPosition(this.Position);
            }

            //Update player sprite
            if (this.Velocity != Vector2.Zero)
            {
                if (CurrentHorizontalFrame < HorizontalFrames)
                    CurrentHorizontalFrame++;
                else
                    CurrentHorizontalFrame = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int spriteSize = 48;
            spriteBatch.Draw(
                Sprite, 
                Position - Global.GlobalPosition, 
                new Rectangle(CurrentHorizontalFrame * spriteSize, CurrentVerticalFrame * spriteSize, spriteSize, spriteSize), 
                Color.White, 
                0f, 
                Vector2.Zero, 
                1f, 
                SpriteEffects.None, 
                0f);
        }
    }
}
