using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CG20120829q6SnowplowRoad {
    public class Snowplow {
        private Model _model;
        private Vector3 _position;

        public Snowplow(Model model, Vector3 position) {
            _model = model;
            _position = position;
        }
    }
}
