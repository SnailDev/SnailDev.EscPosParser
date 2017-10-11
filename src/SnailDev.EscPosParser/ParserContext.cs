using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class ParserContext
    {
        private ParserProfile profile { get; set; }

        private List<Command> commands { get; set; }

        private JObject search { get; set; }

        private Stack<string> searchStack { get; set; }

        public ParserContext(ParserProfile profile)
        {
            this.profile = profile;
            commands = new List<Command>();
            Reset();
        }

        public void Reset()
        {
            search = null;
            searchStack = new Stack<string>();
        }

        public void NavigateCommand(string arg)
        {
            searchStack.Push(arg);

            if (search.Property(arg.ToString()) == null)
            {
                Reset();
            }
            else if (search[arg] is JObject)
            {
                // Command continues after this
                search = search[arg] as JObject;
            }
            else
            {
                var type = string.Concat("SnailDev.EscPosParser.", search[arg]);
                Assembly assembly = Assembly.GetExecutingAssembly(); // Get current assembly
                commands.Add(assembly.CreateInstance(type) as Command);
                Reset();
            }
        }

        public void AddChar(char chr)
        {
            //System.Diagnostics.Debug.WriteLine(chr);
            if (searchStack.Count > 0)
            {
                // Matching parts of a command now.
                NavigateCommand(chr.ToString());
                return;
            }

            if (commands.Count != 0)
            {
                // Command is in progress
                var top = commands[commands.Count - 1];
                var ret = top.AddChar(chr);
                if (ret)
                {
                    // Character has been accepted by the command
                    return;
                }
            }

            // Has been rejected or we don't have a command yet. See if we can start a string
            if ((commands.Count == 0) || !(commands[commands.Count - 1] is TextCommand))
            {
                var top = new TextCommand(profile.CommandTree);
                if (top.AddChar(chr))
                {
                    // Character was accepted to start a string.
                    commands.Add(top);

                    return;
                }
            }

            // Character starts a command sequence
            search = profile.CommandTree;
            NavigateCommand(chr.ToString());
        }

        /// <summary>
        /// get navigated commands
        /// </summary>
        /// <returns></returns>
        public List<Command> GetCommands()
        {
            return commands;
        }
    }
}
