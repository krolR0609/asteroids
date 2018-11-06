using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroids
{
    public class Sprite
    {
        protected Texture2D texture;

        public Vector2 Position;
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

        public virtual void Load(ContentManager content)
        {
        }

        public virtual void Unload()
        {
            texture.Dispose();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }
    }
}
