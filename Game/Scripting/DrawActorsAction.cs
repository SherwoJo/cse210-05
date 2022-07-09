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
            Cycle cycle_1 = (Cycle)cast.GetFirstActor("cycle_1");
            List<Actor> segments_1 = cycle_1.GetSegments();
            Cycle cycle_2 = (Cycle)cast.GetFirstActor("cycle_2");
            List<Actor> segments_2 = cycle_2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments_1);
            videoService.DrawActors(segments_2);
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}
