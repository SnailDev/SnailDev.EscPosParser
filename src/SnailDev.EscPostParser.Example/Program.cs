using SnailDev.EscPosParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnailDev.EscPostParser.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserBinToText();

            Console.ReadLine();
        }

        static void ParserBinToText()
        {
            ParserProfile profile = new ParserProfile();
            ParserContext context = new ParserContext(profile, true);
            using (FileStream fs = new FileStream(@"D:\receipt-text.bin", FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                while (br.PeekChar() != -1)
                {
                    context.AddChar(br.ReadChar());
                }

                br.Close();
                fs.Close();
            }


            var commands = context.GetCommands();
            foreach (var command in commands)
            {
                if (command.GetType().GetInterface("ITextContainer") != null)
                {
                    Console.Write((command as TextCommand).GetContent());
                }
                if (command.GetType().GetInterface("ILineBreak") != null)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
