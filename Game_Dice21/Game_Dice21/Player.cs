using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Dice21
{
    public class Player
    {
        public string Name;
        public int Bank;
        public int Points;

        public Player(string name, int bank)
        {
            Name = name;
            Bank = bank;
            Points = 0;
        }
    }
}
