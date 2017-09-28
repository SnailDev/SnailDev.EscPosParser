using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class EscPosCommandWithData : EscPosCommand
    {
        protected char cmd1 { get; set; }

        protected char cmd2 { get; set; }

        protected char arg1 { get; set; }

        protected char arg2 { get; set; }

        protected long cmdSize { get; set; }

        protected DataCommand dataCommand { get; set; }

        public override bool AddChar(char chr)
        {
            if (cmd1 == Char.MinValue)
            {
                cmd1 = chr;
                return true;
            }
            else if (cmd2 == Char.MinValue)
            {
                cmd2 = chr;
                cmdSize = (int)cmd1 + (int)cmd2 * 256;
                return true;
            }
            else if (arg1 == Char.MinValue)
            {
                arg1 = chr;
                return true;
            }
            else if (arg2 == Char.MinValue)
            {
                arg2 = chr;
                dataCommand = new DataCommand(cmdSize - 2);
                return true;
            }

            return dataCommand.AddChar(chr);
        }
    }
}
