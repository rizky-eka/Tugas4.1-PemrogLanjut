using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();

        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("NIM", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 150, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Huruf", 100, HorizontalAlignment.Center);
        }

        private void ResetForm ()
        {
            txtNIM.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNIM.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private bool NumericOnly (KeyPressEventArgs e)
        {
            var strValid = "0123456789";

            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
               if (strValid.IndexOf(e.KeyChar) <0 )
                {
                    return true;
                }
                return false;
            }
            else
                return false;

        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();

            mhs.NIM = txtNIM.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);

            list.Add(mhs);

            var msg = "Data mahasiswa berhasil disimpan.";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            ResetForm();
        }
        private void TampilkanData()
        {
            lvwMahasiswa.Items.Clear();

            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.NIM);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                if (mhs.Nilai <= 20)
                {
                    item.SubItems.Add("E");
                }
                else if (mhs.Nilai <= 40)
                {
                    item.SubItems.Add("D");
                }
                else if (mhs.Nilai <= 60)
                {
                    item.SubItems.Add("C");
                }
                else if (mhs.Nilai <= 80)
                {
                    item.SubItems.Add("B");
                }
                else if (mhs.Nilai <= 100)
                {
                    item.SubItems.Add("A");
                }

                lvwMahasiswa.Items.Add(item);
            }
        }

        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {

                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus?", "Konfirmasi",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {

                    var index = lvwMahasiswa.SelectedIndices[0];

                    list.RemoveAt(index);

                    TampilkanData();
                }
            }
            else
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
