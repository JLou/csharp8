using System;
using System.Collections.Generic;
using System.Text;

namespace alltherest
{
    public struct Beard
    {
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
}
