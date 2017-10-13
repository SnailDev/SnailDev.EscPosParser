using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class PrintRasterBitImageCommand : EscPosCommandWithData
    {
        private char? mode { get; set; }

        private char? xL { get; set; }
        private char? xH { get; set; }
        private char? yL { get; set; }
        private char? yH { get; set; }

        public override bool AddChar(char chr)
        {
            if (!mode.HasValue)
            {
                mode = chr;
                return true;
            }
            else if (!xL.HasValue)
            {
                xL = chr;
                return true;
            }
            else if (!xH.HasValue)
            {
                xH = chr;
                return true;
            }
            else if (!yL.HasValue)
            {
                yL = chr;
                return true;
            }
            else if (!yH.HasValue)
            {
                yH = chr;
                dataCommand = new UnknownDataCommand(cmdSize - 2);
                return true;
            }

            return dataCommand.AddChar(chr);
        }
    }
}
