namespace GUI_KPL
{
    partial class RiwayatPembelian
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
            dataGridViewPembelian = new DataGridView();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPembelian).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPembelian
            // 
            dataGridViewPembelian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPembelian.Location = new Point(72, 92);
            dataGridViewPembelian.Margin = new Padding(6);
            dataGridViewPembelian.Name = "dataGridViewPembelian";
            dataGridViewPembelian.RowHeadersWidth = 82;
            dataGridViewPembelian.Size = new Size(1336, 877);
            dataGridViewPembelian.TabIndex = 4;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.YellowGreen;
            btnKembali.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(72, 995);
            btnKembali.Margin = new Padding(6);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(254, 79);
            btnKembali.TabIndex = 5;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click_1;
            // 
            // RiwayatPembelian
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1489, 1103);
            Controls.Add(btnKembali);
            Controls.Add(dataGridViewPembelian);
            Name = "RiwayatPembelian";
            Text = "RiwayatPembelian";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPembelian).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewPembelian;
        private Button btnKembali;
    }
}