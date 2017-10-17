using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Select printing color
    /// [Format]  ASCII ESC r n
    ///             Hex 1B 72 n
    ///         Decimal 27 114 n
    /// [Range] n = 0, 1, 48, 49
    /// [Default] n = 0
    /// [Description]   Selects the printing color specified by n.
    ///                 • When n = 0,48, color 1 is selected.
    ///                 • When n = 1,49, color 2 is selected
    /// </summary>
    public class SelectPrintColorCommand : EscPosCommandWithOneArg
    {

    }
}
