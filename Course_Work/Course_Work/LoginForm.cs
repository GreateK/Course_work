using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Work
{
    public partial class LoginForm : Form
    {

        DataBase data = new DataBase();
        

        public LoginForm()
        {
            InitializeComponent();

            this.passwordBox.AutoSize = false;
            this.passwordBox.Size = new Size(passwordBox.Size.Width, 44);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        Point lastPoint;

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = loginBox.Text;
            var passUser = passwordBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string querystring = $"select id_user, login_user, password_user, is_admin from register where " +
                $"login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, data.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                var user = new CheckUser(dt.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(dt.Rows[0].ItemArray[3]));

                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm frm1 = new MainForm(user);
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            reg_button.ForeColor = Color.Gray;

            RegForm frm2 = new RegForm();
            this.Hide();
            frm2.ShowDialog();
            this.Show();
        }

    }
}
