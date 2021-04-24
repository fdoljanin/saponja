using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Saponja.Domain.Helpers
{
    public static class FileHelpers
    {
        public static string ReadFirstFewChars(string filename, int charCount)
        {
            using var stream = File.OpenRead(filename);
            using var reader = new StreamReader(stream, Encoding.UTF8);

            var buffer = new char[charCount];
            var outCharCount = reader.ReadBlock(buffer, 0, charCount);

            var result = new string(buffer);
            return result;
        }
    }
}
