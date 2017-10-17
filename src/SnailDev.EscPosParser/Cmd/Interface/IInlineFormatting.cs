using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public interface IInlineFormatting
    {
        void applyToInlineFormatting(InlineFormatting formatting);
    }

    public class InlineFormatting
    {
        public const int Justify_Left = 0;
        public const int Justify_Center = 1;
        public const int Justify_Right = 2;

        public bool Bold { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Justification { get; set; }

        public InlineFormatting()
        {
            Width = 1;
            Height = 1;
            Justification = Justify_Left;
        }

        public static InlineFormatting GetDefault()
        {
            return new InlineFormatting();
        }
    }
}
