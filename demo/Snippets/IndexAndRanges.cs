using System;

namespace Snippets
{
    public static class IndexAndRanges
    {
        public static void PullMyIndex()
        {
            #region index-and-range
            var carsNameList = new string[] { "AUDI", "FORD", "JAGUAR", "LEXUS", "RENAULT", "TOYOTA", "VOLVO" };

            Console.WriteLine(string.Join(", ", carsNameList));

            /*
            [1..4]
            [2..]
            [..2]
            [^2..]
            [..^3]
            [^4..^2]

            Index idx = ^4;
            Range r = 1..idx;
            carsNameList[r];
            */

            #endregion
        }
    }
}