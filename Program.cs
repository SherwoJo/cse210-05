using System;
using cse210_05.Game.Casting;
using cse210_05.Game.Directing;
using cse210_05.Game.Scripting;
using cse210_05.Game.Services;

namespace cse210_05
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("food", new Food());
            cast.AddActor("cycle", new Cycle());
            cast.AddActor("score", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
