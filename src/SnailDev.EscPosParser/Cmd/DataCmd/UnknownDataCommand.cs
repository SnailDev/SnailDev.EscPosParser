using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class UnknownDataCommand : DataCommand
    {
        public UnknownDataCommand(long dataSize) : base(dataSize)
        {
        }
    }
}
