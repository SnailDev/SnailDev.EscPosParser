using System;
using System.Collections.Generic;

namespace SnailDev.EscPosParser.Example
{
    class Program
    {
        static void Main(string[] args)
        {
             // var filepath = @"D:\receipt-text.bin";
             var filepath = @"D:\receipt-with-logo.bin";

            // parser text info
            Esc2Text esc2text = new Esc2Text();
            esc2text.PrintText(filepath);

            Console.WriteLine("-----------------------");

            // parser image
            EscImage image = new EscImage();
            image.ExtractImages(filepath);

            Console.WriteLine("-----------------------");
            Esc2Html html = new Esc2Html();
            html.ExtractHtml(filepath);

            Console.ReadLine();
        }
    }
}
