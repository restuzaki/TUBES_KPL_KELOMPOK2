namespace GUI_KPL
{
    partial class BacaResep
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
            label6 = new Label();
            button3 = new Button();
            label5 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.YellowGreen;
            label6.Location = new Point(523, 88);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(490, 51);
            label6.TabIndex = 26;
            label6.Text = "Apotekku Baca Resep Obat\r\n";
            // 
            // button3
            // 
            button3.BackColor = Color.YellowGreen;
            button3.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(84, 1055);
            button3.Margin = new Padding(6);
            button3.Name = "button3";
            button3.Size = new Size(189, 85);
            button3.TabIndex = 25;
            button3.Text = "Kembali";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = Color.YellowGreen;
            label5.Location = new Point(584, 180);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(368, 32);
            label5.TabIndex = 24;
            label5.Text = "*cari obat berdasarkan Nama/ID\r\n";
            // 
            // button1
            // 
            button1.BackColor = Color.YellowGreen;
            button1.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(682, 315);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(163, 66);
            button1.TabIndex = 19;
            button1.Text = "Cari";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(141, 393);
            dataGridView1.Margin = new Padding(6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(1279, 634);
            dataGridView1.TabIndex = 18;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(603, 233);
            textBox1.Margin = new Padding(6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(336, 39);
            textBox1.TabIndex = 14;
            // 
            // BacaResep
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 1186);
            Controls.Add(label6);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Name = "BacaResep";
            Text = "BacaResep";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Button button3;
        private Label label5;
        private Button button1;
        private DataGridView dataGridView1;
        private TextBox textBox1;
    }
}