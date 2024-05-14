using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Dice21
{
    public class ThrowForm
    {
        public int Value;
        public void RollDice()
        {
            Random random = new Random();
            Value = random.Next(1, 7);
        }
    }
}
