using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class PrintBarcodeCommand : EscPosCommand
    {
        private char? mode { get; set; }
        private DataCommand dataCommand { get; set; }

        public override bool AddChar(char chr)
        {
            if (!mode.HasValue)
            {
                mode = chr;
                var modeInt = (int)mode;
                if (0 <= modeInt && modeInt <= 6)
                {
                    dataCommand = new BarcodeADataCommand();
                }
                else if (65 <= modeInt && modeInt <= 78)
                {
                    dataCommand = new BarcodeBDataCommand();
                }
                return true;
            }

            if (dataCommand == null)
            {
                return false;
            }

            return dataCommand.AddChar(chr);
        }
    }
}
