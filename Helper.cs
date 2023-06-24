using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShare.UnitTest
{
    public static class Helper
    {
        public static string ReadTxt(string path)
        {
            return File.ReadAllText(path, Encoding.UTF8);
        }

        public static byte[] ReadCsv(string path)
        {
            using (var reader = new StreamReader(path))
            {
                List<byte> result = new List<byte>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    result.Add(byte.Parse(line!));
                }

                return result.ToArray();
            }
        }
    }
}
