using System;
using System.Linq;

namespace WReCommerce.Common.Utility
{
    public class ShippingLabelGenerator
    {
        private static Random random = new Random();

        public static string GenerateShippingLabel()
        {
            return RandomString(32);
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}