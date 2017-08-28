using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vigor.Entity
{
    public class Player : Character
    {
        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Player(Texture2D image, Vector2 vector, int spriteCount) : base(image, vector, spriteCount)
        {
            this._speed = 5;
        }

    }
}
