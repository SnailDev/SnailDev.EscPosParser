using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Print and reverse feed n lines
    /// [Format]  ASCII ESC e n
    ///             Hex 1B 65 n
    ///         Decimal 27 101 n
    /// [Range] 0 ≤ n ≤ 255
    /// [Description] Prints the data in the print buffer and feeds n lines in the reverse direction.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class PrintAndReverseFeedLinesCommand : EscPosCommandWithOneArg, ILineBreak
    {

    }
}
