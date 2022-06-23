using System;
using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05.Game.Scripting
{
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            List<Actor> segments = cycle.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActor(score);
            videoService.DrawActor(food);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}
