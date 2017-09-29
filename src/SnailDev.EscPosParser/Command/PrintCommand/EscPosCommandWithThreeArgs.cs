using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class EscPosCommandWithThreeArgs : EscPosCommand
    {
        protected char arg1 { get; set; }
        protected char arg2 { get; set; }
        protected char arg3 { get; set; }

        public override bool AddChar(char chr)
        {
            if (this.arg1 == Char.MinValue)
            {
                this.arg1 = chr;
                return true;
            }
            else if (this.arg2 == Char.MinValue)
            {
                this.arg2 = chr;
                return true;
            }
            else if (arg3 == Char.MinValue)
            {
                this.arg3 = chr;
                return true;
            }

            return false;
        }
    }
}
