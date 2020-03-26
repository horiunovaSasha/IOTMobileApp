using System;
using System.Collections.Generic;

namespace IOTMobileApp.Models
{
    public class Colour
    {
        public int id { get; set; }
        public string Hex { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Colour(byte r, byte g, byte b, string hex)
        {
            R = r;
            G = g;
            B = b;
            Hex = hex;
        }
    }
}
