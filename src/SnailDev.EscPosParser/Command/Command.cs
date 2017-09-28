using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// command abstract class
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// add char
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public abstract bool AddChar(char chr);
    }
}
