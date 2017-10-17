using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.EscPosParser.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // parser text info
            Esc2Text esc2text = new Esc2Text();
            esc2text.PrintText();

            Console.WriteLine("-----------------------");

            // parser image
            EscImage image = new EscImage();
            image.ExtractImages();


            Console.ReadLine();
        }
    }
}
