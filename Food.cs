using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace Custom_Program
{
    public abstract class Food : GameObject
    {
        private int _foodValue, _decayTime;

        //Constructor
        public Food(float x, float y, int foodvalue, int decaytime)
        {
            X = x;
            Y = y;
            FoodValue = foodvalue;
            DecayTime = decaytime;
        }

        //Default Constructor
        public Food() : this(1000, 150, 0, 0) { }

        //FoodValue Property -- How much hunger does the food remove
        public int FoodValue
        {
            get { return _foodValue; }
            set { _foodValue = value; }
        }

        //DecayTime Property -- How long the food as been present
        public int DecayTime
        {
            get { return _decayTime; }
            set { _decayTime = value; }
        }

        //Collide Method
        public abstract bool Collide(Fish myfish);

        //Override for method IsAt
        public override bool IsAt(Point2D pt)
        { return false; }

        //Override for Interact
        public override void Interact(Point2D pt, CallCard c, GameScene context)
        { }







    }
}
