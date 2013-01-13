using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ManagerLib.GO;
using System.Threading;

namespace ManagerLib.Managers {
    public class PhysicsManager {
        private SceneManager _sceneManager;
        private Vector2 _wind;
        private Random _random;     

        public PhysicsManager(SceneManager sceneManager){
            _sceneManager = sceneManager;
            _wind = new Vector2(0, 0);
            _random = new Random();
            StartWind(10000);
        }

        public void Update(GameTime gameTime) {            
            foreach(AbstractEntity source in _sceneManager.GetEntities()) {
                if(source.IsCollideable && source.IsMoveable) {
                    foreach(AbstractEntity target in _sceneManager.GetEntities()) {
                        if(target.IsCollideable) {
                            if(source != target) {                                                                

                                Rectangle sizeOfCollision = Rectangle.Intersect(source.BoundingBox, target.BoundingBox);
                                if(sizeOfCollision.Width > 0 || sizeOfCollision.Height > 0){                                    
                                    if(source == _sceneManager.GetPlayer())
                                        _sceneManager.IncreaseScore();
                                    else
                                        source.Direction *= -1;
                                }
                            }
                        }
                    }
                }
            }
        }

        #region Wind

        private void StartWind(int interval) {
            Timer timer = new Timer(new TimerCallback(GenerateGust), null, 0, interval);         
        }

        private void GenerateGust(object state) {
            _wind.X = (float)_random.Next(-1, 2);
            _wind.Y = (float)_random.Next(-1, 2);

        }

        #endregion
        #region Pixel-perfect

        public static bool IntersectBoundingBoxes(AbstractEntity entity1, AbstractEntity entity2, int alphaThreshold1, int alphaThreshold2)
        {
            // Get the bounding rectangle of the person
            Rectangle entity1Rectangle =
                            new Rectangle((int)entity1.Position.X, (int)entity1.Position.Y,
                            entity1.Texture.Width, entity1.Texture.Height);

            // Get the bounding rectangle of this block
            Rectangle entity2Rectangle =
                            new Rectangle((int)entity2.Position.X, (int)entity2.Position.Y,
                            entity2.Texture.Width, entity2.Texture.Height);

            // The color data for the images; used for per pixel collision
            Color[] entity1TextureData = new Color[entity1.Texture.Width * entity1.Texture.Height];
            Color[] entity2TextureData = new Color[entity2.Texture.Width * entity2.Texture.Height];
            entity1.Texture.GetData(entity1TextureData);
            entity2.Texture.GetData(entity2TextureData);
            return IsIntersectingPixels(entity1Rectangle, entity2Rectangle, entity1TextureData, entity2TextureData, 0, 0);
        }

        public static bool IsIntersectingPixels(Rectangle entity1Rectangle, Rectangle entity2Rectangle, Color[] entity1TextureData, Color[] entity2TextureData, int alphaThreshold1, int alphaThreshold2)
        {
            // Find the bounds of the rectangle intersection
            int top = Math.Max(entity1Rectangle.Top, entity2Rectangle.Top);
            int bottom = Math.Min(entity1Rectangle.Bottom, entity2Rectangle.Bottom);
            int left = Math.Max(entity1Rectangle.Left, entity2Rectangle.Left);
            int right = Math.Min(entity1Rectangle.Right, entity2Rectangle.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colorA = entity1TextureData[(x - entity1Rectangle.Left) +
                                         (y - entity1Rectangle.Top) * entity1Rectangle.Width];
                    Color colorB = entity2TextureData[(x - entity2Rectangle.Left) +
                                         (y - entity2Rectangle.Top) * entity2Rectangle.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A > alphaThreshold1 && colorB.A > alphaThreshold2)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
