using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veri;
using Model;
using System.Data;

namespace Business
{
    class NotControl
    {
        Data d = new Data();

        public Not IDdenNotGetir(int id)
        {
            d.komut.CommandText = "SELECT * FROM tblNot WHERE NotID=@p";
            d.komut.Parameters.AddWithValue("p",id);
            DataRow dr = d.SatirGetir();

            Not n = new Not();
            n.NotID = (int)dr["NotID"];
            n.Tarih = (DateTime)dr["Tarih"];
            n.Yazi = dr["Yazi"].ToString();
            n.KategoriID = (int)dr["KategoriID"];
            return n;
        }

        public List<Not> TumNotlar() {
            return FillDoldur("SELECT * FROM tblNot ORDER BY KategoriID");
        }

        public List<Not> KatIDdenNotlar(int katid)
        { //belli bir kategoriye ait notların listesi
            return FillDoldur("SELECT * FROM tblNot WHERE KategoriID="+katid);
        }

        public List<Not> YeniNotlar()
        {   //en son eklenen 10 not listesi
            return FillDoldur("SELECT TOP 10 * FROM tblNot ORDER BY NotID DESC");
        }

        public List<Not> FillDoldur(string sorgu) {
            d.komut.CommandText = sorgu;
            DataTable dt = d.TabloGetir();
            List<Not> liste = new List<Not>();
            foreach (DataRow item in dt.Rows)
            {
                Not n = new Not();
                n.NotID = (int)item["NotID"];
                n.KategoriID = (int)item["KategoriID"];
                n.Tarih = (DateTime)item["Tarih"];
                n.Yazi = item["Yazi"].ToString();
                liste.Add(n); //listeye eklemek önemli
            }
            return liste;
        }

        public string Sil(Not n) {
            d.komut.CommandText = "DELETE FROM tblNot WHERE NotID=@p";
            d.komut.Parameters.AddWithValue("p", n.NotID);
            int s = d.KomutCalistir();
            return Mesaj.CalistirSonuc(s,"not","silindi");
        }

        public string Ekle(Not n)
        {
            d.komut.CommandText = "INSERT INTO tblNot (Yazi,KategoriID) VALUES (@pyazi,@pkat)";
            d.komut.Parameters.AddWithValue("pyazi",n.Yazi);
            d.komut.Parameters.AddWithValue("pkat",n.KategoriID);
            int s = d.KomutCalistir();
            return Mesaj.CalistirSonuc(s,"not","eklendi");
        }

        public string Duzenle(Not n)
        {
            d.komut.CommandText = "UPDATE tblNot SET Yazi=@pyazi, KategoriID=@pkatid WHERE NotID=@pid";
            d.komut.Parameters.AddWithValue("pyazi",n.Yazi);
            d.komut.Parameters.AddWithValue("pkatid",n.KategoriID);
            d.komut.Parameters.AddWithValue("pid",n.NotID);
            int s = d.KomutCalistir();
            return Mesaj.CalistirSonuc(s, "not", "güncellendi");

            //ADO.NET
            //LinqToSql
            //EntityFramework (DbFirst : önce veritabanı)
                            //(ModelFirst : önce model)
                            //(CodeFirst : önce kod)

        }
    }
}
