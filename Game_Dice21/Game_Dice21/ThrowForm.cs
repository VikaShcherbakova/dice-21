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
    public partial class ThrowForm : Form
    {
        private Game game;
        private Round round;
        private int index = 0;
        
        public ThrowForm(Game game, Round round)
        {
            InitializeComponent();
            this.game = game;
            this.round = round;
            round.AddMove(game.Players[index]);
            ShowCurrentPlayer();
            
        }
        private void UpdateInfo(Player player)
        {
            label3.Text = $"Общий банк: {round.TotalBank}";
            label1.Text = $"Ход игрока: {player.Name}\nБанк: {player.Bank}\nОчки: {player.Points}";
        }

        private void ShowCurrentPlayer()
        {
            if (index == game.Players.Count)
            {
                var Form4 = new Results(game, round);
                this.Hide();
                Form4.Show();
            }
            else
            {
                Player player = game.Players[index];
                round.AddMove(player);
                UpdateInfo(player);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile($"C:\\Users\\Admin\\source\\repos\\Game_Dice21\\Game_Dice21\\images\\dice.gif");
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button2.Text = "Остановиться";
            label2.Text = "";
            index++;
            ShowCurrentPlayer();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Move move = round.Moves.Last();
            move.AddThrow();
            string value = move.Throws.Last().Value.ToString();
            label2.Text = $"Выпавшее значение: {value}";
            pictureBox1.Image = Image.FromFile($"C:\\Users\\Admin\\source\\repos\\Game_Dice21\\Game_Dice21\\images\\i{value}.png");
            UpdateInfo(move.Player);
            button2.Visible = move.Player.Points > 0;
            button1.Visible = move.Player.Points < 21;
            if (move.Player.Points > 21)
            {
                MessageBox.Show("Вы проиграли в этом раунде, так как набрали больше 21 очка");
                button2.Text = "Следующий игрок";
                button1.Visible = false;
            }
            button3.Visible = false;
        }
    }
}
