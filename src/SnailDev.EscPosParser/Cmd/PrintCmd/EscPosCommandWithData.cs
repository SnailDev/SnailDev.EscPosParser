using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class EscPosCommandWithData : EscPosCommand
    {
        protected char? cmd1 { get; set; }

        protected char? cmd2 { get; set; }

        protected char? arg1 { get; set; }

        protected char? arg2 { get; set; }

        protected long cmdSize { get; set; }

        protected DataCommand dataCommand { get; set; }

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
                cmdSize = (int)cmd1 + (int)cmd2 * 256;
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
                dataCommand = GetDataCommand(arg1.Value, arg2.Value, cmdSize - 2);
                return true;
            }

            return dataCommand.AddChar(chr);
        }

        protected virtual DataCommand GetDataCommand(char arg1, char arg2, long dataSize)
        {
            return new UnknownDataCommand(dataSize);
        }

        public DataCommand DataCommand()
        {
            return dataCommand;
        }
    }
}
