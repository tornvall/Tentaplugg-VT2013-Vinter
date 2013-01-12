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
        private AbstractEntity _player;

        public SceneManager() {
            _entities = new List<AbstractEntity>();         
        }

        public void AddEntity(AbstractEntity entity) {
            _entities.Add(entity);
        }

        public void AddPlayer(AbstractEntity entity) {
            _player = entity;
            _entities.Add(_player);
        }

        public List<AbstractEntity> GetEntities() {
            return _entities;
        }

        public AbstractEntity GetPlayer() {
            return _player;
        }

        public void Update(GameTime gameTime) {
            foreach(AbstractEntity entity in _entities) {
                entity.Update(gameTime);
            }
        }
    }
}
