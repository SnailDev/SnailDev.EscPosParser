using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Initialize printer
    /// [Format]  ASCII ESC @
    ///             Hex 1B 40
    ///         Decimal 27 64
    /// [Description] Clears the data in the print buffer and resets the printer modes to the modes that were 
    ///               in effect when the power was turned on.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class InitializeCommand : EscPosCommand
    {

    }
}
