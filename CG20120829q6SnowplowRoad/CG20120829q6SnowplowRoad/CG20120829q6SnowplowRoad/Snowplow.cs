using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace CG20120829q6SnowplowRoad {
    public class Snowplow {
        private Model _model;
        private Vector3 _position;

        public Snowplow(ContentManager content, Vector3 position) {
            _model = content.Load<Model>("snowplow");
            _position = position;
        }
    }
}
