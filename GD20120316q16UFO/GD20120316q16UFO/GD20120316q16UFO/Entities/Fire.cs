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
        public Fire(Vector2 pos, Texture2D texture, Rectangle boundingbox)
        :base()
        {
            Position = pos;
            Texture = texture;
            BoundingBox = boundingbox;
            IsRenderable = true;

        }

        public override void Update(GameTime gameTime) {
           
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, null,Color.White,0f, Vector2.Zero, 0.5f,SpriteEffects.None,0f);
        }
    }
}
