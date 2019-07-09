using System;
using System.Collections.Generic;
using System.Text;

namespace alltherest
{
    static class LocalStatic
    {
        static void Run()
        {
            double convertionRate = 1.1197;

            double EurosToDollar(double amount) => convertionRate * amount;

            static double ConvertMoney(double amount, double convertionRate) =>
                convertionRate * amount;

        }
    }
}
