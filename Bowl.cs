    using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace Custom_Program
{
    internal class Bowl : GameObject
    {
        private Bitmap _bitmap;

        //Constructor
        private Bowl(float x, float y)
        {
            X = x;
            Y = y;
            _bitmap = new Bitmap("Fish Bowl", "C:\\Users\\matth\\OneDrive - Swinburne University\\2023 Swinburne\\OOP\\Custom Program\\Resources\\Fish_Bowl.png");
        }

        //Default Constructor
        public Bowl() : this(0,0) { }

        //Override for method IsAt
        public override bool IsAt(Point2D pt)
        { return false; }

        //Override for method Update
        public override void Interact(Point2D pt, CallCard c, GameScene context)
        { }

        //Override for method Update
        public override void Update()
        { }

        //Override for method Draw 
        public override void Draw()
        { _bitmap.Draw(0,0); }
    }
}


