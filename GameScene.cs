using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using SplashKitSDK;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace Custom_Program
{
    public class GameScene
    {
        private State _state =  null;

        //Constructor
        public GameScene(State state)
        {  
            TransitionTo(state); //Sets up inital game state
        }

        //State change method
        public void TransitionTo(State state)
        {
            Console.WriteLine($"{state.GetType().Name}");
            _state = state;
            _state.SetContext(this);
        }

        //Checks if something is clicked on --> interacts with the item if clicked
        public void ClickedOn(Point2D pt)
        { _state.ClickedOn(pt); }

        //Adds objects to game using current state
        public void AddEntity(GameObject newentity)
        { _state.AddEntity(newentity); }


        //Draws all objects using current state
        public void GameDraw()
        { _state.Draw(); }

        //Calls all game updates using current state 
        public void GameUpdates()
        { _state.Update(); }



    }
    

}
