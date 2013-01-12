using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagerLib.GO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ManagerLib.Managers {
    public class RenderManager {
        List<AGameObject> _gameObjects;

        public RenderManager(List<AGameObject> gameObjects) {
            _gameObjects = gameObjects;
        }

        public void Update(GameTime gameTime) {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {

        }
    }
}
