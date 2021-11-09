// mortified version of script create by Sanjay Madhav
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BalloonBuddy {
    public class GameObject {
        protected string textureName = "";
        protected Texture2D texture;

        protected Game game;
        public Vector2 position = Vector2.Zero;

        public GameObject(Game myGame) { game = myGame; } // Yup, game is myGame
            
        public virtual void Draw(SpriteBatch batch) { 
            if (texture != null) {                  // position is the center of the sprite.
                Vector2 drawPosition = position;    //drawPosition is the corner.
                drawPosition.X -= texture.Width / 2;
                drawPosition.Y -= texture.Height / 2;
                batch.Draw(texture, drawPosition, Color.White);
            }
        }

        public virtual void LoadContent() {
            if (textureName != "") {
                texture = game.Content.Load<Texture2D>(textureName);
            }
        }

        public virtual void Update(float deltaTime) {}

        public float Width {
            get { return texture.Width; }
        }
        public float Height {
            get { return texture.Height; }
        }

        // Add new functions above^
    }
}

        