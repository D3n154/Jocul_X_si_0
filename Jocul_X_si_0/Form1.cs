using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jocul_X_si_0
{
    public partial class Form1 : Form
    {
        bool player = true;//true = Player X; false = Player O
        int players_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (player == true)
            {
                b.Text = "X";
                b.BackColor = Color.LightBlue;
            }
            else
            {
                b.Text = "O";
                b.BackColor = Color.LightPink;
            }

            player = !player;
            players_count++;
            b.Enabled = false;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool found_winner = false;

            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
                found_winner = true;
            else if ((button6.Text == button5.Text) && (button5.Text == button4.Text) && (!button6.Enabled))
                found_winner = true;
            else if ((button9.Text == button8.Text) && (button8.Text == button7.Text) && (!button9.Enabled))
                found_winner = true;

            if ((button1.Text == button6.Text) && (button6.Text == button9.Text) && (!button1.Enabled))
                found_winner = true;
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
                found_winner = true;
            else if ((button3.Text == button4.Text) && (button4.Text == button7.Text) && (!button3.Enabled))
                found_winner = true;

            if ((button1.Text == button5.Text) && (button5.Text == button7.Text) && (!button1.Enabled))
                found_winner = true;
            else if ((button3.Text == button5.Text) && (button5.Text == button9.Text) && (!button3.Enabled))
                found_winner = true;

            if (found_winner == true)
            {
                disableButtons();

                String winner = " ";
                if (player == true)
                {
                    winner = "O";
                    o_winCount.Text = (Int32.Parse(o_winCount.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_winCount.Text = (Int32.Parse(x_winCount.Text) + 1).ToString();
                }
                MessageBox.Show("Player " + winner + " Wins!");
            }
            else
            {
                if (players_count == 9)
                    MessageBox.Show("Draw!");
            }

        }

        private void disableButtons()
        {
            List<Button> buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, };
            foreach (Button b in buttons)
            {
                    b.Enabled = false;
            }

        }

        private void Reset_ButtonClick(object sender, EventArgs e)
        {
            player = true;
            players_count = 0;

            List<Button> buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, };
            foreach (Button b in buttons)
            {
                b.Enabled = true;
                b.Text = " ";
                b.BackColor = DefaultBackColor;
            }
        }

        private void NewGame_ButtonClick(object sender, EventArgs e)
        {
            player = true;
            players_count = 0;

            List<Button> buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, };
            foreach (Button b in buttons)
            {
                b.Enabled = true;
                b.Text = " ";
                b.BackColor = DefaultBackColor;
            }

            o_winCount.Text = "0";
            x_winCount.Text = "0";
        }

        private void Exit_ButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
