using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Select character font
    /// [Format] ASCII ESC M n
    ///            Hex 1B 4D n
    ///        Decimal 27 77 n
    /// [Range] 0 ≤ n ≤ 2, 48 ≤ n ≤ 50
    /// [Default] n = 0
    /// [Description] Selects character fonts
    /// n           Function
    /// 0, 48       Character font A selected.
    /// 1, 49       Character font B selected.
    /// 2, 50       Character font C selected.
    /// Notes:  1. Some printers do not have font C. See the ESC/POS Application Programming Guide (ESC/POS
    ///         APG) 2. With the TM-U220, the range of n is n = 0, 1, 48, and 49. The default value is 1.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class SelectFontCommand : EscPosCommandWithOneArg
    {

    }
}
