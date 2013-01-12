using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ManagerLib.GO {
    public abstract class AbstractEntity {

        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Boolean IsMoveable { get; set; }
        public Boolean IsRenderable { get; set; }
        public Boolean IsCollideable { get; set; }
        public Rectangle BoundingBox { get; set; }
        public Texture2D Texture { get; set; }

        public AbstractEntity() {
            Position = new Vector2(0, 0);
            Direction = new Vector2(0,0);
            Speed = 0f;
            IsMoveable = false;
            IsRenderable = false;
            IsCollideable = false;
            BoundingBox = new Rectangle(0, 0, 0, 0);
            Texture = null;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
