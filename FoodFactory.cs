using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    public sealed class FoodFactory
    {
        private static FoodFactory _instance;

        public FoodFactory()
        { }

        public static FoodFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FoodFactory();
            }
            return _instance;
        }

        public Food CreateFood(FoodType foodType, bool clicked)
        {
            Food food = null;
            switch (foodType)
            {
                case FoodType.Flakes:
                    food = new myFlakes();
                    break;
                case FoodType.Worms:
                    food = new myWorm();
                    break;
                default:
                    food = new myFlakes();
                    break;
            }
            if (clicked)
            {
                food.X = SplashKit.MouseX();
                food.Y = SplashKit.MouseY();
            }
            else
            {
                food.X = SplashKit.Rnd(600, 1300);
                food.Y = 100;
            }
            return food;
        }
    }
}
