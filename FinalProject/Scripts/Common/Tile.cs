// MonoGame script created by Cathy Nguyen
using Microsoft.Xna.Framework;

// TileMap -> Tile -> CheckBounds

namespace BalloonBuddy {

    public class Tile : GameObject {
        Game1 game1;
        public CheckBounds checkBounds;
        bool tangible;

        public Tile(Game myGame, Game1 g1, string tileTextureName, bool hasCollision) : base(myGame) {
            textureName = tileTextureName;
            game1 = g1;
            tangible = hasCollision;
            if(tangible)
                checkBounds = new CheckBounds(myGame, game1);
        }

        public override void Update(float deltaTime) {
            if(tangible)
                checkBounds.CheckCollisions(game1.player, this);
        }

        // Add new functions above^
    }
}
