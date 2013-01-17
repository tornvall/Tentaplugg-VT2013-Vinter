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

        public Snowplow(ContentManager content, GraphicsDevice device, Vector3 position)
        {
            this.device = device;
            _model = content.Load<Model>("snowplow");
            _position = position;
            _rotation = 0.0f;
        }

        public void Update(GameTime gameTime)
        {
            _rotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds *
                MathHelper.ToRadians(0.1f);
        }

        public void Draw()
        {
            // Set the position of the camera in world space, for our view matrix.
            Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 5000.0f);

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
                    effect.View = Matrix.CreateLookAt(cameraPosition,
                        Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(45.0f), device.Viewport.AspectRatio,
                        1.0f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
    }
}
