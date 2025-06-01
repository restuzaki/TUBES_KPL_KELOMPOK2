using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.View;
namespace GUI_KPL
{
    public partial class AnalisisPenyakitForm : Form
    {
        private AnalisisPenyakit analisis = new AnalisisPenyakit();
        public AnalisisPenyakitForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            dataGridView1.DataSource = analisis.GetDiseaseAnalyses().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            bool parseSuccess = int.TryParse(textBox2.Text, out int jumlah);

            if (!parseSuccess)
            {
                MessageBox.Show("Jumlah kasus harus berupa angka.");
                return;
            }
            if (string.IsNullOrWhiteSpace(nama) || jumlah < 0)
            {
                MessageBox.Show("Nama penyakit tidak boleh kosong dan jumlah kasus harus >= 0.");
                return;
            }
            // Tambahkan data ke analisis penyakit
            analisis.TambahPenyakitAsync(new PenyakitAnalisis
            {
                NamaPenyakit = nama,
                JumlahKasus = jumlah
            });
            // Tampilkan pesan sukses
            MessageBox.Show("Data berhasil ditambahkan!");

            textBox1.Clear();
            textBox2.Clear();

            // Refresh DataGridView
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nama = textBox3.Text;
            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama penyakit tidak boleh kosong.");
                return;
            }
            // Hapus data penyakit berdasarkan nama
            analisis.HapusPenyakitAsync(nama);
            // Tampilkan pesan sukses
            MessageBox.Show("Data berhasil dihapus!");
            // Refresh DataGridView
            textBox3.Clear();
            LoadData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            User currentUser = new User
            {
                Nama = "Admin",
                Role = "Admin"
            };
            MenuAdmin admMenu = new(currentUser);
            admMenu.Show();
            this.Hide();
        }
    }
}
