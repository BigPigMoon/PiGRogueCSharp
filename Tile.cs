using System.Text.RegularExpressions;

namespace PiGRogue
{
    class Tile
    {
        public string type;
        public string color;
        public bool block;
        public char c;

        public Tile(string t, string col, bool b)
        {
            type = t;
            color = col;
            block = b;

            string pattern = @"[A-Z]";
            string matchValue = Regex.Match(type, pattern).Value;

            if (matchValue != "") { c = matchValue[0]; }
            else { c = type[type.Length - 1]; }
        }
    }
}
