using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigor.Utils
{

    /// <summary>
    /// Returns a rectangle with coordinates and size of specified sprite animation
    /// All sprite movement animations will be on a sprite sheet of 4 directions
    /// </summary>
    class Rectangles
    {
        //Row 1
        public static Rectangle GetLeftAnimationDimensions(int spriteSheetWidth, int spriteSheetHeight, int spriteCount)
        {
            return new Rectangle(0, 0, spriteSheetWidth/spriteCount, spriteSheetHeight/4);
        }

        //Row 2
        public static Rectangle GetRighttAnimationDimensions(int spriteSheetWidth, int spriteSheetHeight, int spriteCount)
        {
            return new Rectangle(0, spriteSheetHeight / 4, spriteSheetWidth / spriteCount, spriteSheetHeight / 4);
        }

        //Row 3
        public static Rectangle GetUpAnimationDimensions(int spriteSheetWidth, int spriteSheetHeight, int spriteCount)
        {
            return new Rectangle(0, (spriteSheetHeight/4)*2, spriteSheetWidth/spriteCount, spriteSheetHeight/4);
        }

        //Row 4
        public static Rectangle GetDownAnimationDimensions(int spriteSheetWidth, int spriteSheetHeight, int spriteCount)
        {
            return new Rectangle(0, (spriteSheetHeight/4)*3, spriteSheetWidth / spriteCount, spriteSheetHeight / 4);
        }
    }
}
