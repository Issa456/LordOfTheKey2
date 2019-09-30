using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheKey
{
    class Creature : Core
    {
        public Creature(string name, int health, char symbol, int x, int y) : base (name, symbol, x, y)
        {
            Health = health;
        }
        public int Health { get; set; }
        public int Damage { get; set; }
    }
}
