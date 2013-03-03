using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace CG20120829q6SnowplowRoad {
    public class Snowplow
    {
        private GraphicsDevice device;
        private Model _model;
        private Vector3 _position;
        private float _rotation;

        private bool containerRotationPositive = true;
        private ModelBone containerBone;
        private Matrix containerTransform;
        private float containerRotationValue;

        public Vector3 Position {
            get { return _position; }
            set { _position = value;}
        }

        public Snowplow(ContentManager content, GraphicsDevice device, Vector3 position)
        {
            this.device = device;
            _model = content.Load<Model>("snowplow");
            _position = position;
            _rotation = 0.0f;

            containerBone = _model.Bones["Cube.013"];
            containerTransform = containerBone.Transform;
        }

        public void Update(GameTime gameTime)
        {
            _position.X -= 2f;

            if (containerRotationPositive)
            {
                containerRotationValue += 0.01f;
                if (containerRotationValue >= 1)
                    containerRotationPositive = false;
            }
            else
            {
                containerRotationValue -= 0.01f;
                if (containerRotationValue <= -1)
                    containerRotationPositive = true;
            }
        }

        public void Draw(Matrix view, Matrix projection)
        {
            // Set the position of the camera in world space, for our view matrix.            
            containerBone.Transform = Matrix.CreateRotationX(containerRotationValue) * containerTransform;

            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[_model.Bones.Count];
            _model.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in _model.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] *
                        Matrix.CreateRotationY(_rotation)
                        * Matrix.CreateTranslation(_position);
                    effect.View = view;
                    effect.Projection = projection;
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
    }
}
