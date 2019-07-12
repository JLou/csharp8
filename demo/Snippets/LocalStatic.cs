using System;

namespace Snippets
{
    static class LocalStatic
    {
        #region local-static
        static double Convert(double amount)
        {
            double convertionRate = 1.1197;
            return ConvertMoney(amount, convertionRate);

            double EurosToDollar(double amount) => convertionRate * amount;

            static double ConvertMoney(double amount, double convertionRate) =>
                convertionRate * amount;
        }
        #endregion

        public static void ConvertStuff()
        {
            var monnies = new[] {10d, 15.5, 12_345.67, -1_000_000_000.52};
            foreach (var item in monnies)
            {
                Console.WriteLine($"{item:F2}EUR is ${Convert(item):F2}");
            }
        }
    }
}