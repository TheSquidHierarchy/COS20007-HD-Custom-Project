using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;



namespace Custom_Program
{
    
    public abstract class GameObject
    {
        private float _x, _y;

        //Constructor
        public GameObject()
        { }

        //X Property
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        //Y Property
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        //IsAt Property --> returns whether GameObject is at provided location 
        public abstract bool IsAt(Point2D pt);

        //Interact Method --> calls objects interaction
        public abstract void Interact(Point2D pt, CallCard c, GameScene context);

        //Update Method --> Called every tick to edit draw
        public abstract void Update();

        //Draw Method --> Called every tick
        public abstract void Draw();

        

        
    }
}
