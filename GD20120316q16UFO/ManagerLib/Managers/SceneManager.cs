using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ManagerLib.GO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace ManagerLib.Managers {
    public class SceneManager {
        private List<AGameObject> _gameObjects;

        public SceneManager(List<AGameObject> gameObjects, ContentManager contentManager) {
            _gameObjects = gameObjects;           
        }

        public void LoadContent(ContentManager content) {
            
        }

        public void Update(GameTime gameTime) {

        }


    }
}
