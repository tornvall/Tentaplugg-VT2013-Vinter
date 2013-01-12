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
        public UFO(Vector2 pos, Texture2D texture, Rectangle boundingbox)
        :base()
        {
            Position = pos;
            Texture = texture;
            BoundingBox = boundingbox;
        }

        public void HandleInput(ActionType type) {
            switch(type) {
                case ActionType.Up:
                    Direction = new Vector2(0, -1);
                    break;
                case ActionType.Down:
                    Direction = new Vector2(0, 1);
                    break;
                case ActionType.Right:
                    Direction = new Vector2(1, 0);
                    break;
                case ActionType.Left:
                    Direction = new Vector2(-1, 0);
                    break;
            }
        }

        public override void Update(GameTime gameTime) {
           
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
