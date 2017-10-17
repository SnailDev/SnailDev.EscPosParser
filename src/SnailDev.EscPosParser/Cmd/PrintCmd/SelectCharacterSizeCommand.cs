using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class SelectCharacterSizeCommand : EscPosCommandWithOneArg, IInlineFormatting
    {
        public void applyToInlineFormatting(InlineFormatting formatting)
        {
            formatting.Width = (arg.Value / 16) + 1;
            formatting.Height = (arg.Value % 16) + 1;
        }
    }
}
