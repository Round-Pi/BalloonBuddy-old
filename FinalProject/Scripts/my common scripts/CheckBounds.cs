// MonoGame script created by Cathy Nguyen
using Microsoft.Xna.Framework;

// For platformers
// separate script for player, derived from CheckBounds?

// TileMap -> Tile -> CheckBounds

namespace BalloonBuddy {
    public class CheckBounds : GameObject {// Each tile has this (ineffecticent way)
        Game1 game1;
        Player player;

        bool soft = true; // set true if soft platform

        public CheckBounds(Game myGame, Game1 g1) : base(myGame) {
            game1 = g1;
            player = game1.player;
        }

        // Put in Tile Update function:
        public void CheckCollisions(Player player, Tile tile) {
            //HurtBoxCollision();
            //FloorCollision(player, gameTime);
            //FloorCollision(player);

            TileCollision(player, tile); // TODO: Get this to work
        }
        // add non-player collisions around here

        protected void TileCollision(Player player, Tile tile) {

            float playerHalf = player.Height / 2; // assuming both are squares!
            float tileHalf = tile.Height / 2;
            // Do not subtract with the 4 floats below:
            float tileX = tile.position.X; 
            float tileY = tile.position.Y;
            float playX = player.position.X;
            float playY = player.position.Y;
            // player collides with tile ---------------------------------------------------------------------
       
            // hit tile's left:
            if(playX > tileX -playerHalf -tileHalf // TODO: implement walk and fall. (isosceles right triangle thingy)
                && ShortcutTools.IsBetween(playY, tileY-tileHalf, tileY+tileHalf) ) {

                player.position.X = MathHelper.Clamp(
                    player.position.X, 
                    tileX -playerHalf -tileHalf, // *min*
                    playX + 1000); // no max
            }
            // hit tile's right:
            else if(playX < tileX +playerHalf +tileHalf
                && ShortcutTools.IsBetween(playY, tileY-tileHalf, tileY+tileHalf) ) {

                player.position.X = MathHelper.Clamp(
                    player.position.X,
                    playX - 1000, // no min
                    tileX +playerHalf +tileHalf); // *max*
            }

            // land on tile/platform: 
            else if(playY > tileY - playerHalf - tileHalf // TODO: make sure player is falling aka player.position,Y++
                && ShortcutTools.IsBetween(playX, tileX - tileHalf, tileX + tileHalf)) {

                player.startY = player.position.Y; // so you can jump again
                player.jumping = false;

                player.position.Y = MathHelper.Clamp(
                    player.position.Y,
                    playY - 1000, // no min
                    tileY - playerHalf - tileHalf); // *max*
            }
            // skip if soft platform:
            else if(playY < tileY + playerHalf + tileHalf
                && ShortcutTools.IsBetween(playX, tileX - tileHalf, tileX + tileHalf)
                && !soft) {

                player.position.Y = MathHelper.Clamp(
                    player.position.Y,
                    tileY + playerHalf + tileHalf, // *min*
                    playY + 1000); // no max
            }
            // add to temp to player position?
        }

        // Add new functions above^

        //protected void ScreenEdgeCheck(Player player) { // TODO: Move to Game1.cs or Create camera script
        //    // screen edge collisions-------------------------------------
        //    if (player.position.X - 32 < player.Height / 2) { // LEFT the screen
        //        //ballBoingSFX.Play();
        //    }
        //    else if (player.position.X - 992 > player.Height / 2) { // get back here RIGHT away
        //        //ballBoingSFX.Play();
        //    }
        //    if (player.position.Y - 32 < player.Height / 2) { // crashing through the roof
        //        //ballBoingSFX.Play();
        //    }
        //    // Out of Bounds Check ---------------------------------------
        //    else if (player.position.Y - 768 > player.Height / 2) { // falling into the abyss
        //        // lose life and/or respawn
        //    }
        //}

        //protected void FloorCollision(Player player) {
        //    // if statement
        //    //player.starY = player.position.Y; // maybe
        //}

        //protected void HurtBoxCollision(Player player, List<Tile> tiles) { // "soft" platforms only use FloorCollisions, no TileCollisions
        //    // Bookmarks: Tile collisions and deletion
        //    // Tile collisions and deletion-------------------------------------
        //    Tile tileColl = null; // attacking enemy?
        //
        //    foreach (Tile b in tiles) {
        //        //Console.WriteLine("Tile hit");
        //        if ((player.position.X > (b.position.X - b.Width / 2 - radius)) &&
        //            (player.position.X < (b.position.X + b.Width / 2 + radius)) &&
        //            (player.position.Y > (b.position.Y - b.Height / 2 - radius)) &&
        //            (player.position.Y < (b.position.Y + b.Height / 2 + radius))) 
        //        {
        //            tileColl = b;
        //        }
        //        //break;
        //    }
        //
        //    // Ball bounce if hit-------------------------------------------------
        //    if (tileColl != null) {
        //        // block left/right side - - - - - - - - - - - - - - - - - - - - -
        //        if (
        //            (player.position.X + radius >= tileColl.position.X - 32 
        //                || player.position.X - radius <= tileColl.position.X + 32)
        //            &&
        //            ShortcutTools.IsBetween (
        //                value: player.position.Y,
        //                min: tileColl.position.Y - 16,
        //                max: tileColl.position.Y + 16) ) 
        //        {
        //            //Console.WriteLine("X bounce");
        //            //player.direction.X = -player.direction.X;
        //            // Stop moving  
        //        }
        //        // block up/down side- - - - - - - - - - - - - - - - - - - - - - -
        //        if (
        //            ShortcutTools.IsBetween (
        //                value: player.position.X,
        //                min: tileColl.position.X - 32,
        //                max: tileColl.position.X + 32)
        //            &&
        //            (player.position.Y + radius >= tileColl.position.Y - 16
        //                || player.position.Y - radius <= tileColl.position.Y + 16) )
        //        {
        //
        //        }
        //
        //    }
        //}

    }
}
