using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;

namespace Game_Dice21
{
    public class Game
    {
        public List<Player> Players;
        public List<Round> Rounds;

        public Game()
        {
            Players = new List<Player>();
            Rounds = new List<Round>();
        }

        public void AddPlayer(string name, int bank)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя не может быть пустым");
            }
            Player player = new Player(name, bank);
            Players.Add(player);
        }

        public void AddRound(Round round)
        {
            Rounds.Add(round);
        }
    }
}
