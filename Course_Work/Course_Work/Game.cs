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

namespace Course_Work
{
    enum Rowstate
    {
        Existed,
        New,
        Modified,
        Deleted,
        ModifiedNew
    }
    public partial class Game : Form
    {
        DataBase _dataBase = new DataBase();
        private readonly CheckUser _user;
        Point lastPoint;

        int selectedRow;
        public Game(CheckUser user)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _user = user;

            delButton.Visible = user.IsAdmin;
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
            dataGridView1.Columns.Add("game_id", "id игры");
            dataGridView1.Columns.Add("croupier_id", "id крупье");
            dataGridView1.Columns.Add("table_id", "id стола");
            dataGridView1.Columns.Add("date_time", "дата игры");
            dataGridView1.Columns.Add("best_combination", "лучшая комбинация");
            dataGridView1.Columns.Add("IsNew", "ColumnName");

            dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), 
                record.GetInt32(1), 
                record.GetInt32(2), 
                record.GetDateTime(3),
                record.GetString(4), 
                Rowstate.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Game";

            SqlCommand cmd = new SqlCommand(queryString, _dataBase.getConnection());

            _dataBase.openConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            
            if (!_user.IsAdmin)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    row.Cells[3].Value = "###########";
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                game_id_tb.Text = row.Cells[0].Value.ToString();
                croupier_id_tb.Text = row.Cells[1].Value.ToString();
                table_id_tb.Text = row.Cells[2].Value.ToString();
                date_tb.Text = row.Cells[3].Value.ToString();
                combo_tb.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dataBase.openConnection();

            var idCroupier = croupier_id_tb.Text;
            var idTable = table_id_tb.Text;
            var date = date_tb.Text;
            var best_comb = combo_tb.Text;

            if (date != "")
            {
                try
                {
                    var addQuery = $"insert into Game (croupier_id, table_id, date_time, best_combination) values ('{idCroupier}', '{idTable}', '{date}', '{best_comb}')";

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

            string searching = $"Select * from Game where concat (croupier_id, table_id, date_time, best_combination) like '%" + search_tb.Text + "%'";

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
            catch(Exception) { MessageBox.Show("Ничего не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
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
                        var deleteQuery = $"delete from Game where game_id = {id}";

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
                    var id_game = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var id_croupier = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var id_table = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var date = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var combo = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update Game set croupier_id = '{id_croupier}', table_id = '{id_table}', " +
                        $"date_time = '{date}', best_combination = '{combo}' where game_id = '{id_game}'";

                    var command = new SqlCommand(changeQuery, _dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }

            _dataBase.closeConnection();

            if (!_user.IsAdmin)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    row.Cells[3].Value = "###########";
                }
            }
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            deleteRow();
            Update();
        }

        private void Change()
        {
            try
            {
                var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

                var IDGame = game_id_tb.Text;
                var IDCroupier = croupier_id_tb.Text;
                var IDTable = table_id_tb.Text;
                var DateTime = date_tb.Text;
                var combination = combo_tb.Text; 

                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(IDGame, IDCroupier, IDTable, DateTime, combination);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = Rowstate.Modified;
                }
                else { MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception) { MessageBox.Show("Ничего не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);

            if (!_user.IsAdmin)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    row.Cells[3].Value = "###########";
                }
            }
        }

        private void Game_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Game_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void changeButton_Click_1(object sender, EventArgs e)
        {
            Change();
            Update();
        }
    }
}
