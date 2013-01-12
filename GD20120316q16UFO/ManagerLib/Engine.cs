using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ManagerLib.Managers;
using ManagerLib.GO;

namespace ManagerLib {
    public class Engine {
        private SceneManager _sceneManager;
        private PhysicsManager _physicsManager;
        private RenderManager _renderManager;

        public Engine() {
            _sceneManager = new SceneManager();
            _physicsManager = new PhysicsManager(_sceneManager);
            _renderManager = new RenderManager(_sceneManager);            
        }
        public void AddEntity(AbstractEntity entity) {
            _sceneManager.AddEntity(entity);
        }

        public void Update(GameTime gameTime) {
            _sceneManager.Update(gameTime);
            _physicsManager.Update(gameTime);
            _renderManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            _renderManager.Draw(gameTime, spriteBatch);
        }
    }
}
