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
    public partial class TransferDesk : Form
    {
        DataBase _dataBase = new DataBase();
        private readonly CheckUser _user;
        Point lastPoint;

        int selectedRow;
        public TransferDesk(CheckUser user)
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
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("card_number", "кол-во карт");
            dataGridView1.Columns.Add("places", "кол-во мест");
            dataGridView1.Columns.Add("IsNew", "ColumnName");

            dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), Rowstate.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Transfer_desk";

            SqlCommand cmd = new SqlCommand(queryString, _dataBase.getConnection());

            _dataBase.openConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void TransferDesk_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                selectedRow = e.RowIndex;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[selectedRow];

                    table_id_tb.Text = row.Cells[0].Value.ToString();
                    number_tb.Text = row.Cells[1].Value.ToString();
                    places_tb.Text = row.Cells[2].Value.ToString();
                }
            }
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            _dataBase.openConnection();

            var card_number = number_tb.Text;
            var places = places_tb.Text;

            if (card_number != "" && places != "")
            {
                try
                {
                    var addQuery = $"insert into Transfer_desk (card_number, places) values ('{card_number}', '{places}')";

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

            string searching = $"Select * from Transfer_desk where concat (id, card_number, places) like '%" + search_tb.Text + "%'";

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
                    dataGridView1.Rows[index].Cells[3].Value = Rowstate.Deleted;
                    return;
                }
                dataGridView1.Rows[index].Cells[3].Value = Rowstate.Deleted;
            }
            catch (Exception) { MessageBox.Show("Ничего не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        new private void Update()
        {
            _dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (Rowstate)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == Rowstate.Existed) continue;

                if (rowState == Rowstate.Deleted)
                {
                    try
                    {
                        var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Transfer_desk where id = {id}";

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
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var card_number = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var places_number = dataGridView1.Rows[index].Cells[2].Value.ToString();

                    var changeQuery = $"update Transfer_desk set card_number = '{card_number}', places = '{places_number}' where player_id = '{id}'";
                    try
                    {
                        var command = new SqlCommand(changeQuery, _dataBase.getConnection());
                        command.ExecuteNonQuery();
                    }
                    catch (Exception) { MessageBox.Show("Введены недопустимые параметры!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
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
            RefreshDataGrid(dataGridView1);
        }

        private void Change()
        {
            try
            {
                var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

                var ID = table_id_tb.Text;
                var card_num = number_tb.Text;
                var places_num = places_tb.Text;

                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(ID, card_num, places_num);
                    dataGridView1.Rows[selectedRowIndex].Cells[3].Value = Rowstate.Modified;
                }
                else { MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception) { MessageBox.Show("Ничего не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void change_tb_Click(object sender, EventArgs e)
        {
            Change();
            Update();
            RefreshDataGrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void TransferDesk_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void TransferDesk_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
