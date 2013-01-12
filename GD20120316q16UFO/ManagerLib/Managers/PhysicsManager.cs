using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ManagerLib.GO;
using System.Threading;

namespace ManagerLib.Managers {
    public class PhysicsManager {
        private SceneManager _sceneManager;
        private Vector2 _wind;
        private Random _random;     

        public PhysicsManager(SceneManager sceneManager){
            _sceneManager = sceneManager;
            _wind = new Vector2(0, 0);
            _random = new Random();
            StartWind(10000);
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

        private void StartWind(int interval) {
            Timer timer = new Timer(new TimerCallback(GenerateGust), null, 0, interval);         
        }

        private void GenerateGust(object state) {
            _wind.X = (float)_random.Next(-1, 2);
            _wind.Y = (float)_random.Next(-1, 2); 
        
        }      

    }
}
