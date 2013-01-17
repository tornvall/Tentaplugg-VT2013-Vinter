using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CG20120829q6SnowplowRoad {
    public class Camera {
        private Matrix _view;
        private Matrix _projection;
        private Vector3 _position;
        private Vector3 _target;

        public Matrix View { get { return _view; } }
        public Matrix Projection { get { return _projection; } }
        public Vector3 Position { get { return _position; } }
        public Vector3 Target { get { return _target;} set{_target=value;}} 

        public Camera(GraphicsDevice device, Vector3 position, Vector3 target) {
            _position = position;
            _target = target;
            Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                device.Viewport.AspectRatio,
                0.1f,
                10000f,
                out _projection);

            _view = Matrix.CreateLookAt(_position, _target, Vector3.Up);

        }

        public void Update(Vector3 position, Vector3 target) {
            _position = position;
            _target = target;

            _view = Matrix.CreateLookAt(position, target, Vector3.Up);
        }


    }
}
