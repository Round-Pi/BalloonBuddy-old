﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

// Unused
namespace BalloonBuddy {
    public class Background : GameObject {
        Game1 game1;
        int heightInTiles;
        int widthInTiles;
        public List<Tile> tiles = new List<Tile>();

        public Background(Game myGame, Game1 g1) : base(myGame) {
            //textureName = "backgroundEmpty";
            textureName = "Outline";
            heightInTiles = g1.tileMap.heightInTiles;
            widthInTiles = g1.tileMap.widthInTiles;
            game1 = g1;
        }

        public override void Draw(SpriteBatch batch) { // spawn tiles
            for(int row = 0; row < heightInTiles; row++) { // how many rows (12)
                for(int col = 0; col < widthInTiles; col++) { // how many items in row (16)

                    Tile newTile = new Tile(game, game1, textureName, false);
                    newTile.LoadContent();
                    newTile.position = new Vector2(
                        col * TileMap.tileSize + game1.tileMap.mapPosition.X,
                        row * TileMap.tileSize + game1.tileMap.mapPosition.Y);
                    newTile.Draw(batch);
                    tiles.Add(newTile); // store tiles

                }
            }

        }
            // Add new functions above^
    }
}
