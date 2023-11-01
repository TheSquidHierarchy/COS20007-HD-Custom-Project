using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using SplashKitSDK;

namespace Custom_Program
{
    
    public class Program
    {
        
        public static void Main()
        {
            //Set up window 
            Window window = new Window("Fish Bowl", 2000, 1265); //2000, 1265 //1900, 1000

            //Starts game using Gamestart state
            GameScene myGame = new GameScene(new GameStart()); 

            //Game Loop
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                //Left Mouse Clicked --> Checks for collision
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                { myGame.ClickedOn(SplashKit.MousePosition()); }

                //Tick Calls
                myGame.GameUpdates();
                myGame.GameDraw();

                SplashKit.RefreshScreen(60);

            } while (!window.CloseRequested);

            
        }
    }
}
