using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KisiGrup
{
    public partial class GrupForm : Form
    {
        SqlConnection c;
        Grup grup = new Grup();

        public GrupForm(string cs)
        {
            c = new SqlConnection(cs);
            InitializeComponent();
        }

        private string[] getdata()
        {
            return new string[] { textBox1.Text, textBox2.Text };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grup.ekle(getdata());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                grup.sil(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            else
                MessageBox.Show("Lütfen aşağıdaki DataGridView'dan silmek istediğiniz grubun satırını seçiniz.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                grup.guncelle(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), getdata());
            else
                MessageBox.Show("Lütfen aşağıdaki DataGridView'dan silmek istediğiniz grubun satırını seçiniz.");
        }

        private void GrupForm_Load(object sender, EventArgs e)
        {
            grup.c = c;
            grup.gf = this;
            grup.dbcheck();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = r.Cells[1].Value.ToString();
                textBox2.Text = r.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
