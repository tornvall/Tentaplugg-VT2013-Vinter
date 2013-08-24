using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CG20120109q4Pyramid {
    public class Pyramid {
        #region Fields
        private GraphicsDevice _device;
        private VertexPositionColor[] _vertices;
        private VertexBuffer _vertexBuffer;
        private IndexBuffer _indexBuffer;
        private int[] _indices;

        private float _rotX;
        private float _rotY;
        private float _rotZ;
        public Vector3 Position { get; set; }
        private float _scale;     

        #endregion

        #region Properties
        public float RotX {
            get{return _rotX;}
            set{_rotX=value;} 
        }
        public float RotY {
            get{return _rotY;}
            set{_rotY=value;} 
        }
        public float RotZ {
            get{return _rotZ;}
            set{_rotZ=value;} 
        }
        #endregion

        public Pyramid(GraphicsDevice device, Vector3 position, float scale) {
            _device = device;
            Position = position;
            _scale = scale;
            _rotX = 0;
            _rotY = 0;
            _rotZ = 0;

            this.InitializeVertices();
            this.IntitializeIndices();
            this.InitializeBuffer();
        }
        private void InitializeVertices() {
            _vertices = new VertexPositionColor[5];

            // Top
            _vertices[0] = new VertexPositionColor(new Vector3(0, 10, 0), Color.Red);

            // Bottom Front Left
            _vertices[1] = new VertexPositionColor(new Vector3(-10, 0, 10), Color.Blue);           

            // Bottom Front Right
            _vertices[2] = new VertexPositionColor(new Vector3(10, 0, 10), Color.Yellow);

            // Bottom Back Right
            _vertices[3] = new VertexPositionColor(new Vector3(10, 0, -10), Color.Green);

            // Bottom Back Left
            _vertices[4] = new VertexPositionColor(new Vector3(-10, 0, -10), Color.Purple);
        }

        private void IntitializeIndices() {
            _indices = new int[18];

            //Front
            _indices[0] = 0;
            _indices[1] = 2;
            _indices[2] = 1;

            //Right
            _indices[3] = 0;
            _indices[4] = 3;
            _indices[5] = 2;

            //Back
            _indices[6] = 0;
            _indices[7] = 4;
            _indices[8] = 3;

            //Left
            _indices[9] = 0;
            _indices[10] = 1;
            _indices[11] = 4;

            //Bottom Front
            _indices[12] = 1;
            _indices[13] = 2;
            _indices[14] = 4;

            //Bottom Back
            _indices[15] = 2;
            _indices[16] = 3;
            _indices[17] = 4;
        }

        private void InitializeBuffer() {
            _vertexBuffer = new VertexBuffer(_device, typeof(VertexPositionColor), _vertices.Length, BufferUsage.None);
            _indexBuffer = new IndexBuffer(_device, typeof(int), _indices.Length, BufferUsage.None);

            _vertexBuffer.SetData<VertexPositionColor>(_vertices);
            _indexBuffer.SetData<int>(_indices);            
        }

        public void Draw(BasicEffect effect, Matrix parent){
            Matrix world = Matrix.Identity
                * Matrix.CreateScale(_scale)
                * Matrix.CreateFromYawPitchRoll(_rotY, _rotX, _rotZ)
                * Matrix.CreateTranslation(Position);
            
            effect.World = world * parent;
            effect.VertexColorEnabled = true;
            effect.CurrentTechnique.Passes[0].Apply();

            _device.SetVertexBuffer(_vertexBuffer);
            _device.Indices = _indexBuffer;
            _device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _vertices.Length, 0, _indices.Length / 3);          
        }
    }
}
