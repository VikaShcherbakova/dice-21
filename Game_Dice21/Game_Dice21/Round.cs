using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Dice21
{
    public class Round
    {
        public int TotalBank;
        public List<Move> Moves;

        public Round()
        {
            Moves = new List<Move>();
        }

        public void PutDownChips(Player player)
        {
            TotalBank++;
            player.Bank--;
        }
        public void AddMove(Player player)
        {
            Move move = new Move(player);
            Moves.Add(move);
        }

        public List<Player> AppointWinner(Game game)
        {
            List<Player> winners = new List<Player>();
            int maxScore = 0;

            foreach (Player player in game.Players)
            {
                if (player.Points <= 21 && player.Points > maxScore)
                {
                    maxScore = player.Points;
                }
            }

            foreach (Player player in game.Players)
            {
                if (player.Points == maxScore)
                {
                    winners.Add(player);
                }
            }

            if (winners.Count == 0)
            {
                MessageBox.Show("Все игроки проиграли");
            }
            else
            {
                int chipsPerWinner = TotalBank / winners.Count;
                if (winners.Count == 1)
                {
                    winners[0].Bank += TotalBank;
                    TotalBank = 0;
                }
                else if (winners.Count > 1)
                {
                
                    foreach (Player winner in winners)
                    {
                        winner.Bank += chipsPerWinner;
                    }
                    TotalBank = 0;
                }
            }

            return winners;
        }

        public void EndRound(Game game)
        {
            
            Player firstPlayer = game.Players.First();
            game.Players.Remove(firstPlayer);
            game.Players.Add(firstPlayer);

            game.Players.RemoveAll(player => player.Bank == 0);
            foreach (Player player in game.Players)
            {
                player.Points = 0;
            }
        }
    }
}
