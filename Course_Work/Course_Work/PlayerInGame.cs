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
using static System.Windows.Forms.AxHost;

namespace Course_Work
{
    public partial class PlayerInGame : Form
    {
        DataBase _dataBase = new DataBase();
        private readonly CheckUser _user;
        Point lastPoint;

        int selectedRow;

        public PlayerInGame(CheckUser user)
        {
            InitializeComponent();
            _user = user;
            del_button.Visible = user.IsAdmin;
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

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("player_id", "id игрока");
            dataGridView1.Columns.Add("game_id", "id игры");
            dataGridView1.Columns.Add("start_buget", "стартовый бюджет");
            dataGridView1.Columns.Add("finish_buget", "конечный бюджет");
            dataGridView1.Columns.Add("card_combination", "комбинация карт");
            dataGridView1.Columns.Add("IsNew", "ColumnName");

            dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3), record.GetString(4), Rowstate.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Player_in_game";

            SqlCommand cmd = new SqlCommand(queryString, _dataBase.getConnection());

            _dataBase.openConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void PlayerInGame_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                player_id_tb.Text = row.Cells[0].Value.ToString();
                game_id_tb.Text = row.Cells[1].Value.ToString();
                start_buget_tb.Text = row.Cells[2].Value.ToString();
                finish_buget_tb.Text = row.Cells[3].Value.ToString();
                combo_tb.Text = row.Cells[4].Value.ToString();
            }
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            _dataBase.openConnection();

            var idPlayer = player_id_tb.Text;
            var idGame = game_id_tb.Text;
            var sb = start_buget_tb.Text;
            var fb = finish_buget_tb.Text;
            var best_comb = combo_tb.Text;

            if (idPlayer != "" && idGame != "" && sb != "" && fb != "" && best_comb != "")
            {
               try
               {
                    var addQuery = $"insert into Player_in_game (player_id, game_id, start_buget, finish_buget, card_combination) values ('{idPlayer}', '{idGame}', '{sb}', '{fb}', '{best_comb}')";

                    var command = new SqlCommand(addQuery, _dataBase.getConnection());

                    command.ExecuteNonQuery();

                    MessageBox.Show("Строка добавлена в таблицу!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
                catch (Exception)
               {
                    MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
               }
            }
            else { MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            _dataBase.closeConnection();
        }

        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string searching = $"Select * from Player_in_game where concat (player_id, game_id, start_buget, finish_buget, card_combination) like '%" + search_tb.Text + "%'";

            SqlCommand com = new SqlCommand(searching, _dataBase.getConnection());

            _dataBase.openConnection();

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void deleteRow()
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                dataGridView1.Rows[index].Visible = false;

                if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridView1.Rows[index].Cells[5].Value = Rowstate.Deleted;
                    return;
                }
                dataGridView1.Rows[index].Cells[5].Value = Rowstate.Deleted;
            }
            catch (Exception) { MessageBox.Show("Ничего не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        new private void Update()
        {
            _dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (Rowstate)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == Rowstate.Existed) continue;

                if (rowState == Rowstate.Deleted)
                {
                    try
                    {
                        var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Player_in_game where player_id = {id}";

                        var command = new SqlCommand(deleteQuery, _dataBase.getConnection());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("На данный id ссылается другая таблица!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGrid(dataGridView1);
                    }
                }

                if (rowState == Rowstate.Modified)
                {

                        var id_player = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        var id_game = dataGridView1.Rows[index].Cells[1].Value.ToString();
                        var s_b = dataGridView1.Rows[index].Cells[2].Value.ToString();
                        var f_b = dataGridView1.Rows[index].Cells[3].Value.ToString();
                        var combo = dataGridView1.Rows[index].Cells[4].Value.ToString();

                        var changeQuery = $"update Player_in_game set start_buget = '{s_b}', finish_buget = '{f_b}', card_combination = '{combo}' where player_id = '{id_player}'";

                        var command = new SqlCommand(changeQuery, _dataBase.getConnection());
                        command.ExecuteNonQuery();

                }
            }

            _dataBase.closeConnection();
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            deleteRow();
            Update();
        }

        private void Change()
        {
            try
            {
                var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

                var idPlayer = player_id_tb.Text;
                var idGame = game_id_tb.Text;
                var startB = start_buget_tb.Text;
                var finishB = finish_buget_tb.Text;
                var combination = combo_tb.Text;

                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(idPlayer, idGame, startB, finishB, combination);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = Rowstate.Modified;
                }
                else { MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception) { MessageBox.Show("Ничего не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            Change();
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void PlayerInGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void PlayerInGame_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}