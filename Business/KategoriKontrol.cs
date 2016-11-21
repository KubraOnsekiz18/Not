using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veri;

namespace Business
{
    class KategoriKontrol
    {
        Data d = new Data();

        public Kategori IDdenKatGetir(int id)
        {
            d.komut.CommandText = "SELECT * FROM tblKategori WHERE KategoriID=@pid";
            d.komut.Parameters.AddWithValue("pid", id);
            DataRow dr = d.SatirGetir();

            Kategori k = new Kategori();
            k.KategoriID = (int)dr["KategoriID"];
            k.KategoriAdi = dr["KategoriAdi"].ToString();
            return k;
        }
        public List<Kategori> TumKategoriler()
        {
            d.komut.CommandText = "SELECT * FROM tblKategori ORDER BY KategoriAdi ASC";
            DataTable dt = d.TabloGetir();

            List<Kategori> liste = new List<Kategori>();
            foreach (DataRow item in dt.Rows)
            {
                Kategori k = new Kategori();
                k.KategoriID = (int)item["KategoriID"];
                k.KategoriAdi = item["KategoriAdi"].ToString();
                liste.Add(k);
            }
            return liste;
        }
        public string Ekle(Kategori k)
        {
            d.komut.CommandText = "INSERT INTO tblKategori (KategoriAdi) VALUES (@p)";
            d.komut.Parameters.AddWithValue("p", k.KategoriAdi);
            int s = d.KomutCalistir();
            return Mesaj.CalistirSonuc(s, "kategori", "eklendi");
        }
        public string Sil(Kategori k)
        {
            d.komut.CommandText = "DELETE FROM tblKategori WHERE KategoriID=@p";
            d.komut.Parameters.AddWithValue("p", k.KategoriID);
            int s = d.KomutCalistir();
            return Mesaj.CalistirSonuc(s, "kategori", "silindi");
            //Başarıyla kategori silindi

            //NotControl.cs de Sil metodunu oluşturalım
        }
        public string Duzenle(Kategori k) {
            d.komut.CommandText = "UPDATE tblKategori SET KategoriAdi = @p WHERE KategoriID=@pid";
            d.komut.Parameters.AddWithValue("p",k.KategoriAdi);
            d.komut.Parameters.AddWithValue("pid",k.KategoriID);
            int s = d.KomutCalistir();
            return Mesaj.CalistirSonuc(s,"kategori","güncellendi");
        }

        //1-Veri katmanına referans ekleyelim
        //2-Data.cs nin public olduğunu kontrol edelim
        //3-using bloğuna "using Veri;"

    }
}
