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

        



    }
}
