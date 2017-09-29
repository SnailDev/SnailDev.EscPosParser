using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Select justification
    /// [Format]  ASCII ESC a n
    ///             Hex 1B 61 n
    ///         Decimal 27 97 n
    /// [Range] 0 ≤ n ≤ 2, 48 ≤ n ≤ 50
    /// [Default] n = 0
    /// [Description] Aligns all the data in one line to the position specified by n as follows:
    /// n       Justification
    /// 0, 48   Left justification
    /// 1, 49   Centering
    /// 2, 50   Right justification
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class SelectJustificationCommand : EscPosCommandWithOneArg, IInlineFormatting
    {
        public void applyToInlineFormatting(InlineFormatting formatting)
        {
            if (arg == 0 || arg == 48)
            {
                formatting.Justification = InlineFormatting.Justify_Left;
            }
            else if (arg == 1 || arg == 49)
            {
                formatting.Justification = InlineFormatting.Justify_Center;
            }
            else if (arg == 2 || arg == 50)
            {
                formatting.Justification = InlineFormatting.Justify_Right;
            }
        }
    }
}
