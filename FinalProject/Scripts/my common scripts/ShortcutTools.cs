// MonoGame script created by Cathy Nguyen
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BalloonBuddy {
    public class ShortcutTools : GameObject {

        public ShortcutTools(Game myGame) : base(myGame) {}
        public static bool IsBetween(float value, float min, float max) {
            // if value is between min and max, return true.
            return value > min && value < max;
        }
        public static float DistanceFloat(Vector2 startVec, Vector2 endVec) {
            Vector2 dist = endVec - startVec;
            //float distanceSq = (dist.X)*(dist.X) + (dist.Y)*(dist.Y);
            float distanceSq = (float)Math.Pow(dist.X, 2) + (float)Math.Pow(dist.Y, 2);
            return (float)Math.Sqrt(distanceSq);
        }
        public static Vector2 DistanceVector(Vector2 startVec, Vector2 endVec) {
            return endVec - startVec;
        }
        public static Vector2 Normalize(float ribbon, Vector2 inputV) {
            // Set the fixed distance away to the float ribbon
            float distance = DistanceFloat(Vector2.Zero, inputV);
            float recip = ribbon / distance;
            Vector2 outputV;
            outputV.X = recip * inputV.X;
            outputV.Y = recip * inputV.Y;
            return outputV;
        }
        //public static Vector2 Normalize(float ribbon, Vector2 v) {
        //    // Set the fixed distance away to the float ribbon
        //    float distance = DistanceFloat(Vector2.Zero, v);
        //    float recip = ribbon / distance;
        //    v.X *= recip;
        //    v.Y *= recip;
        //    return v;
        //}
        public static void Testing(KeyboardState keyState, bool condition) { // for debugging and playtesting
            // Is the bool condition met?
            bool printResult = true; // Allow console to print?
            if(condition && printResult) {
                Console.WriteLine("Add a string or variable here.");
                printResult = false;
            }
            if(!printResult && keyState.IsKeyDown(Keys.T)) {
                printResult = true;
            }
        }

        // Add new functions above^
    }
}
