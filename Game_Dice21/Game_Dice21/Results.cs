using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Dice21
{
    public partial class Results : Form
    {
        private Game game;
        private Round round;

        public Results(Game game, Round round)
        {
            InitializeComponent();
            this.game = game;
            this.round = round;
            List<Player> winners = round.AppointWinner(game);
            string winnerInfo = "";
            foreach (Player winner in winners)
            {
                winnerInfo+= $"{winner.Name} выиграл, его банк составляет {winner.Bank} \n";
            }
            label1.Text = winnerInfo;
            DisplayPlayerScores();
        }

        private void DisplayPlayerScores()
        {
            var sortedPlayers = game.Players
                .OrderByDescending(p => p.Points <= 21 ? p.Points : int.MinValue)
                .ThenBy(p => p.Points > 21 ? p.Points : int.MaxValue);

            foreach (Player player in sortedPlayers)
            {
                dataGridView1.Rows.Add(player.Name, player.Points, player.Bank);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            round.EndRound(game);
            if (game.Players.Count > 1)
            {
                round = new Round();
                game.AddRound(round);
                var Form2 = new PutDownAChip(game, round);
                this.Hide();
                Form2.Show();
            }
            else
            {
                MessageBox.Show("Недостаточное количество игроков. Игра завершена");
                var Start = new Start();
                this.Hide();
                Start.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            var Form1 = new AddPlayers(game);
            this.Hide();
            Form1.Show();
        }
    }
}
