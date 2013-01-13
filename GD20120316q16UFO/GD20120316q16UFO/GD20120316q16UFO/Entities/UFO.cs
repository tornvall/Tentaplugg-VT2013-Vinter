using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagerLib.GO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ManagerLib;

namespace GD20120316q16UFO.Entities {
    public class UFO : AbstractEntity {
        public UFO(GraphicsDevice device, Vector2 pos, Texture2D texture)
        :base(device)
        {            
            Position = pos;
            Scale = 0.5f;
            Texture = texture;
            BoundingBox = new Rectangle(
                (int)pos.X,
                (int)pos.Y,
                (int)(texture.Width*Scale),
                (int)(texture.Height*Scale));
            IsRenderable = true;
            IsCollideable = true;            
            Speed = 2f;
            
        }

        public override void Update(GameTime gameTime) {
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
