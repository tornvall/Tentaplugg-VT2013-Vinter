using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagerLib.GO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GD20120316q16UFO.Entities {
    public class Score : AbstractEntity {
        private SpriteFont _font;

        public Score(GraphicsDevice device, SpriteFont font) : base(device){
            _font = font;
            IsRenderable = true;
        }


        public override void Update(GameTime gameTime) {
           
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(_font, "testtext", new Vector2(10, 10), Color.White);
        }
    }
}
