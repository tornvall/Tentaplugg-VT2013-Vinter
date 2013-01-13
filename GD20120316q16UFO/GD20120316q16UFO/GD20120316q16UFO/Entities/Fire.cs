using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagerLib.GO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ManagerLib;

namespace GD20120316q16UFO.Entities {
    public class Fire : AbstractEntity {
        Random random = new Random();
        int timeCounter = 0;

        public Fire(GraphicsDevice device, Vector2 pos, Texture2D texture)
            :base(device)
        {
            Position = pos;
            Texture = texture;
            Scale = 0.5f;
            BoundingBox = new Rectangle(
                (int)pos.X,
                (int)pos.Y,
                (int)(texture.Width * Scale),
                (int)(texture.Height * Scale));
            IsRenderable = true;
            IsCollideable = true;

            NewDirection();
        }

        public void NewDirection()
        {
            float directionX = (float)((random.NextDouble() - 0.5) * 4);
            float directionY = (float)((random.NextDouble() - 0.5) * 4);

            if(directionX == 0 && directionY == 0)
                directionX = 1;

            Direction = new Vector2(directionX, directionY);            
        }

        public override void Update(GameTime gameTime) {
            timeCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (timeCounter > 2000)
            {
                NewDirection();
                timeCounter -= 2000;
            }

            float positionX = (float)(Position.X + (Direction.X * gameTime.ElapsedGameTime.Milliseconds / 20));
            float positionY = (float)(Position.Y + (Direction.Y * gameTime.ElapsedGameTime.Milliseconds / 20));

            if (positionX < 0)
                positionX = 0;
            if (positionX > Device.Viewport.Width)
                positionX = Device.Viewport.Width-1;

            if (positionY < 0)
                positionY = 0;
            if (positionY > Device.Viewport.Height)
                positionY = Device.Viewport.Height - 1;

            Position = new Vector2(positionX, positionY);


            BoundingBox = new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)(Texture.Width * Scale),
                (int)(Texture.Height * Scale));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);

            //Texture2D dummyTexture = new Texture2D(Device, 1, 1);
            //dummyTexture.SetData(new Color[] { Color.White });
            //spriteBatch.Draw(dummyTexture, BoundingBox, Color.White);
        }
    }
}
