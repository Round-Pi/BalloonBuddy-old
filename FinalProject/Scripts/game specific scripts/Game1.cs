// MonoGame script created by Cathy Nguyen
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Note: Have other classes inherit GameObject, to use Load and Draw functions.

// Execution order:             Initialize -> LoadContent -> Update *30 -> Draw *1
// Collision checking order:    TileMap -> Tile -> CheckBounds

namespace BalloonBuddy {

    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Inherits GameObject:
        public Player player;
        Balloon balloon;
        public TileMap tileMap;
        Background background;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        // Bookmark: Adjust window size here
            graphics.PreferredBackBufferHeight = 768; // 64 * 12
            graphics.PreferredBackBufferWidth = 1024; // 64 * 16
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() { 
            // Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
            // Use this.Content to load your game content here
            // Bookmark: Change starting positions here

            player = new Player(this); // Note: this loads the main method in a class
            player.LoadContent(); // LoadContent from GameObject i.e. loads texture
            player.position = new Vector2(544, 544);

            balloon = new Balloon(this);
            balloon.LoadContent();
            balloon.position = new Vector2(player.position.X, player.position.Y - Balloon.ribbonLength);

            tileMap = new TileMap(this, this);
            tileMap.LoadContent();
            tileMap.mapPosition = new Vector2(TileMap.tileSize/2, TileMap.tileSize / 2);
            // The position of the map top leftcorner, moves the ENTIRE map.

            background = new Background(this, this);
            background.LoadContent();
            background.position = tileMap.position;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() { // Unload any non ContentManager content here

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) { 
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(); // Order matters! background -> foreground, low to high priority

            background.Draw(spriteBatch);
            tileMap.Draw(spriteBatch);
            player.Draw(spriteBatch);
            balloon.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) { // Add your update logic here
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            player.Update(deltaTime);
            BalloonFollows(); // basically its update function
            balloon.position.Y -= Balloon.howMuchHelium;
            tileMap.Update(deltaTime);

            base.Update(gameTime);
        }
        // New (non-MonoGame) functions go here:

        private void BalloonFollows() {
            if(ShortcutTools.DistanceFloat(player.position, balloon.position) > Balloon.ribbonLength) {
                Vector2 v = ShortcutTools.DistanceVector(player.position, balloon.position);
                balloon.position = player.position + ShortcutTools.Normalize(Balloon.ribbonLength, v);
            }
        }

        // Add new functions above^
    }
}
