using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    internal class PreGameUI : GameObject
    {
        private Bitmap _bitmap, _bitmap1;

        //Constructor
        private PreGameUI(float x, float y)
        {
            X = x;
            Y = y;
            _bitmap = new Bitmap("Start", "C:\\Users\\matth\\OneDrive - Swinburne University\\2023 Swinburne\\OOP\\Custom Program\\Resources\\Start.png");
            _bitmap1 = new Bitmap("Exit", "C:\\Users\\matth\\OneDrive - Swinburne University\\2023 Swinburne\\OOP\\Custom Program\\Resources\\Exit.png");
        }

        //Default Constructor
        public PreGameUI() : this(850, 450) { }

        //Override for method IsAt
        public override bool IsAt(Point2D pt)
        {
            if (SplashKit.BitmapPointCollision(_bitmap, X, Y, pt.X, pt.Y))
            { return true; }
            else if (SplashKit.BitmapPointCollision(_bitmap1, X, Y + 150, pt.X, pt.Y))
            { return true; }
            else { return false; }
         }

        //Override for method interact
        public override void Interact(Point2D pt, CallCard c, GameScene context)
        {
            if (SplashKit.BitmapPointCollision(_bitmap, X, Y, pt.X, pt.Y))
            { context.TransitionTo(new GamePlaying()); }
            if (SplashKit.BitmapPointCollision(_bitmap1, X, Y + 150, pt.X, pt.Y))
            { SplashKit.CloseAllWindows(); }
        }


        //Override for method Update
        public override void Update()
        { }

        //Override for method Draw 
        public override void Draw()
        {
            _bitmap.Draw(850, 450);
            _bitmap1.Draw(850, 600);
        }
    }
}

