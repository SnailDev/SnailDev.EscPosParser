using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class FeedAndCutCommand : EscPosCommandWithTwoArgs
    {
        private List<int> argArr = new List<int>() { 0x00, 0x48, 0x01, 0x49 };

        public override bool AddChar(char chr)
        {
            if (!arg1.HasValue)
            {
                this.arg1 = chr;
                return true;
            }
            else if (argArr.Contains((int)arg1) || arg2.HasValue)
            {
                // One arg only, or arg already set
                return false;
            }
            else
            {
                // Read feed length also
                this.arg2 = chr;
                return true;
            }
        }
    }
}
