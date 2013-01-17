using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CG20120829DancingSquares {
    public class Camera {

        private Matrix _view;
        private Matrix _projection;

        public Matrix View { get { return _view; } }
        public Matrix Projection { get { return _projection; } }

        private Vector3 _position;
        private GraphicsDevice _device;

        public Camera(GraphicsDevice device, Vector3 position) {
            _position = position;
            _device = device;


            Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                _device.Viewport.AspectRatio,
                0.1f,
                1000.0f,
                out _projection);

            Vector3 target = new Vector3(0,0,0);
            Vector3 up = Vector3.Up;
            Matrix.CreateLookAt(
                ref _position,
                ref target,
                ref up,
                out _view);
        }
    }
}
