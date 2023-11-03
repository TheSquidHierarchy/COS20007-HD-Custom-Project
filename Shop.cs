using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Color = SplashKitSDK.Color;


namespace Custom_Program
{
    public enum FoodType { Flakes, Worms, FlakesAuto, WormsAuto };
    public class Shop : GameObject
    {
        private Bitmap _bitmap;
        private int _money, _moneyValue, _timer;
        private bool _purchased, _purchased1;
        private Color _color,_color1;
        private FoodType _foodType;
        private HungerBar _hunger;

        //Constructor
        public Shop(HungerBar hunger, float x, float y)
        {
            X = x;
            Y = y;
            _money = 0;
            _moneyValue = 1;
            _purchased1 = false;
            _purchased = false;
            
            _bitmap = new Bitmap("Worm Icon", "C:\\Users\\matth\\OneDrive - Swinburne University\\2023 Swinburne\\OOP\\Custom Program\\Resources\\Worm.png");
            _timer = 0;
            _color = Color.ForestGreen;
            _color1 = Color.ForestGreen;
            CurrentType = FoodType.Flakes;
            _hunger = hunger;
            

        }

        //Default Constructor
        //public Shop() : this(30, 100) { }

        //Money Property
        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
        public int MoneyValue
        {
            get { return _moneyValue; }
            set { _moneyValue = value; }
        }

        //Whether upgrade 1 is purchase property
        public bool Upgrade1Purchased
        {
            get { return _purchased1; }
            set { _purchased1 = value; }
        }

        
        //FoodType Property
        public FoodType CurrentType
        {
            get { return _foodType; }
            set { _foodType = value; }
        }

        //Override for method IsAt
        public override bool IsAt(Point2D pt)
        {
            if ((pt.X > 28) && (pt.X < 82))
            {
                if ((pt.Y > 128) && (pt.Y < 172))
                { return true; }

                if ((pt.Y > 198) && (pt.Y < 242))
                {
                    Console.WriteLine("clicked 1");
                    return true; }

                if ((pt.Y > 268) && (pt.Y < 312))
                {
                    Console.WriteLine("clicked 2");
                    return true; }
            }
            return false;
        }

        //Override for Interact
        public override void Interact(Point2D pt, CallCard c, GameScene context)
        {
            if ((pt.Y > 128) && (pt.Y < 172) && Money >= 10 && _purchased == false)
            {
                Money -= 10;
                _color = Color.Red;
                _foodType = FoodType.Worms;
                _purchased = true;
            }
            if ((pt.Y > 198) && (pt.Y < 242) && _purchased1 == false && Money >= 20)
            {
                Money -= 20;
                _color1 = Color.Red;
                _purchased1 = true;
            }
            if ((pt.Y > 268) && (pt.Y < 312) && Money >= 2)
            {
                Money -= 2;
                _hunger.Width += 10;
                _hunger.ChangingWidth += 10;
                Console.WriteLine("purchased");
            }
        }


        //Override for method Update
        public override void Update()
        {
            _timer++;
            if (_timer >= 60)
            {
                _money  += _moneyValue;
                _timer = 0;
            }
        }

        //Override for method Draw 
        public override void Draw()
        {
            //Current Money
            SplashKit.DrawText($"Gold:", Color.Black, "Bold Font", 100 , X , Y );
            SplashKit.DrawText($"{Money}", Color.Black, "Bold Font", 100, X , Y + 10);

            //Worm Upgrade Icon
            SplashKit.FillRectangle(Color.Black, X -2, Y + 30 - 2, 54, 54);
            SplashKit.FillRectangle(_color, X, Y + 30, 50, 50);
            _bitmap.Draw(X, Y+30);
            SplashKit.DrawText("15", Color.Black, X + 5, Y + 70);

            //Auto Dispenser Upgrade Icon
            SplashKit.FillRectangle(Color.Black, X - 2, Y + 100 - 2, 54, 54);
            SplashKit.FillRectangle(_color1, X, Y + 100, 50, 50);
            SplashKit.DrawText("Auto", Color.Black, X + 10, Y + 120);
            SplashKit.DrawText("30", Color.Black, X + 5, Y + 140);

            //Health Upgrade Icon
            SplashKit.FillRectangle(Color.Black, X - 2, Y + 170 - 2, 54, 54);
            SplashKit.FillRectangle(Color.ForestGreen, X, Y + 170, 50, 50);
            SplashKit.DrawText("Health", Color.Black, X + 5, Y + 190);
            SplashKit.DrawText("2", Color.Black, X + 5, Y + 210);
        }
    }
}
