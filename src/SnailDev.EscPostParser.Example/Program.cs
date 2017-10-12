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
            ParserBinToText(false);

            Console.ReadLine();
        }

        static void ParserBinToText(bool isdebug)
        {
            ParserProfile profile = new ParserProfile();
            ParserContext context = new ParserContext(profile);
            using (FileStream fs = new FileStream(@"D:\receipt-with-logo.bin", FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((int)fs.Length);

                foreach (var bye in bytes)
                {
                    context.AddChar((char)bye);
                }

                br.Close();
                fs.Close();
            }

            var commands = context.GetCommands();
            foreach (var command in commands)
            {
                if (isdebug)
                {
                    // Debug output if requested. List commands and the interface for retrieving the data.
                    var className = command.GetType().Name;
                    var implList = command.GetType().GetInterfaces();
                    var implNames = new List<string>();
                    foreach (var eachType in implList)
                    {
                        implNames.Add(eachType.Name);
                    }

                    var implStr = implNames.Count == 0 ? "" : $"({string.Join(",", implNames.ToArray())})";
                    Console.WriteLine($"[DEBUG] {className} {implStr}");
                }
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
