using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name]  Turn emphasized mode on/off
    /// [Format] ASCII ESC E n
    ///            Hex 1B 45 n
    ///        Decimal 27 69 n
    /// [Range] 0 ≤ n ≤ 255
    /// [Default] n = 0
    /// [Description]   Turns emphasized mode on or off.
    ///                 • When the LSB of n is 0, emphasized mode is turned off.
    ///                 • When the LSB of n is 1, emphasized mode is turned on.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class EnableEmphasisCommand : EscPosCommandWithOneArg, IInlineFormatting
    {
        public void applyToInlineFormatting(InlineFormatting formatting)
        {
            formatting.Bold = (int)arg == 1;
        }
    }
}
