using System;
using System.Collections.Generic;
using System.Reflection;
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

        /// <summary>
        /// http://www.cnblogs.com/snaildev/p/7661993.html
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public bool IsAvailableAs(string assembly)
        {
            var implName = $"SnailDev.EscPosParser.{assembly}";
            return Type.GetType(implName).IsAssignableFrom(this.GetType());
        }
    }
}
