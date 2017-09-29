using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Turn double-strike mode on/off
    /// [Format] ASCII ESC G n
    ///            Hex 1B 47 n
    ///        Decimal 27 71 n
    /// [Range] 0 ≤ n ≤ 255
    /// [Default] n = 0
    /// [Description] Turns double-strike mode on or off.
    ///               • When the LSB of n is 0, double-strike mode is turned off.
    ///               • When the LSB of n is 1, double-strike mode is turned on.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class EnableDoubleStrikeCommand : EscPosCommandWithOneArg
    {

    }
}
