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
using System.Reflection;

namespace Course_Work
{
    public partial class Player : Form
    {
        DataBase _dataBase = new DataBase();
        Point lastPoint;

        int selectedRow;


        public Player()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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
            dataGridView2.Columns.Add("player_id", "id игрока");
            dataGridView2.Columns.Add("player_name", "Имя игрока");
            dataGridView2.Columns.Add("IsNew", "ColumnName");

            dataGridView2.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), Rowstate.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Player";

            SqlCommand cmd = new SqlCommand(queryString, _dataBase.getConnection());

            _dataBase.openConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void Player_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];

                player_id_tb.Text = row.Cells[0].Value.ToString();
                player_name_tb.Text = row.Cells[1].Value.ToString();
            }

        }

        private void new_button_Click(object sender, EventArgs e)
        {
            _dataBase.openConnection();

            var name = player_name_tb.Text;

            if (name != "")
            {
                var addQuery = $"insert into Player (player_name) values ('{name}')";

                var command = new SqlCommand(addQuery, _dataBase.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    MessageBox.Show("Строка добавлена в таблицу!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else { MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            _dataBase.closeConnection();
        }

        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string searching = $"Select * from Player where concat (player_id, player_name) like '%" + search_tb.Text + "%'";

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
            int index = dataGridView2.CurrentCell.RowIndex;

            dataGridView2.Rows[index].Visible = false;

            if (dataGridView2.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView2.Rows[index].Cells[2].Value = Rowstate.Deleted;
                return;
            }
            dataGridView2.Rows[index].Cells[2].Value = Rowstate.Deleted;
        }

        new private void Update()
        {
            _dataBase.openConnection();

            for (int index = 0; index < dataGridView2.Rows.Count; index++)
            {
                var rowState = (Rowstate)dataGridView2.Rows[index].Cells[2].Value;

                if (rowState == Rowstate.Existed) continue;

                if (rowState == Rowstate.Deleted)
                {
                    try
                    {
                        var id = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Player where player_id = {id}";

                        var command = new SqlCommand(deleteQuery, _dataBase.getConnection());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("На данный id ссылается другая таблица!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGrid(dataGridView2);
                    }
                }

                if (rowState == Rowstate.Modified)
                {
                    var id = dataGridView2.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView2.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Player set player_name = '{name}' where player_id = '{id}'";

                    var command = new SqlCommand(changeQuery, _dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }

            _dataBase.closeConnection();
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView2);
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
                var selectedRowIndex = dataGridView2.CurrentCell.RowIndex;

                var id = player_id_tb.Text;
                var name = player_name_tb.Text;

                if (dataGridView2.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    dataGridView2.Rows[selectedRowIndex].SetValues(id, name);
                    dataGridView2.Rows[selectedRowIndex].Cells[2].Value = Rowstate.Modified;
                }
                else { MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception) { MessageBox.Show("Ничего не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            Change();
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView2);
        }

        private void Player_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
