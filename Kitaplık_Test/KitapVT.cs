using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kitaplık_Test
{
    
    public class KitapVT
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\habib\OneDrive\Desktop\Kitaplik.accdb");

        public List<Kitap> Liste()
        {
            List<Kitap> kitap = new List<Kitap>();
            connection.Open();
            OleDbCommand command = new OleDbCommand("Select*from Kitaplar", connection);
            OleDbDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                Kitap kitap1 = new Kitap();
                kitap1.Id = Convert.ToInt16(dr[0].ToString());
                kitap1.Ad = dr[1].ToString();
                kitap1.Yazar = dr[2].ToString();

                kitap.Add(kitap1);
            }
            connection.Close(); 
            return kitap;
        }
        public void KitapEkle(Kitap kt)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("insert into Kitaplar (KitapAd,Yazar) values (@kt1,@kt2)",connection);
            command.Parameters.AddWithValue("@kt1", kt.Ad);
            command.Parameters.AddWithValue("@kt2", kt.Yazar);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kitap kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

    }
}
