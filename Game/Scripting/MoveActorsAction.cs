using System;
using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05.Game.Scripting
{
    public class MoveActorsAction : Action
    {
        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            List<Actor> actors = cast.GetAllActors();
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
            }

            Score score = (Score)cast.GetFirstActor("score");
            score.AddPoints(1);
        }
    }
}
