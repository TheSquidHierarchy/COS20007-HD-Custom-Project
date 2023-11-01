using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    public class CallCard : GameObject
    {
        private string _desc;
        private int _width, _timer;
        
        //Constructor
        public CallCard(double x, double y, string desc, int width)
        {
            X = (float)x;
            Y = (float)y;
            _desc = desc;
            _width = width;
            _timer = 0;
            }

        //Default Constructor
        public CallCard() : this(1000, 150, "", 0) { }

        //Description Property
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        //Width Property
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        //Override for method IsAt
        public override bool IsAt(Point2D pt)
        { return false; }

        //Override for method Update
        public override void Interact(Point2D pt, CallCard c, GameScene context)
        { }

        //Override for method Update
        public override void Update()
        {
            if (_width > 0)
            {
                _timer++;
                if (_timer >= 100) { _timer=0; _width = 0; }
            }
        }

        //Override for method Draw 
        public override void Draw()
        {
            if (_width > 0)
            {
                SplashKit.FillRectangle(Color.PapayaWhip, X + 35, Y - 35, _width, 20);
                SplashKit.DrawText($"{_desc}", Color.Black, X + 38, Y - 28);
            }
            
        }
    }
}
