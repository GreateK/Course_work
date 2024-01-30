using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Course_Work
{
    public partial class MainForm : Form
    {
        private readonly CheckUser _user;
        public MainForm(CheckUser user)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            
            _user = user;   

            thirdButton.Visible = _user.IsAdmin;
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_button_MouseEnter(object sender, EventArgs e)
        {
            Close_button.ForeColor = Color.Red;
        }

        private void Close_button_MouseLeave(object sender, EventArgs e)
        {
            Close_button.ForeColor = Color.White;
        }

        Point lastPoint;

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void firstButton_MouseEnter(object sender, EventArgs e)
        {
            firstButton.ForeColor = Color.DarkGray;
        }

        private void secondButton_MouseEnter(object sender, EventArgs e)
        {
            secondButton.ForeColor = Color.DarkGray;
        }

        private void thirdButton_MouseEnter(object sender, EventArgs e)
        {
            thirdButton.ForeColor = Color.DarkGray;
        }

        private void fourthButton_MouseEnter(object sender, EventArgs e)
        {
            fourthButton.ForeColor = Color.DarkGray;
        }

        private void fifthButton_MouseEnter(object sender, EventArgs e)
        {
            fifthButton.ForeColor = Color.DarkGray;
        }

        private void fifthButton_MouseLeave(object sender, EventArgs e)
        {
            fifthButton.ForeColor = Color.White;
        }

        private void fourthButton_MouseLeave(object sender, EventArgs e)
        {
            fourthButton.ForeColor = Color.White;
        }

        private void thirdButton_MouseLeave(object sender, EventArgs e)
        {
            thirdButton.ForeColor = Color.White;
        }

        private void secondButton_MouseLeave(object sender, EventArgs e)
        {
            secondButton.ForeColor = Color.White;
        }

        private void firstButton_MouseLeave(object sender, EventArgs e)
        {
            firstButton.ForeColor = Color.White;
        }


        private void firstButton_Click(object sender, EventArgs e)
        {
            Croupier croupier_table = new Croupier(_user);

            this.Hide();
            croupier_table.ShowDialog();
            this.Show();
        }

        private void secondButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(_user);

            this.Hide();
            game.ShowDialog();
            this.Show();
        }

        private void thirdButton_Click(object sender, EventArgs e)
        {
            Player player = new Player();

            this.Hide();
            player.ShowDialog();
            this.Show();
        }

        private void fourthButton_Click(object sender, EventArgs e)
        {
            PlayerInGame playerInGame = new PlayerInGame(_user);

            this.Hide();
            playerInGame.ShowDialog();
            this.Show();
        }

        private void fifthButton_Click(object sender, EventArgs e)
        {
            TransferDesk transferDesk = new TransferDesk(_user);

            this.Hide();
            transferDesk.ShowDialog();
            this.Show();
        }

    }
}
