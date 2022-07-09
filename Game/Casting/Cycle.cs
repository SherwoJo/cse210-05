using System;
using System.Collections.Generic;
using System.Linq;

namespace cse210_05.Game.Casting
{
    public class Cycle : Actor
    {
        private List<Actor> segments = new List<Actor>();
        public int Player { get; set; }

        /// <summary>
        /// Constructs a new instance of a Cycle.
        /// </summary>
        public Cycle(int PlayerNumber)
        {
            Player = PlayerNumber;
            PrepareBody();
        }

        /// <summary>
        /// Gets the cycle's trail segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the cycle's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the cycle's segments (including the head).
        /// </summary>
        /// <returns>A list of cycle segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the cycle's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                if (Player == 1)
                {
                    segment.SetColor(Constants.GREEN);
                }
                else
                {
                    segment.SetColor(Constants.BLUE);
                }
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }

            GrowTail(1);
        }

        /// <summary>
        /// Turns the head of the cycle in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the cycle for moving.
        /// </summary>
        private void PrepareBody()
        {
            if (Player == 1)
            {
                int x = Constants.MAX_X / 4;
                int y = Constants.MAX_Y / 2;

                for (int i = 0; i < Constants.CYCLE_LENGTH; i++)
                {
                    Point position = new Point(x, y + i * Constants.CELL_SIZE);
                    Point velocity = new Point(0, -1 * Constants.CELL_SIZE);
                    string text = i == 0 ? "8" : "#";
                    Color color = i == 0 ? Constants.YELLOW : Constants.GREEN;
                    Actor segment = new Actor();
                    segment.SetPosition(position);
                    segment.SetVelocity(velocity);
                    segment.SetText(text);
                    segment.SetColor(color);
                    segments.Add(segment);
                }
            }

            else if (Player == 2)
            {
                int x = 3 * (Constants.MAX_X / 4);
                int y = Constants.MAX_Y / 2;

                for (int i = 0; i < Constants.CYCLE_LENGTH; i++)
                {
                    Point position = new Point(x, y + i * Constants.CELL_SIZE);
                    Point velocity = new Point(0, -1 * Constants.CELL_SIZE);
                    string text = i == 0 ? "8" : "#";
                    Color color = i == 0 ? Constants.PURPLE : Constants.BLUE;
                    Actor segment = new Actor();
                    segment.SetPosition(position);
                    segment.SetVelocity(velocity);
                    segment.SetText(text);
                    segment.SetColor(color);
                    segments.Add(segment);
                }
            }
        }
    }
}
