using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Select print mode (s)
    /// [Format] ASCII ESC ! n
    ///            Hex 1B 21 n
    ///        Decimal 27 33 n
    /// [Range] 0 ≤ n ≤ 255
    /// [Default] n = 0
    /// [Description] Selects the character font and styles(emphasize, double-height, double-width, and
    ///               underline) together
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class SelectPrintModeCommand : EscPosCommandWithOneArg, IInlineFormatting
    {
        public void applyToInlineFormatting(InlineFormatting formatting)
        {
            
        }
    }
}
