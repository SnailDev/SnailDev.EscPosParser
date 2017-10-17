using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Generate pulse
    /// [Format]  ASCII ESC p m t1 t2
    ///             Hex 1B 70 m t1 t2
    ///         Decimal 27 112 m t1 t2
    /// [Range] m = 0, 1, 48, 49
    ///             0 ≤ t1 ≤ 255
    ///             0 ≤ t2 ≤ 255
    /// [Description] Outputs the pulse specified by t1 and t2 to connector pin m to open the chash drawer, 
    ///               as follows:
    /// m           Function
    /// 0, 48       Drawer kick-out connector pin 2.
    /// 1, 49       Drawer kick-out connector pin 5.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class PulseCommand : EscPosCommandWithThreeArgs
    {

    }
}
