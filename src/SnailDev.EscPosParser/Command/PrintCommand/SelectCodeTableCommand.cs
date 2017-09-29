using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name]  Select character code table
    /// [Format]  ASCII ESC t n
    ///             Hex 1B 74 n
    ///         Decimal 27 116 n
    /// [Range] Except for Thai model:0 ≤ n ≤ 5, 16 ≤ n ≤ 19, n = 254, 255
    ///         For Thai model: 0 ≤ n ≤ 5, 16 ≤ n ≤ 26, n = 254, 255
    /// [Default] Except for Thai model:n = 0
    ///           For Thai model: n = 20
    /// [Description] Selects a page n from the character code table
    /// </summary>
    public class SelectCodeTableCommand : EscPosCommandWithOneArg
    {

    }
}
