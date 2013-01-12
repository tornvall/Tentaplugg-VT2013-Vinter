using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ManagerLib.GO;

namespace ManagerLib.Managers {
    public class PhysicsManager {
        private SceneManager _sceneManager;

        public PhysicsManager(SceneManager sceneManager){
            _sceneManager = sceneManager;
        }

        public void Update(GameTime gameTime) {            
            foreach(AbstractEntity source in _sceneManager.GetEntities()) {
                if(source.IsCollideable && source.IsMoveable) {
                    foreach(AbstractEntity target in _sceneManager.GetEntities()) {
                        if(target.IsCollideable) {
                            if(source != target) {

                                Rectangle sizeOfCollision = Rectangle.Intersect(source.BoundingBox, target.BoundingBox);
                                if(sizeOfCollision.Width > 0 || sizeOfCollision.Height > 0){
                                    source.Direction *= -1;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
