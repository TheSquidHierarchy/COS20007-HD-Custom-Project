using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Program
{
    internal class GameStart : State
    {
        private readonly List<GameObject> _gameObjects;
        private CallCard _callCard;
        
        public GameStart()
        {
            _gameObjects = new List<GameObject>(); //Setup Object List 
            _callCard = new CallCard();
            AddEntity(new Bowl());
            AddEntity(new PreGameUI());
        }
        public override void AddEntity(GameObject newentity)
        { _gameObjects.Add(newentity); }
        public override void ClickedOn(Point2D pt)
        {
            foreach (GameObject g in _gameObjects)
            { if (g.IsAt(pt)) { g.Interact(pt, _callCard, _context); } }
        }
        public override void Draw()
        { foreach (GameObject g in _gameObjects) { g.Draw(); } }
        public override void Update()
        { }
    }
    
}
