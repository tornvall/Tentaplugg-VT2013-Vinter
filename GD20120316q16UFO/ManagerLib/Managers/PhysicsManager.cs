using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ManagerLib.GO;

namespace ManagerLib.Managers {
    public class PhysicsManager {
        List<AGameObject> _gameObjects;
        public PhysicsManager(List<AGameObject> gameObjects){
            _gameObjects = gameObjects;
        }

        public void Update(GameTime gameTime) {

        }
    }
}
