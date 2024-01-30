using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Course_Work
{
    public partial class RegForm : Form
    {
        DataBase dataBase = new DataBase();
        public RegForm()
        {
            InitializeComponent();

            this.passwordBox2.AutoSize = false;
            this.passwordBox2.Size = new Size(passwordBox2.Size.Width, 44);
            comboBox1.Items.Insert(0, "Крупье");
            comboBox1.Items.Insert(1, "Администратор");

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }


        Point lastpoint;
        private void mainPanal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void mainPanal_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var login = loginBox2.Text;
            var password = passwordBox2.Text;
            var index = comboBox1.SelectedIndex;

            string querystr = $"insert into register(login_user, password_user, is_admin) values('{login}', '{password}', {index})";
            SqlCommand cmd = new SqlCommand(querystr, dataBase.getConnection());

            dataBase.openConnection();

            if (checkuser())
            {
                return;
            }
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            dataBase.closeConnection();

        }

        private Boolean checkuser()
        {

            var logUser = loginBox2.Text;
            var passUser = passwordBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string qstring = $"select id_user, login_user, password_user, is_admin from register where login_user = '{logUser}'";

            SqlCommand command = new SqlCommand(qstring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже используется!");
                return true;
            }
            else return false;

        }
    }
}
