using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Color = SplashKitSDK.Color;

namespace Custom_Program
{
    public class Fish : GameObject
    {
        private Bitmap _bitmap;
        private Vector2D _velocity;
        

        //Constructor
        public Fish(float x, float y)
        {
            _bitmap = new Bitmap("Fish", "C:\\Users\\matth\\OneDrive - Swinburne University\\2023 Swinburne\\OOP\\Custom Program\\Resources\\Fish.png");
            X = x;
            Y = y;
            
            _velocity.X = 2;
            _velocity.Y = 2;
        }

        //Default Constructor
        public Fish() : this(1000, 350) { }

        //VectorX Property
        public double Vx
        {
            get { return _velocity.X; }
            set { _velocity.X = value; }
        }

        //VectorY Property
        public double Vy
        {
            get { return _velocity.Y; }
            set { _velocity.Y = value; }
        }

        //Bitmap Property
        public Bitmap MyBmp
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }

        //Override for method IsAt
        public override bool IsAt(Point2D pt)
        { return SplashKit.BitmapPointCollision(_bitmap, X, Y, pt.X, pt.Y); }

        //Override for Interact 
        public override void Interact(Point2D pt, CallCard c, GameScene context)
        { 
            
            c.X = (float)pt.X;
            c.Y = (float)pt.Y; 
            c.Desc = "This is a fish";
            c.Width = 120;
        }

        //Update Method
        public override void Update()
        {
            //Forces Fish to stay inside play area
            if (X < 550)
            {
                X = 551;
                _velocity.X = -(_velocity.X);
            }
            else if (X > 1350)
            {
                X = 1349;
                _velocity.X = -(_velocity.X);
            }
            else if (Y < 100)
            {
                Y = 101;
                _velocity.Y = 0;
            }
            else if (Y > 850)
            {
                Y = 849;
                _velocity.Y = 0;
            }
            else
            {
                //Update Position
                X += (float)_velocity.X;
                Y += (float)_velocity.Y;

                //Decay Velocity
                _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0, 0.02));
            }
        }
        
        //Override for method Draw 
        public override void Draw()
        {
            if (_velocity.X<0)
            { _bitmap.Draw(X, Y); }
            else { _bitmap.Draw(X, Y, SplashKit.OptionFlipY()); }
        }
        
        
    }
    
}
