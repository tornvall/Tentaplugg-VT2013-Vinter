using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CG20120109q4Pyramid {
    public class Axis {
        private GraphicsDevice _device;
        private VertexPositionColor[] _vertices;

        public Axis(GraphicsDevice device, Ray ray, Color color) {
            _device = device;

            _vertices = new VertexPositionColor[2];
            _vertices[0] = new VertexPositionColor(ray.Position, color);
            _vertices[1] = new VertexPositionColor(ray.Position +(ray.Direction*100), color);

        }

        public void Draw(BasicEffect effect) {
            effect.VertexColorEnabled = true;
            effect.World = Matrix.Identity;

            effect.CurrentTechnique.Passes[0].Apply();

            _device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, _vertices, 0, 1);
        }
    }
}
