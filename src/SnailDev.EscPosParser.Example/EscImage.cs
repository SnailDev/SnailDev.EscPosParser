using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ExtractImages()
        {
            var filepath = @"D:\receipt-with-logo.bin";
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

                        buff.AsPng().Save("123.png", FreeImageAPI.FREE_IMAGE_FORMAT.FIF_PNG);
                    }
                }
            }
        }
    }
}
