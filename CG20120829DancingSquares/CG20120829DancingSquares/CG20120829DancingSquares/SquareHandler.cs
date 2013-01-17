using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CG20120829DancingSquares {
    public class SquareHandler {

        private List<Square> _squares;
        private Vector3 _position;
        private Random _random;

        public SquareHandler(GraphicsDevice device, Vector3 position, int numOfSquares) {
            _position = position;
            _random = new Random();
            _squares = new List<Square>();

            for(int i = 0; i < numOfSquares; i++) {
                float x = _random.Next(-10,11);
                float y = _random.Next(-10,11);
                float z = _random.Next(-10,11);

                _squares.Add(new Square(device,new Vector3(x,y,z),1f));
            }
        }

        public void Update(GameTime gameTime) {
            foreach(Square item in _squares)
                item.Update(gameTime);            
        }

        public void Draw(BasicEffect effect) {
            foreach(Square item in _squares)
                item.Draw(effect, Matrix.Identity);
        }
    }
}
