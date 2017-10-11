﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class TextCommand : DataCommand, ITextContainer
    {
        private JObject commandTree { get; set; }

        public TextCommand(JObject commandTree)
        {
            this.commandTree = commandTree;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public override bool AddChar(char chr)
        {
            if (Data == null) Data = new StringBuilder();

            // Reject ESC/POS control chars.
            if (commandTree.Property(chr.ToString()) != null)
            {
                return false;
            }

            Data.Append(chr);
            return true;
        }

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