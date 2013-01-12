using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ManagerLib.GO {
    public abstract class AGameObject {

        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public Rectangle BoundingBox { get; set; }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
