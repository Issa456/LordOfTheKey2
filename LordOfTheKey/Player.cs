using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordOfTheKey
{
    class Player : Creature
    {
        public Player(string name, int health, char symbol, int x, int y) : base(name, health, symbol, x, y)
        {

        }
    }
}
