using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagerLib.GO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ManagerLib.Managers;

namespace GD20120316q16UFO.Entities {
    public class Score : AbstractEntity {
        private SpriteFont _font;
        private int _points;
        private SceneManager _sceneManager;

        public Score(GraphicsDevice device, SpriteFont font, SceneManager sceneManager) : base(device){
            _font = font;
            IsRenderable = true;
            _sceneManager = sceneManager;
            _points = 0;
        }


        public override void Update(GameTime gameTime) {
            _points = _sceneManager.GetScore();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(_font, Convert.ToString(_points), new Vector2(10, 10), Color.White);
        }
    }
}
