using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name]  Select paper sensor(s) to output paper-end signal
    /// [Format] ASCII ESC c 3 n
    ///            Hex 1B 63 33 n
    ///        Decimal 27 99 51 n
    /// [Range] 0 ≤ n ≤ 255
    /// [Default] n = 0
    /// [Description] Selects whether to output paper-end signal to a parallel interface or not 
    ///               when a paperend is detected by the sensor selected.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class SelectPaperEndSensorsCommand : EscPosCommandWithOneArg
    {

    }
}
