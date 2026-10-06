using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KisiGrup
{
    internal class Kisi
    {
        public SqlConnection c;
        public KisiForm kf;

        public void dbcheck()
        {
            if (c.State != ConnectionState.Open)
                c.Open();
            DataTable dt = new DataTable();
            new SqlDataAdapter("select * from Kisiler", c).Fill(dt);
            kf.dataGridView1.DataSource = dt;
        }

        public void ekle(string[] data)
        {
            try
            {
                dbcheck();
                SqlCommand cmd = new SqlCommand("insert into Kisiler values(@p0, @p1, @p2, @p3, @p4, @p5, @p6)", c);
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

        public void sil(string id)
        {
            try
            {
                dbcheck();
                SqlCommand cmd = new SqlCommand("delete from Kisiler where kisi_id = @id", c);
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
                SqlCommand cmd = new SqlCommand("update Kisiler set ad = @p0, soyad = @p1, tel_no1 = @p2, tel_no2 = @p3, mail = @p4, unvan = @p5, grup_id = @p6 where kisi_id = @id", c);
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
