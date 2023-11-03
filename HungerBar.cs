using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    public class HungerBar : GameObject
    {
        private double _width, _height, _changingWidth, _level;
        private bool _alive;
        

        //Constructor
        public HungerBar(float x, float y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            _alive = true;
            _changingWidth = 120;
            _level = 0.5;
        }


        //Default Constructor
        public HungerBar() : this(30, 30, 120, 40) { }

        //Width and Height Properties
        public double ChangingWidth
        {
            get { return _changingWidth; }
            set { _changingWidth = value; }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }
        //Alive Property
        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }
        

        //Increase health Method
        public void ReduceHunger(Food f)
        {
            //if (ChangingWidth + f.FoodValue >= Width) { ChangingWidth = Width; }
            if (ChangingWidth == 0) { ChangingWidth = 0; }
            else { ChangingWidth += f.FoodValue; }
        }

        //Override for method IsAt
        public override bool IsAt(Point2D pt)
        {
            if ((pt.X > X) && (pt.X < (X + Width)))
            {
                if ((pt.Y > Y) && (pt.Y < (Y + 40)))
                {
                    return true;
                }
            }
            return false;
        }
    

        //Override for Interact
        public override void Interact(Point2D pt, CallCard c, GameScene context)
        {
            c.X = (float)pt.X;
            c.Y = (float)pt.Y;
            c.Desc = "Hunger Bar";
            c.Width = 90;
        }

        //Override for method Update
        public override void Update()
        {
            //level management
            if ((_level >= 0) && (_level < 2))
            {_level += 0.001; }

            //health management
            if (ChangingWidth > 0 && ChangingWidth < Width+30)
            { 
                ChangingWidth -= 0.25 * _level;
                _alive = true;
            }
            else
            {
               _alive = false;
            }

        }

        //Override for method Draw 
        public override void Draw()
        {
            //Draw Border
            if (ChangingWidth > Width) { SplashKit.FillRectangle(Color.LightGoldenrodYellow, X - 4, Y - 4, ChangingWidth + 8, 48); }
            else { SplashKit.FillRectangle(Color.Black, X - 4, Y - 4, Width +8, 48); }
            //Draw Icon
            if (ChangingWidth > Width)
            {
                SplashKit.FillRectangle(Color.IndianRed, X, Y, Width, Height);
                SplashKit.FillRectangle(Color.Red, X+Width, Y, ChangingWidth - Width, Height);
            }
            else
            {
                 SplashKit.FillRectangle(Color.IndianRed, X, Y, ChangingWidth, Height);
            }
                
        }
        
    }
}
