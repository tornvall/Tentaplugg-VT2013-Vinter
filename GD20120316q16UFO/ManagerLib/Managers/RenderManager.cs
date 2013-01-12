using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagerLib.GO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ManagerLib.Managers {
    public class RenderManager {
        private SceneManager _sceneManager;

        public RenderManager(SceneManager sceneManager) {
            _sceneManager = sceneManager;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach(AbstractEntity entity in _sceneManager.GetEntities()){
                if(entity.IsRenderable)
                    entity.Draw(gameTime, spriteBatch);
            }

        }
    }
}
