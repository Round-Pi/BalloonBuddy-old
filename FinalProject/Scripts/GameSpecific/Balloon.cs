// Monogame script created by Cathy Nguyen
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BalloonBuddy {
    public class Balloon : GameObject { // Bookmark

        public const float ribbonLength = TileMap.tileSize * 2;
        public const float howMuchHelium = 10; // positive float plz

        public Balloon(Game myGame) : base(myGame) {
            textureName = "balloon";
        }

        // Add new functions above^
    }
}
