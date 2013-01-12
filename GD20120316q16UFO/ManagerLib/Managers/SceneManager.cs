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
        private  List<AbstractEntity> _entities;
                

        public SceneManager() {
            _entities = new List<AbstractEntity>();         
        }

        public void AddEntity(AbstractEntity entity) {
            _entities.Add(entity);
        }

        public List<AbstractEntity> GetEntities() {
            return _entities;
        }

        public void Update(GameTime gameTime) {
            foreach(AbstractEntity entity in _entities) {
                if(entity.IsMoveable) {
                    entity.Position += entity.Direction * entity.Speed;
                }
            }
        }


    }
}
