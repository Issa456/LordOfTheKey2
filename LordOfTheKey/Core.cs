using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheKey
{
    class Core
    {
        public Core(string name, char symbol, int x, int y)
        {
            Name = name;
            Symbol = symbol;
            X = x;
            Y = y;
        }
        public string Name { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
