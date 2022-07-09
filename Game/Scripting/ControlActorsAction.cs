using System;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05.Game.Scripting
{
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction_1 = new Point(0, -Constants.CELL_SIZE);
        private Point direction_2 = new Point(0, -Constants.CELL_SIZE);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            // left Player 1
            if (keyboardService.IsKeyDown("a"))
            {
                direction_1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right Player 1
            if (keyboardService.IsKeyDown("d"))
            {
                direction_1 = new Point(Constants.CELL_SIZE, 0);
            }

            // up Player 1
            if (keyboardService.IsKeyDown("w"))
            {
                direction_1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down Player 1
            if (keyboardService.IsKeyDown("s"))
            {
                direction_1 = new Point(0, Constants.CELL_SIZE);
            }
        
        
            // left Player 2
            if (keyboardService.IsKeyDown("j"))
            {
                direction_2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right Player 2
            if (keyboardService.IsKeyDown("l"))
            {
                direction_2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up Player 2
            if (keyboardService.IsKeyDown("i"))
            {
                direction_2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down Player 2
            if (keyboardService.IsKeyDown("k"))
            {
                direction_2 = new Point(0, Constants.CELL_SIZE);
            }

            Cycle cycle_1 = (Cycle)cast.GetFirstActor("cycle_1");
            cycle_1.TurnHead(direction_1);
            Cycle cycle_2 = (Cycle)cast.GetFirstActor("cycle_2");
            cycle_2.TurnHead(direction_2);

        }
    }
}
