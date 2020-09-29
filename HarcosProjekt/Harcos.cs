using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        string nev;
        int szint;
        int tapasztalat;
        int eletero;
        int alapEletero;
        int alapSebzes;

        public Harcos(string nev, int statuszSablon)
        {
            
        }

        public string Nev
        { 
            get => this.nev; 
            set => this.nev = value;
        }
        public int Szint 
        { 
            get => this.szint;
            set => this.szint = value;
        }
        public int Tapasztalat 
        {
            get => this.tapasztalat;
            set => this.tapasztalat = value; 
        }
        public int AlapEletero 
        { 
            get => this.alapEletero;
        }
        public int AlapSebzes
        {
            get => this.alapSebzes;
        }
        public int Eletero
        {
            get => this.eletero;
            set => this.eletero = value;
        }
        public int Sebzes
        {
            get => this.alapSebzes + this.szint;
        }
        public int SzintLepeshez
        {
            get => 10 + this.szint * 5;
        }
        public int MaxEletero
        {
            get=> this.alapEletero + szint * 3;
        }

        public void Megkuzd(Harcos masikHarcos)
        {

        }

        public void Gyogyul()
        {

        }

        public string ToString()
        {
            return "";
        }
    }
}
