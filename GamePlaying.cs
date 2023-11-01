using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    internal class GamePlaying: State
    {
        private readonly List<GameObject> _gameObjects;
        private CallCard _callCard;
        private HungerBar _hungerBar;
        private Fish _newFish;
        private Shop _newShop;
        private int _clicktimer, _autotimer;
        private FoodFactory _factory;
        public GamePlaying()
        {
            _clicktimer = 0;
            _autotimer = 0;
            _gameObjects = new List<GameObject>(); //Setup Object List
            //Setup Background and UI Objects
            
            _hungerBar = new HungerBar();
            _newShop = new Shop(_hungerBar, 30, 100);
            _callCard = new CallCard();
            _newFish = new Fish();
            
            _factory = FoodFactory.GetInstance();
            AddEntity(new Bowl());
            AddEntity(_hungerBar);
            AddEntity(_callCard);
            AddEntity(_newFish);
            AddEntity(_newShop);
        }
        public override void AddEntity(GameObject newentity)
        { _gameObjects.Add(newentity); }

        public override void ClickedOn(Point2D pt)
        {
            foreach (GameObject g in _gameObjects)
            { if (g.IsAt(pt)) { g.Interact(pt, _callCard, _context); } }
        }

        public void RemoveEntity()
        {
            foreach (GameObject g in _gameObjects.ToList())
            {
                if (g is Food)
                {
                    Food f = (Food)g;
                    if (f.DecayTime >= 500)
                    { _gameObjects.Remove(f); }
                    else if (f.Collide(_newFish))
                    {
                        _gameObjects.Remove(f); //Remove Food
                        _hungerBar.ReduceHunger(f); //Reduce Hunger
                    }
                }
            }
        }

        public override void Draw()
        { foreach (GameObject g in _gameObjects) { g.Draw(); } }

        public override void Update()
        {
            ///FISH MOVEMENT
            if (SplashKit.KeyTyped(KeyCode.AKey))
            { _newFish.Vx = (float)-4; }
            if (SplashKit.KeyTyped(KeyCode.DKey))
            { _newFish.Vx = (float)4; }
            if (SplashKit.KeyTyped(KeyCode.WKey))
            { _newFish.Vy = (float)-4; }
            if (SplashKit.KeyTyped(KeyCode.SKey))
            { _newFish.Vy = (float)4; }


            /// FOOD MANAGEMENT
            _clicktimer++; //Increment timer
            _autotimer++; //Increment timer

            //Right Mouse Clicked --> Add Food to Game 
            if (SplashKit.MouseClicked(MouseButton.RightButton) && _clicktimer >= 30)
            {
                GameObject newFood = _factory.CreateFood(_newShop.CurrentType, true);
                AddEntity(newFood);
                _clicktimer = 0;
            }
            else if (_newShop.Upgrade1Purchased && _autotimer >= 40)
            {
                GameObject newFood = _factory.CreateFood(_newShop.CurrentType, false);//Uses factory pattern to make the food
                AddEntity(newFood);
                _autotimer = 0;
            }
            //Checks all objects and removes necessary ones
            RemoveEntity();

            ///STATE MANAGEMENT 
            //Call Update for all GameObjects --> as long as fish is still alive
            if (_hungerBar.Alive == true)
            {
                foreach (GameObject g in _gameObjects)
                { g.Update(); }
            }
            else  { _context.TransitionTo(new GameOver()); }
        }
    }
}
