using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ManagerLib.Managers {
    public class InputManager {
        private SceneManager _sceneManager;
        Dictionary<Keys, ActionType> _inputDictionary;

        public InputManager(SceneManager sceneManager) {
            _sceneManager = sceneManager;
            _inputDictionary = new Dictionary<Keys, ActionType>();
        }

        public void AddInput(Keys key, ActionType type) {
            try {
                _inputDictionary.Add(key, type);
            } catch(Exception) {                
                throw;
            }
        }

        public void Update(GameTime gameTime) {

            KeyboardState keyboardState = Keyboard.GetState();

            foreach(Keys item in keyboardState.GetPressedKeys()) {

                ActionType type;
                _inputDictionary.TryGetValue(item,out type);

                if(type != null)
                    _sceneManager.PerformAction(type);
            }
            
        }

    }
}
