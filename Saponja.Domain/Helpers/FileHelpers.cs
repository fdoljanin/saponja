using System.IO;
using System.Text;

namespace Saponja.Domain.Helpers
{
    public static class FileHelpers
    {
        public static string ReadFirstFewChars(string filename, int charCount)
        {
            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
            using var stream = File.OpenRead(serverPath);
            using var reader = new StreamReader(stream, Encoding.UTF8);

            var buffer = new char[charCount];
            reader.ReadBlock(buffer, 0, charCount);

            var result = new string(buffer);
            return result;
        }
    }
}
