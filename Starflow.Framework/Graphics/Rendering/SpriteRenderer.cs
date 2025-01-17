﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
   public sealed class SpriteRenderer : Component
   {
        public Sprite sprite;
        public Color color = Color.White;
        public bool flipX;
        public bool flipY;
        public int sortingOrder;

        public Rectangle Rect
        {
            get
            {
                if (sprite != null)
                {
                    return new Rectangle(transform.position.ToPoint() + sprite.offset.ToPoint(),
                            new Point((int)(transform.scale.X * sprite.texture.Bounds.Size.X), (int)(transform.scale.Y * sprite.texture.Bounds.Size.Y)));
                }
                else
                    return new Rectangle();
            }
        }

        public SpriteRenderer()
        {
            GameManager.Components.Add(this);
        }

        public override void Draw(SpriteBatch sb)
        {
            if (sprite == null) return;
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (flipX)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
                if (flipY)
                    spriteEffects = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
            }
            else if (flipY)
            {
                spriteEffects = SpriteEffects.FlipVertically;
                if (flipX)
                    spriteEffects = SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally;
            }

            // temp solution rn
            if (sprite.texture != null)
            {
                sprite.pivot = new Vector2(sprite.texture.Width / 2, sprite.texture.Height / 2);
                sb.Draw(sprite.texture, Rect, null, color, MathHelper.ToRadians(gameObject.transform.rotation), sprite.pivot, spriteEffects, 0f);
            }
        }
   }
}
