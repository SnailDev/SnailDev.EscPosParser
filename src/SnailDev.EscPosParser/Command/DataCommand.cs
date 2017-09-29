﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    /// <summary>
    /// data struct
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
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dataSize"></param>
        public DataCommand(long dataSize)
        {
            DataSize = dataSize;
        }

        /// <summary>
        /// add char
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public override bool AddChar(char chr)
        {
            if (Data == null)
            {
                Data = new StringBuilder();
            }

            if (Data.Length < DataSize)
            {
                Data.Append(chr);
                return true;
            }

            return false;
        }
    }
}
