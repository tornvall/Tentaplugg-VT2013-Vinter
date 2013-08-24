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

namespace CG20120109q4Pyramid {
    /// <summary>
    /// Create a  program that displays a pyramid in  the middle of the screen. The pyramid 
    /// should be able to rotate rotating around the origin of the world (0,0,0) (x-, y- and zaxis)
    /// when the x, y or z buttons are pressed.  The pyramid should be defined in a 
    /// separate class and should be drawn using indexed vertices that are uploaded to the 
    /// GPU using vertex buffers.
    /// 
    /// Drawing the pyramid  without indexing and uploading the vertices to the GPU can result in maximum 4p. (7p)
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Pyramid pyramid;
        SimpleCamera camera;
        BasicEffect effect;
        Axis axisX;
        Axis axisY;
        Axis axisZ;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            pyramid = new Pyramid(GraphicsDevice, new Vector3(0, 0, 0), 0.5f);
            camera = new SimpleCamera(GraphicsDevice.Viewport.AspectRatio, new Vector3(20,10,20), Vector3.Zero);

            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;

            axisX = new Axis(GraphicsDevice, new Ray(Vector3.Zero, Vector3.UnitX), Color.Red);
            axisY = new Axis(GraphicsDevice, new Ray(Vector3.Zero, Vector3.UnitY), Color.Green);
            axisZ = new Axis(GraphicsDevice, new Ray(Vector3.Zero, Vector3.UnitZ), Color.Blue);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState kb = Keyboard.GetState();

            if(kb.IsKeyDown(Keys.Escape))
                Exit();
            if(kb.IsKeyDown(Keys.X))
                pyramid.RotX += 0.1f;
            if(kb.IsKeyDown(Keys.Y))
                pyramid.RotY += 0.1f;
            if(kb.IsKeyDown(Keys.Z))
                pyramid.RotZ += 0.1f;

            if(kb.IsKeyDown(Keys.Up))
                pyramid.Position += new Vector3(0,0.2f,0);
            if(kb.IsKeyDown(Keys.Down))
                pyramid.Position += new Vector3(0, -0.2f, 0);
            if(kb.IsKeyDown(Keys.Left))
                pyramid.Position += new Vector3(-0.2f, 0, 0);
            if(kb.IsKeyDown(Keys.Right))
                pyramid.Position += new Vector3(0.2f, 0, 0);

            if(kb.IsKeyDown(Keys.A))
                pyramid.Position += new Vector3(0, 0, 0.2f);
            if(kb.IsKeyDown(Keys.S))
                pyramid.Position += new Vector3(0, 0, -0.2f);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            effect.View = camera.View;
            effect.Projection = camera.Projection;

            // TODO: Add your drawing code here
            pyramid.Draw(effect, Matrix.Identity);
            axisX.Draw(effect);
            axisY.Draw(effect);
            axisZ.Draw(effect);

            base.Draw(gameTime);
        }
    }
}
