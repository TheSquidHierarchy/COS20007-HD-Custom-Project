using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    public abstract class State
    {
        protected GameScene _context;
        
        public void SetContext(GameScene context)
        {
            this._context = context;
        }


        public abstract void Draw();
        public abstract void Update();
        public abstract void ClickedOn(Point2D pt);
        public abstract void AddEntity(GameObject newEntity);
        
    }
}
