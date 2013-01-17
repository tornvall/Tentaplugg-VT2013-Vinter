using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace CG20120829q6SnowplowRoad {
    public class RoadTile {
        private Vector3 _position;

        private VertexBuffer _vertexBuffer;
        private VertexPositionTexture[] _vertices;
        private IndexBuffer _indexBuffer;
        private int[] _indices;
        private float _scale;

        GraphicsDevice _device;

        public RoadTile(GraphicsDevice device, Vector3 position, float scale) {
            _position = position;
            _device = device;
            _scale = scale;

            this.InitializeVertices();
            this.InitializeIndices();

            _vertexBuffer = new VertexBuffer(_device, typeof(VertexPositionTexture), _vertices.Length, BufferUsage.None);
            _indexBuffer = new IndexBuffer(_device, typeof(int), _indices.Length, BufferUsage.None);

            _vertexBuffer.SetData<VertexPositionTexture>(_vertices);
            _indexBuffer.SetData<int>(_indices);

        }

        private void InitializeVertices() {
            _vertices = new VertexPositionTexture[4];

            //Front left
            _vertices[0] = new VertexPositionTexture(new Vector3(-1, 0, 1), new Vector2(0, 1));

            //Front right
            _vertices[1] = new VertexPositionTexture(new Vector3(1, 0, 1), new Vector2(1, 1));
            
            //Back right
            _vertices[2] = new VertexPositionTexture(new Vector3(1, 0, -1), new Vector2(1, 0));

            //Back left
            _vertices[3] = new VertexPositionTexture(new Vector3(-1, 0, -1), new Vector2(0, 0));

        }
        private void InitializeIndices() {
            _indices = new int[6];

            //Triangle 1
            _indices[0] = 3;
            _indices[1] = 2;
            _indices[2] = 0;
            
            //Triangle 2
            _indices[3] = 2;
            _indices[4] = 1;
            _indices[5] = 0;
        }

        public void Draw(BasicEffect effect) {
            Matrix world = Matrix.Identity
                *Matrix.CreateScale(_scale)
                * Matrix.CreateTranslation(_position);

            effect.World = world;
            effect.CurrentTechnique.Passes[0].Apply();
            _device.SetVertexBuffer(_vertexBuffer);
            _device.Indices = _indexBuffer;
            _device.DrawIndexedPrimitives(PrimitiveType.TriangleList,0,0,_vertices.Length, 0, _indices.Length/3);
        }
    }
}
