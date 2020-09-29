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
        static void Main(string[] args)
        {
            List<Harcos> harcosok = new List<Harcos>();
            StreamReader sr = new StreamReader("harcosok1.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] harcosAdatok = sor.Split(';');
                Harcos h = new Harcos(harcosAdatok[0], int.Parse(harcosAdatok[1]));
                harcosok.Add(h);
            }
            foreach(Harcos h in harcosok)
            {
                Console.WriteLine(h.ToString());
            }

            Console.ReadLine();
        }
    }
}
