using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KisiGrup
{
    internal class Grup
    {
        public SqlConnection c;
        public GrupForm gf;

        public void dbcheck()
        {
            if (c.State != ConnectionState.Open)
                c.Open();
            DataTable dt = new DataTable();
            new SqlDataAdapter("select * from Gruplar", c).Fill(dt);
            gf.dataGridView1.DataSource = dt;
        }

        public bool ekle(string[] data)
        {
            try
            {
                dbcheck();
                SqlCommand cmd = new SqlCommand("insert into Gruplar values(@p0, @p1)", c);
                for (int i = 0; i < data.Length; i++)
                    cmd.Parameters.AddWithValue($"@p{i}", data[i]);
                cmd.ExecuteNonQuery();
                dbcheck();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void sil(string id)
        {
            try
            {
                dbcheck();
                SqlCommand cmd = new SqlCommand("delete from Gruplar where grup_id = @id", c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                dbcheck();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void guncelle(string id, string[] data)
        {
            try
            {
                dbcheck();
                SqlCommand cmd = new SqlCommand("update Gruplar set grup_adi = @p0, aciklama = @p1 where grup_id = @id", c);
                cmd.Parameters.AddWithValue("@id", id);
                for (int i = 0; i < data.Length; i++)
                    cmd.Parameters.AddWithValue($"@p{i}", data[i]);
                cmd.ExecuteNonQuery();
                dbcheck();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
