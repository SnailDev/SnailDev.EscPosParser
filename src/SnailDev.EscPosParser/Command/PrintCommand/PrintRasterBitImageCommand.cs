using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class PrintRasterBitImageCommand : EscPosCommandWithData
    {
        private char mode { get; set; }

        private char xL { get; set; }
        private char xH { get; set; }
        private char yL { get; set; }
        private char yH { get; set; }

        public override bool AddChar(char chr)
        {
            if (mode==Char.MinValue)
            {
                mode = chr;
                return true;
            }
            else if (xL == Char.MinValue)
            {
                xL = chr;
                return true;
            }
            else if (xH == Char.MinValue)
            {
                xH = chr;
                return true;
            }
            else if (yL == Char.MinValue)
            {
                yL = chr;
                return true;
            }
            else if (yH == Char.MinValue)
            {
                yH = chr;
                dataCommand = new UnknownDataCommand(cmdSize - 2);
                return true;
            }

            return dataCommand.AddChar(chr);
        }
    }
}
