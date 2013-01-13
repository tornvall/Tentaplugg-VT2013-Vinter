using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ManagerLib;
using ManagerLib.GO;
using GD20120316q16UFO.Entities;

namespace GD20120316q16UFO {
    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Engine engine;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {       
            engine = new Engine();
            base.Initialize();
        }

        protected override void LoadContent() {            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AbstractEntity ufo = new UFO(graphics.GraphicsDevice, new Vector2(50, 50), Content.Load<Texture2D>("Sprites/ufo"), new Rectangle(0,0,50,50));

            AbstractEntity fire = new Fire(graphics.GraphicsDevice, new Vector2(250, 250), Content.Load<Texture2D>("Sprites/fire"), new Rectangle(0, 0, 50, 50));

            AbstractEntity score = new Score(graphics.GraphicsDevice, Content.Load<SpriteFont>("Fonts/score"), engine.GetSceneManager());
            engine.GetSceneManager().AddPlayer(ufo);
            engine.GetSceneManager().AddEntity(fire);
            engine.GetSceneManager().AddEntity(score);
        }

        protected override void UnloadContent() {
            
        }

        protected override void Update(GameTime gameTime) {            
            engine.Update(gameTime);

            if(engine.GetInputManager().IsKeyPressed(Keys.Escape))
                Exit();
            if(engine.GetInputManager().IsKeyPressed(Keys.Up))
                engine.GetSceneManager().GetPlayer().Direction = new Vector2(0,-1);
            if(engine.GetInputManager().IsKeyPressed(Keys.Down))
                engine.GetSceneManager().GetPlayer().Direction = new Vector2(0, 1);
            if(engine.GetInputManager().IsKeyPressed(Keys.Left))
                engine.GetSceneManager().GetPlayer().Direction = new Vector2(-1, 0);
            if(engine.GetInputManager().IsKeyPressed(Keys.Right))
                engine.GetSceneManager().GetPlayer().Direction = new Vector2(1, 0);                                           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            engine.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
