using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ManagerLib.Managers {
    public class InputManager {
        private SceneManager _sceneManager;
        private KeyboardState _keyboardState;

        public InputManager(SceneManager sceneManager) {
            _sceneManager = sceneManager;            
        }

        public Boolean IsKeyPressed(Keys key) {
            return _keyboardState.IsKeyDown(key);
        }

        public void Update(GameTime gameTime) {
            _keyboardState = Keyboard.GetState();            
        }

    }
}
