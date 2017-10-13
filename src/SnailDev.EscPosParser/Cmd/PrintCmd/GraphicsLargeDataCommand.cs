using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class GraphicsLargeDataCommand : EscPosCommandWithLargeData
    {
        protected override DataCommand GetDataCommand(char arg1, char arg2, long dataSize)
        {
            var arg2Int = (int)arg2;
            if (arg2Int == 0 || arg2Int == 48)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 1 || arg2Int == 49)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 2 || arg2Int == 50)
            {
                return new PrintBufferredDataGraphicsSubCommand(dataSize);
            }
            else if (arg2Int == 3 || arg2Int == 51)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 4 || arg2Int == 52)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 64)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 65)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 66)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 67)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 68)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 69)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 80)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 81)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 82)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 83)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 84)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 85)
            {
                return new UnknownDataCommand(dataSize);
            }
            else if (arg2Int == 112)
            {
                // Raster format data to print buffer
                return new StoreRasterFmtDataToPrintBufferGraphicsSubCommand(dataSize);
            }
            else if (arg2Int == 113)
            {
                // Column format data to print buffer
                return new StoreColumnFmtDataToPrintBufferGraphicsSubCommand(dataSize);
            }
            // Fallthrough for unknown sub-commands.
            return new UnknownDataCommand(dataSize);
        }
    }
}
