using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class EscPosCommandWithOneArg : EscPosCommand
    {
        protected char? arg { get; set; }

        public override bool AddChar(char chr)
        {
            if (!this.arg.HasValue)
            {
                this.arg = chr;
                return true;
            }

            return false;
        }
    }
}
