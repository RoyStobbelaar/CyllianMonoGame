using CyllianMonoGame.Entities.Characters;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CyllianMonoGame.Config;

namespace CyllianMonoGame.Level
{
    /// <summary>
    /// Holds different layers for tiles, and npc/player
    /// </summary>
    public class Map : DrawableGameComponent
    {
        public List<Tilemap> Layers { get; set; } //Diffent layers for background tiles
        public string Id { get; set; } //Each map needs its own id; eg: 'forest_of_miracles_1a'
        public List<object> EntryPoints { get; set; } //A map can be entered from 1 or multiple locations
        public List<object> ExitPoints { get; set; } //A map can be left from 1 or multiple locations
        public Player Player { get; set; }

        public Texture2D DebugTexture { get; set; }
        public SpriteFont DebugFont { get; set; }

        public Map(Game game) : base(game)
        {
            this.Layers = new List<Tilemap>();
        }

        /// <summary>
        /// Load tiles and such
        /// </summary>
        /// <param name="name"></param>
        public void Initialize(string name)
        {
            this.Id = name;

            //Load tiles depending on map name

            Tilemap testMap = new Tilemap(new Vector2(40, 40), Game.Content.Load<Texture2D>("Tiles//World_A2"));
            this.Layers.Add(testMap);
            this.Player = new Player(new Vector2(300, 300), Game.Content.Load<Texture2D>("Characters//Sprite//Actor1"),Vector2.Zero);

            this.DebugFont = Game.Content.Load<SpriteFont>("Font//DebugFont");
            this.DebugTexture = new Texture2D(GraphicsDevice, 1, 1);
            this.DebugTexture.SetData(new Color[] { Color.White });
        }

        /// <summary>
        /// Check collision between player and tiles/npc/monster/interactive thing
        /// </summary>
        public void CheckCollision()
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Update map

            //Update player
            Player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Layers.Count > 0)
            {
                foreach (Tilemap map in Layers)
                {
                    map.Draw(spriteBatch);
                }
            }

            //Draw NPC's on top of layers
            if(Player != null)
            {
                Player.Draw(spriteBatch);
            }

            //Draw debug information
            if (Global.Debugmode)
            {
                //Draw player info
                spriteBatch.DrawString(DebugFont, Player.Position.ToString(), new Vector2(Player.Position.X - 24 - Global.GlobalPosition.X, Player.Position.Y - 24 - Global.GlobalPosition.Y), Color.Red);

                //Draw camera
                var r = Global.Camera.BoundingBox;

                spriteBatch.Draw(DebugTexture, new Rectangle(r.Left, r.Top, 2, r.Height), Color.Black);
                spriteBatch.Draw(DebugTexture, new Rectangle(r.Right, r.Top, 2, r.Height), Color.Black);
                spriteBatch.Draw(DebugTexture, new Rectangle(r.Left, r.Top, r.Width, 2), Color.Black);
                spriteBatch.Draw(DebugTexture, new Rectangle(r.Left, r.Bottom, r.Width, 2), Color.Black);
            }
        }
    }
}
