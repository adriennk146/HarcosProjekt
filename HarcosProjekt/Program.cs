using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Program
    {
        static List<Harcos> harcosok = new List<Harcos>();
        static int fordulo = 0;
        static Harcos h1;
        static void Main(string[] args)
        {
            FelhasznaloHarcosa();
            Beolvasas();
            Jatek();
            
           

            Console.ReadLine();
        }

        static void FelhasznaloHarcosa()
        {
            Console.WriteLine("\t\t\tÜdv a játékban!\n" +
                "Adj nevet a harcosodnak:");
            string nev = Console.ReadLine();
            int statuszSablon;
            int ujra = 0;
            do
            {
                if (ujra > 0)
                {
                    Console.WriteLine("Hibás értéket adtál meg!!");
                }
                Console.WriteLine("Milyen státusz sablonnal szeretnéd létrehozni a harcosodat?\n" +
                "1 - Alap életerő: 15\tAlap sebzés: 3\n" +
                "2 - Alap életerő: 12\tAlap sebzés: 4\n" +
                "3 - Alap életerő:  8\tAlap sebzés: 5\n");
                try
                {
                    statuszSablon = int.Parse(Console.ReadLine());
                }
                catch
                {
                    statuszSablon = 0;
                }
                
                ujra++;
            } while (statuszSablon < 1 || statuszSablon > 3);
            h1 = new Harcos(nev, statuszSablon);
        }


        static void Beolvasas()
        {
            StreamReader sr = new StreamReader("harcosok1.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] harcosAdatok = sor.Split(';');
                Harcos h = new Harcos(harcosAdatok[0], int.Parse(harcosAdatok[1]));
                harcosok.Add(h);
            }
        }

        static void HarcosokKiiratasa()
        {
            int db = 1;

            Console.WriteLine("\n\tA HARCOSOK:\n");
            Console.WriteLine("#" + db + " -\t" + h1.ToString());
            db++;
            foreach (Harcos h in harcosok)
            {
                Console.WriteLine("#" + db + " -\t" + h.ToString());
                db++;
            }
        }

       

        static char Menu()
        {
            char valasztott = 'n';
            int ujra = 0;
            do
            {
                if (ujra > 0)
                {
                    Console.WriteLine("HIBÁS ÉRTÉKET ADTÁL MEG!");
                }
                Console.WriteLine("\nVÁLASSZ AZ ALÁBBI MENÜPONTOK KÖZÜL:\n" +
                "a - Megkűzdeni egy harcossal\n" +
                "b - Gyógyulni\n" +
                "c - Kilépni");
                valasztott = char.Parse(Console.ReadLine());
                ujra++;
            } while (valasztott != 'a' && valasztott != 'b' && valasztott != 'c');
            return valasztott;
        }

        static void Jatek()
        {
            char menupont = 'n';
            do
            {
                fordulo++;
                Console.WriteLine("\t\t\t" + fordulo + ". FORDULÓ:");
                HarcosokKiiratasa();
                menupont = Menu();
                switch (menupont)
                {
                    case 'a': h1.Megkuzd(KivelKuzd()); break;
                    case 'b': h1.Gyogyul(); break;
                }
                if (fordulo % 3 == 0)
                {
                    RandomHarcos().Megkuzd(h1);
                    foreach (Harcos h in harcosok)
                    {
                        h.Gyogyul();
                    }
                }
            } while (menupont != 'c');



        }

        static Harcos KivelKuzd()
        {
            int ujra = 0;
            int szam = 0;
            do
            {
                if (ujra > 0)
                {
                    Console.WriteLine("HIBÁS ÉRTÉKET ADOTT MEG!");
                }
                Console.WriteLine("Hányas harcossal szeretnél kűzdeni?");
                try
                {
                    szam = int.Parse(Console.ReadLine());
                }
                catch
                {
                    szam = 0;
                }
                ujra++;
            } while (szam > harcosok.Count() || szam < 1);

            return harcosok[szam - 1];
        }

        static Harcos RandomHarcos()
        {
            Random r = new Random();
            return harcosok[r.Next(0, harcosok.Count - 1)];

        }





    }
}
