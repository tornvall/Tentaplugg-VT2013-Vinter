using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace CG20120829q6SnowplowRoad {
    public class TileHandler {
        private Snowplow _snowplow;

        private List<RoadTile> _tiles;
        private Vector3 _previousPosition;
        private GraphicsDevice _device;
        private float _scale;

        public TileHandler(GraphicsDevice device, Snowplow snowplow) {
            _scale = 200f;
            _device = device;
            _snowplow = snowplow;
            _previousPosition = _snowplow.Position;
            _tiles = new List<RoadTile>();

            _tiles.Add(new RoadTile(_device, this.PlowToGround(_previousPosition), _scale));
        }


        public void Update(GameTime gameTime) {
            if(Vector3.Distance(_previousPosition, _snowplow.Position) > 400f) {
                _tiles.Add(new RoadTile(_device, this.PlowToGround(_snowplow.Position), _scale));
                _previousPosition = this.PlowToGround(_snowplow.Position);
            }

        }

        private Vector3 PlowToGround(Vector3 plowpos) {
            return new Vector3(plowpos.X,50, plowpos.Z);
        }

        public void Draw(BasicEffect effect) {

            foreach(RoadTile tile in _tiles)
                tile.Draw(effect);
        }

    }
}
