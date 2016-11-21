using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Mesaj
    {
        public static string CalistirSonuc(int sayi,string tür, string islem) {
            if (sayi > 0)
            {
                return "Başarıyla " + tür + " " + islem;
            }
            else return "Bir hata oluştu";
            //eğer sayi 0dan büyükse
                //Başarıyla tür islem
                //Başarıyla kategori silindi
                //Başarıyla not güncellendi
            //değilse
                //Bir hata oluştu

        }
    }
}
