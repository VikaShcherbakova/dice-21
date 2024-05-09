using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;

namespace Game_Dice21
{
    public class Move
    {
        public List<Throw> Throws;
        public Player Player;
        public int TotalScore;

        public Move(Player player)
        {
            Throws = new List<Throw>();
            Player = player;
            TotalScore = 0;
        }

        public void AddThrow()
        {
            Throw throw1 = new Throw();
            throw1.RollDice();
            Throws.Add(throw1);
            TotalScore += throw1.Value;
            Player.Points += throw1.Value;
        }

    }
}
