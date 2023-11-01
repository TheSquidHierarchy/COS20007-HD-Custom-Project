using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = SplashKitSDK.Color;

namespace Custom_Program
{
    internal class myFlakes : Food
    {

        private Bitmap _bitmap;
        private Vector2D _velocity;

        //Constructor
        private myFlakes(float x, float y, int FoodValue, int DecayTime) : base(x, y, FoodValue, DecayTime)
        {
            _bitmap = new Bitmap("Flakes", "C:\\Users\\matth\\OneDrive - Swinburne University\\2023 Swinburne\\OOP\\Custom Program\\Resources\\Flakes.png");
           
            _velocity.X = 0;
            _velocity.Y = 1.5;
        }

        //Default Constructor
        public myFlakes() : this(1000, 200, 8, 0) { }

        //Override for method Collide
        public override bool Collide(Fish myfish)
        {
            return SplashKit.BitmapCollision(myfish.MyBmp, myfish.X, myfish.Y, _bitmap, X, Y);
        }

        

        //Override for method Update
        public override void Update()
        {
            DecayTime++; //increments how long the food has been alive
            if (Y > 150 && Y < 900) //Checks if inside Bowl
            {
                //Update Position
                X += (float)_velocity.X;
                Y += (float)_velocity.Y;

                //Decay Velocity
                _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0, -0.02));
            }
            else if (Y > 0 && Y < 150) //Checks if above Bowl
            {
                if (_velocity.Y > 0)
                {
                    //Update Position
                    X += (float)_velocity.X;
                    Y += (float)_velocity.Y;

                    //Decay Velocity
                    _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0, -0.009));
                }
                else { _velocity = SplashKit.VectorTo(0, 0); }
            }
            else { _velocity = SplashKit.VectorTo(0, 0); } //Otherwise outside game area
        }

        //Override for method Draw 
        public override void Draw()
        {
            if (X > 550 && X < 1400 && Y < 950 ) //Checks inside game area
            { _bitmap.Draw(X, Y); }
        }
    }
}
