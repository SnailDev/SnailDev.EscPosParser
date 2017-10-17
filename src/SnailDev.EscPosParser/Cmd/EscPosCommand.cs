using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// esc pos command
    /// </summary>
    public class EscPosCommand : Command
    {
        public override bool AddChar(char chr)
        {
            return false;
        }
    }
}
