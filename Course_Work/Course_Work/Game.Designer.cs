namespace Course_Work
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.table_id_tb = new System.Windows.Forms.TextBox();
            this.date_tb = new System.Windows.Forms.TextBox();
            this.combo_tb = new System.Windows.Forms.TextBox();
            this.delButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.croupier_id_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.game_id_tb = new System.Windows.Forms.TextBox();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Close_button = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(37)))), ((int)(((byte)(150)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.table_id_tb);
            this.panel2.Controls.Add(this.date_tb);
            this.panel2.Controls.Add(this.combo_tb);
            this.panel2.Controls.Add(this.delButton);
            this.panel2.Controls.Add(this.changeButton);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.croupier_id_tb);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.game_id_tb);
            this.panel2.Controls.Add(this.search_tb);
            this.panel2.Location = new System.Drawing.Point(32, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 325);
            this.panel2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(48, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "id Стола";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(28, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Дата игры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(11, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Лучш. комб.";
            // 
            // table_id_tb
            // 
            this.table_id_tb.Location = new System.Drawing.Point(160, 129);
            this.table_id_tb.Name = "table_id_tb";
            this.table_id_tb.Size = new System.Drawing.Size(311, 22);
            this.table_id_tb.TabIndex = 18;
            // 
            // date_tb
            // 
            this.date_tb.Location = new System.Drawing.Point(160, 179);
            this.date_tb.Name = "date_tb";
            this.date_tb.Size = new System.Drawing.Size(311, 22);
            this.date_tb.TabIndex = 17;
            // 
            // combo_tb
            // 
            this.combo_tb.Location = new System.Drawing.Point(160, 228);
            this.combo_tb.Name = "combo_tb";
            this.combo_tb.Size = new System.Drawing.Size(311, 22);
            this.combo_tb.TabIndex = 16;
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(620, 213);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(201, 33);
            this.delButton.TabIndex = 15;
            this.delButton.Text = "Удалить";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(620, 154);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(201, 33);
            this.changeButton.TabIndex = 14;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 33);
            this.button1.TabIndex = 13;
            this.button1.Text = "Новая запись";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(42, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "id Крупье";
            // 
            // croupier_id_tb
            // 
            this.croupier_id_tb.Location = new System.Drawing.Point(160, 78);
            this.croupier_id_tb.Name = "croupier_id_tb";
            this.croupier_id_tb.Size = new System.Drawing.Size(311, 22);
            this.croupier_id_tb.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(59, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "id Игры";
            // 
            // game_id_tb
            // 
            this.game_id_tb.Location = new System.Drawing.Point(160, 25);
            this.game_id_tb.Name = "game_id_tb";
            this.game_id_tb.Size = new System.Drawing.Size(311, 22);
            this.game_id_tb.TabIndex = 9;
            // 
            // search_tb
            // 
            this.search_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_tb.Location = new System.Drawing.Point(139, 273);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(225, 30);
            this.search_tb.TabIndex = 8;
            this.search_tb.Text = "Поиск";
            this.search_tb.TextChanged += new System.EventHandler(this.search_tb_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(921, 270);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(37)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Close_button);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 100);
            this.panel1.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Обновить страницу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(357, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "Таблица \"Игра\"";
            // 
            // Close_button
            // 
            this.Close_button.AutoSize = true;
            this.Close_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(37)))), ((int)(((byte)(150)))));
            this.Close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Close_button.Location = new System.Drawing.Point(901, 9);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(32, 31);
            this.Close_button.TabIndex = 6;
            this.Close_button.Text = "X";
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            this.Close_button.MouseEnter += new System.EventHandler(this.Close_button_MouseEnter);
            this.Close_button.MouseLeave += new System.EventHandler(this.Close_button_MouseLeave);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(42)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(945, 755);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Game";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Game_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Game_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_MouseMove);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox croupier_id_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox game_id_tb;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Close_button;
        private System.Windows.Forms.TextBox table_id_tb;
        private System.Windows.Forms.TextBox date_tb;
        private System.Windows.Forms.TextBox combo_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}