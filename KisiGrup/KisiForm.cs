using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KisiGrup
{
    public partial class KisiForm : Form
    {
        SqlConnection c;
        Kisi kisi = new Kisi();

        public KisiForm(string cs)
        {
            c = new SqlConnection(cs);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GrupForm gf = new GrupForm(c.ConnectionString);
            gf.ShowDialog();
        }

        private string[] getdata()
        {
            return new string[] { textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text, textBox6.Text, textBox5.Text, textBox7.Text };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kisi.ekle(getdata());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                kisi.sil(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            else
                MessageBox.Show("Lütfen aşağıdaki DataGridView'dan silmek istediğiniz kişinin satırını seçiniz.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                kisi.guncelle(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), getdata());
            else
                MessageBox.Show("Lütfen aşağıdaki DataGridView'dan güncellemek istediğiniz kişinin satırını seçiniz.");
        }

        private void KisiForm_Load(object sender, EventArgs e)
        {
            kisi.c = c;
            kisi.kf = this;
            kisi.dbcheck();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = r.Cells[1].Value.ToString();
                textBox3.Text = r.Cells[2].Value.ToString();
                textBox2.Text = r.Cells[3].Value.ToString();
                textBox4.Text = r.Cells[4].Value.ToString();
                textBox6.Text = r.Cells[5].Value.ToString();
                textBox5.Text = r.Cells[6].Value.ToString();
                textBox7.Text = r.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string s = textBox8.Text.ToLower();
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                if (i.Cells[1].Value.ToString().ToLower().StartsWith(s))
                {
                    i.Selected = true;
                    break;
                }
                else
                    i.Selected = false;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string s = textBox9.Text.ToLower();
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                if (i.Cells[2].Value.ToString().ToLower().StartsWith(s))
                {
                    i.Selected = true;
                    break;
                }
                else
                    i.Selected = false;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string s = textBox10.Text.ToLower();
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                if (i.Cells[3].Value.ToString().ToLower().StartsWith(s))
                {
                    i.Selected = true;
                    break;
                }
                else
                    i.Selected = false;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string s = textBox11.Text.ToLower();
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                if (i.Cells[7].Value.ToString().ToLower().StartsWith(s))
                {
                    i.Selected = true;
                    break;
                }
                else
                    i.Selected = false;
            }
        }
    }
}