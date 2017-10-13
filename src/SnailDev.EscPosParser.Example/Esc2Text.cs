using SnailDev.EscPosParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser.Example
{
    public class Esc2Text
    {
        public bool IsDebug;
        private EscParser parser;

        public Esc2Text()
        {
            parser = new EscParser();
        }

        public void PrintText()
        {
            var filepath = @"D:\receipt-with-logo.bin";
            var commands = parser.GetCommands(filepath);
            foreach (var command in commands)
            {
                if (IsDebug)
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
                if (command.IsAvailableAs("ITextContainer"))
                {
                    Console.Write((command as TextCommand).GetContent());
                }
                if (command.IsAvailableAs("ILineBreak"))
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
