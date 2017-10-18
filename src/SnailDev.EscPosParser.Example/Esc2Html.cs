using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.EscPosParser.Example
{
    public class Esc2Html
    {
        public bool IsDebug;
        private EscParser parser;

        public Esc2Html()
        {
            parser = new EscParser();
        }

        public void ExtractHtml(string filepath)
        {
            // var filepath = @"D:\receipt-text.bin";
            var commands = parser.GetCommands(filepath);
            Command buffImage = null;

            StringBuilder sb = new StringBuilder();
            var formatting = InlineFormatting.GetDefault();
            List<string> outPrint = new List<string>();

            foreach (var command in commands)
            {
                if (command.IsAvailableAs("InitializeCommand"))
                {
                    formatting = InlineFormatting.GetDefault();
                }
                if (command.IsAvailableAs("IInlineFormatting"))
                {
                    (command as IInlineFormatting).applyToInlineFormatting(formatting);
                }
                if (command.IsAvailableAs("ITextContainer"))
                {
                    sb.Append(GenerateSpan(formatting, (command as TextCommand).GetContent()));
                }
                if (command.IsAvailableAs("ILineBreak"))
                {
                    // Write fresh block element out to HTML
                    if (sb.ToString() == "")
                    {
                        sb.Append(GenerateSpan(formatting, ""));
                    }
                    // Block-level formatting such as text justification
                    var classes = GetBlockClasses(formatting);
                    outPrint.Add($"<div class=\"{string.Join(" ", classes)}\">{sb.ToString()}</div>");
                    sb = new StringBuilder();
                }

                if (command.IsAvailableAs("GraphicsDataCommand") || command.IsAvailableAs("GraphicsLargeDataCommand"))
                {
                    var data = (command as EscPosCommandWithData).DataCommand();
                    if (data.IsAvailableAs("StoreRasterFmtDataToPrintBufferGraphicsSubCommand"))
                    {
                        buffImage = data;
                    }
                    else if (data.IsAvailableAs("PrintBufferredDataGraphicsSubCommand") && buffImage != null)
                    {
                        var buff = buffImage as StoreRasterFmtDataToPrintBufferGraphicsSubCommand;
                        var imgAlt = $"Image {buff.GetWidth()}x{buff.GetHeight()}";

                        var imgSrc = $"data:image/png;base64,{BitMapToBase64(new FreeImageAPI.FreeImageBitmap(buff.AsPng()).ToBitmap())}"; 
                        var imgWidth = buff.GetWidth() / 2; // scaling, images are quite high res and dwarf the text


                        buffImage = null;
                        sb.Append($"<img class=\"esc-bitimage\" src=\"{imgSrc}\" alt=\"{imgAlt}\" width=\"{imgWidth}px\" />");
                        // Append and flush buffer
                        var classes = GetBlockClasses(formatting);
                        outPrint.Add($"<div class=\"{string.Join(" ", classes)}\">{sb.ToString()}</div>");
                        sb = new StringBuilder();
                    }
                }
            }

            var csses = GetCsses($"{Environment.CurrentDirectory}\\resources\\esc2html.css");
            var metaInfo = WrapBlock("<meta charset=\"UTF-8\">\n<style>", "</style>", csses);
            var receipt = WrapBlock("<div class=\"esc-receipt\">", "</div>", outPrint);
            var head = WrapBlock("<head>", "</head>", metaInfo);
            var body = WrapBlock("<body>", "</body>", receipt);
            head.AddRange(body);
            var html = WrapBlock("<html>", "</html>", head, false);

            var outDir = $"{Environment.CurrentDirectory}\\output\\";
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            FileStream fs = new FileStream($"{outDir}receipt-with-logo.html", FileMode.Create, FileAccess.Write);
            var outData = Encoding.UTF8.GetBytes($"<!DOCTYPE html>\n{string.Join("\n", html)}\n");
            fs.Write(outData, 0, outData.Length);
            fs.Flush();
            fs.Close();
        }

        private string GenerateSpan(InlineFormatting formatting, string content)
        {
            // Gut some features-
            if (formatting.Width > 2)
            {
                // Widths > 2 are not implemented. Cap the width at 2 to avoid formatting issues.
                formatting.Width = 2;
            }
            if (formatting.Height > 2)
            {
                // Widths > 2 are not implemented either
                formatting.Height = 2;
            }

            // Determine formatting classes to use
            List<string> classes = new List<string>();

            if (formatting.Bold)
            {
                classes.Add("esc-emphasis");
            }
            if (formatting.Width > 1 || formatting.Height > 1)
            {
                classes.Add("esc-text-scaled");
                // Add a single class representing height and width scaling
                var widthClass = formatting.Width > 1 ? $"-width-{formatting.Width}" : "";
                var heightClass = formatting.Height > 1 ? $"-height-{formatting.Height}" : "";
                classes.Add($"esc{widthClass}{heightClass}");
            }

            // Provide span content as HTML
            var contentHtml = "";
            if (string.IsNullOrWhiteSpace(content))
            {
                contentHtml = "&nbsp;";
            }
            else
            {
                contentHtml = System.Web.HttpUtility.HtmlEncode(content);
            }

            // Output span with any non-default classes
            if (classes.Count == 0)
            {
                return contentHtml;
            }
            return $"<span class=\"{ string.Join(" ", classes) }\">{contentHtml}</span>";
        }

        private List<string> GetBlockClasses(InlineFormatting formatting)
        {
            List<string> classes = new List<string>() { "esc-line" };

            if (formatting.Justification == InlineFormatting.Justify_Center)
            {
                classes.Add("esc-justify-center");
            }
            else if (formatting.Justification == InlineFormatting.Justify_Right)
            {
                classes.Add("esc-justify-right");
            }

            return classes;
        }

        private List<string> WrapBlock(string tag, string closeTag, List<string> contents, bool indent = true)
        {
            List<string> ret = new List<string>();
            ret.Add(tag);

            foreach (var content in contents)
            {
                ret.Add($"{(indent ? "  " : "")}{content}");
            }

            ret.Add(closeTag);

            return ret;
        }

        private List<string> GetCsses(string resource)
        {
            List<string> csses = new List<string>();
            FileStream fs = new FileStream(resource, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(fs, Encoding.UTF8);
            string strReadline;
            while ((strReadline = read.ReadLine()) != null)
            {

                csses.Add(strReadline);

            }

            fs.Close();
            read.Close();

            return csses;
        }

        private string BitMapToBase64(Bitmap bitMap)
        {
            MemoryStream ms = new MemoryStream();
            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytes = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, (int)ms.Length);
            ms.Close();

            return Convert.ToBase64String(bytes);
        }
    }
}
