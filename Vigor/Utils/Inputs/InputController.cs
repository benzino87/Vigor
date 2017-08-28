using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vigor.Entity;

namespace Vigor.Utils.Inputs
{
    public static class InputController
    {
       public static void HandlePlayerInput()
        {

        }

        public static void HandlePlayerInput(float gamePadX, float gamePadY, Player player)
        {
            if (gamePadX < 0 && gamePadX < gamePadY)
            {
                player.IsMovingLeft = true;
                player.IsMovingRight = false;
                player.IsMovingDown = false;
                player.IsMovingUp = false;
            }
            if (gamePadX > 0 && gamePadX > gamePadY)
            {
                player.IsMovingRight = true;
                player.IsMovingLeft = false;
                player.IsMovingUp = false;
                player.IsMovingDown = false;
            }
            if (gamePadY > 0 && gamePadY > gamePadX)
            {
                player.IsMovingUp = true;
                player.IsMovingDown = false;
                player.IsMovingLeft = false;
                player.IsMovingRight = false;
            }
            if (gamePadY < 0 && gamePadY < gamePadX)
            {
                player.IsMovingDown = true;
                player.IsMovingUp = false;
                player.IsMovingLeft = false;
                player.IsMovingRight = false;
            }
            if (gamePadX == 0 && gamePadY == 0)
            {
                player.IsMovingLeft = false;
                player.IsMovingRight = false;
                player.IsMovingDown = false;
                player.IsMovingUp = false;
            }

            HandlePlayerMovement(gamePadX, gamePadY, player);
        }

        private static void HandlePlayerMovement(float gamePadX, float gamePadY, Player player)
        {
            if (gamePadX > 0)
            {
                player.posX += player.Speed;
                player.Vector = new Vector2(player.posX, player.posY);
            }
            if (gamePadX < 0)
            {
                player.posX -= player.Speed;
                player.Vector = new Vector2(player.posX, player.posY);
            }
            if (gamePadY > 0)
            {
                player.posY -= player.Speed;
                player.Vector = new Vector2(player.posX, player.posY);
            }
            if (gamePadY < 0)
            {
                player.posY += player.Speed;
                player.Vector = new Vector2(player.posX, player.posY);
            }
        }
    }
}
