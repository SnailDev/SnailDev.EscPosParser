using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// [Name] Print and line feed
    /// [Format]  ASCII LF
    ///             Hex 0A
    ///         Decimal 10
    /// [Description] Prints the data in the print buffer and feeds one line based on the current line spacing.
    /// http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf
    /// </summary>
    public class LineFeedCommand : EscPosCommand, ILineBreak
    {

    }
}
