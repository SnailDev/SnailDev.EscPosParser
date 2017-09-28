using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class EnableEmphasisCommand : EscPosCommandWithOneArg, IInlineFormatting
    {
        public void applyToInlineFormatting(InlineFormatting formatting)
        {
            throw new NotImplementedException();
        }
    }
}
