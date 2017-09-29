using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public interface IImageContainer
    {
        /// <summary>
        /// get width
        /// </summary>
        /// <returns></returns>
        int GetWidth();

        /// <summary>
        /// get height
        /// </summary>
        /// <returns></returns>
        int GetHeight();
    }
}
