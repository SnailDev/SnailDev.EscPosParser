using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnailDev.EscPosParser.Example
{
    public class EscImage
    {
        public bool IsDebug;
        private EscParser parser;

        public EscImage()
        {
            parser = new EscParser();
        }

        public void ExtractImages(string filepath)
        {
            // var filepath = @"D:\receipt-with-logo.bin";
            var commands = parser.GetCommands(filepath);
            Command buffImage = null;
            int imageNo = 0;

            foreach (var command in commands)
            {
                if (command.IsAvailableAs("GraphicsDataCommand") || command.IsAvailableAs("GraphicsLargeDataCommand"))
                {
                    var data = (command as EscPosCommandWithData).DataCommand();
                    if (data.IsAvailableAs("StoreRasterFmtDataToPrintBufferGraphicsSubCommand"))
                    {
                        buffImage = data;
                    }
                    else if (data.IsAvailableAs("PrintBufferredDataGraphicsSubCommand"))
                    {
                        var buff = buffImage as StoreRasterFmtDataToPrintBufferGraphicsSubCommand;
                        var desc = $"{buff.GetWidth()} x {buff.GetHeight()}";
                        imageNo++;
                        Console.WriteLine($"[ Image {imageNo}: {desc} ]");

                        var outDir= $"{Environment.CurrentDirectory}\\output\\";
                        if (!Directory.Exists(outDir))
                        {
                            Directory.CreateDirectory(outDir);
                        }
                        new FreeImageAPI.FreeImageBitmap(buff.AsPng()).Save($"{outDir}receipt-with-logo.png", FreeImageAPI.FREE_IMAGE_FORMAT.FIF_PNG);

                        FileStream fs = new FileStream($"{outDir}receipt-with-logo.pbm", FileMode.Create, FileAccess.Write);                                 
                        fs.Write(buff.AsPbm(), 0, buff.AsPbm().Length);
                        fs.Flush();
                        fs.Close();
                    }
                }
            }
        }
    }
}
