using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Print and feed n lines
    /// [Format]  ASCII ESC d n
    ///             Hex 1B 64 n
    ///         Decimal 27 100 n
    /// [Range] 0 ≤ n ≤ 255
    /// [Default] Prints the data in the print buffer and feeds n lines
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class PrintAndFeedLinesCommand : EscPosCommandWithOneArg, ILineBreak
    {

    }
}
