using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnailDev.EscPosParser.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"D:\Mallcoo_Git\ReceiptPrint\Mallcoo.SPLData\20171026spl\00005.SPL", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            byte[] bytes = br.ReadBytes((int)fs.Length);

            BinaryReader br1 = new BinaryReader(new MemoryStream(bytes));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i > 2)
                {
                    if (bytes[i - 1] == 0x16 && bytes[i - 3] == 0x15)
                    {
                        br1.BaseStream.Seek(i, SeekOrigin.Current);
                        foreach (var bye in br1.ReadBytes(bytes[i]))
                        {
                            sb.Append((char)bye);
                        }
                    }
                }
            }

            br.Close();
            fs.Close();

            Console.WriteLine(sb.ToString()); 

            Console.ReadLine();
        }
    }
}
