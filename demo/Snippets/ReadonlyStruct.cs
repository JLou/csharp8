using System;

namespace Snippets
{
    public static class ReadonlyStruct 
    {
        public static void DescribePeople()
        {
            var Jerome = new Beard(4, "blonde");
            var Antoine = new Beard(1, "noire");
            var JL = new Beard(10, "blonde");

            Console.WriteLine($"Jerome voici ta description: {Jerome}");
            Console.WriteLine($"Antoine voici ta description: {Antoine}");
            Console.WriteLine($"Jean-Lou voici ta description: {JL}");
        }
    }

    #region readonly-struct
    public struct Beard
    {
        public Beard(int length, string color)
        {
            Length = length;
            Color = color;
        }
        public int Length { get; set; }

        public string Color { get; set; }

        public readonly string LengthAdjective => Length switch
        {
            int l when l < 2 => "courte",
            int l when l >= 2 && l <= 10 => "moyenne",
            int l when l > 10 => "longue",
            _ => "étrange"
        };

        public override readonly string ToString() =>
            $"Tu as une {LengthAdjective} barbe de couleur {Color}";
    }
    #endregion
}