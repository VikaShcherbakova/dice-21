using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Dice21
{
    public partial class AddPlayers : Form
    {
        private Game game;
        private Round round;

        public AddPlayers(Game game) 
        { 
            this.game = game; 
            InitializeComponent(); 
        }
        private void button1_Click(object sender, EventArgs e) 
        { 
            string name = textBox1.Text; 
            int bank = (int)numericUpDown1.Value;

            try
            {
                game.AddPlayer(name, bank);
                textBox1.Clear();
                numericUpDown1.Value = 1;
                dataGridView1.Rows.Add(name, bank);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (game.Players.Count > 1) 
            { 
                button2.Visible = true; 
            } 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            round = new Round(); 
            game.AddRound(round); 
            var Form2 = new PutDownAChip(game, round); 
            this.Hide(); 
            Form2.Show(); 
        }
    }

}
