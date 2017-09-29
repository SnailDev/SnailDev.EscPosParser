using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class TextCommand : DataCommand, ITextContainer
    {
        /// <summary>
        /// get text content
        /// </summary>
        /// <returns></returns>
        public string GetContent()
        {
            return Data.ToString();
        }
    }
}
