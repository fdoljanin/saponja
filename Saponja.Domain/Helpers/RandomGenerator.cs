using System;

namespace Saponja.Domain.Helpers
{
    public static class RandomGenerator
    {
        public static string GenerateRandomString() {
            var guid = Guid.NewGuid();
            var randomString = Convert.ToBase64String(guid.ToByteArray());
            randomString = randomString.Replace("=", "");
            randomString = randomString.Replace("+", "");

            return randomString;
        }
    }
}
