﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BalloonBuddy {
    public class Camera : GameObject {

        public Camera(Game myGame) : base(myGame) {
            textureName = "";
        }

        protected void ScreenEdgeCheck(Player player) { // TODO: Move to Game1.cs or Create camera script
            // screen edge collisions-------------------------------------
            if(player.position.X - 32 < player.Height / 2) { // LEFT the screen
                //ballBoingSFX.Play();
            }
            else if(player.position.X - 992 > player.Height / 2) { // get back here RIGHT away
                //ballBoingSFX.Play();
            }
            if(player.position.Y - 32 < player.Height / 2) { // crashing through the roof
                //ballBoingSFX.Play();
            }
            // Out of Bounds Check ---------------------------------------
            else if(player.position.Y - 768 > player.Height / 2) { // falling into the abyss
                // lose life and/or respawn
            }
            
        }

        // Add new functions above^
    }
}
