using System;
using System.Collections.Generic;
using System.Data;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05.Game.Scripting
{
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the cycle collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycle cycle_1 = (Cycle)cast.GetFirstActor("cycle_1");
            Cycle cycle_2 = (Cycle)cast.GetFirstActor("cycle_2");
            Actor head_1 = cycle_1.GetHead();
            Actor head_2 = cycle_2.GetHead();
            List<Actor> body_1 = cycle_1.GetBody();
            List<Actor> body_2 = cycle_2.GetBody();

            foreach (Actor segment in body_1)
            {
                if (segment.GetPosition().Equals(head_2.GetPosition()))
                {
                    isGameOver = true;
                }
            }

            foreach (Actor segment in body_2)
            {
                if (segment.GetPosition().Equals(head_1.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
                List<Actor> segments = cycle.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
        }
    }
}
