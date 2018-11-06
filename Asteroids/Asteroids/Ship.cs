using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroids
{
    public class Ship : Sprite
    {
        private SpriteFont font;
        private const float AngleSub = 1.6f;

        public Vector2 Speed = new Vector2(0,0);
        public float Angle = 0f;

        private float RotationSpeed = 0.15f;
        public Vector2 Direction;
        public Vector2 DirectionV;

        public Ship()
        {
            Direction = new Vector2(2, 2);
            DirectionV = new Vector2(0, 0);
            Position = new Vector2(320, 240);
        }
        public override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpaceShip");
            font = content.Load<SpriteFont>("Font");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Angle += RotationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Angle -= RotationSpeed;
            }

            double angle = Math.Abs(MathHelper.ToDegrees(Angle));
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Direction = new Vector2((float)Math.Cos(Angle), (float)Math.Sin(Angle));
                Speed += new Vector2(0.1f, 0.1f);
            }

            Position += Direction * Speed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, Angle + AngleSub, new Vector2(texture.Width/2, texture.Height/2), 1, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, $"x:{Position.X} y:{Position.Y}", new Vector2(5, 5), Color.Red);
            spriteBatch.DrawString(font, $"rot {MathHelper.ToDegrees(Angle)}", new Vector2(5, 20), Color.Red);
            spriteBatch.DrawString(font, $"spd {Speed}", new Vector2(5, 35), Color.Red);
            spriteBatch.DrawString(font, $"dir {Direction.X} {Direction.Y}", new Vector2(5, 55), Color.Red);
        }
    }
}
