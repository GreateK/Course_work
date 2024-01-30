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
    public partial class Croupier : Form
    {
        private readonly CheckUser _user;
        DataBase _dataBase = new DataBase();
        Point lastPoint;

        int selectedRow;
        public Croupier(CheckUser user)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _user = user;

            delButton.Visible = user.IsAdmin;
            button1.Visible= user.IsAdmin;
            changeButton.Visible = user.IsAdmin;
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
            dataGridView1.Columns.Add("croupier_id", "id крупье");
            dataGridView1.Columns.Add("croupier_name", "имя крупье");
            dataGridView1.Columns.Add("IsNew", "ColumnName");

            dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), Rowstate.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Croupier";

            SqlCommand cmd = new SqlCommand(queryString, _dataBase.getConnection());

            _dataBase.openConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void Croupier_Load(object sender, EventArgs e)
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

                croupier_id_tb.Text = row.Cells[0].Value.ToString();
                croupier_name_tb.Text = row.Cells[1].Value.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _dataBase.openConnection();

            var name = croupier_name_tb.Text;

            if (name != "")
            {
                var addQuery = $"insert into croupier (croupier_name) values ('{name}')";

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
            else { MessageBox.Show("Ошибка заполнения таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);}
            _dataBase.closeConnection();
        }

        private void Search(DataGridView dgv)
        { 
            dgv.Rows.Clear();

            string searching = $"Select * from croupier where concat (croupier_id, croupier_name) like '%" + search_tb.Text + "%'";

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
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[2].Value = Rowstate.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[2].Value = Rowstate.Deleted;
        }

        new private void Update()
        {
            _dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (Rowstate)dataGridView1.Rows[index].Cells[2].Value;

                if (rowState == Rowstate.Existed) continue;

                if (rowState == Rowstate.Deleted)
                {   
                    try
                    {
                        var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Croupier where croupier_id = {id}";

                        var command = new SqlCommand(deleteQuery, _dataBase.getConnection());
                        command.ExecuteNonQuery();
                    }
                    catch(Exception) 
                    {
                        MessageBox.Show("На данный id ссылается другая таблица!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGrid(dataGridView1);
                    }
                }

                if (rowState == Rowstate.Modified)
                { 
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Croupier set croupier_name = '{name}' where croupier_id = '{id}'";

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

                var id = croupier_id_tb.Text;
                var name = croupier_name_tb.Text;

                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, name);
                    dataGridView1.Rows[selectedRowIndex].Cells[2].Value = Rowstate.Modified;
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
            RefreshDataGrid(dataGridView1);
        }

        private void Croupier_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Croupier_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
