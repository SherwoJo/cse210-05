using System;
using cse210_05.Game.Casting;

namespace cse210_05.Game.Scripting
{
    public class Action
    {
        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public virtual void Execute(Cast cast, Script script)
        {
            
        }
    }
}
