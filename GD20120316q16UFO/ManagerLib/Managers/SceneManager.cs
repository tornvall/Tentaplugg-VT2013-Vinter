using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ManagerLib.GO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace ManagerLib.Managers {
    public class SceneManager {
        private  List<AbstractEntity> _entities;
        private AbstractEntity _player;
        private int _scorePoints;
        private bool hasEnded;

        public SceneManager() {
            _entities = new List<AbstractEntity>();
            _scorePoints = 0;
            hasEnded = false;
            StartTimer(120000);
        }

        public void AddEntity(AbstractEntity entity) {
            _entities.Add(entity);
        }

        public void AddPlayer(AbstractEntity entity) {
            _player = entity;
            _entities.Add(_player);
        }
        public bool GameHasEnded() {
            return hasEnded;
        }

        public List<AbstractEntity> GetEntities() {
            return _entities;
        }

        public AbstractEntity GetPlayer() {
            return _player;
        }

        public void IncreaseScore() {
            _scorePoints++;
        }
        public int GetScore() {
            return _scorePoints;
        }

        public void Update(GameTime gameTime) {
            foreach(AbstractEntity entity in _entities) {
                entity.Update(gameTime);

                entity.Position += entity.Direction *entity.Speed;
            }
        }

        private void StartTimer(int interval) {
            Timer timer = new Timer(new TimerCallback(EndGame), null, interval, 0);            
        }

        private void EndGame(object state) {
            hasEnded = true;
        }
    }
}
