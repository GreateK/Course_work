namespace Course_Work
{
    partial class PlayerInGame
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Close_button = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.start_buget_tb = new System.Windows.Forms.TextBox();
            this.finish_buget_tb = new System.Windows.Forms.TextBox();
            this.combo_tb = new System.Windows.Forms.TextBox();
            this.del_button = new System.Windows.Forms.Button();
            this.change_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.game_id_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.player_id_tb = new System.Windows.Forms.TextBox();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Обновить страницу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(309, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "Таблица \"Игрок в игре\"";
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
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(37)))), ((int)(((byte)(150)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.start_buget_tb);
            this.panel2.Controls.Add(this.finish_buget_tb);
            this.panel2.Controls.Add(this.combo_tb);
            this.panel2.Controls.Add(this.del_button);
            this.panel2.Controls.Add(this.change_button);
            this.panel2.Controls.Add(this.new_button);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.game_id_tb);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.player_id_tb);
            this.panel2.Controls.Add(this.search_tb);
            this.panel2.Location = new System.Drawing.Point(32, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 347);
            this.panel2.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(56, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Бюджет начало";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(66, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Бюджет конец";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(40, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Комбинация карт";
            // 
            // start_buget_tb
            // 
            this.start_buget_tb.Location = new System.Drawing.Point(235, 137);
            this.start_buget_tb.Name = "start_buget_tb";
            this.start_buget_tb.Size = new System.Drawing.Size(311, 22);
            this.start_buget_tb.TabIndex = 18;
            // 
            // finish_buget_tb
            // 
            this.finish_buget_tb.Location = new System.Drawing.Point(235, 181);
            this.finish_buget_tb.Name = "finish_buget_tb";
            this.finish_buget_tb.Size = new System.Drawing.Size(311, 22);
            this.finish_buget_tb.TabIndex = 17;
            // 
            // combo_tb
            // 
            this.combo_tb.Location = new System.Drawing.Point(235, 226);
            this.combo_tb.Name = "combo_tb";
            this.combo_tb.Size = new System.Drawing.Size(311, 22);
            this.combo_tb.TabIndex = 16;
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(641, 191);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(201, 33);
            this.del_button.TabIndex = 15;
            this.del_button.Text = "Удалить";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // change_button
            // 
            this.change_button.Location = new System.Drawing.Point(641, 133);
            this.change_button.Name = "change_button";
            this.change_button.Size = new System.Drawing.Size(201, 33);
            this.change_button.TabIndex = 14;
            this.change_button.Text = "Изменить";
            this.change_button.UseVisualStyleBackColor = true;
            this.change_button.Click += new System.EventHandler(this.change_button_Click);
            // 
            // new_button
            // 
            this.new_button.Location = new System.Drawing.Point(641, 78);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(201, 33);
            this.new_button.TabIndex = 13;
            this.new_button.Text = "Новая запись";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(138, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "id Игры";
            // 
            // game_id_tb
            // 
            this.game_id_tb.Location = new System.Drawing.Point(235, 90);
            this.game_id_tb.Name = "game_id_tb";
            this.game_id_tb.Size = new System.Drawing.Size(311, 22);
            this.game_id_tb.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(121, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "id Игрока";
            // 
            // player_id_tb
            // 
            this.player_id_tb.Location = new System.Drawing.Point(235, 46);
            this.player_id_tb.Name = "player_id_tb";
            this.player_id_tb.Size = new System.Drawing.Size(311, 22);
            this.player_id_tb.TabIndex = 9;
            // 
            // search_tb
            // 
            this.search_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_tb.Location = new System.Drawing.Point(181, 290);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(225, 30);
            this.search_tb.TabIndex = 8;
            this.search_tb.Text = "Поиск";
            this.search_tb.TextChanged += new System.EventHandler(this.search_tb_TextChanged);
            // 
            // PlayerInGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(42)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(945, 777);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayerInGame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PlayerInGame_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerInGame_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PlayerInGame_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Close_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button del_button;
        private System.Windows.Forms.Button change_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox game_id_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox player_id_tb;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox start_buget_tb;
        private System.Windows.Forms.TextBox finish_buget_tb;
        private System.Windows.Forms.TextBox combo_tb;
        private System.Windows.Forms.Button button2;
    }
}