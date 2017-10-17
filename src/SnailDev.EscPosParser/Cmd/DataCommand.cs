using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// data command
    /// </summary>
    public class DataCommand : Command
    {
        /// <summary>
        /// data
        /// </summary>
        protected StringBuilder Data { get; set; }

        /// <summary>
        /// size of data
        /// </summary>
        protected long DataSize { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dataSize"></param>
        public DataCommand()
        {
            DataSize = 0;
            Data = new StringBuilder();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dataSize"></param>
        public DataCommand(long dataSize)
        {
            DataSize = dataSize;
            Data = new StringBuilder();
        }

        /// <summary>
        /// add char
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public override bool AddChar(char chr)
        {
            if (Data.Length < DataSize)
            {
                Data.Append(chr);
                return true;
            }

            return false;
        }
    }
}
