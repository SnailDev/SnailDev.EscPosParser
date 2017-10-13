using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnailDev.EscPosParser
{
    public class EscParser
    {
        private EscParserContext context;

        public EscParser(string profileName = "Default")
        {
            context = new EscParserContext(profileName);
        }

        /// <summary>
        /// get commands in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<Command> GetCommands(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return this.GetCommands(fs);
            }
        }

        /// <summary>
        /// get commands in stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public List<Command> GetCommands(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            byte[] bytes = br.ReadBytes((int)stream.Length);

            foreach (var bye in bytes)
            {
                context.AddChar((char)bye);
            }

            br.Close();
            stream.Close();

            return context.GetCommands();
        }
    }
}
