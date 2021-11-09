// MonoGame script created by Cathy Nguyen
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

// For RPGs, check next tile before the player moves. 
//      use 2D arrays arr[x,y] 
//      left(x-1) ; right(x+1) ; up(y-1) ; down(y+1)

// Note: +Y is down. But +X is still right.

namespace BalloonBuddy {
    public class Player : GameObject {

        const float walkSpeed = 600; // positive
        const float runSpeed = 1200; // positive
        const float initalJumpSpeed = 10; // positive
        const float slowFall = 0.3f;
        const float normalFall = 2;

        const float lowestY = 532;
        public float startY = lowestY; // the Y position where jump starts    
        float jumpSpeed = 0;
        public bool jumping = false;

        public Player(Game myGame) : base(myGame) {
            textureName = "PlatChar";
        }

        public override void Update(float deltaTime) {
            KeyboardState keyState = Keyboard.GetState(); // check keyboard state

            if(keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A)) { // to the left!
                if(keyState.IsKeyDown(Keys.LeftShift)) {
                    position.X -= runSpeed * deltaTime; 
                }
                else { position.X -= walkSpeed * deltaTime; }
            }
            else if(keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D)) { // to the Right!
                if(keyState.IsKeyDown(Keys.LeftShift)) {
                    position.X += runSpeed * deltaTime; 
                }
                else { position.X += walkSpeed * deltaTime; }
            }

            // no deltaTime?
            if(jumping) { // and falling, gravity physics stuff
                position.Y += jumpSpeed; // gravity is an increase in Y
                  if(keyState.IsKeyDown(Keys.Space) || jumpSpeed > 0) 
                    { jumpSpeed += slowFall; } // Fall slower when spacebar down
                else if(keyState.IsKeyUp(Keys.Space))
                    { jumpSpeed += normalFall; } // Fall faster when spacebar up

                if(position.Y >= startY) {
                    position.Y = startY; // like a clamp?
                    jumping = false; // aka, go to the else statement below.
                }
            }
            else { 
                if(keyState.IsKeyDown(Keys.Space)) { // Player jumps
                    jumping = true; // aka, go to the if statement above.
                    jumpSpeed = -12; // initial speed of jump
                    // play jump sound
                    startY = lowestY; // startY resets
                }
            }

            base.Update(deltaTime);
        }

        // Add new functions above^
    }
}
