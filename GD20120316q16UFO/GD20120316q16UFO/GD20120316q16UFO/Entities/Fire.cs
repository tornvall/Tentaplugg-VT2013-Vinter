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

        public Fire(Vector2 pos, Texture2D texture, Rectangle boundingbox)
            :base()
        {
            Position = pos;
            Texture = texture;
            BoundingBox = boundingbox;
            IsRenderable = true;

            NewDirection();
        }

        public void NewDirection()
        {
            float directionX = (float)(random.NextDouble() - 0.5);
            float directionY = (float)(random.NextDouble() - 0.5);

            if(directionX == 0 && directionY == 0)
                directionX = 1;

            Direction = new Vector2(directionX, directionY);            
        }

        public override void Update(GameTime gameTime) {

            Position = new Vector2((float)(Direction.X * (gameTime.ElapsedGameTime.Milliseconds / 1000)),
                (float)(Direction.Y * (gameTime.ElapsedGameTime.Milliseconds / 1000)));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, null,Color.White,0f, Vector2.Zero, 0.5f,SpriteEffects.None,0f);
        }
    }
}
