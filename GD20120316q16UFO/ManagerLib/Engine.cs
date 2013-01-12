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
        private PhysicsManager _physicsManager;
        private RenderManager _renderManager;
        private SceneManager _sceneManager;

        private List<AGameObject> _gameObjects;

        public Engine(ContentManager content) {
            _gameObjects = new List<AGameObject>();

            _physicsManager = new PhysicsManager(_gameObjects);
            _renderManager = new RenderManager(_gameObjects);
            _sceneManager = new SceneManager(_gameObjects, content);
        }

        public void LoadContent(ContentManager content) {
            _sceneManager.LoadContent(content);
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
