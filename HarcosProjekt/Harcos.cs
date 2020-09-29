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
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            switch (statuszSablon)
            {
                case 1:
                    this.alapEletero = 15;
                    this.alapSebzes = 3; 
                    break;
                case 2:
                    this.alapEletero = 12;
                    this.alapSebzes = 4; 
                    break;
                case 3:
                    this.alapEletero = 8;
                    this.alapSebzes = 5; 
                    break;
            }
            this.eletero = MaxEletero;
        }

        public string Nev
        {
            get
            {
                return this.nev;
            }
            set
            {
                this.nev = value;
            }
        }
        public int Szint 
        {
            get
            {
                return this.szint;
            }
            set
            {
                if(this.szint +1 ==value && this.Tapasztalat>=this.SzintLepeshez )
                {
                    this.Tapasztalat -= this.SzintLepeshez;
                    this.szint = value;
                    this.Eletero = this.MaxEletero;
                }
                
            }
        }
        public int Tapasztalat 
        {
            get
            {
                return this.tapasztalat;
            }
            set
            {
                this.tapasztalat = value;
                if(this.tapasztalat>this.SzintLepeshez)
                {
                    this.Szint++;
                }
            }
        }
        public int AlapEletero 
        {
            get
            {
                return this.alapEletero;
            }
        }
        public int AlapSebzes
        {
            get
            {
                return this.alapSebzes;
            }
        }
        public int Eletero
        {
            get
            {
                return this.eletero;
            }
            set
            {
               
                this.eletero = value;
                if(this.eletero==0)
                {
                    this.Tapasztalat = 0;
                }
                if(this.eletero>this.MaxEletero)
                {
                    this.eletero = this.MaxEletero;
                }
            }
        }
        public int Sebzes
        {
            get
            {
                return this.alapSebzes + this.szint;
            }
        }
        public int SzintLepeshez
        {
            get
            {
                return 10 + this.szint * 5;
            }
        }
        public int MaxEletero
        {
            get
            {
                return this.alapEletero + szint * 3;
            }
        }

        public void Megkuzd(Harcos masikHarcos)
        {
            if(this==masikHarcos)
            {
                Console.WriteLine("***HIBA! NEM LEHET MINDKÉT HARCOS UGYANAZ!***");
            }
            else if(this.eletero==0 || masikHarcos.Eletero==0)
            {
                Console.WriteLine("***Az egyik harcosnak nincs életereje, így nem harcolhat!***");
            }
            else
            {
                masikHarcos.Eletero -= this.Sebzes;
                this.Tapasztalat += 5;
                if(masikHarcos.Eletero>0)
                {
                    masikHarcos.Tapasztalat += 5;
                    masikHarcos.Megkuzd(this);
                }
                else
                {
                    this.Tapasztalat += 10;
                }
            }


        }

        public void Gyogyul()
        {
            if (this.Eletero == 0)
            {
                this.Eletero = this.MaxEletero;
            }
            else
            {
                this.Eletero += 3 + this.Szint;
            }
        }

        public string ToString()
        {
            return string.Format("{0} - LVL: {1} - EXP: {2}/{3} - HP: {4}/{5} - DMG: {6}",
                this.nev,this.szint,this.tapasztalat,this.SzintLepeshez,this.eletero,this.MaxEletero,
                this.Sebzes);
        }
    }
}
