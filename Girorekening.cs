using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamengesteldObject
{
    public class Girorekening
    {
        private string naam;
        private int gironummer;
        private double saldo;

        public Girorekening(string rekeninghouder, int rekeningnummer)
        {
            naam = rekeninghouder;
            gironummer = rekeningnummer;
            saldo = 0;
        }

        public Girorekening(string rekeninghouder, int rekeningnummer, double saldo)
        {
            naam = rekeninghouder;
            gironummer = rekeningnummer;
            this.saldo = saldo;
        }

        public void stort(double bedrag)
        {
            saldo = saldo + bedrag;
        }

        public double geefSaldo()
        {
            return saldo;
        }

        public double neemOp(double bedrag)
        {
            saldo = saldo - bedrag;

            return bedrag;   
        }

        public void veranderNaam(string nieuweNaam)
        {
            naam = nieuweNaam;
        }

        public string geefNaam()
        {
            return naam;
        }

        public int geefNummer()
        {
            return gironummer;
        }
    }
}