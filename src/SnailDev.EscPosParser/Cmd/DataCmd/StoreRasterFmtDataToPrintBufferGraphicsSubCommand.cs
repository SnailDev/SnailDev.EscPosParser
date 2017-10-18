using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class StoreRasterFmtDataToPrintBufferGraphicsSubCommand : DataCommand
    {
        private char? tone { get; set; }

        private char? color { get; set; }

        private char? widthMultiple { get; set; }

        private char? heightMultiple { get; set; }

        private char? x1 { get; set; }

        private char? y1 { get; set; }

        private char? x2 { get; set; }

        private char? y2 { get; set; }

        public StoreRasterFmtDataToPrintBufferGraphicsSubCommand(long dataSize)
        {
            this.DataSize = dataSize - 8;
        }

        /// <summary>
        /// add char
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public override bool AddChar(char chr)
        {
            if (!tone.HasValue)
            {
                tone = chr;
                return true;
            }
            else if (!color.HasValue)
            {
                color = chr;
                return true;
            }
            else if (!widthMultiple.HasValue)
            {
                widthMultiple = chr;
                return true;
            }
            else if (!heightMultiple.HasValue)
            {
                heightMultiple = chr;
                return true;
            }
            else if (!x1.HasValue)
            {
                x1 = chr;
                return true;
            }
            else if (!x2.HasValue)
            {
                x2 = chr;
                return true;
            }
            else if (!y1.HasValue)
            {
                y1 = chr;
                return true;
            }
            else if (!y2.HasValue)
            {
                y2 = chr;
                return true;
            }
            else if (Data.Length < DataSize)
            {
                Data.Append(chr);

                return true;
            }

            return false;
        }

        public int GetWidth()
        {
            return x1.Value + x2.Value * 256;
        }

        public int GetHeight()
        {
            return y1.Value + y2.Value * 256;
        }

        /// <summary>
        /// pbm image format
        /// </summary>
        /// <returns></returns>
        public byte[] AsPbm()
        {
            var pbmStr = $"P4\n{GetWidth()} {GetHeight()}\n{Data}";
            var pbmChrs = pbmStr.ToCharArray();

            byte[] pbmBytes = new byte[pbmChrs.Length];
            for (int i = 0; i < pbmChrs.Length; i++)
            {
                pbmBytes[i] = (byte)pbmChrs[i];
            }

            return pbmBytes;
        }

        public Stream AsPng()
        {
            return new MemoryStream(AsPbm());
        }
    }
}
