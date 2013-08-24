using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CG20120109q4Pyramid
{
    public class SimpleCamera
    {
        #region Fields

        private float aspectRation;
        private Matrix projection;
        private Matrix view;

        private Vector3 cameraPosition;
        private Vector3 cameraTarget;
        private Vector3 cameraUpVector = Vector3.Up;

        #endregion
        #region Properties

        public Matrix Projection
        {
            get { return this.projection; }
        }

        public Matrix View
        {
            get { return this.view; }
        }

        #endregion

        public SimpleCamera(float aspectRatio, Vector3 position, Vector3 target)
        {
            cameraPosition = position;
            cameraTarget = target;

            Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                aspectRatio,
                0.1f,
                1000.0f,
                out projection);

            Matrix.CreateLookAt(
                ref cameraPosition,
                ref cameraTarget,
                ref cameraUpVector,
                out view);
        }

        public void CreateLookAt(Vector3 pos, Vector3 target, Vector3 upVector) {
            this.cameraPosition = pos;
            this.cameraTarget = target;
            this.cameraUpVector = upVector;

            Matrix.CreateLookAt(
                    ref cameraPosition,
                    ref cameraTarget,
                    ref cameraUpVector,
                    out view);
        }
    }
}
