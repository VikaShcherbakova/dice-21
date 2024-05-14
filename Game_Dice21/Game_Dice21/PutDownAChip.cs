using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Game_Dice21
{
    public partial class PutDownAChip : Form
    {
        private Game game;
        private Round round;
        private int index = 0;
        public PutDownAChip(Game game, Round round)
        {
            this.game = game;
            this.round = round;
            InitializeComponent();
            ShowCurrentPlayer();
        }

        private void ShowCurrentPlayer()
        {
            label3.Text = $"Общий банк: {round.TotalBank}";
            if (index == game.Players.Count && game.Players.Count > 1)
            {
                var Form3 = new ThrowForm(game, round);
                this.Hide();
                Form3.Show();
            }
            else
            {
                Player player = game.Players[index];
                label2.Text = $"Ход игрока: {player.Name}\nБанк: {player.Bank}";
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            round.PutDownChips(game.Players[index]);
            index++;
            ShowCurrentPlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Player currentPlayer = game.Players[index];
            game.Players.Remove(currentPlayer);
            ShowCurrentPlayer();
            if (game.Players.Count < 2)
            {
                MessageBox.Show("Недостаточное количество игроков. Игра завершена");
                var Start = new Start();
                this.Hide();
                Start.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
