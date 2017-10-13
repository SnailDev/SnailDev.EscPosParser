using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class EscPosCommandWithLargeData : EscPosCommandWithData
    {
        private char? cmd3 { get; set; }
        private char? cmd4 { get; set; }

        public override bool AddChar(char chr)
        {
            if (!cmd1.HasValue)
            {
                cmd1 = chr;
                return true;
            }
            else if (!cmd2.HasValue)
            {
                cmd2 = chr;
                return true;
            }
            else if (!cmd3.HasValue)
            {
                cmd3 = chr;
                return true;
            }
            else if (!cmd4.HasValue)
            {
                cmd4 = chr;
                cmdSize = (int)cmd1 + (int)cmd2 * 256 + (int)cmd3 * 65536 + (int)cmd4 * 16777216;
                return true;
            }
            else if (!arg1.HasValue)
            {
                arg1 = chr;
                return true;
            }
            else if (!arg2.HasValue)
            {
                arg2 = chr;
                dataCommand = new UnknownDataCommand(cmdSize - 2);
                return true;
            }

            return dataCommand.AddChar(chr);
        }
    }
}
