using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = SplashKitSDK.Color;

namespace Custom_Program
{
    internal class GameOver : State
    {
        private readonly List<GameObject> _gameObjects;
        private CallCard _callCard;

        public GameOver()
        { 
            _gameObjects = new List<GameObject>(); //Setup Object List 
            _callCard = new CallCard();
            AddEntity(new Bowl());
            AddEntity(new PostGameUI());
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
