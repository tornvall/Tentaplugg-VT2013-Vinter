using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CG20120829DancingSquares {
    public class Square {

        private VertexBuffer _vertexBuffer;
        private IndexBuffer _indexBuffer;

        private int[] _indices;
        private VertexPositionColor[] _vertices;

        private GraphicsDevice _device;

        private Vector3 _position;
        private float _scale;
        private float _rotX;

        public Square(GraphicsDevice device, Vector3 position, float scale) {
            _device = device;
            _position = position;
            _scale = scale;
            _rotX = 0;

            this.InitializeVertices();
            this.InitializeIndices();

            _vertexBuffer = new VertexBuffer(_device, typeof(VertexPositionColor), _vertices.Length, BufferUsage.None);
            _indexBuffer = new IndexBuffer(_device, typeof(int), _indices.Length, BufferUsage.None);

            _vertexBuffer.SetData<VertexPositionColor>(_vertices);
            _indexBuffer.SetData<int>(_indices);

        }

        public void Update(GameTime gameTime) {
            _rotX += 0.1f;
        }

        private void InitializeVertices() {
            _vertices = new VertexPositionColor[8];

            //Top Front Left
            _vertices[0] = new VertexPositionColor(new Vector3(-1,1,1), Color.Red);

            //Top Front Right
            _vertices[1] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);

            //Top Back Right
            _vertices[2] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Red);

            //Top Back Left
            _vertices[3] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Red);

            //Bottom Front Left
            _vertices[4] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Red);

            //Bottom Front Right
            _vertices[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Red);

            //Bottom Back Right
            _vertices[6] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Red);

            //Bottom Back Left
            _vertices[7] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Red);
        }

        private void InitializeIndices() {
            _indices = new int [36];

            //Front Triangle 1
            _indices[0] = 0;
            _indices[1] = 1;
            _indices[2] = 4;

            //Front Triangle 2
            _indices[3] = 1;
            _indices[4] = 5;
            _indices[5] = 4;

            //Right Triangle 1
            _indices[6] = 1;
            _indices[7] = 2;
            _indices[8] = 5;

            //Right Triangle 2
            _indices[9] = 2;
            _indices[10] = 6;
            _indices[11] = 5;

            //Back Triangle 1
            _indices[12] = 2;
            _indices[13] = 3;
            _indices[14] = 6;

            //Back Triangle 2
            _indices[15] = 3;
            _indices[16] = 7;
            _indices[17] = 6;

            //Left Triangle 1
            _indices[18] = 3;
            _indices[19] = 0;
            _indices[20] = 7;

            //Left Triangle 2
            _indices[21] = 0;
            _indices[22] = 4;
            _indices[23] = 7;

            //Top Triangle 1
            _indices[24] = 3;
            _indices[25] = 2;
            _indices[26] = 0;

            //Top Triangle 2
            _indices[27] = 2;
            _indices[28] = 1;
            _indices[29] = 0;

            //Bottom Triangle 1
            _indices[30] = 4;
            _indices[31] = 5;
            _indices[32] = 7;

            //Bottom Triangle 2
            _indices[33] = 5;
            _indices[34] = 6;
            _indices[35] = 7;

        }

        public void Draw(BasicEffect effect, Matrix parent) {
            Matrix world = Matrix.Identity
                * Matrix.CreateScale(_scale)
                * Matrix.CreateRotationX(_rotX)
                * Matrix.CreateTranslation(_position);

            effect.World = world * parent;
            effect.CurrentTechnique.Passes[0].Apply();

            _device.SetVertexBuffer(_vertexBuffer);
            _device.Indices = _indexBuffer;

            _device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _vertices.Length, 0, _indices.Length / 3);
        }

    }
}
