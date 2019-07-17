using System;

namespace Snippets
{
    public static class IndexAndRanges
    {
        public static void PullMyIndex()
        {
            #region index-and-range
            var carsNameList = new string[] { "AUDI", "FORD", "JAGUAR", "LEXUS", "RENAULT", "TOYOTA", "VOLVO" };
            var slice = carsNameList[1..4];

            Index idx = ^4;
            Range r = 1..idx;
            
            // slice = carsNameList[r];
            // slice = carsNameList[2..];
            // slice = carsNameList[..2];
            // slice = carsNameList[^2..];
            // slice = carsNameList[..^3];
            // slice = carsNameList[^4..^2];

            Console.WriteLine(string.Join(", ", slice));
            #endregion
        }
    }
}