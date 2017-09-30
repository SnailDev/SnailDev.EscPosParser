using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class ParserProfile
    {
        private JObject commandTree { get; set; }

        /// <summary>
        /// command tree
        /// </summary>
        public JObject CommandTree
        {
            get
            {
                return commandTree;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="profileName"></param>
        public ParserProfile(string profileName = "Default")
        {
            var profilePath = $"{System.Environment.CurrentDirectory}\\Profile\\{profileName}Commands.json";
            using (StreamReader sr = new StreamReader(profilePath))
            {
                try
                {
                    commandTree = JObject.Parse(sr.ReadToEnd())["CommandsTree"] as JObject;
                }
                catch
                {
                    throw new Exception("Your profile formatting is error.");
                }
                finally
                {
                    sr.Close();
                }
            }
        }
    }
}
