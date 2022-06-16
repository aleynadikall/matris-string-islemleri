using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matris
{
    class Program
    {
        static void Main(string[] args)
        {
            //gerektigi anda donguyu durdurabilmek icin dongunun durumu degiskene atanmistir.
            bool devamEdilsinMi = true;
            while (devamEdilsinMi)
            {
                //metod cagirildi.
                IslemSecmeMenusu();
                int menuIslemSecim = Convert.ToInt32(Console.ReadLine());

                //secime gore ne olmali buna karar verecek yapi olusturuldu.
                switch (menuIslemSecim)
                {
                    case 1:
                        //metod cagirildi.
                        MatrisIslemleri();
                        Console.ReadKey();
                        break;
                    case 2:
                        //metod cagirildi.
                        StringIslemleri();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Çıkış Yapmak");
                        Console.WriteLine("Devam Etmek İçin Tıklayınız...");
                        Console.ReadKey();
                        devamEdilsinMi = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim!!!");
                        Console.WriteLine("Devam Etmek İçin Tıklayınız..");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                //ekran temizledik.
            }

        }




        //İslem secim menusu icin gerekli bilgilerin oldugu metod.
        private static void IslemSecmeMenusu()
        {

            Console.WriteLine("..:: İşlemler ::..");
            Console.WriteLine("1-Matris İşlemleri");
            Console.WriteLine("2-String İşlemleri");
            Console.WriteLine("3-Çıkış");
            Console.Write("Seçiminiz:");

        }





        //String islemleri icin gerekli bilgilerin oldugu metod.
        private static void StringIslemleri()
        {
            //ekran temizledik.
            Console.Clear();

            //istenilenHarf in stringIfade de kac adet oldugunu tutan degisken.
            int harfSayisi = 0;

            //String islemlerin secimi sonucu cikacak kisim.
            Console.WriteLine("..::String İşlemleri::..");
            Console.Write("İşlem Yapılacak Stringi Giriniz:");
            string stringIfade = Console.ReadLine();
            Console.Write("İstenilen Harfi Giriniz:");
            char istenilenHarf = Convert.ToChar(Console.ReadLine());

            //stringIfade nin harflerini tek tek gezen döngü.
            for (int i = 0; i < stringIfade.Length; i++)
            {
                //stringIfade nin harfleri gezilirken ifdeki esitlik sayesinde stringIfade de kac tane istenilenHarf var bulduk.
                if (stringIfade[i] == istenilenHarf)
                {
                    harfSayisi++;
                }
            }

            //istenilenHarf in stringIfadede 2 tane olmasi durumunda ne olmali,2 tane olmamasi durumunda ne olmali karar verecek yapi.
            if (harfSayisi == 2)
            {
                //stringe yapılabilecek islemler,islemlerin secimi ve secimlere gore cagirilan metodlar..
                Console.WriteLine("1-Ara Metni Tersten Yazma");
                Console.WriteLine("2-Ara Metni 5 kere Tekrarlı Yazma");
                Console.Write("Seçiminiz:");
                char stringIslemSecim = Convert.ToChar(Console.ReadLine());
                if (stringIslemSecim == '1')
                {
                    TerstenYazdir(stringIfade, istenilenHarf);
                }
                else if (stringIslemSecim == '2')
                {
                    BesKereTekrarliYazdir(stringIfade, istenilenHarf);
                }
                else
                {
                    Console.WriteLine("Hatalı Seçim!!!");

                }


            }
            else
            {
                Console.WriteLine("Aranan harf kelime içerisinde 2 tane bulunamamıştır.");

            }
            Console.WriteLine("Devam Etmek İçin Tıklayınız...");
        }

        //StringIslemleri() icin kullanilacak 2 metoda parametreler atandi.
        private static void TerstenYazdir(string stringIfade, char istenilenHarf)
        {

            string yeniStringIfade = " ";

            //stringIfadeyi Ters Çevirme
            //stringIfade nin son elemanindan ilk elemanina kadar yeniStringIfade ye atandi.
            for (int i = stringIfade.Length - 1; i >= 0; i--)
            {
                yeniStringIfade += stringIfade[i];

            }

            //kullanicinin girdigi harf bosluk ile degistirildi.
            yeniStringIfade = yeniStringIfade.Replace(istenilenHarf, ' ');

            //ters cevrilen stringIfadeden istenilenHarf(artik bosluk) cikarildiginda geriye kalan kisim ekrana bir kere yazdirildi.
            for (int i = 0; i < yeniStringIfade.Length; i++)
            {
                if (yeniStringIfade[i] != ' ')
                {
                    Console.Write(yeniStringIfade[i]);
                }

            }
            Console.WriteLine();

        }

        private static void BesKereTekrarliYazdir(string stringIfade, char istenilenHarf)
        {
            string yeniStringIfade = " ";

            //stringIfadenin elemanlarini yeniStringIfadeye atadik.
            for (int i = 0; i <= stringIfade.Length - 1; i++)
            {
                yeniStringIfade += stringIfade[i];

            }

            //ekrana islem sonucu olusan yeniStringIfadeyi 5 kere yazdiran for dongusu.
            for (int j = 0; j < 5; j++)
            {
                //yeniStringIfade elemanlarina stringIfadenin elemanlari tek tek atayan dongu.
                for (int i = 0; i < yeniStringIfade.Length; i++)
                {
                    //Boylece kullanici tarafindan girilen harf ve bosluklar yeniStringIfadede olmayacak.
                    if (yeniStringIfade[i] != istenilenHarf && yeniStringIfade[i] != ' ')
                    {
                        Console.Write(yeniStringIfade[i]);

                    }

                }
                Console.WriteLine();
            }

        }





        //matris islemleri icin gereken bilgiler.
        private static void MatrisIslemleri()
        {

            Console.Clear();

            //matris islemleri sonucu ekranda gozukecek bilgiler.
            Console.WriteLine("..::Matris İşlemleri::..");
            Console.Write("Matrisin satır sayısını giriniz (1-10 arasında) : ");
            int satirSayisi = Convert.ToInt32(Console.ReadLine());

            //kullanicidan alinan satir sayisi=matris boyutu olacak sekilde olusturulan 2 boyutlu matris.
            int[,] matris = new int[satirSayisi, satirSayisi];

            //kullanicinin matris elemanlarina tek tek deger girmesini sagladik.
            for (int i = 0; i < satirSayisi; i++)
            {

                for (int j = 0; j < satirSayisi; j++)
                {
                    //matrisin ilk elemani ekranda [0,0] dan baslamasin diye i ve j lere 1 ekledik.Boylece ekranda [1,1] seklinde yazacak.
                    Console.Write("["+ (i + 1) + "," + (j + 1) +"]");
                    matris[i, j] = Convert.ToInt32(Console.ReadLine());

                }

            }

            //matris elemanlarini ekrana kare matris gorunumunde yazdirdik.
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < satirSayisi; j++)
                {
                    Console.Write(matris[i, j] + " ");
                }
                Console.WriteLine();
            }

            //olusan matrise yapilabilecek islemler ve secimi.
            Console.WriteLine("1-Satır En Büyük");
            Console.WriteLine("2-Satır Toplam");
            Console.Write("Seciminiz:");
            int matrisIslemSecim = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Sonuc: ");
            //metodumuzu cagirdik.
            SatirBuyukVeToplamBuldur(matrisIslemSecim, satirSayisi, matris);
        }

        //MatrisIslemlerinde kullanilacak metod.
        private static void SatirBuyukVeToplamBuldur(int matrisIslemSecim, int satirSayisi, int[,] matris)
        {
            //matrisIslemSecimi ne gore olmasi gerekenler.
            if (matrisIslemSecim == 1)
            {
                //satirlarin en buyuklerini tutan dizi olusturduk.
                int[] satirinBuyugu = new int[satirSayisi];

                //kare matrisin elemanlarini tek tek gezerek satirlardaki en buyukleri diziye atama islemini dongu ile sagladik.
                for (int i = 0; i < satirSayisi; i++)
                {
                    for (int j = 0; j < satirSayisi; j++)
                    {

                        if (satirinBuyugu[i] < matris[i, j])
                        {
                            satirinBuyugu[i] = matris[i, j];
                        }

                    }
                }

                //buyukleri tutan dizi uzunluguna gore dizideki elemanlari ekrana yazdirdik. 
                for (int i = 0; i < satirinBuyugu.Length; i++)
                {
                    Console.Write(satirinBuyugu[i] + " ");
                }
                Console.WriteLine();

            }
            else if (matrisIslemSecim == 2)
            {
                //satir toplamlarini tutan bir dizi olusturduk.
                int[] satirinToplami = new int[satirSayisi];

                //her satirin toplamini satirinToplami dizisinin ilk elemanina atayan dongu olusturduk.
                for (int i = 0; i < satirSayisi; i++)
                {
                    for (int j = 0; j < satirSayisi; j++)
                    {
                        satirinToplami[i] += matris[i, j];
                    }
                }


                //Toplamlarin tutuldugu dizinin uzunluguna gore toplamlari ekrana yazdirdik.
                for (int i = 0; i < satirinToplami.Length; i++)
                {
                    Console.Write(satirinToplami[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Hatali Secim!!!");
            }
            Console.Write("Devam Etmek İçin Tıklayınız...");
        }
    }
}
