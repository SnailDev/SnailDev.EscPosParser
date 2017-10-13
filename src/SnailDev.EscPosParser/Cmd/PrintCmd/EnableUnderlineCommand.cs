using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Turn underline mode on/off
    /// [Format]  ASCII ESC − n
    ///             Hex 1B 2D n
    ///         Decimal 27 45 n
    ///[Range] 0 ≤ n ≤ 2, 48 ≤ n ≤ 50
    ///[Default]    n = 0
    ///[Description]    Turns underline mode on or off, based on the following values of n:
    ///               n             Function
    ///               0, 48         Turns off underline mode
    ///               1, 49         Turns on underline mode, set at 1-dot width
    ///               2, 50         Turns on underline mode, set at 2-dot width
    /// Note: With the TM-U230 or TM-U200/TM-U210, the range is n = 0, 1, 48, 49
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class EnableUnderlineCommand : EscPosCommandWithOneArg
    {

    }
}
