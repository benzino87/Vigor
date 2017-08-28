using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vigor.Utils;

namespace Vigor.Entity
{
    public enum SpriteAnimations
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    public abstract class Character
    {
        private float _posX;
        public float posX
        {
            get { return this._posX; }
            set { this._posX = value; }
        }
        private float _posY;
        public float posY
        {
            get { return this._posY; }
            set { this._posY = value; }
        }

        private Vector2 _vector;
        public Vector2 Vector { get { return this._vector; } set { this._vector = value; } }

        private Texture2D _image;
        public Texture2D Image { get { return this._image; } }

        private Dictionary<int, Rectangle> spriteSheet;


        //Rectangles that hold positions of all sprite animations on sprite sheet
        private Rectangle _movementLeftRectangle;
        private Rectangle _movementRightRectangle;
        private Rectangle _movementDownRectangle;
        private Rectangle _movementUpRectangle;


        private int _lastSecond;
        private int _spriteCount;
        private int _spriteSheetWidth;
        private int _spriteSheetHeight;

        private bool _isMovingLeft;
        public bool IsMovingLeft
        {
            get { return this._isMovingLeft; }
            set { this._isMovingLeft = value; }
        }
        private bool _isMovingRight;
        public bool IsMovingRight
        {
            get { return this._isMovingRight; }
            set { this._isMovingRight = value; }
        }
        private bool _isMovingDown;
        public bool IsMovingDown
        {
            get { return this._isMovingDown; }
            set { this._isMovingDown = value; }
        }
        private bool _isMovingUp;
        public bool IsMovingUp
        {
            get { return this._isMovingUp; }
            set { this._isMovingUp = value; }
        }

        private int _lastMovingDirection;


        public Character(Texture2D image, Vector2 vector, int spriteCount)
        {
            this._posX = 0;
            this._posY = 0;
            this._image = image;
            this._vector = vector;
            this._spriteSheetWidth = image.Width;
            this._spriteSheetHeight = image.Height;
            this._spriteCount = spriteCount;


            Rectangle leftAnimation = Rectangles.GetLeftAnimationDimensions(image.Width, image.Height, spriteCount);
            this._movementRightRectangle = Rectangles.GetRighttAnimationDimensions(image.Width, image.Height, spriteCount);
            this._movementDownRectangle = Rectangles.GetDownAnimationDimensions(image.Width, image.Height, spriteCount);
            this._movementUpRectangle = Rectangles.GetUpAnimationDimensions(image.Width, image.Height, spriteCount);

            spriteSheet = new Dictionary<int, Rectangle>();
            spriteSheet.Add((int)SpriteAnimations.LEFT, leftAnimation);
            spriteSheet.Add((int)SpriteAnimations.RIGHT, _movementRightRectangle);
            spriteSheet.Add((int)SpriteAnimations.DOWN, _movementDownRectangle);
            spriteSheet.Add((int)SpriteAnimations.UP, _movementUpRectangle);

            
            this._spriteCount = 1;

        }

        public void UpdatePosition(float x, float y)
        {
            this._posX = x;
            this._posY = y;
        }

        //Update rectangles
        private void MovingLeft(GameTime gameTime)
        {

        }

        private void MovingRight(GameTime gameTime)
        {

        }

        private void MovingDown(GameTime gameTime)
        {

        }

        private void MovingUp(GameTime gameTime)
        {

        }

        private void ResetSpriteRectangles(int ignoreKey)
        {
            
        }

        private void IterateSpriteAnimations(int direction)
        {
            //Pull value out of dictionary before operating
            Rectangle rect = spriteSheet[direction];
            if (rect.X == this._spriteSheetWidth - rect.Width)
                rect.X = 0;
            else
                rect.X += rect.Width;

            spriteSheet[direction] = rect;
        }

        public void Update(GameTime gameTime)
        { 
            if (gameTime.TotalGameTime.Milliseconds % 100 == 0)
            {
                if (_isMovingLeft)
                {
                    IterateSpriteAnimations((int)SpriteAnimations.LEFT);
                    ResetSpriteRectangles((int)SpriteAnimations.LEFT);
                    _lastMovingDirection = (int)SpriteAnimations.LEFT;
                }
                    
                if (_isMovingRight)
                {
                    IterateSpriteAnimations((int)SpriteAnimations.RIGHT);
                    ResetSpriteRectangles((int)SpriteAnimations.RIGHT);
                    _lastMovingDirection = (int)SpriteAnimations.RIGHT;
                }
                    
                if (_isMovingDown)
                {
                    IterateSpriteAnimations((int)SpriteAnimations.DOWN);
                    ResetSpriteRectangles((int)SpriteAnimations.DOWN);
                    _lastMovingDirection = (int)SpriteAnimations.DOWN;
                }
                    
                if (_isMovingUp)
                {
                    IterateSpriteAnimations((int)SpriteAnimations.UP);
                    ResetSpriteRectangles((int)SpriteAnimations.UP);
                    _lastMovingDirection = (int)SpriteAnimations.UP;
                }
            }                         
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(_isMovingLeft)
                spriteBatch.Draw(this._image, this._vector, spriteSheet[(int)SpriteAnimations.LEFT], Color.White);
            if (_isMovingRight)
                spriteBatch.Draw(this._image, this._vector, spriteSheet[(int)SpriteAnimations.RIGHT], Color.White);
            if (_isMovingDown)
                spriteBatch.Draw(this._image, this._vector, spriteSheet[(int)SpriteAnimations.DOWN], Color.White);
            if (_isMovingUp)
                spriteBatch.Draw(this._image, this._vector, spriteSheet[(int)SpriteAnimations.UP], Color.White);
            if (!_isMovingLeft && !_isMovingRight && !_isMovingUp && !_isMovingDown)
                spriteBatch.Draw(this._image, this._vector, spriteSheet[_lastMovingDirection], Color.White);
        }

    }
}
