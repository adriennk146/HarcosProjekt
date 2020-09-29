﻿using System;
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
            return string.Format("{0} - LVL: {1} - EXP: {2}/{3} - HP: {4}/{5} - DMG: {6}",
                this.nev,this.tapasztalat,this.SzintLepeshez,this.eletero,this.MaxEletero,
                this.Sebzes);
        }
    }
}
