﻿// MonoGame script created by Cathy Nguyen
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Put txtFileName.txt in "Levels" folder
// Put texture file in "Content" folder
// Suggested Task: Modify to use sprite sheet instead of individual sprite files

// TileMap -> Tile -> CheckBounds

namespace BalloonBuddy {
    public class TileMap : GameObject {
        const string txtFileName = "test"; // Bookmark: text/map file thingy
        public const int tileSize = 64; // sprites are tileSize x tileSize pixels

        public int heightInTiles; // map height in tiles
        public int widthInTiles; // map width in tiles
        int[,] tileID;
        public List<Tile> tiles = new List<Tile>(); 
        public Vector2 mapPosition; // change it in Game1.cs instead
        Game1 game1;

        public TileMap(Game myGame, Game1 g1) : base(myGame) {
            textureName = "";
            game1 = g1;
        }
        public override void LoadContent() { // populate tiles
            string textFile = Path.GetFullPath(
                Path.Combine(Directory.GetCurrentDirectory() 
                + @"\..\..\..\..\Maps\" + txtFileName + ".txt"));
            // ReadAllLines and foreach is for strings only :<
            string[] lines = File.ReadAllLines(textFile);
            heightInTiles = lines.Length; // Counts how many lines - should be 12
            widthInTiles = lines[0].Split(' ').Length; //  counts how many items in a line - should be 16
            tileID = new int[heightInTiles, widthInTiles];

            for(int row = 0; row < heightInTiles; row++) {
                string[] splitLine = lines[row].Split(' '); // split single string to an array
                widthInTiles = splitLine.Length;
                //tileID = new int[lines.Length, splitLine.Length];

                for(int col = 0; col < widthInTiles; col++) {
                    tileID[row, col] = Int32.Parse(splitLine[col]); // populate each element with an int
                }
            }
        }

        public override void Draw(SpriteBatch batch) { // spawn tiles
            for(int row = 0; row < heightInTiles; row++) { // how many rows
                for(int col = 0; col < widthInTiles; col++) { // how many items in row

                    if(tileID[row,col] == 0) { textureName = ""; }                   
                    else if(tileID[row,col] > 0) {

                        String tileTexture = "";
                        // Bookmark: Assign a texture to an int --------------
                        if(tileID[row, col] == 1) {
                            tileTexture = "Ground1"; // add new string variable for file name of texture
                        }
                        else if(tileID[row, col] == 2) {
                            tileTexture = "Ground2";
                        }
                        else if(tileID[row, col] == 3) {
                            tileTexture = "Underground";
                        }
                        else { Console.WriteLine("tileTexture string is null"); }

                        // Adding instance of Tile. Have instance check collisions (inefficient)
                        Tile newTile = new Tile(game, game1, tileTexture, true);
                        newTile.LoadContent();
                        newTile.position = new Vector2(
                            col * tileSize + mapPosition.X, 
                            row * tileSize + mapPosition.Y);
                        newTile.Draw(batch);

                        //texture = game.Content.Load<Texture2D>(tileTexture);
                        //position = new Vector2(
                        //    col * tileSize + mapPosition.X,
                        //    row * tileSize + mapPosition.Y);
                        //base.Draw(batch);

                        tiles.Add(newTile); // store tiles

                    }
                    else { Console.WriteLine(":("); }
                }
            } 
        }

        public override void Update(float deltaTime) {
            foreach(Tile t in tiles) {
                t.Update(deltaTime); // each tile checks for its collision
            }
            base.Update(deltaTime); // Can be removed. It's empty anyways.
        }

        // Add new functions above^
    }
}
